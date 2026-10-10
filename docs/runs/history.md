# Runs, one line each

Newest last. The evidence itself is never kept as folders in git: only the latest report that still proves something stays on
disk, in `Tests/Pickle/Evidence/` (ignored by git).

**Trimmed 2026-10-09, after publication (AGENTS.md).** The development-era runs of 2026-09-20 to 2026-09-23 (first suite run, the
two-pass rule's first passes, the mistaken and infrastructure runs, the three same-tree sources reruns, the Pickle v4.8.4 passes)
are dropped: the two runs below supersede all of them on the shipped patches, and `git log -p docs/runs/history.md` holds the detail.
Post-publication regression played 2026-10-10 on the published tree (see below); 1.0.1 and 1.0.2 changed the description only,

- 2026-10-10 (RUN_DONE aaa2), non-regression, bare pass `-Filter 01-alone` on the tree of `2cb1aa4` (49 patch files, 1.0.2 published): 1 of 1, `exitReason: passed`, `setName: sans-facultatifs`, scenario name read; no error or warning attributed to the mod. Kept: `Tests/Pickle/Evidence/2026-10-10-bare` (`summary.md`, `summary.json`, `junit.xml`).
- 2026-10-10 (RUN_DONE 02f9), non-regression, sources pass `-Filter 02-with-sources -DepMap wsl-deps.sources.map` on the tree of `2cb1aa4`: 5 of 5, `exitReason: passed`, `setName: sources`, five scenario names read; errors in the log come from other mods (KCSG, VEF, Alpha Books cross-references), none attributed to this mod. Kept: `Tests/Pickle/Evidence/2026-10-10-sources`.
