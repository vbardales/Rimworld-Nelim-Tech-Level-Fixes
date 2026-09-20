# In-game scenarios, run by Pickle

A short suite, run inside a running RimWorld by
[Pickle](https://github.com/RimWorks/Rimworld-Pickle) (`rimworks.pickle`, Workshop 3791648678).

**Read `Tests/Run.ps1` first.** The unit tests apply these same patch operations headless, over
all 166 corrections, in well under a minute. A Pickle run takes over the machine — real pointer,
real clicks, screen occupied — and takes far longer, so nothing lives here that can be proved
outside the game. That rule cost this suite its bulk: a generated feature asserting all 166
corrections was written on 2026-09-20 and deleted the same day, because the unit tests prove
exactly that and a scenario which restates one confiscates the machine for nothing.

`Mod/` is a companion mod, **Nelim's Tech Level Fixes - Pickle tests**, never published. It holds
the feature file, so nothing test-related ships in the Workshop folder.

## What is left, and why it needs the game

| Scenario | Why a unit test cannot say it |
|---|---|
| the mod is loaded and says nothing | whether the game loaded this mod at all, and whether it logged anything doing so |
| it loads after the mods it corrects | `loadAfter` is a request; only the running game shows the order it settled on |
| a correction survives the whole modlist (add, replace, research) | the unit tests apply **this mod's** patches to **one source mod's** defs in isolation. A game applies every active mod's patches to one combined document. If a third mod sets the same field later, only this shows it. |

Five scenarios, a handful of defs. Spot checks on the real pipeline, not a second inventory.

## No step assembly

This suite compiles nothing. Every step it uses is built into Pickle — `mod "X" is loaded`,
`mod "X" loads after "Y"`, `def "X" field "techLevel" is "Y"`, `no errors were logged` — which is
why a mod with no C# of its own can still have one. The `field` step reads a dotted path off the
live def, so it reports the value the game ended up with.

## Setup, once

1. Subscribe to Pickle, and enable it.
2. Link the companion mod into RimWorld's `Mods` folder. A junction needs no elevation:

   ```powershell
   New-Item -ItemType Junction -Path "C:\Program Files (x86)\Steam\steamapps\common\RimWorld\Mods\TechLevelFixesPickleTests" -Target "<repo>\Tests\Pickle\Mod"
   ```

3. Enable it below Nelim's Tech Level Fixes and Pickle.

The scenarios name defs from Alpha Books, Ancient Amulets, Glitter-Craft and Alchemy, so those
four mods have to be in the modlist for the run to mean anything. A scenario whose mod is absent
fails on the def, which is the run missing a mod rather than a broken correction.

## Run

- **In game**: dev mode on, debug actions menu, *Pickle*. Tick this suite, *Run selected*.
- **Unattended**: `RimWorldWin64.exe "-pickle-run=Nelim's Tech Level Fixes - Pickle tests"`. The
  filter is the companion mod's name, exactly; without it Pickle also runs its own sample
  features.

Never start a second RimWorld: one machine, one game, one runner. Take
`%LOCALAPPDATA%\rimworld-pickle-run.lock` before any launch or driven run, and move the previous
report out of `PickleReports` first — a run overwrites it, captures included. `Run-Pickle.ps1` in
ArchitectStudio is the reference script for both.

## Status

Never executed. Running it needs a RimWorld that the audit sessions must not start.
