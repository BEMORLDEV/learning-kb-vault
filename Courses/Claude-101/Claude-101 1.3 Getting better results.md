---
type: lesson
course: "[[Claude-101]]"
lesson: "1.3"
title: "Getting better results"
captured: 2026-09-14
migrated: 2026-09-30
est_time: "15 min"
formats: [written, video]
source: 'claude.ai project "Claude Knowledge Base", claude/claude-101/notes.md'
---
# 1.3 Getting better results

**Captured:** 2026-09-14 · **Est. time:** 15 min · Written lesson + embedded video *Data Analysis with AI* (transcript + summary reviewed)

Course: [[Claude-101]]

## Summary

Five common failures (too generic, wrong length, wrong format, confident but wrong, tone off) each have a matching fix, and confident but wrong is the one you can't spot by reading. The lesson defines AI Fluency through the 4D framework: Delegation, Description, Discernment, Diligence. It shows a lightweight eval: gather 5 to 10 real examples, write test prompts, compare, refine. The video's Delegation and Diligence Loop and the Rio case study show testing AI against data where you already know the answer, and that validation builds confidence but does not remove responsibility.

## Objectives

- Recognize common AI challenges and troubleshoot them
- Define AI Fluency and know where to go deeper
- Explain how to set up evals for your own workflows

## Written

### Troubleshooting table

| Symptom | What's actually happening | Fix |
|---|---|---|
| **Too generic** | Prompt lacked context about your specific situation | Add audience, role, constraints. "Write an email about the delay" → who the client is, how long the delay, that it's the *second* delay, and the tone to strike |
| **Too long / too short** | Claude is guessing at appropriate length | State it: "two paragraphs," "under 100 words," "length isn't a concern" |
| **Wrong format** | Claude understood *what*, not *how* it should look | Show, don't tell. Give an example of the format, or describe the structure explicitly |
| **Confident but wrong** | Plausible-sounding generation — worst on specific facts and niche topics | Verify independently for high-stakes work. Ask for sources or a confidence level. **Enable web search** to ground responses |
| **Tone is off** | Defaults to helpful and professional | Describe the tone in plain language, or paste an example written in the voice you want |

> [!note] Note
> The confident-wrong row is the one that actually costs you something. The other four produce output you can see is wrong; this one produces output you can't. Note also that the cheapest fix — turning on web search — is listed last. For anything time-sensitive or factual it should be the first move, not the fallback.

### The iteration mindset

Your first prompt rarely produces a perfect result. Treat it as the opening of a conversation, not a one-shot request.

- **First drafts are starting points.** Review, identify what works and what doesn't, refine
- **Specific feedback beats vague.** "Make it shorter" works; "cut the first two paragraphs and make the conclusion more action-oriented" works better
- **Know when to start fresh.** A conversation that's gone off track is often faster to abandon than to redirect

### AI Fluency — the full 4D framework

**AI Fluency** = the ability to collaborate effectively with AI. Not knowing which buttons to click — developing the *judgment* to use AI well across different situations.

Developed by **Prof. Rick Dakan** (Ringling College of Art and Design) and **Prof. Joseph Feller** (University College Cork).

| Competency | Definition |
|---|---|
| **Delegation** | Deciding what work humans do, what AI does, and how to distribute between them. Requires understanding your goals, AI's capabilities, and making strategic choices about collaboration |
| **Description** | Communicating effectively with AI. Defining outputs clearly, guiding processes, specifying desired behaviors and interactions |
| **Discernment** | Critically evaluating AI outputs, processes, behaviors, and interactions. Assessing quality, accuracy, appropriateness; determining where improvement is needed |
| **Diligence** | Using AI responsibly and ethically. Thoughtful choices about systems and interactions, maintaining transparency, taking accountability for AI-assisted work |

**The course maps its own content onto this:** the three-part prompt framework from §1.2 is rooted in **Description**. The troubleshooting techniques above draw on **Discernment** and **Diligence**.

> [!note] Note
> This resolves the gap flagged in §1.2 — all four competencies are at least named here. But *named* isn't *taught*: Delegation and Description get a framework, Discernment gets the eval approach below, and Diligence gets a single sentence about accountability. The dedicated AI Fluency course is still where the depth is.

### Evals

The question behind this section: *how do I know Claude is actually good at this particular task?* This is Discernment made concrete.

**Why it matters** — your work is unique. Claude might be strong at drafting marketing copy and weak at technical documentation in your specific domain. Running simple evals helps you:
- Find where Claude adds the most value in your workflow
- Identify tasks needing more context or examples
- Build confidence for recurring tasks

**The lightweight approach — no infrastructure required:**

