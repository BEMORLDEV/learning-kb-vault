---
type: plan
updated: 2026-09-30
---

# Learning plan

A rough plan, not a schedule. See [[LearningKB-Rules]] for how it works.

## Now

Aim for about 5.

## Next

## Someday

## Flagged topics

Every open `#explore` task in the vault. Move one into Now, Next or Someday when you decide to pursue it.

```dataview
TASK
WHERE contains(tags, "#explore") AND !completed AND !startswith(path, "_templates")
```

## Courses

```dataview
TABLE status, provider, first_party
FROM "Courses"
WHERE type = "course"
SORT status ASC
```
