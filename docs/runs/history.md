# Runs, one line each

Newest last. The evidence itself is never kept as folders in git: only the latest report that still proves something stays on
disk, in `Tests/Pickle/Evidence/` (ignored by git).

**Trimmed 2026-10-09, after publication (AGENTS.md).** The development-era runs of 2026-09-20 to 2026-09-23 (first suite run, the
two-pass rule's first passes, the mistaken and infrastructure runs, the three same-tree sources reruns, the Pickle v4.8.4 passes)
are dropped: the two runs below supersede all of them on the shipped patches, and `git log -p docs/runs/history.md` holds the detail.
No post-publication regression has been played yet; 1.0.1 and 1.0.2 changed the description only, no file under `Mod/Patches/`.

- 2026-10-08 11:38 (RUN_DONE c85e), bare pass `-Filter 01-alone` on the tree of `324e9ec` (49 patch files): 1 of 1, `exitReason: passed`, scenario name checked. Kept: `Evidence/2026-10-08-bare/` (`summary.md`, `summary.json`, `junit.xml`). This is the proof of the no-target guarantee.
- 2026-10-08 (RUN_DONE f719), sources pass `-Filter 02-with-sources -DepMap wsl-deps.sources.map` on the tree of `324e9ec`: 5 of 5, `exitReason: passed`, names read. Kept: `Evidence/2026-10-08-sources/` (`summary.md`, `summary.json`, `junit.xml`). With the bare pass above: `tested`.
