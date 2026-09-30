// PII scanner for the LearningKB vault (copied from TechKB).
// LearningKB change: images under _attachments/ are not scanned (decided 2026-09-30). Redact screenshots before saving them.
// Modes:
//   --staged   (default) scan files staged for commit; exit 1 if anything unapproved is found. Used by the pre-commit hook.
//   --approve  walk through unapproved findings in staged files; approved items are added to .pii-allow as SHA-256 fingerprints.
//   --all      audit every tracked and untracked file in the working tree (report only).
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

var mode = args.FirstOrDefault() ?? "--staged";
var root = Git("rev-parse", "--show-toplevel").Trim();
if (string.IsNullOrEmpty(root)) { Console.Error.WriteLine("PII scan: not inside a git repository."); return 2; }
var allowPath = Path.Combine(root, ".pii-allow");
var allow = LoadAllow(allowPath);

List<(string Path, byte[] Bytes)> files = mode switch
{
    "--all" => AllFiles(root),
    "--staged" or "--approve" => StagedFiles(),
    _ => throw new ArgumentException($"Unknown mode {mode}. Use --staged, --approve, or --all.")
};

var findings = files.SelectMany(f => Scanner.Scan(f.Path, f.Bytes)).Where(x => !allow.Contains(x.Fingerprint)).ToList();
// one prompt per unique value, even if it appears in several places
var groups = findings.GroupBy(x => x.Fingerprint).ToList();

if (groups.Count == 0)
{
    if (mode != "--staged") Console.WriteLine("PII scan: nothing unapproved found.");
    return 0;
}

if (mode == "--approve")
{
    var approved = new List<Finding>();
    foreach (var g in groups)
    {
        var first = g.First();
        Console.WriteLine();
        Console.WriteLine($"[{first.Rule}] {first.Masked}");
        foreach (var f in g) Console.WriteLine($"    {f.Path}:{f.Line}");
        Console.Write("Approve this for commit? (y/N) ");
        var answer = Console.ReadLine()?.Trim().ToLowerInvariant();
        if (answer is "y" or "yes") approved.Add(first);
    }
    if (approved.Count > 0)
    {
        var lines = approved.Select(a => $"{a.Fingerprint}  # {a.Rule} {DateTime.Now:yyyy-MM-dd} {a.Path}");
        File.AppendAllLines(allowPath, lines);
        Git("add", ".pii-allow");
        Console.WriteLine($"\nApproved {approved.Count} item(s); .pii-allow updated and staged.");
    }
    var left = groups.Count - approved.Count;
    Console.WriteLine(left == 0 ? "Everything approved. Commit again." : $"{left} item(s) not approved. Remove them from the files, re-stage, and commit again.");
    return left == 0 ? 0 : 1;
}

Console.Error.WriteLine();
Console.Error.WriteLine($"PII scan: {groups.Count} item(s) need review. {(mode == "--staged" ? "Commit blocked." : "")}");
foreach (var g in groups)
{
    var first = g.First();
    Console.Error.WriteLine($"  [{first.Rule}] {first.Masked}  ->  {string.Join(", ", g.Select(f => $"{f.Path}:{f.Line}"))}");
}
Console.Error.WriteLine();
Console.Error.WriteLine("To review and approve:  dotnet run --project .githooks/PiiScan -c Release -- --approve");
Console.Error.WriteLine("Or remove the values from the files, re-stage, and commit again.");
return 1;

static HashSet<string> LoadAllow(string path) =>
    File.Exists(path)
        ? File.ReadAllLines(path).Select(l => l.Split('#')[0].Trim()).Where(l => l.Length > 0).ToHashSet(StringComparer.OrdinalIgnoreCase)
        : new HashSet<string>(StringComparer.OrdinalIgnoreCase);

static List<(string, byte[])> StagedFiles()
{
    var names = Git("diff", "--cached", "--name-only", "-z", "--diff-filter=ACMR").Split('\0', StringSplitOptions.RemoveEmptyEntries);
    return names.Where(Scanner.ShouldScan).Select(n => (n, GitBytes("show", $":{n}"))).ToList();
}

static List<(string, byte[])> AllFiles(string root)
{
    var names = Git("ls-files", "-z", "--cached", "--others", "--exclude-standard").Split('\0', StringSplitOptions.RemoveEmptyEntries);
    return names.Where(Scanner.ShouldScan).Select(n => (n, File.ReadAllBytes(Path.Combine(root, n)))).ToList();
}

