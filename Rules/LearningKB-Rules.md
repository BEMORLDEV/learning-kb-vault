---
type: rules
status: final
updated: 2026-09-30
---

# LearningKB rules

Rules for this vault. Read this before working here.

The focus for now is **capture**: record what training courses present, in the forms they present it. How to reuse that content (quizzes, question banks, study plans) is decided later. See Later below.

## What this vault is for

LearningKB holds what Breck is learning: course content as it was presented, topics he wants to explore, and a rough plan for what to pursue.

It is not the reference library. The test:

- If it's course content, or about Breck learning something (progress, plans, topics to explore), it goes here.
- If a fact would be true for anyone and stands on its own (how a service, language or pattern works), it goes in TechKB (`C:\ObsidianVaults\TechKB`), and the lesson note can link to it.
- Anything about Breck's career, roles, applications or LinkedIn goes in JobSearch.

## Where things live

- Vault: `C:\ObsidianVaults\LearningKB`. Private GitHub repo `BEMORLDEV/learning-kb-vault`, branch `main`.
- The vault is private and will never be shared or published.
- Plugins and their settings: [[Obsidian-Plugins]].
- Templates: `_templates/`.

## Capture

### Structure

Each course gets a folder with a parent note and one child note per lesson.

```
Courses/
  Claude-101/
    Claude-101.md                      parent
    Claude-101 1.1 What is Claude.md   one per lesson
```

- **Parent note** (template `_templates/Course.md`): what the course is, provider, status, source link, certificate, an outline of every lesson, and the course's open `#explore` flags.
- **Lesson notes** (template `_templates/Lesson.md`): one per lesson. Frontmatter links back to the parent.
- A large lesson can be split further into subtopic notes in the same folder, named with the lesson ID, for example `Claude-101 2.2a Artifact types`.
- Note names start with the course slug, so lessons from different courses never share a name.
- Lesson IDs are `<module>.<lesson>`, so `1.2` is Module 1, Lesson 2.
- This is a trial (started 2026-09-30). Adjust once a course or two has been captured.

### How content is recorded

Inside each lesson note, content is grouped by how the course presented it:

| Section | What goes there |
|---|---|
| Written | The lesson text, summarized. |
| Video | The transcript or key points. |
| Visual | Screenshots and diagrams, with a caption and source. |
| Knowledge check | The course's own questions and answers, as the course gave them. |
| Lab or exercise | What was asked, briefly. |

Leave out sections a lesson doesn't have.

- Every lesson note starts with a short **Summary**. Below it, keep everything: capture the lesson in full, not condensed (decided 2026-09-30).
- Short quotes are fine where the wording matters.
- Breck's own commentary goes in a note callout: `> [!note] Note`.
- Anything that looks wrong, dated or at odds with official docs goes in a warning callout: `> [!warning] Flag`. Record it; never quietly correct it.
- If a lesson skips something important, flag the gap.
- Third-party courses (not from the product's vendor) set `first_party: false` and carry a Flag callout at the top of the parent note.

## Planning

### Flagging topics to explore

While capturing, flag anything worth exploring as a task, right where it came up:

```markdown
- [ ] #explore MCP sampling: how does the client approve requests?
```

Tick the box when it's handled or no longer interesting.

### The learning plan

[[Learning-Plan]] at the vault root holds a rough plan:

- **Flagged topics:** every open `#explore` task in the vault, collected by Dataview.
- **Now, Next, Someday:** short lists Breck arranges by hand. Each item gets a line on why it matters and a rough target if there is one.

Aim for about 5 items in Now. This is a soft limit: when adding one would go past 5, Claude mentions it once and asks. Either answer is fine. Books don't count.

## Attachments

- Pasted images and files go in `_attachments/<course folder>/`, set by the Custom Attachment Location plugin.
- Give images a descriptive name, no spaces, for example `claude-101_1-2-artifact-panel.png`.
- Put a one-line caption with the source under each image.
- Prefer Mermaid for diagrams you create. Use screenshots for things that are really visual.
- Keep images reasonably small. Compress before committing.
- **Redact screenshots before saving them, and never take screenshots from work systems.** The PII scan skips images in `_attachments/`, so nothing else checks them.

## Privacy and git

- A pre-commit PII scan runs on every commit (`.githooks/`, see its README). It's a copy of TechKB's with one change: images under `_attachments/` are skipped.
- Never suggest `--no-verify` or turning hooks off.
- Run the scan's `--all` audit before any bulk import and show Breck the findings. Pause Obsidian Git auto-commit during bulk imports.
- No real exam content: nothing covered by a certification exam NDA and nothing from exam dump sites.

## How Claude works here

- Claude writes files. Breck commits and pushes.
- Claude never moves, copies or deletes notes or attachments. Breck does that.
- Before writing, stage the current file from disk. After writing, check the file size on disk matches.
- Before creating a note, check that no note with that name (any case) exists.
- Folder names never change once created. Dataview queries depend on them.
- Plain, direct sentences. No em dashes.
- Quote any YAML value that contains a colon or `#`. No `# | ^ [ ] : /` in note names.
- Present choices as options. Breck decides.
- Give exact commands and say where to run each one (machine, folder, shell).

## Later

Ideas discussed 2026-09-30 and parked until capture is working. None of these are rules yet.

- **Full learning plan framework:** define, assess, plan, execute, review, with track statuses, milestones and proof of completion.
- **Question bank:** store course questions with their source, one note per question.
- **Verification:** check answers against official docs, with `verified`, `verified_against`, `last_verified`, and `disputed` for conflicts.
- **Study aids:** Claude generates flashcards and practice questions from the notes on demand instead of storing them. Misses get logged with a date.
- **Spaced repetition** (phase 2): schedule reviews from the miss log, with a plugin or a Dataview query.

## Open questions

- Claude 101 moved in on 2026-09-30 ([[Claude-101]]). Still to move from the "Claude Knowledge Base" claude.ai project: the Coursiv course notes, the course roster and suggested order (into [[Learning-Plan]]), and the certificate tracker. Its LinkedIn staging goes to JobSearch.
- New claude.ai project for LearningKB, or convert "Claude Knowledge Base"?
- Books: same parent and child pattern (a note per chapter)?
