---
type: lesson
course: "[[Claude-101]]"
lesson: "1.4"
title: "How you'll work with Claude on your desktop"
captured: 2026-09-14
migrated: 2026-09-30
est_time: "6 min"
formats: [written]
source: 'claude.ai project "Claude Knowledge Base", claude/claude-101/notes.md'
---
# 1.4 How you'll work with Claude on your desktop

**Captured:** 2026-09-14 · **Est. time:** 6 min · Written lesson

Course: [[Claude-101]]

## Summary

Desktop work with Claude comes in three shapes: turn by turn (Chat), handing work off (Cowork) and building software (the Code tab). Notice the shape of the work first and the tab follows. Chat is for exchanges where the answer changes the next question; Cowork is for multi-step work that ends in a real file, spans tools or runs on a schedule, with control points like plan review and approval gates; the Code tab works in a codebase, locally or in the cloud. The key line: Chat hands files back as downloads, while Cowork saves them into your folder.

## Objectives

- Distinguish the three ways of working with Claude on the desktop
- Recognize which shape a task calls for *before* starting it
- Know where each lives in the app today

## Written

### The core claim

Work with Claude sorts into **three shapes**. Recognizing which one you're in is the entire skill of this lesson. You don't pick a tab first — you notice what kind of work is in front of you, and the tab follows.

| Shape | What it means | Where it lives |
|---|---|---|
| **Turn by turn** | You ask, Claude answers, you steer, it revises. The thinking happens *in the exchange* | **Chat** |
| **Handing work off** | You describe an outcome; Claude plans it, does it, returns the result. You don't stitch the steps together | **Cowork** |
| **Building software** | Claude works directly in a codebase — reading, writing, testing, running commands | **Code tab** |

First two are where most knowledge workers live; the third is the developer's workspace.

### Shape 1 — Turn by turn (Chat)

Claude as thinking partner. The value is the exchange itself.

**Reach for it when:**
- **The answer changes what you ask next.** You couldn't have written the whole request up front because you didn't know yet
- **You want to stay in it.** Drafting, editing, thinking aloud — the point is your judgment on every turn, not a finished artifact
- **It's quick.** Setting up a whole task would be overhead

**Desktop-native capabilities (beyond claude.ai):**

| Feature | Detail |
|---|---|
| Quick entry | Double-tap **Option** (Mac) to pull Claude over whatever you're doing; compact window stays on top as you switch apps |
| Screenshots / window sharing | Claude sees what you see (Mac) |
| Dictation | Talk through a problem instead of typing (Mac) |
| Desktop connectors | Connect local tools and services |

### Shape 2 — Handing work off (Cowork)

Delegating the whole piece of work — gather context, do the analysis, produce the finished thing.

**Reach for it when:**
- **Several sequential steps.** Pull figures → compare → draft → format. One instruction, not four errands
- **The output is a real deliverable.** A doc, spreadsheet, deck, PDF — *saved where you need it*, not pasted into a chat window
- **The work spans your tools.** Notes in one place, thread in Slack, numbers in a spreadsheet
- **It should run on a schedule,** or while you're doing something else

**Handing off ≠ stepping back.** The control points:
- Claude may ask questions up front to pin down scope and format
- It shows you the plan before starting
- You can watch it work — sources drawn from, files forming, progress through the plan — and steer at any point
- When set to ask before acting, it stops for approval on consequential actions (sending an email, sharing a file)

**Capabilities today:**

| Feature | Detail |
|---|---|
| **Local folder access** | Point Claude at a folder; it reads what's there and **saves finished work back to the same place** |
| **Scheduled tasks** | Set once, runs on your cadence. Catches up if the computer or app was closed at the scheduled time |
| **Subagents** | Splits a big job across parallel background workers, each with its own context; returns one deliverable |
| **Projects** | Workspace with its own files, instructions, and memory — built around the tasks you run |
| **Browser use** | With Claude in Chrome — navigate sites, pull data from pages with no API |
| **Computer use** | Operate the computer directly (click, type, open apps) when no connector exists. Permission per app, blocklist available. **Research preview, Pro and Max** |
| **Plugins** | Ready-made bundles of skills, connectors, and agents for a role — sales, finance, legal. Under **Customize → Plugins** |

