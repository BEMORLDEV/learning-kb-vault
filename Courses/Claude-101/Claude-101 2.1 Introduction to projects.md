---
type: lesson
course: "[[Claude-101]]"
lesson: "2.1"
title: "Introduction to projects"
captured: 2026-09-14
migrated: 2026-09-30
est_time: "20 min"
formats: [written, video]
source: 'claude.ai project "Claude Knowledge Base", claude/claude-101/notes.md'
---
# 2.1 Introduction to projects

**Captured:** 2026-09-14 · **Est. time:** 20 min · Written lesson + video *Introduction to Projects* (video not transcribed — written lesson captured)

Course: [[Claude-101]]

## Summary

A project is a self-contained workspace with its own memory, chat history, knowledge base and custom instructions, worth creating for ongoing work with repeated reference material, consistent requirements or a team. Claude does not see the project description, so anything it must act on goes in the instructions. Large knowledge bases switch to RAG, where Claude searches the files instead of loading them all, so descriptive file names and grouping related files matter. Team and Enterprise plans add sharing with view, edit and owner permissions.

## Objectives

- Explain what projects are and when to use them
- Create a project with name, description, visibility
- Add documents to the knowledge base
- Write effective project instructions
- Share projects with teammates (Team/Enterprise)

## Written

### What a project is

A **self-contained workspace** with four things of its own:

| Component | What it holds |
|---|---|
| **Memory** | Context that persists within the project |
| **Chat histories** | Conversations grouped to this work stream |
| **Knowledge base** | Documents Claude references across *every* chat in the project |
| **Custom instructions** | Behavior rules applied to every conversation in the project |

### When to create one

Projects earn their keep on **ongoing** work, not one-off questions. The three triggers:

| Trigger | Example |
|---|---|
| **Reference materials used repeatedly** | Meeting notes, survey results, reports, historical data |
| **Consistent requirements for how Claude responds** | Always formal, always cite sources, always follow our template |
| **Team collaboration** | Multiple people working from the same foundation |

### Setup

**Step 1 — Create.** Sidebar → Projects (or claude.ai/projects) → **+ New Project**. Give it a descriptive name, a brief description, and set visibility (private, or shared with your organization on Claude for Work).

> [!note] Note
> Buried detail worth flagging: **Claude does not see the project description.** It's for you and your teammates to understand the project's purpose. Anything you want Claude to actually act on has to go in the *instructions*, not the description. Easy trap.

**Step 2 — Instructions.** Tell Claude how to behave across every conversation in the project. Good instructions typically cover:

| Element | Example |
|---|---|
| Context about the work | "This project is for creating marketing content for our B2B software product" |
| Process | "First consider a blog structure that will entice this audience, then write the draft" |
| Tone and style | "Professional but conversational. Avoid jargon where possible" |
| Specific requirements | "Always include a call-to-action at the end of marketing copy" |

Click **Save instructions**. They apply to every chat in the project and **work alongside** your user preferences and styles.

Instructions can also automate workflows — e.g. *"When I upload a meeting transcript, create a structured summary using this template."* The lesson's framing: think of instructions as **programming Claude's behavior for this project**.

**Step 3 — Knowledge base.** Files menu on the right of the project's main page. Click **+** to add.

- **Formats:** PDF, DOCX, CSV, TXT, HTML, and more
- **Google Drive** can be connected to link documents directly
- **What to upload:** reference documents (brand guidelines, style guides, templates) · background materials (research, meeting notes, requirements) · examples of work to emulate · technical documentation and specs

**Pro tip from the lesson:** name files descriptively. Claude uses file names to understand and retrieve the right information — `Q4-2024-Brand-Guidelines.pdf` beats `document1.pdf`.

### How large knowledge bases scale — RAG

Projects scale automatically via **Retrieval Augmented Generation (RAG)**.

| Behavior | Detail |
|---|---|
| Below the limit | Claude loads the whole knowledge base into context |
| Approaching the context window limit | Claude **stops loading everything** and instead *searches* the project's files, retrieving only what's relevant to your question |
| Capacity gain | **Up to 10x**, while maintaining response quality |
| Signal | A **visual indicator** appears when the project is RAG-enabled |

The experience is meant to feel identical either way — you still upload, chat, and get context-aware answers.

> [!note] Note
> This is why the filename advice isn't a nicety. Once RAG kicks in, Claude isn't reading everything — it's *searching*. Filenames become retrieval signal. The best-practices section makes this explicit: Claude uses **filenames and proximity** to understand relationships between documents, so grouping related files matters too. Anyone who has built a retrieval system will recognize the advice; the useful part is that the product tells you when the mode flips.

### Collaboration (Claude for Work — Team and Enterprise)

**Three permission levels:**

| Level | Can do |
|---|---|
| **Can view** | See contents, access knowledge, chat — but no changes. Read-only with discussion rights |
| **Can edit** | Modify instructions, update knowledge, manage members, contribute fully |
| **Owner** | Everything, including controlling who sees the project — specific people or the whole organization |

**Sharing:** open the project → **Share project** (right of the project name) → add members by name or email, or paste a list for bulk sharing → or share with "Everyone at [organization]" to make it discoverable in the **Team** tab.

Members get email notifications and find shared projects under **"Shared with me."**

### Example project types (from the lesson)

Product launch · research support · client account hub · event planning workspace · job description generator. The common pattern: durable reference material + a consistent house style + repeated deliverables.

### Best practices

| Practice | Why |
|---|---|
| **Start focused, then expand** | One specific use case beats one project for everything |
| **Keep knowledge current** | Outdated documents produce outdated responses |
| **Write clear instructions** | Vague instructions → inconsistent results |
| **Name documents descriptively; group related files** | Claude uses filenames *and proximity* to understand relationships |
| **Reference documents by name in your prompts** | "Based on our Q3 report, what were the top customer concerns?" helps Claude focus its search |

## Video

The lesson includes a video, *Introduction to Projects*. It was not transcribed; the written lesson was captured instead (see the capture line above).

## Lab or exercise

### Reflection prompts (from the lesson)
1. What ongoing work would benefit from a dedicated project with persistent context?
2. What documents am I re-uploading or re-explaining to Claude on a regular basis?
3. Are there projects that would benefit from shared knowledge and instructions across a team?

> [!note] Note
> Reflection prompt 2 is the actual test for whether something should be a project. If you've uploaded the same file twice, that's the signal — not some judgment about whether the work feels "big enough."

> [!note] Note
> Worked example close at hand: this knowledge base *is* a project. Persistent instructions (the capture conventions), a knowledge base that grows per lesson, and chats grouped to one work stream. Reflection prompt 1 answered itself.

## My application

<!-- Where I'd actually use this. Fill in as I go. -->
- TODO: audit existing projects against the "start focused" advice — several were created per-employer/per-search and may be fragmenting context that belongs together.
- TODO: check whether any project instructions are vague enough to be producing inconsistent results.
- Instruction-as-automation is the underused feature: "when I upload X, produce Y in this template" is a standing workflow, not a preference.

## Links

- Help Center — projects: https://support.anthropic.com/en/articles/9519177-how-can-i-create-and-manage-projects

## Next

### Preview of 2.2

Next: **Artifacts** — building mini-apps and outputs Claude creates that you can share right away.

## Topics to explore

Add a task for anything worth exploring, for example `- [ ] #explore <topic>`.
