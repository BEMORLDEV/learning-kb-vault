---
type: course
title: ""
provider: ""
first_party: true
status: queued
url: ""
started:
completed:
certificate: ""
tags: []
---

# {{title}}

## About

What the course covers, who it's from, and why it's on the list.

## Outline

Every lesson in the course. Link a lesson once its note exists.

- [ ] 1.1

## Lessons captured

```dataview
TABLE lesson, captured
WHERE type = "lesson" AND file.folder = this.file.folder
SORT lesson ASC
```

## Topics to explore

```dataview
TASK
WHERE contains(tags, "#explore") AND !completed AND startswith(path, this.file.folder)
```

## Log

- {{date:YYYY-MM-DD}}: Course note created.
