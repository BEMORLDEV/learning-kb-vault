---
type: course
title: "Claude 101"
provider: "Anthropic Academy"
first_party: true
status: active
url: "https://anthropic.skilljar.com/claude-101"
format: "Self-paced, 14 lessons across 5 modules, certificate of completion"
lessons_total: 14
lessons_captured: 5
started: 2026-09-14
completed:
certificate: ""
migrated: 2026-09-30
source: 'claude.ai project "Claude Knowledge Base", claude/claude-101/notes.md'
tags: []
---

# Claude 101

## About

**Course:** Claude 101 · Anthropic Academy
**URL:** https://anthropic.skilljar.com/claude-101
**Format:** Self-paced, 14 lessons across 5 modules · Certificate of completion
**Capture started:** 2026-09-14
**Status:** In progress — 5 of 14 lessons captured — Module 1 complete

Study guide derived from these notes: [[Claude-101 Study Guide 2026-09-14]] · Course roster and certificate tracking: `_index.md`, still in the claude.ai project until it migrates.

> Original summaries written for personal study. Course material is © Anthropic PBC; nothing here reproduces the source lessons verbatim.
> Blockquotes beginning **`Note —`** are my own synthesis, not course content.

Since the move to LearningKB, those blockquotes are note callouts in each lesson. The wording is unchanged.

## Outline

### Module 1 — Meet Claude
*What Claude is, how to talk to it, how to get good results.*

- [x] [[Claude-101 1.1 What is Claude|1.1 What is Claude?]]
- [x] [[Claude-101 1.2 Your first conversation with Claude|1.2 Your first conversation with Claude]]
- [x] [[Claude-101 1.3 Getting better results|1.3 Getting better results]]
- [x] [[Claude-101 1.4 How you'll work with Claude on your desktop|1.4 How you'll work with Claude on your desktop]]

### Module 2 — Organizing your work and knowledge
*How Projects, Artifacts, and Skills give Claude structure and reusable knowledge.*

- [x] [[Claude-101 2.1 Introduction to projects|2.1 Introduction to projects]]
- [ ] 2.2 Creating with artifacts
- [ ] 2.3 Working with skills

### Module 3 — Expanding Claude's reach
*How Connectors, Enterprise Search, and Research bring your tools and the web into the conversation.*

- [ ] 3.1 Connecting your tools
- [ ] 3.2 Enterprise search
- [ ] 3.3 Research for deep dives

### Module 4 — Putting it all together
*What Claude looks like across roles, and where else you can work with it.*

- [ ] 4.1 Claude in action: use-cases by role
- [ ] 4.2 Other ways to work with Claude

### Module 5 — Conclusion & certificate

- [ ] 5.1 What's next?
- [ ] 5.2 Certificate of completion

## Lessons captured

```dataview
TABLE lesson, captured
WHERE type = "lesson" AND file.folder = this.file.folder
SORT lesson ASC
```

## Topics to explore

These were the open questions in the original notes.

<!-- Things to chase down. -->
- [ ] #explore How does the Skills model in Claude.ai relate to Claude Code's skill system — same mechanism, different surface?
- [ ] #explore Which models support the 1M-token context window?
- [ ] #explore Styles vs. Settings preferences vs. Project custom instructions — which wins when they conflict? **Partially answered (2.1):** project instructions "work alongside" user preferences and styles, so they layer rather than replace. Conflict resolution still unstated.
- [ ] #explore Does Memory operate per-Project or account-wide? **Partially answered (2.1):** a project is described as having *its own* memory, so project-scoped memory exists. Whether account-level memory persists alongside it is unstated.
- [ ] #explore Switching models starts a new chat — does any context carry over, or is it a true reset? Matters for mid-task escalation from Sonnet to Opus.
- [ ] #explore Which connectors are available on my plan/org, and does Enterprise Search overlap with the connected-data-sources toggle? (Lessons 3.1 / 3.2.)

Every open flag from this course:

```dataview
TASK
WHERE contains(tags, "#explore") AND !completed AND startswith(path, this.file.folder)
```

## Cross-lesson themes