| Step | What to do |
|---|---|
| **1. Gather examples** | 5–10 examples of a task you do regularly — emails, reports, analyses you've already produced |
| **2. Create test prompts** | Write prompts that would generate similar output. Include the context you'd naturally have |
| **3. Compare** | Does Claude capture the key information? Is tone and style appropriate? What's missing? |
| **4. Refine** | Adjust prompts, add examples showing what good looks like, or identify where human review is non-negotiable |

> [!note] Note
> This is regression testing with human judgment as the oracle. Familiar shape. The valuable part isn't the technique — it's that it converts "is Claude any good at this" from a vibe into an empirical question with a recorded answer.

> [!note] Note
> There's a formal version of this in the developer track (eval suites, `claude plugin eval`). Worth connecting the two when Track B/C comes around — same instinct, different rigor.

## Video

### Video: the Delegation–Diligence Loop

*Sourced from the **AI Fluency for nonprofits** course. The narration references a previous lesson on data privacy and a next lesson on workflow augmentation — those belong to that course, not Claude 101.*

**Core question:** how can I trust AI's analytical results?

**Answer:** test it against data you already understand, before you delegate real work.

| Step | Detail |
|---|---|
| 1 | Identify a specific recurring analytical task you want to delegate. Be precise |
| 2 | Find past data where you already completed the analysis — you need the right answers to grade against |
| 3 | Work with AI to reproduce it. Evaluate: what did it produce? how did it approach the task? how did it communicate findings? |
| 4 | Identify gaps, refine the delegation, test again |

**Two valid outcomes.** Either you validate an approach you can use confidently on new data, *or* you learn after several refinements that this isn't a task to delegate. The second outcome is a result, not a failure.

#### Case study — Rio, Valley Veterans Services

Program director. Quarterly task: analyze program attendance against employment outcomes — participation rates, monthly changes, whether attendance correlates with job placement. Takes hours.

**Delegation decision:** he wants to keep interpreting the results himself. What he wants off his plate is the data cleaning and formula work.

**Test setup:** last quarter's raw messy data, plus the known correct answers from when he did it manually.

| Round | What happened | What he learned |
|---|---|---|
| **1** | AI correctly found the attendance/job-placement correlation, but missed an insight about the combined housing assistance + job placement program | Correct ≠ complete |
| **2** | He refined the description, asking it to attend to program type. AI caught the miss | **Future prompts must specify program type** |
| **3** | He pushed harder — cohort analysis by enrollment date. The data didn't contain enrollment dates, and AI tried to infer them | **Enrollment dates must be supplied explicitly; inference is not acceptable** |

**Result:** a validated approach plus written notes on exactly what context to include each time, and where his own follow-up is still required.

**Diligence doesn't stop after validation.** On new data he still checks whether the numbers make sense against what he knows, takes accountability for the final report, and is transparent about AI's role. The difference is he's working from validated confidence rather than guesswork.

**If you're not data-savvy enough to spot the gaps yourself:** AI is also good at helping you find solutions you wouldn't have reached alone — Excel formulas, reformatting messy data, structuring an analysis. Treat it like a data analyst on your team: keep asking for clarification and explanation until you can follow the process and understand the output.

**Generalizes to:** donor analysis, budget forecasting, survey synthesis, outcome tracking. Test first, validate what works, then apply — or learn what not to delegate.

> [!note] Note
> The sharpest line in the whole lesson: **validation builds confidence but does not eliminate responsibility.** That's the actual definition of Diligence, and it's the thing that separates using AI professionally from using it carelessly.

> [!note] Note
> Round 3 is the most instructive round, and it's easy to skim past. AI silently inferred data that wasn't there rather than saying "you didn't give me enrollment dates." Rio only caught it because he knew the data. That's the confident-wrong failure mode from the troubleshooting table, showing up in a concrete case — and the reason the eval has to be run against data where you already know the answer.

## My application

<!-- Where I'd actually use this. Fill in as I go. -->
- TODO: pick one recurring task and run the 4-step eval properly. Candidates worth considering — a TRON reporting/analysis task where I have known-good prior output, or résumé/job-application screening where I can grade against decisions I already made.
- TODO: keep a written "context checklist" per validated task, the way Rio did. That artifact is the actual output of an eval, not the pass/fail.

## Links

- AI Fluency course (free) — https://www.anthropic.com/ai-fluency

## Next

### Preview of 1.4

The next lesson covers the Claude desktop app and **three ways of working**:
- **Chat** — turn by turn
- **Cowork** — handing work off
- **Claude Code** — building software

> [!note] Note
> Directly relevant to the course order in `_index.md`. Cowork sits at #2 there. **Confirmed after capturing 1.4** — Cowork is one of the three primary shapes of work, not a side feature, and it's the surface this knowledge base is being built in. The placement holds.

## Topics to explore

Add a task for anything worth exploring, for example `- [ ] #explore <topic>`.