static string Git(params string[] a) => Encoding.UTF8.GetString(GitBytes(a));

static byte[] GitBytes(params string[] a)
{
    var psi = new ProcessStartInfo("git") { RedirectStandardOutput = true, RedirectStandardError = true, UseShellExecute = false };
    foreach (var x in a) psi.ArgumentList.Add(x);
    using var p = Process.Start(psi)!;
    using var ms = new MemoryStream();
    p.StandardOutput.BaseStream.CopyTo(ms);
    p.WaitForExit();
    return ms.ToArray();
}

record Finding(string Rule, string Path, int Line, string Masked, string Fingerprint);

static class Scanner
{
    // Paths the scanner itself owns (patterns and fingerprints would trip it).
    static readonly string[] Skip = { ".pii-allow", ".githooks/" };
    static readonly string[] BinaryExt = { ".pdf", ".docx", ".doc", ".xlsx", ".xls", ".pptx", ".png", ".jpg", ".jpeg", ".gif", ".webp", ".heic", ".zip" };

    // Third-party plugin code (minified JS/CSS) is full of words like "password:" and long digit runs.
    // It isn't Breck's data, so skip it. Plugin settings (data.json) and all notes are still scanned.
    static readonly string[] CodeExt = { ".js", ".mjs", ".cjs", ".css", ".map" };

    // Screenshots and illustrations live in _attachments/. They can't be read as text, and flagging each one
    // would block every commit, so images there are skipped. Other files there (PDFs, Office files) are still flagged.
    static readonly string[] ImageExt = { ".png", ".jpg", ".jpeg", ".gif", ".webp", ".heic", ".bmp" };

    public static bool ShouldScan(string path) =>
        !Skip.Any(s => path == s || path.StartsWith(s, StringComparison.Ordinal))
        && !(path.StartsWith(".obsidian/", StringComparison.Ordinal) && CodeExt.Contains(System.IO.Path.GetExtension(path).ToLowerInvariant()))
        && !(path.StartsWith("_attachments/", StringComparison.Ordinal) && ImageExt.Contains(System.IO.Path.GetExtension(path).ToLowerInvariant()));

    const RegexOptions O = RegexOptions.IgnoreCase | RegexOptions.CultureInvariant;
    static readonly (string Rule, Regex Rx, Func<Match, bool>? Check)[] Rules =
    {
        ("ssn", new(@"(?<!\d)(\d{3})[- ](\d{2})[- ](\d{4})(?!\d)", O), m => ValidSsn(m.Groups[1].Value, m.Groups[2].Value, m.Groups[3].Value)),
        ("ssn", new(@"\b(?:ssn|ss#|social\s+security(?:\s+(?:no|number|#))?)\W{0,10}(\d{9})\b", O), m => { var d = m.Groups[1].Value; return ValidSsn(d[..3], d[3..5], d[5..]); }),
        ("card-number", new(@"(?<![\d-])(?:\d[ -]?){12,18}\d(?![\d-])", O), m => Luhn(m.Value)),
        ("bank-routing", new(@"\b(?:routing|aba|rtn)\b(?:\s*(?:no\.?|number|num|#))?\W{0,15}(\d{9})\b", O), m => AbaChecksum(m.Groups[1].Value)),
        ("bank-account", new(@"\b(?:account|acct)\s*(?:no\.?|number|num|#)?\s*[:#]?\s*(\d[\d -]{4,20}\d)\b", O), null),
        ("date-of-birth", new(@"\b(?:dob|date\s+of\s+birth|birth\s*date|born\s+on)\b\W{0,5}(\d{1,4}[/.-]\d{1,2}[/.-]\d{1,4}|[a-z]{3,9}\.?\s+\d{1,2},?\s+\d{4})", O), null),
        ("id-number", new(@"\b(?:driver'?s?\s+licen[cs]e|dl\s*#|passport|itin|ein|tax\s+id)\s*(?:no\.?|number|#)?\s*[:#]?\s*([a-z0-9][a-z0-9-]{5,})\b", O), m => m.Groups[1].Value.Any(char.IsDigit)),
        ("password", new(@"\b(?:password|passwd|pwd|passcode|pin)\s*[:=]\s*\S+", O), null),
        ("secret", new(@"\bAKIA[0-9A-Z]{16}\b|\bgh[pousr]_[A-Za-z0-9]{36,}\b|-----BEGIN [A-Z ]*PRIVATE KEY-----|\b(?:api[_-]?key|secret|access[_-]?token|client[_-]?secret)\s*[:=]\s*['""]?[A-Za-z0-9_\-/+]{16,}", O), null),
        ("phone", new(@"(?<![\d-])(?:\+?1[ .-]?)?\(?\d{3}\)?[ .-]\d{3}[ .-]\d{4}(?![\d-])", O), null),
        ("street-address", new(@"\b\d{1,6}\s+(?:[A-Z][a-z]+\.?\s+){1,4}(?:St|Street|Ave|Avenue|Rd|Road|Dr|Drive|Blvd|Boulevard|Ln|Lane|Ct|Court|Way|Pl|Place|Cir|Circle|Pkwy|Parkway|Ter|Terrace|Hwy|Highway|Trl|Trail)\b\.?", RegexOptions.CultureInvariant), null),
    };

