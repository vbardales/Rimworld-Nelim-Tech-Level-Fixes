# Nelim's Tech Level Fixes — tests

Not shipped: it lives beside `Mod/`, never inside it, so Steam never receives it.

This mod ships no assembly, no `Defs`, no `Languages`: `Mod/` holds `About/` and `Patches/` and nothing else, and every
patch only writes a `techLevel` value on a def another mod (or the base game) defines. That shapes what there is to test.
The counts in this file are deliberately not written down: the number of source mods and corrections grows with every
cherrypick pass, and a figure here would be wrong the next day. `Tests/Check-Patches.ps1` prints the current ones.

## Where each scenario stands

Eight scenarios were written first, as manual plans. Each one is now either covered by an automated test or **not
applicable**, with its reason. **No manual test remains to be validated.**

| # | Scenario | Status | Covered by |
|---|---|---|---|
| 1 | It loads, and nothing complains | automated | Pickle, both passes: `no errors were logged`. Unit tests: every patch operation applies without error |
| 2 | A correction lands, replace branch | automated | Unit tests: every correction whose source mod is installed is applied to its real def. Pickle: `Bucket_Generic` (Additional Tools declares `Industrial` itself) |
| 3 | A correction lands, add branch | automated | Pickle: `ABooks_AdventuringLogs`, `ABooks_PsychologyBook`, and the inherited case `AMU_AmuletBarkeep` / `AMU_MedalSurgeon`. Unit tests, as above |
| 4 | A missing source mod does nothing, quietly | automated | Pickle, bare pass: no target is staged, and `no def ... exists`, `no def ... was patched`, `no warnings from mod` all hold. Unit tests: a document without the def comes back byte-identical |
| 5 | Delete one correction's file | **not applicable** | see below |
| 6 | Delete the whole `Patches/` folder | **not applicable** | see below |
| 7 | Load order: this mod's value wins | automated | Pickle, sources pass: `mod "nelim.techlevelfixes" loads after ...` |
| 8 | Save, reload, add, remove | **not applicable** | see below |

### Why 5, 6 and 8 are not applicable

`AUDIT.md` ("On ne teste pas le jeu"): what RimWorld does by itself, and how it activates, deactivates or reloads a mod, is the
game's responsibility, not the mod's. The mod answers for what it **declares**, and that is read in the sources.

- **5 and 6 (removing a patch file, or the folder).** Both exercise the game's handling of a file that is absent. The mod
  declares nothing that could break: `About.xml` names mods in `loadAfter`, never a patch file (checked: no `.xml` and no
  `Patches/` in that list), so nothing refers to a file that could go missing. What the values become without the patch is what
  the bare pass and the "missing target does nothing" unit tests already show: an unpatched def keeps its source value.
- **8 (save, reload, add or remove the mod).** `techLevel` lives on the def, which the game rebuilds at every load; the mod
  stores nothing. It has no assembly, so no saved data, and no `Defs`, so no def a save could reference and find missing when the
  mod is removed (checked: no `Defs`, `Languages` or `Assemblies` folder under `Mod/`). What the game does with a save when a mod
  is added or removed is the game's.

This is a judgement about how a rule applies, made by the audit session on 2026-09-26. It replaces the plan of 2026-09-22 that
asked for human-recorded videos of 5, 6 and 8. Nothing is deleted from the mod; if the owner disagrees, the three scenarios
come back as manual and `tested` waits for them.

## How many passes, and what each covers

`AUDIT.md`: a mod is validated over **at least two passes**, one **without** the optional mods and one **with**, and the report
says which is which. A green on one says nothing about the other.

This mod is an awkward case for that rule. It declares **no dependency at all**, on purpose: a correction whose target is absent
is a no-op. So the pass without the optional mods corrects exactly nothing and cannot prove a single value. It is not pointless:
it is the only pass that tests the promise the whole design rests on, that every correction with no target loads, applies and
logs nothing.

| Pass | Request | What it stages | What it proves |
|---|---|---|---|
| **sans-facultatifs** | `-Filter '01-alone'`, no `-DepMap` | Core, the DLCs, Harmony, RimLogging, Pickle, this mod | The shipped corrections, all without a target, load and say nothing: `success: Always` observed in a real game rather than in a fixture |
| **sources** | `-Filter '02-with-sources' -DepMap wsl-deps.sources.map` | the above plus Alpha Books, Additional Tools, Ancient Amulets | Every value assertion, both patch branches, the inherited-value case no headless test can reach, and the load order the game settled on |

A pass is one request; the two are separate requests (`Submit-PickleRun.ps1`, see `Tests/Pickle/README.md`).
`01-alone.feature` asserts the targets are **absent**, so it must not run in the sources pass; `02-with-sources.feature` names
defs that only exist there, so it must not run in the bare pass. Hence the filters.

**Not covered, and said so.** The sources pass stages **3 of the source mods this mod lists in `loadAfter`**; the others are not
mounted in any Pickle pass. `AUDIT.md` defines the pass "with the optional mods" as everything the mod declares in `loadAfter`,
so this is a gap against the letter of it, decided by the mod's design (the modlist is gated by tech level and a source mod comes
back only when the playthrough reaches its level). The unit tests cover the others: against their real defs for those installed,
against synthetic fixtures for the rest. Whether the source mods can all coexist has **not been measured**, and nothing here
implies they can. If an incompatibility is ever found, it gets its own named map beside `wsl-deps.sources.map` and its own row above.

**Incompatibilities and languages.** The mod declares no `incompatibleWith`, so no pass exists to look at one. It adds no player-facing
text, so there is nothing to display in French and English and no `-Language` pass.

### What has run

Every run is one line in `docs/runs/history.md`. **None of them is on the current revision:** the suite last ran on the tree of
`a37ff89` (31 patch files) and `Mod/` now holds more. The latest reports still worth holding are in `Tests/Pickle/Evidence/`
(ignored by git). A report is kept only while it proves something about the revision now in the repository.

### What `tested` still needs

Both requests above, played on a **frozen** tree (a request carries no SHA: the mod is staged when its ticket is played, so no
commit may land until the `RUN_DONE`), with `exitReason`, the discovered-against-played count and the suite name read before the
figures. Then their verdict goes in `docs/runs/history.md` and `STATUS.md`. Nothing else is left: no `@wip`, no `@requires`, no
`@review` capture, no manual scenario.

## Reading the log

- Development mode on, so a bad patch shows up as a red `XML error` line instead of silently doing nothing.
- The log: `C:\Users\nelim\AppData\LocalLow\Ludeon Studios\RimWorld by Ludeon Studios\Player.log`.
- To read a def's live `techLevel` by hand: Dev Mode's magnifying-glass **Inspect** tool, click the thing, expand `def`, read
  `techLevel`. It is the value after every patch has run, which is what this mod is responsible for.
- Watch for a `PatchOperationAdd` that fires against a field which already exists: it means an upstream mod added its own
  `techLevel` since the correction was arbitrated, and the cherrypick pass for that mod is due again.
- Whether a corrected item's new level visibly changes where it turns up (raid loot, trader stock, research gating) is a statistical
  effect, out of scope for a pass or fail here. The `techLevel` on the def is the correction this mod makes.
