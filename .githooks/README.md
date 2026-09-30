# PII pre-commit scan

Every commit (including Obsidian Git auto-commits) runs `pre-commit`, which scans the staged files for PII and blocks the commit if it finds anything that hasn't been approved.

## One-time setup (per clone)

```powershell
git config core.hooksPath .githooks
```

Requires the .NET SDK (8 or newer) on PATH. If `dotnet` is missing, the hook blocks every commit (fails closed).

## When a commit is blocked

Review and approve from the vault root:

```powershell
dotnet run --project .githooks/PiiScan -c Release -- --approve
```

Each finding is shown partly masked with its file and line. Answer `y` to approve or `n` to leave it blocked. Then either commit again or remove the unapproved values, re-stage, and commit.

Approved items go in `.pii-allow` as SHA-256 fingerprints of the value, never the value itself. A value approved once is approved everywhere it appears.

## Full audit

```powershell
dotnet run --project .githooks/PiiScan -c Release -- --all
```

## What it flags

SSNs (format + validity rules), card numbers (Luhn check), bank routing (ABA checksum) and account numbers, dates of birth, driver's license / passport / tax IDs, `password:` / `pin:` values, API keys and private keys, phone numbers, street addresses, and every binary file (PDF, DOCX, images). Binaries can't be read reliably, so each new version needs a human look once.

## What it skips

Images (`.png`, `.jpg`, `.jpeg`, `.gif`, `.webp`, `.heic`, `.bmp`) under `_attachments/`. This is a LearningKB change, decided 2026-09-30, so screenshots don't block every commit. The scanner can't see text inside an image, so redact screenshots before saving them and never take them from work systems. Images anywhere else, and PDFs or Office files under `_attachments/`, are still flagged.

Third-party plugin code inside `.obsidian/` (`.js`, `.css`, `.map` files). Minified code is full of words like `password:` and long digit runs, so scanning it only produces false alarms. Plugin settings (`data.json`) and every note are still scanned. The scanner's own files (`.githooks/`, `.pii-allow`) are also skipped.
