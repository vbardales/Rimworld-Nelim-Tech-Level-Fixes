# Runs, one line each

Newest last. The evidence itself is never kept as folders in git: only the latest report that still proves something stays on
disk, in `Tests/Pickle/Evidence/` (ignored by git). Before 2026-09-26 the reports were committed under `Tests/Pickle/results/`;
that folder was removed and these lines are what is left of it.

**None of these runs is on the current revision.** The suite last ran on the tree of `a37ff89` (31 patch files); `Mod/` now holds
45. A run of the shipped revision is required for `tested` and has not been done. A launcher log says `exitReason: passed` and the
counts it printed; it is not the report itself.

- 2026-09-20, sources pass, first run of the suite, on the tree of `5543a85`: 4 of 5 scenarios passed. The failure was an undefined
  step (`def ... of type ... field` exists only for `exists`), not a defect of the mod; the scenario was rewritten on defs whose
  name belongs to one def type only. **No valid report survives.** The file saved that day as `results/2026-09-20-summary.md` was
  found on 2026-09-26 to hold another mod's report (TailorMade Waistlines' three trouser scenarios, 3 of 3), copied from the shared
  `pickle-reports/` folder after that mod's run had overwritten ours. The "4 of 5" rests on what the session read that day.
- 2026-09-21, sources pass (before the two-pass rule existed), on the tree of `421f136`: 5 of 5 passed. Kept as text only:
  `Evidence/2026-09-21-sources/summary.md`; there is no `summary.json`, so `exitReason` cannot be re-read from it.
- 2026-09-21 11:33, bare pass (`sans-facultatifs`), weak form (`mod is loaded`, `no errors were logged`): 1 of 1, `exitReason: passed`,
  2 features discovered and 1 played (the filter keeping `02-with-sources.feature` out). Report not kept, superseded below.
- 2026-09-21 12:08, bare pass, strengthened form on the tree of `bf9d8d7` (`no def ... exists`, `no def ... was patched`,
  `no warnings from mod "Nelim's Tech Level Fixes"`): 1 of 1, 5 steps of 5 `PASSED`, `exitReason: passed`, 0 errors, two unattributed
  `[Vanilla]` warnings (Steam under WSL; the companion test mod's dependency without a URL). Kept: `Evidence/2026-09-21-bare-strengthened/`.
- 2026-09-22 15:55 (launcher log), bare pass with the whole suite by mistake: 2 of 6. Not a defect of the mod: the real-modlist
  feature necessarily lacked its three source mods. Discarded.
- 2026-09-22 16:21 (launcher log), bare pass: 0 scenarios, `exitReason: infrastructure-error`. The filter went through with literal
  apostrophes and matched no feature. Discarded; evidence for nothing.
- 2026-09-22 16:31 (launcher log), bare pass, `-Filter 01-alone.feature`, on the tree of `a37ff89`: 1 of 1, `exitReason: passed`.
- 2026-09-22 16:57, 17:35 and 18:01 (launcher logs), sources pass, `-Filter 02-with-sources.feature -DepMap wsl-deps.sources.map`, on
  the tree of `a37ff89`: 5 of 5 passed each time, `exitReason: passed`. Three runs of the same tree; not three pieces of evidence.
- 2026-09-22 23:26 (launcher log), sources pass on Pickle v4.8.4 (`-PickleSrc`, the release that carries PR #20): 5 of 5,
  `exitReason: passed`. Kept: `Evidence/2026-09-22-v4.8.4-sources.out.log`.
- 2026-09-23 00:08 (launcher log), bare pass on Pickle v4.8.4: 1 of 1, `exitReason: passed`. Kept:
  `Evidence/2026-09-23-v4.8.4-bare.out.log`. This is the run that re-establishes the no-target guarantee on that release, which the
  2026-09-22 note in `STATUS.md` said was still open; it was found in the launcher log on 2026-09-26, not recorded at the time.
