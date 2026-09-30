---
type: rules
status: final
updated: 2026-09-30
---

# Obsidian plugins: LearningKB vault

The plugins this vault runs and why. Follows [[Obsidian-Plugin-Tracking]]. Plugin config lives in `.obsidian/`. When a plugin is added, removed, or a key setting changes, update this note in the same commit.

## Community plugins

| Plugin | What it does | Why it's here | Key settings |
|---|---|---|---|
| Dataview | Queries notes by their properties. | Why: not recorded yet. | Defaults. |
| Obsidian Git | Commits and pushes the vault from inside Obsidian. | Why: not recorded yet. | Defaults, no `data.json` yet. Auto-commit is off until it's configured. The vault has no git repo yet. |
| Omnisearch | Full-text search with ranking and typo tolerance. | Why: not recorded yet. | PDF, Office and image indexing are off. The local HTTP API is off. |
| Custom Attachment Location | Controls where pasted images and files are saved, using variables like `{{noteFileName}}`. | Why: not recorded yet. | Defaults, no `data.json` yet. |

## Core plugins that matter

| Plugin | Why it's here |
|---|---|
| Templates | Why: not recorded yet. The Templates folder isn't set. |
| Properties | Edits frontmatter, which Dataview reads. |
| File recovery | Local snapshots between commits. |
| Sync | Why: not recorded yet. |
| Bases | Why: not recorded yet. |

The other core plugins are Obsidian defaults and aren't tracked here.

## Open questions

- Fill in why each community plugin is here.
- Obsidian Git: set up the repo (with the PII hook like the other vaults?), then set the auto-commit interval.
- Omnisearch: turn on PDF indexing if course material comes in as PDFs?
- Custom Attachment Location: pick the attachment folder pattern.
- Sync and Bases: keep or turn off?
- Set the Templates folder once `_templates/` exists.
- "Automatically update internal links" is off (default). Turn it on to match JobSearch and TechKB?