<!-- Patterns worth pulling out once several lessons are in. -->

**Context is the lever (1.1, 1.2).** Both lessons land on the same point from different angles — the large context window is only useful if you actually fill it with the right material. Uploads, preferences, and Memory are all mechanisms for reducing how much you have to re-explain.

**Layers of persistence (1.2).** Three tiers so far, worth keeping straight:

| Scope | Mechanism |
|---|---|
| Single conversation | Uploads, follow-up turns |
| Every conversation | Settings preferences, Styles |
| Learned over time | Memory |

**Three independent dials (1.2 video).** The control surface separates cleanly:

| Dial | Controls | Adjust when |
|---|---|---|
| Model (Opus / Sonnet) | Raw capability | Task is genuinely hard |
| Extended Thinking | Reasoning depth per turn | Answer needs step-by-step care |
| Tools (web search, connectors) | What Claude can *reach* | Claude lacks information, not intelligence |

Default posture: Sonnet, thinking off, tools on as needed. Escalate deliberately rather than by reflex.

**4D is the spine (1.2, 1.3).** The course is quietly organized around the AI Fluency framework even where it doesn't say so:

| Competency | Where it shows up so far |
|---|---|
| Delegation | §1.3 video — deciding what to hand off, and what not to |
| Description | §1.2 three-part prompt structure |
| Discernment | §1.3 troubleshooting table + the eval approach |
| Diligence | §1.3 — verify, take accountability, be transparent about AI's role |

**Two failure classes, two responses (1.2, 1.3).** Worth holding separately:

| Class | Looks like | Response |
|---|---|---|
| **Visible failure** | Too long, wrong format, wrong tone, off-target | Iterate — feedback, redirect, edit & resubmit |
| **Invisible failure** | Confident, fluent, wrong. Inferred data that wasn't there | Verify against known-good. Enable web search. Run an eval before trusting the task at all |

> [!note] Note
> Every iteration technique in the course addresses the first class. Only evals address the second. That asymmetry is the most useful thing in the first three lessons.

**The framework is the product's design rationale (1.3, 1.4).** 4D isn't a separate topic bolted onto the tooling — the tooling is shaped by it:

| 4D competency | Product expression (1.4) |
|---|---|
| Delegation | Choosing the shape — turn by turn vs. hand-off. "Describe the outcome, not the first question" |
| Description | Scope and format questions Cowork asks before starting |
| Discernment | Watching the task take shape; reviewing plan and output |
| Diligence | Approval gates on consequential actions; you stay in control of what leaves your desk |

**Where the finished file lands is the real dividing line (1.4).** Chat reads uploads and returns downloads. Cowork reads a folder and writes back into it. Everything else between the two surfaces is a matter of degree; this one is categorical.

**Four layers of instruction now, not three (1.2, 2.1).** The persistence table from Module 1 needs a row:

| Scope | Mechanism | Introduced |
|---|---|---|
| One conversation | Uploads, follow-up turns | 1.2 |
| **One work stream** | **Project instructions + project knowledge base** | **2.1** |
| Every conversation | Settings preferences, Styles | 1.2 |
| Learned over time | Memory (account and/or project) | 1.2, 2.1 |

Project instructions "work alongside" preferences and styles — they layer rather than replace. Precedence on actual conflict is still undocumented.

**Retrieval changes what good input looks like (2.1).** Once a knowledge base trips the RAG threshold, Claude searches instead of reading everything. Two consequences the course presents as tips but which are really mechanics: **filenames become retrieval signal**, and **file proximity encodes relationships**. Descriptive naming isn't tidiness — it's the index.

## Study material

[[Claude-101 Study Guide 2026-09-14]] is the study guide built from Lessons 1.1 to 2.1: cheat sheet, 38 practice questions, 117 flashcards and 3 concept maps. It is kept as it was on 2026-09-14 and is not updated.

## Log

- 2026-09-14: Capture started in the claude.ai project "Claude Knowledge Base". Lessons 1.1 to 2.1 captured.
- 2026-09-30: Moved into LearningKB. One note per lesson, a summary added to each, everything else kept.
