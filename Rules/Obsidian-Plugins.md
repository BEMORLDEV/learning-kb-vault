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
| Custom Attachment Location | Controls where pasted images and files are saved. | Screenshots and illustrations for course and book content go in one `_attachments/` folder, with a subfolder per note (decided 2026-09-30). See [[LearningKB-Rules]]. | Location for new attachments: `_attachments/{{noteFileName}}`. Follow Obsidian attachment location: off. Attachment rename mode: only pasted images. Generated file name: `file-{{date:{momentJsFormat:'YYYYMMDDHHmmssSSS'}}}` (default). |
| Advanced Rename and Delete Handler | Handles renames and deletes for the whole vault: updates links, moves attachment folders, cleans up after deletes. | Required by Custom Attachment Location, which does nothing without it. Keeps each note's attachment subfolder in step with the note. | Handle renames: on. Update file name aliases: on. Rename attachment folder: on. Rename attachment files: off, so descriptive image names are kept. Delete conflicting attachments: off. Handle deletions: on (deleting a note deletes images only that note used; git history keeps them). Empty folder behavior: Delete. Rescue shared attachments: off. Several notes could adopt: ask. |
| Dataview | Queries notes by their properties. | Why: not recorded yet. Expected use: the 00-Start-Here dashboard (active tracks) and question bank queries (unverified, stale, often missed). | Defaults. |
| Obsidian Git | Commits and pushes the vault from inside Obsidian. | Why: not recorded yet. | Defaults, no `data.json` yet. Auto-commit is off until it's configured. The PII hook runs on its commits. |
| Omnisearch | Full-text search with ranking and typo tolerance. | Why: not recorded yet. | PDF, Office and image indexing are off. The local HTTP API is off. |

If Custom Attachment Location or Advanced Rename and Delete Handler is off, pasted images land wherever Obsidian's default says and renames leave attachment folders behind.

## Core plugins that matter

| Plugin | Why it's here |
|---|---|
| Templates | Why: not recorded yet. The Templates folder isn't set. |
| Properties | Edits frontmatter, which Dataview reads. |
| File recovery | Local snapshots between commits. |
| Sync | Why: not recorded yet. |
| Bases | Why: not recorded yet. |

The other core plugins are Obsidian defaults and aren't tracked here.

## Related settings

- "Automatically update internal links" (`alwaysUpdateLinks`) is off, the Obsidian default. Advanced Rename and Delete Handler updates links on rename instead.

## Open questions

- Fill in why Dataview, Obsidian Git and Omnisearch are here.
- Obsidian Git: set the auto-commit interval and whether to auto-push. JobSearch commits 15 minutes after the last change and pushes by hand.
- Omnisearch: turn on PDF indexing if course material comes in as PDFs?
- Generated attachment file name: keep `file-<timestamp>` and rename by hand, or add the note name as a prefix?
- Sync and Bases: keep or turn off?
- Set the Templates folder once `_templates/` exists.
- Test the attachment setup: paste into a `Test` note, rename it, delete it.
