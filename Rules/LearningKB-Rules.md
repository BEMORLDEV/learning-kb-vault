---
type: rules
status: final
updated: 2026-09-30
---

# LearningKB rules

Rules for this vault. Read this before working here. Decisions recorded 2026-09-30.

## What this vault is for

LearningKB tracks what Breck is learning: tracks, courses, books, certifications, resources, progress, study plans and a private question bank.

It is not the reference library. The test:

- If a fact is about Breck learning something (progress, plans, what's hard, what's next), it goes here.
- If a fact would be true for anyone (how a service, language or pattern works), it goes in TechKB (`C:\ObsidianVaults\TechKB`). The course or book note links to it.
- Anything about Breck's career, roles or applications goes in JobSearch.

## Where things live

- Vault: `C:\ObsidianVaults\LearningKB`. Private GitHub repo `BEMORLDEV/learning-kb-vault`, branch `main`.
- The vault is private and will never be shared or published.
- Plugins and their settings: [[Obsidian-Plugins]].

## Note types

One note per thing. Edit in place; git keeps history. No `_v2` files, addenda or session-recap files.

| Type | What it is |
|---|---|
| Track | A learning goal that groups the rest, for example "Azure AI". Holds the learning plan. |
| Course | One course or learning path. Progress goes here as dated log lines. |
| Book | One book. Tracked separately from tracks. |
| Certification | One exam or credential. |
| Resource | Docs, labs, videos or articles worth keeping. |
| Question bank | Practice questions, linked from the course they came from. |

Templates for each type will go in `_templates/`.

## Learning plan framework

Each Track note holds its plan, built in five steps.

1. **Define.** The goal is something Breck can do, not just know. Record why (job search, current work, certification, curiosity), what "done" means, and a target date if there is one.
2. **Assess.** A short baseline: what's known, what's fuzzy, what's new. For a certification, take a practice test cold and start with the misses.
3. **Plan.** Resources (each linked to its own note), 3 to 6 milestones tied to evidence, and a realistic weekly cadence.
4. **Execute.** Progress goes in dated log lines on the Course or Book note. General knowledge goes to TechKB. Practice questions go to the question bank.
5. **Review.** A quick weekly check of what moved and what's stuck. Adjust at each milestone. At the end, mark the track done and record the proof: the cert, a project repo or a MaassBytes post.

Track status values: `idea`, `queued`, `active`, `paused`, `done`, `dropped`.

Track frontmatter fields: `type`, `status`, `goal`, `why`, `done_when`, `target_date`, `cadence`, `next_action`, `next_action_due`, `last_activity`, `proof`.

### Active tracks: a soft limit

Aim for about 5 active tracks at a time. This is a guideline, not a rule. When adding a track would go past 5, Claude mentions it once and asks whether to pause something or go ahead. Either answer is fine. Books don't count toward the 5.

## Question bank

- Practice questions and answers taken from course material are welcome. They stay in this private vault.
- No real exam content: nothing covered by a certification exam NDA and nothing from exam dump sites.
- Every question records where it came from, for example `source: "AI-103 course, Module 3, Lesson 2"`. Questions Claude writes say so.

### Verification

Each question carries:

```yaml
source: "Course, module, lesson"
verified: no        # yes, no or disputed
verified_against: "" # link to the official doc used
last_verified:       # YYYY-MM-DD
```

- Check answers against the vendor's official documentation and record the link.
- If the course answer and the docs disagree, mark it `disputed` and keep both answers. Breck decides. Don't quietly change the course's answer.
- Some questions have no single doc to check against. Mark them `no` with a short note.
- `verified: no` is fine for a new question. Verify at capture when it's cheap, and re-check old ones in batches.

## Attachments

- Pasted images and files go in `_attachments/<note name>/`, set by the Custom Attachment Location plugin. Subfolders match Course or Book notes, not Tracks.
- Name images with a note prefix and a short description, no spaces, for example `ai-103_m3-rag-architecture.png`.
- Put a one-line caption with the source under each image.
- Prefer Mermaid for diagrams you create. It's text, so it diffs cleanly and Claude can edit it. Use screenshots for things that are really visual.
- Keep images reasonably small. Compress before committing.
- **Redact screenshots before saving them, and never take screenshots from work systems.** The PII scan skips images in `_attachments/`, so nothing else checks them.

## Privacy and git

- A pre-commit PII scan runs on every commit (`.githooks/`, see its README). It's a copy of TechKB's with one change: images under `_attachments/` are skipped.
- Never suggest `--no-verify` or turning hooks off.
- Run the scan's `--all` audit before any bulk import and show Breck the findings. Pause Obsidian Git auto-commit during bulk imports.

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

## Open questions

- Question bank layout: one note per course, one note per question, or flashcards for the Spaced Repetition plugin?
- Teaching style: should Claude quiz first, have Breck draft first, or neither?
- Move the Claude 101 training log from the "Claude Knowledge Base" claude.ai project into this vault?
- New claude.ai project for LearningKB, or convert "Claude Knowledge Base"?
