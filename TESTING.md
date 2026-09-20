# Nelim's Tech Level Fixes — in-game test scenarios

Not shipped: it lives beside `Mod/`, never inside it, so Steam never receives it.

This mod ships no assembly (see STATUS.md's `settings_audit`/`localization` notes: there
is no C# anywhere in the tree). Every scenario below has been **written**, none has been
**run**. `STATUS.md`'s `remaining` list tracks that distinction; do not read this file as
a report of things observed.

**Scenarios 1 to 4 and 7 are also played by Pickle**, in `Tests/Pickle/` — the same
checks, asserted inside the running game against the live defs, one scenario per corrected
mod. Prefer that suite for those five: it covers all 166 corrections instead of the handful
spot-checked by hand below, and it needs no manual inspection of a def's fields. It has not
been run either. Scenarios 5, 6 and 8 stay manual: they change the modlist or the files on
disk, which a scenario running inside the game cannot do to itself.

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
