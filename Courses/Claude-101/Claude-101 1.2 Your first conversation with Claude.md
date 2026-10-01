---
type: lesson
course: "[[Claude-101]]"
lesson: "1.2"
title: "Your first conversation with Claude"
captured: 2026-09-14
migrated: 2026-09-30
est_time: "20 min"
formats: [written, video]
source: 'claude.ai project "Claude Knowledge Base", claude/claude-101/notes.md'
---
# 1.2 Your first conversation with Claude

**Captured:** 2026-09-14 · **Est. time:** 20 min · Written lesson + embedded video *Getting started with Claude.ai* (transcript reviewed)

Course: [[Claude-101]]

## Summary

You bring the context and expertise; Claude brings the intelligence, so output quality tracks the context you give it. Good prompts have three parts: set the stage, define the task, specify rules, adapted from the 4D AI Fluency framework. The video adds the interface: the sidebar, the search and tools menu (what Claude can reach), the model selector (Opus for the hardest work, Sonnet as the default), Extended Thinking and Research. Work iteratively with follow-ups, feedback, redirects, restarts or edit and resubmit, and use Memory and Styles so you repeat yourself less.

## Objectives

- Start a conversation and navigate the interface
- Write effective prompts using clear, specific language
- Upload files and images for context
- Use follow-ups to iterate and refine

## Written

### Core takeaways

**Division of labor.** Claude brings the intelligence; you bring the context and domain expertise. Neither half is optional — the output quality tracks how much real context you supply.

**Talk to it like a coworker** — naturally, concisely, conversationally. Not keyword search, not ceremonial prompt-engineering incantations.

**Frequency beats cleverness.** The value compounds through continued, frequent use, not from crafting one perfect one-shot prompt.

### The three-part prompt structure

| Part | Question it answers |
|---|---|
| **Set the stage** | What's my role, what are my objectives, what context should Claude have? |
| **Define the task** | What action do I want — write, analyze, build, research? |
| **Specify rules** | What style/tone/format? Any examples to show what "good" looks like? |

*Worked example from the course* — an investor pitch-deck research request:

- *Stage:* marketing lead at an indie streaming startup, prepping a Series A deck
- *Task:* research the indie film streaming market — trends, competitor positioning, growth opportunities
- *Rules:* current web research with citations, professional report up to 5 pages, with executive summary / market analysis / competitive landscape / growth opportunities

**Source:** adapted from the **4D Framework for AI Fluency** (Prof. Rick Dakan, Ringling College; Prof. Joseph Feller, University College Cork). Four competencies — **Delegation, Description, Discernment, Diligence**. Free course at anthropic.com/ai-fluency.

> [!note] Note
> The three-part structure above maps roughly onto Delegation (what to hand off) and Description (how to specify it). Discernment and Diligence — evaluating output and verifying it — aren't covered in *this* lesson. **Update after 1.3:** the next lesson does introduce all four and explicitly maps this prompt framework to Description. Introduced, not taught in depth — the AI Fluency course is still where the other two actually live.

### Adding context

Supported uploads: **PDF, DOCX, CSV, TXT, PNG, JPEG** and common image formats. Claude parses both text and visual elements (charts, graphics) inside documents.

Practical patterns:
- Upload a doc → summarize key points
- Share an image → describe or analyze it
- Attach a spreadsheet → identify trends
- Upload code → explain it or find bugs

**Setting:** Settings → General → "What personal preferences should Claude consider?" applies preferences to every conversation.

### Iterating

Conversations are meant to be iterative — chain bite-sized prompts rather than front-loading one monolith.

| Move | When to use it | Example |
|---|---|---|
| **Follow-up question** | Response is close, needs depth or a different angle | "Can you expand on the second point?" |
| **Feedback** | Content is right, delivery is off | "Good, but the tone is too formal — make it conversational" |
| **Redirect** | Claude went the wrong direction | "Actually I was asking about X, not Y" |
| **Restart** | Context is polluted beyond recovery | New chat, fresh context |
| **Edit & resubmit** | You want to *refine* the request, not append to it | Pencil icon on your own message |

> [!note] Note
> The edit-and-resubmit distinction is the useful one. Adding a correction as a new message leaves the bad turn in context; editing the original replaces it. Matters for long sessions where context budget is real.

### Personalization

**Memory** — automatically saves key context across conversations (role, preferences, past decisions, working style) so you don't repeat yourself. Reviewable, editable, and deletable in Settings. Syncs across devices.

**Styles** — control how Claude communicates. Presets (concise, formal, explanatory) or a custom style you describe. Applies across all conversations once set.

## Video

### Video-only material

*The embedded video covers several things the written lesson skips entirely. Captured separately so it's obvious where it came from.*

**Sidebar anatomy**
- New chat / chat history
- **Projects** — organize conversations with persistent context and custom instructions
- **Artifacts** — turn ideas into shareable apps, tools, or content

**Search and Tools menu** — the lever for what Claude can *reach*, as distinct from what you paste in:
- **Web search** toggle — pull current data
- **Connected data sources** (e.g. Google Drive) — real-time access to your own systems

Claude decides which of the enabled tools to invoke while working the request; you're granting capability, not scripting the call.

**Model selector** — appears under the text input; click the model name to change. Changing the model starts a new chat.

| Model | Use for |
|---|---|
| **Opus** | Most complex tasks — largest model, hybrid reasoning. Example given: multi-step financial analysis |
| **Sonnet** | Everyday work; the recommended default. Balances capability against cost |

**Extended Thinking mode** — valuable for complex reasoning and analysis; increases latency and is unnecessary for straightforward questions. Recommended ladder: start on Sonnet with thinking off → escalate model or enable thinking only if the answer isn't good enough.

**Research** — systematic multi-angle investigation. Breaks a complex question into sub-questions automatically, explores hundreds of sources, returns a cited report. Runtime **5–45 minutes**, so it's a fire-and-forget move while you do something else. (Covered in depth in Lesson 3.3.)

> [!note] Note
> The three dials: **model** = raw capability, **thinking** = reasoning depth per turn, **tools** = reach. They're independent. Most "Claude got it wrong" moments are a reach problem, not a capability problem — worth checking the tools toggle before reaching for Opus.

> [!note] Note
> *Transcript artifact:* the auto-transcription repeatedly garbles "context and expertise" into "context window expertise." Same line as the written lesson — you bring the context and expertise.

## My application

<!-- Where I'd actually use this. Fill in as I go. -->
- TODO: audit my current Settings → personal preferences; make sure it reflects how I actually want output shaped.
- TODO: try a custom Style vs. relying on per-conversation instructions.

## Links

- AI Fluency course (free) — https://www.anthropic.com/ai-fluency
- Use-case gallery — https://claude.com/resources/use-cases

## Topics to explore

Add a task for anything worth exploring, for example `- [ ] #explore <topic>`.
