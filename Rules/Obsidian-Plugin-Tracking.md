---
type: rules
status: final
updated: 2026-09-30
---

# Rule: track Obsidian plugins in every vault

Every Obsidian vault keeps a note at `Rules/Obsidian-Plugins.md` that records the plugins it runs and why.

## What the note records

- **Community plugins:** each one enabled in `.obsidian/community-plugins.json`. For each, record why it's there, the settings that matter, and what breaks if it's turned off.
- **Core plugins that matter:** only the ones the vault depends on (Templates, Properties, Sync and so on). Skip Obsidian's defaults.
- **Related settings:** vault settings the rules depend on, such as "Automatically update internal links".
- **Open questions:** anything whose reason isn't known yet. Write "Why: not recorded yet". Never guess a reason.

## When to update it

- Update the note whenever a plugin is added, removed, turned on or off, or a key setting changes.
- Make that update in the same commit as the change.
- Get the facts from `.obsidian/` (`community-plugins.json`, `core-plugins.json`, `plugins/<id>/data.json`), not from memory.
- The vault's `CLAUDE.md` points to the note.

## Why

A plugin that's installed with no recorded reason turns into a mystery. Nobody knows whether it's safe to remove, or which notes stop working without it. Dataview queries and Obsidian Git hooks are easy to break without noticing.

## Vaults following this rule

JobSearch, ResumeKB, TechKB, LearningKB (all started 2026-09-30).

## Copies

Each vault above keeps its own identical copy of this note at `Rules/Obsidian-Plugin-Tracking.md`, so no vault links to another. When the rule changes, update all four copies together.
