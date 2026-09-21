# Nelim's Tech Level Fixes — in-game test scenarios

Not shipped: it lives beside `Mod/`, never inside it, so Steam never receives it.

This mod ships no assembly (see STATUS.md's `settings_audit`/`localization` notes: there
is no C# anywhere in the tree). Every scenario below has been **written**, none has been
**run**. `STATUS.md`'s `remaining` list tracks that distinction; do not read this file as
a report of things observed.

**Scenarios 1 to 4 and 7 are covered first by the unit tests**, `Tests/Run.ps1`: they run
RimWorld’s own patch operations over the shipped XML with no game running, cover all 166
corrections rather than the handful spot-checked by hand below, and finish in well under a
minute. Run those on every change.

The same five are also written as Pickle scenarios in `Tests/Pickle/`, which asserts them
against the live defs inside a running game. That is the stronger evidence but the expensive
one: a Pickle run takes over the machine and takes minutes, so it is for confirming a release,
not for iterating. It ran on 2026-09-21, 5 of 5 — but in the "sources" pass only; see
**How many passes** below.

Scenarios 5, 6 and 8 stay manual: they change the modlist or the files on disk, which neither
a unit test nor a scenario running inside the game can do to itself.

## How many passes, and what each covers

`AUDIT.md` since 2026-09-21: a mod is validated over **at least two passes**, one **without** the
optional mods and one **with**, and the report has to say which is which. A green on one says
nothing about the other.

This mod is an awkward case for that rule, and worth stating plainly rather than tidily. It
declares **no dependency at all**, on purpose: a correction whose target is absent is a no-op. So
the pass without the optional mods corrects exactly nothing. It cannot prove a single value.

That does not make it pointless — it makes it the only pass that can test the promise the whole
design rests on.

| Pass | `-DepsMap` | What it stages | What it can prove |
|---|---|---|---|
| **sans-facultatifs** | *(none)* | Core, DLCs, Harmony, RimLogging, Pickle, this mod | That 166 corrections with no target load, apply and log **nothing**. That is `success: Always` observed in a real game rather than in a fixture. |
| **sources** | `wsl-deps.sources.map` | the above, plus Alpha Books, Additional Tools, Ancient Amulets | Every value assertion, and the load order the game settled on. Both patch branches, and the inherited-value case no headless test can reach. |

Two feature files match the split: `01-alone.feature` runs in both, `02-with-sources.feature`
only in the second, where its defs exist.

**The name of the default map mattered.** Until 2026-09-21 this suite's map was called
`wsl-deps.map`, which the staging script reads on *every* pass. With that name there is no bare
pass to be had: the three source mods are staged whether or not anyone asked. It is now
`wsl-deps.sources.map`, and selected by name.

### What has actually run

- **sources**: 2026-09-21, 5 of 5. Recorded in `Tests/Pickle/results/2026-09-21-summary.md`. It
  was run before this rule existed and was not called a pass of anything; naming it afterwards
  describes what it staged, it does not add evidence.
- **sans-facultatifs**: never run.

### On mutually exclusive optional mods

The rule asks for one pass per exclusive combination. For this mod the honest answer is that
**nobody has measured whether the 30 corrected mods can all coexist**, and nothing here should
imply they can. Three of them are staged; 23 are not even installed. What is known is that the
modlist is gated by tech level and moves over time, so the 30 may well never be loaded together on
this machine by design. If an incompatibility is ever found, it gets its own named map beside
`wsl-deps.sources.map`, and its own row in the table above.

## Before starting

- RimWorld 1.6, `TechLevelFixes` active, alongside as many of the 30 corrected mods
  as practical for the session. Scenarios below name specific ones; the full list is
  in `README.md` and `ATTRIBUTION.md`.
- Development mode on, so a bad patch shows up as a red `XML error` line instead of
  silently doing nothing.
- The log to read afterwards, and to attach to any report:
  `C:\Users\nelim\AppData\LocalLow\Ludeon Studios\RimWorld by Ludeon Studios\Player.log`
- To read a spawned thing's actual `techLevel` in game: Dev Mode's magnifying-glass
  **Inspect** tool, click the thing, expand `def` in the field tree that opens, and
  read `techLevel` there. This reads the live def value, after every patch has run —
  the value this mod is responsible for.
- 166 corrections total across 30 patch files, from 1 (ten mods) to 36
  (`zal.ancientamulets.xml`). `README.md` lists the full 30; the scenarios below use
  a representative slice, not all of them. `brrainz.zombieland.xml` (added
  2026-09-17, 3 corrections) follows the exact same shape as everything else here
  and needs no scenario of its own.

## 1. It loads, and nothing complains

1. Start or load a colony with `TechLevelFixes` and every one of the 30 corrected
   mods active.

**Pass:** no red line naming `nelim.techlevelfixes`, no `PatchOperation ... failed`,
no `Could not resolve cross-reference` pointing at any of the 166 corrected
`defName`s.

**Fail:** any such line. Note which file's `defName` it names — the comment at the
top of that `Mod/Patches/<packageId>.xml` names the exact source mod to check first,
since a failure here almost always means that mod's own `defName`s moved.

## 2. A correction actually lands — replace branch

Pick a def the source mod already gave a `techLevel`, so the patch takes its
`PatchOperationReplace` branch.

1. With `TurboPickle.GlitterCraft` (All That Glitters: Glitter-Craft) active, spawn
   `GlitterCraft_BrawlerArmor` in dev mode and inspect it (see **Before starting**).

**Pass:** `techLevel` reads `Spacer`. The source mod shipped it as `Ultra`; the patch
comment records exactly this replacement.

2. Repeat with `GlitterCraft_Saber` and `GlitterCraft_ReconHelmet` (also `Ultra` ->
   `Spacer`), and with `AlchemyAlchemy` from `zal.alchemy` (Alchemy (Continued)) — a
   **research project**, not a `ThingDef`: open the research tree instead of
   spawning an item.

**Pass:** all read `Spacer` / `Medieval` respectively, matching the comment in each
patch file, not the source mod's own value.

## 3. A correction actually lands — add branch

Pick a def the source mod left with no `techLevel` at all, so the patch takes its
`PatchOperationAdd` branch instead.

1. With `sarg.alphabooks` (Alpha Books) active, spawn `ABooks_AdventuringLogs` and
   inspect it.

**Pass:** `techLevel` reads `Medieval` — added by this mod, not overwritten, since
the source def had none.

2. Repeat with `ABooks_ArmyManual` (-> `Industrial`) and, with
   `zal.ancientamulets` (Ancient Amulets (Continued)) active, `AMU_AmuletBarkeep`
   and `AMU_AmuletBlacksmith` (both -> `Neolithic`).

**Pass:** all four read their arbitrated value. This is the branch most likely to
silently fail if a future upstream release adds its own `techLevel`: watch the log
for `PatchOperationAdd` warnings about a field that already exists.

## 4. A missing source mod does nothing, quietly

The description promises this explicitly: "a correction whose item is missing does
nothing."

1. Disable one corrected mod that is otherwise active for the session — `sarg.alphabooks`
   is a convenient pick, 23 corrections — while keeping `TechLevelFixes` active.
2. Load a colony and watch the log.

**Pass:** no error, no warning naming `ABooks_*` or `sarg.alphabooks`. The outer
`PatchOperationConditional` in that file always reports `success`, so its absence
must not appear as a patch failure, only as an absent target.

3. Re-enable it and confirm scenario 3's items are corrected again on the next load.

## 5. Uninstalling one correction: delete its file

1. With the mod active and `zal.alchemy` (Alchemy (Continued)) also active, delete
   `Mod/Patches/zal.alchemy.xml` from the installed copy (not the repository) and
   reload the mod list.
2. Inspect `AlchemyBench` and the `AlchemyAlchemy` research project.

**Pass:** both are back to whatever `zal.alchemy` itself ships — `AlchemyBench`
likely has no `techLevel` at all again, `AlchemyAlchemy` back to `Industrial`. No
error from the missing file; `LoadFolders`/`About.xml` do not name individual patch
files.
3. Restore the file afterwards and confirm scenario 2 passes again.

## 6. Uninstalling everything: delete the folder

1. Delete the entire `Mod/Patches/` folder from the installed copy and reload.

**Pass:** no error (the folder is optional content, not a declared dependency of
anything). Every one of the 166 corrections reverts to its source mod's own value.
Restore the folder afterwards.

## 7. Load order: this mod's value wins

`TechLevelFixes` declares every corrected mod in `loadAfter`, so its patches run
last among them.

1. Pick a mod likely to be patched by something else already in the load order —
   `Mlie.AdvancedRaiders` is maintained and commonly patched by compatibility mods —
   and check its position in the mod list relative to `TechLevelFixes`.

**Pass:** `TechLevelFixes` sorts after it. If a third mod also patches the same
`defName`'s `techLevel` and loads after `TechLevelFixes`, that third mod's value
would win instead — not a defect in this mod, but worth knowing about before
reporting a "wrong" tech level.

## 8. Save, reload, add, remove

`techLevel` lives on the def, not on any saved instance, so it should never drift
across a save/load cycle on its own.

1. Start a colony with several corrected items already present (spawn a handful
   from scenarios 2 and 3), save, and reload.

**Pass:** no red line, and every inspected item still reads its corrected value —
nothing about the correction is only applied once at spawn time.

2. Add `TechLevelFixes` to a save that already has corrected mods' items placed,
   without it.

**Pass:** those items' `techLevel` updates immediately on load, with no other
change — no new def, no missing-content warning, since this mod adds nothing that
did not already exist.

3. Remove `TechLevelFixes` from a save that had it.

**Pass:** the items revert to their source mods' own `techLevel` values. No
missing-content warning for `TechLevelFixes` itself is expected only if nothing in
the save referenced a def unique to it — it has none, so this should be silent.

## What to watch across every scenario

- The exact wording of any red XML error, and which of the 30 patch files' comment
  block names the source mod it points at.
- Whether a `PatchOperationAdd` ever fires against a field that already exists
  (scenario 3) — the sign that an upstream mod added its own `techLevel` since the
  correction was arbitrated, which would make the cherrypick pass due for a rerun.
- Whether any corrected item's new `techLevel` visibly changes where it turns up —
  raid loot, trader stock, research-adjacent gating. This is a statistical effect,
  not a one-shot check, and is out of scope for a pass/fail scenario here; the
  `techLevel` field inspection in each scenario above is the actual, defined
  correction this mod makes.