**Availability:** Pro, Max, Team, Enterprise.

> [!note] Note
> The single operational difference between Chat and Cowork, stated plainly in the lesson: **Chat reads what you upload and hands finished files back as downloads; Cowork saves them into your folder.** Everything else is degree. That's the line to remember when deciding which one a task belongs in.

### Shape 3 — Building software (Code tab)

Full development environment. Visual diffs for what changed, built-in terminal showing commands as they run, git tracking every version for rollback.

**Where the work happens:**

| Environment | Detail |
|---|---|
| **Local** | Claude works directly on a folder — your project files, local tools, a dev server you can preview in the browser |
| **Cloud** | Connect a GitHub repo; Claude works in a cloud environment. **Sessions continue even if you close the app** — start a big refactor, check back later. Good for large codebases or keeping work off your machine |

*Cowork also has a cloud mode in the same spirit — beta, eligible plans, covered in the Introduction to Claude Cowork course.*

**Autonomy settings:**

| Mode | Behavior |
|---|---|
| **Manually approve** | Claude proposes every change and waits |
| **Accept edits** | Claude applies file edits automatically |
| **Plan** | Claude creates a plan before making changes |

**Availability:** Pro, Max, Team, Enterprise. Multiple sessions across projects; filter by environment (Local/Cloud) and status from the sidebar.

### The decision table

| You're about to… | Shape | Where |
|---|---|---|
| Ask, brainstorm, draft, or think something through turn by turn | Turn by turn | **Chat** — quick entry, dictation, screenshots |
| Hand off a multi-step task ending in a finished deliverable, spanning your tools, or running on a schedule | Handing off | **Cowork** — folder access, connectors, scheduled tasks, subagents |
| Write, test, run, and ship code in a codebase | Building software | **Code tab** — Local or Cloud |

## Lab or exercise

### Reflection prompts (from the lesson)
1. Which of this week's requests were genuinely turn-by-turn thinking, and which were whole tasks fed in one question at a time *because that's the habit*?
2. Take the task you'd most like off your plate. Multi-step? Ends in a real file? Spans your tools? If yes to any — it's a hand-off. Write down **the outcome you'd describe**, not the first question you'd ask.

> [!note] Note
> Reflection prompt 1 is the sharpest thing in the lesson. The failure mode it names is real: driving a multi-step task through Chat one turn at a time out of habit, doing the orchestration yourself that Cowork would have done. Worth actually auditing rather than skimming past.

> [!note] Note
> "Describe the outcome, not the first question" is **Delegation** from §1.3 rendered as a product decision. The three control points in Cowork — scope questions, plan review, approval gates on consequential actions — are **Diligence** built into the surface rather than left to the user's discipline. The 4D framework isn't a separate topic from the product; it's the design rationale.

> [!note] Note
> Subagents and Plugins both appear here as one-line features, and both have dedicated courses in Track B (*Introduction to subagents*, *Introduction to agent skills*). This lesson is the teaser; the depth is downstream.

## My application

<!-- Where I'd actually use this. Fill in as I go. -->
- TODO: run reflection prompt 1 honestly against this past week.
- TODO: candidate hand-offs worth setting up as scheduled tasks — a weekly job-search pipeline roll-up, a recurring digest across tracked requisitions.
- Note for the record: this knowledge base is itself a Cowork hand-off — folder-scoped, multi-step, ends in real files. Good worked example of the shape.

## Next

### Preview of Module 2

Next module covers **organizing your work and knowledge** — starting with Projects (2.1), then Artifacts (2.2) and Skills (2.3).

## Topics to explore

Add a task for anything worth exploring, for example `- [ ] #explore <topic>`.
