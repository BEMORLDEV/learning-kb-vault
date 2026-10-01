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
| Custom Attachment Location | Controls where pasted images and files are saved. | Screenshots and illustrations for course content go in one `_attachments/` folder, with a subfolder per course folder (decided 2026-09-30). See [[LearningKB-Rules]]. | Location for new attachments: `_attachments/{{noteFolderName}}`, so one subfolder per course folder (set 2026-09-30). Follow Obsidian attachment location: off. Attachment rename mode: only pasted images. Generated file name: `file-{{date:{momentJsFormat:'YYYYMMDDHHmmssSSS'}}}` (default). |
| Advanced Rename and Delete Handler | Handles renames and deletes for the whole vault: updates links, moves attachment folders, cleans up after deletes. | Required by Custom Attachment Location, which does nothing without it. Keeps each note's attachment subfolder in step with the note. | Handle renames: on. Update file name aliases: on. Rename attachment folder: on. Rename attachment files: off, so descriptive image names are kept. Delete conflicting attachments: off. Handle deletions: on (deleting a note deletes images only that note used; git history keeps them). Empty folder behavior: Delete. Rescue shared attachments: off. Several notes could adopt: ask. |
| Dataview | Queries notes by their properties. | Collects `#explore` tasks and course lists in [[Learning-Plan]], and lists captured lessons and flags in each course parent note. | Defaults. |
| Obsidian Git | Commits the vault from inside Obsidian. | Auto-commits so git keeps every version between manual commits. Set up 2026-09-30 to match JobSearch. | Auto commit-and-sync every 15 minutes after the last edit (`autoSaveInterval: 15`, `autoBackupAfterFileChange: true`). **Push on commit-and-sync: off** (`disablePush: true`), so pushes are manual. Pull on commit-and-sync: off. Pull on startup: on. No separate push or pull timers. All changed files are committed. Error notifications: on, and must stay on, because a blocked PII scan only shows up as an error notice. The PII hook runs on its commits and needs `dotnet` on the PATH Obsidian sees; if auto-commits fail for that reason, add `C:\Program Files\dotnet` under Advanced, Additional PATH environment variable paths. |
| Omnisearch | Full-text search with ranking and typo tolerance. | Why: not recorded yet. | PDF, Office and image indexing are off. The local HTTP API is off. |

If Obsidian Git is off, nothing is committed until Breck commits by hand.

If Custom Attachment Location or Advanced Rename and Delete Handler is off, pasted images land wherever Obsidian's default says and renames leave attachment folders behind.

## Settings screenshots

Taken 2026-09-30. They show the settings at that date and can go stale. The `data.json` files in `.obsidian/plugins/` are the source of truth. When a key setting changes, replace the screenshot in the same commit.

Custom Attachment Location, Core settings:

![[obsidian-plugins_cal-core-2026-09-30.png]]

Custom Attachment Location, Move/renames, attachment rename mode (the other settings on that page are defaults):

![[obsidian-plugins_cal-move-renames-2026-09-30.png]]

Advanced Rename and Delete Handler, Renames and moves:

![[obsidian-plugins_ardh-renames-2026-09-30.png]]

Advanced Rename and Delete Handler, Deletions:

![[obsidian-plugins_ardh-deletions-2026-09-30.png]]

Templates (core plugin):

![[obsidian-plugins_templates-2026-09-30.png]]

Obsidian Git, Automatic:

![[obsidian-plugins_git-automatic-2026-09-30.png]]

Obsidian Git, Pull and Commit-and-sync (push off is the key setting):

![[obsidian-plugins_git-pull-commit-and-sync-2026-09-30.png]]

Obsidian Git, Miscellaneous, notifications (error notifications must stay on):

![[obsidian-plugins_git-notifications-2026-09-30.png]]

The other Obsidian Git sections (Commit, Hunk management, Line author, History, Source control view, Commit author, Advanced) are defaults.

## Core plugins that matter

| Plugin | Why it's here |
|---|---|
| Templates | Inserts `_templates/Course.md` and `_templates/Lesson.md`. Template folder: `_templates`. Date and time formats are the defaults (`YYYY-MM-DD`, `HH:mm`), which the templates expect. |
| Properties | Edits frontmatter, which Dataview reads. |
| File recovery | Local snapshots between commits. |
| Sync | Why: not recorded yet. |
| Bases | Why: not recorded yet. |

The other core plugins are Obsidian defaults and aren't tracked here.

## Related settings

- "Automatically update internal links" (`alwaysUpdateLinks`) is off, the Obsidian default. Advanced Rename and Delete Handler updates links on rename instead.

## Open questions

- Fill in why Omnisearch is here.
- Obsidian Git: confirm the first auto-commit works (`git log -1 --oneline`). If it fails, check that the hook can find `dotnet`.
- Omnisearch: turn on PDF indexing if course material comes in as PDFs?
- Generated attachment file name: keep `file-<timestamp>` and rename by hand, or add the note name as a prefix?
- Sync and Bases: keep or turn off?
- Test the attachment setup: paste into a `Test` note, rename it, delete it.
