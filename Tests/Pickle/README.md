# In-game scenarios, run by Pickle

The corrections of this mod, checked inside a running RimWorld by
[Pickle](https://github.com/RimWorks/Rimworld-Pickle) (`rimworks.pickle`, Workshop 3791648678).

`Mod/` is a companion mod, **Nelim's Tech Level Fixes - Pickle tests**, never published. It holds
the feature files, so nothing test-related ships in the Workshop folder.

## No step assembly

Unlike the other mods in this repository, this suite compiles nothing. Every assertion it makes
is a built-in Pickle step:

| Step | What it settles here |
|---|---|
| `mod "X" is loaded` | the corrected mod is in this run at all |
| `mod "nelim.techlevelfixes" loads after "X"` | the `loadAfter` declaration took effect, so the correction ran last |
| `def "X" field "techLevel" is "Y"` | the def carries the arbitrated value **after every patch has run** |

That last one is the whole mod in one line. `field` reads a dotted path off the live def, so it
reports the value the game ended up with, not the value the XML asked for. A correction that
silently matched nothing fails here and nowhere else: the outer `PatchOperationConditional` of
every generated patch reports `Always`, on purpose, so a missing target never raises an error.

## The feature files

- `01-loading.feature`, written by hand: the mod is loaded, nothing in the log.
- `02-corrections.feature`, **generated** by `Tests/Pickle/Build-Features.ps1` from
  `Mod/Patches/`: one scenario per corrected mod, 166 assertions over 30 mods. Rerun that script
  after any cherrypick pass and commit the result; editing it by hand puts it out of step with
  the patches it is supposed to check.

## Setup, once

1. Subscribe to Pickle, and enable it.
2. Link the companion mod into RimWorld's `Mods` folder. A junction needs no elevation:

   ```powershell
   New-Item -ItemType Junction -Path "C:\Program Files (x86)\Steam\steamapps\common\RimWorld\Mods\TechLevelFixesPickleTests" -Target "<repo>\Tests\Pickle\Mod"
   ```

3. Enable it below Nelim's Tech Level Fixes and Pickle.

Pickle patches the game through Concord when Concord is loaded, and through Harmony otherwise. If
Concord fails to start, clicking steps break - this suite has none, so it is unaffected either way.

## Which mods have to be enabled

Every scenario in `02-corrections.feature` needs its own corrected mod in the modlist. A scenario
whose mod is absent fails on its first step, `mod "X" is loaded`, naming it. **That is the run
missing a mod, not a broken correction**, and the whole reason the scenario opens with that line
rather than going straight to a def that was never going to exist.

A fully green run therefore means all 30 corrected mods enabled at once. On 2026-09-20 only 8 of
them were installed on the development machine, so a run today would show 22 scenarios red for
that reason alone.

## Run

- **In game**: dev mode on, debug actions menu, *Pickle*. Tick this suite, *Run selected*.
- **Unattended**: `RimWorldWin64.exe "-pickle-run=Nelim's Tech Level Fixes - Pickle tests"`. The
  filter is the companion mod's name, exactly; without it Pickle also runs its own sample
  features. Reports land in `PickleReports` beside the saves.

Never start a second RimWorld: one machine, one game, one runner. Take
`%LOCALAPPDATA%\rimworld-pickle-run.lock` before any launch or driven run; `Run-Pickle.ps1` in
ArchitectStudio is the reference script.

## What this suite does not cover

- Uninstalling one correction or all of them (TESTING.md 5 and 6) and adding or removing the mod
  from a save (TESTING.md 8): all three change the modlist or the files on disk, which a scenario
  inside the running game cannot do to itself.
- Whether a corrected tech level changes what actually turns up in raid loot or trader stock.
  That is statistical, not a pass or fail.
- Publication screenshots. This mod draws no window of its own, so there is nothing of its own to
  capture; what a Workshop page should show for an invisible data mod is an open question.