    public static IEnumerable<Finding> Scan(string path, byte[] bytes)
    {
        var ext = System.IO.Path.GetExtension(path).ToLowerInvariant();
        if (BinaryExt.Contains(ext) || bytes.Take(8000).Contains((byte)0))
        {
            // Can't read inside binaries reliably: every binary needs a human look once per version.
            yield return new Finding("binary-file", path, 0, $"{System.IO.Path.GetFileName(path)} ({bytes.Length:N0} bytes)", Hash("binary-file", Convert.ToHexString(SHA256.HashData(bytes))));
            yield break;
        }
        var text = Encoding.UTF8.GetString(bytes);
        var seen = new HashSet<(int, int)>();
        foreach (var (rule, rx, check) in Rules)
        {
            foreach (Match m in rx.Matches(text))
            {
                if (check != null && !check(m)) continue;
                if (!seen.Add((m.Index, m.Length))) continue;
                if (rule == "card-number" && seen.Any(s => s != (m.Index, m.Length) && Overlaps(s, m))) continue;
                var line = 1 + text.AsSpan(0, m.Index).Count('\n');
                yield return new Finding(rule, path, line, Mask(m.Value.Trim()), Hash(rule, Normalize(m.Value)));
            }
        }
    }

    static bool Overlaps((int Start, int Len) s, Match m) => s.Start < m.Index + m.Length && m.Index < s.Start + s.Len;

    static string Normalize(string v) => Regex.Replace(v.ToLowerInvariant(), @"\s+", " ").Trim();

    static string Hash(string rule, string value) => Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes($"{rule}:{value}"))).ToLowerInvariant();

    // Show just enough to recognize the value: keep the last 4 characters, hide the rest of any digits/letters.
    static string Mask(string v)
    {
        if (v.Length <= 4) return new string('*', v.Length);
        var keep = v.Length - 4;
        var sb = new StringBuilder();
        for (int i = 0; i < v.Length; i++) sb.Append(i < keep && char.IsLetterOrDigit(v[i]) && !IsLabel(v, i) ? '*' : v[i]);
        return sb.ToString();
    }

    // Leave leading label words (e.g. "SSN", "password") readable so the reviewer knows what was matched.
    static bool IsLabel(string v, int i)
    {
        var firstDigitOrSep = v.IndexOfAny(new[] { ':', '=', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' });
        return firstDigitOrSep > 0 && i < firstDigitOrSep && char.IsLetter(v[i]);
    }

    static bool ValidSsn(string area, string group, string serial) =>
        area != "000" && area != "666" && area[0] != '9' && group != "00" && serial != "0000";

    static bool Luhn(string raw)
    {
        var d = raw.Where(char.IsDigit).Select(c => c - '0').ToArray();
        if (d.Length < 13 || d.Length > 19 || d.Distinct().Count() == 1) return false;
        int sum = 0; bool dbl = false;
        for (int i = d.Length - 1; i >= 0; i--) { var x = d[i]; if (dbl) { x *= 2; if (x > 9) x -= 9; } sum += x; dbl = !dbl; }
        return sum % 10 == 0;
    }

    static bool AbaChecksum(string s)
    {
        var d = s.Select(c => c - '0').ToArray();
        return (3 * (d[0] + d[3] + d[6]) + 7 * (d[1] + d[4] + d[7]) + (d[2] + d[5] + d[8])) % 10 == 0;
    }
}
