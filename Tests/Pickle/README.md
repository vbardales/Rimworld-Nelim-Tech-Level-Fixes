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

## Two passes, not one

`AUDIT.md` asks every mod for a pass **without** its optional mods and one **with**. See
`../../TESTING.md`, "How many passes", for the table and for what each can prove. In short:

```powershell
powershell.exe -ExecutionPolicy Bypass -File scripts/Run-PickleWsl.ps1 -Mod TechLevelFixes
powershell.exe -ExecutionPolicy Bypass -File scripts/Run-PickleWsl.ps1 -Mod TechLevelFixes -DepMap wsl-deps.sources.map
```

Either pass can be narrowed with `-Filter`, a comma-separated list of terms; a scenario runs as
soon as one term takes it, matched as a case-insensitive substring. `01-alone.feature` runs every
scenario of that file, `::no target` every scenario whose name contains that in any file,
`01-alone.feature:16` the one declared on that line. A filter matching nothing is an **error**,
exit 2 — never a quietly empty pass.

The first stages no corrected mod at all, so it proves only that 166 targetless corrections load
and say nothing — which is exactly the promise `success: Always` makes. The second is where every
value assertion lives. The map is named `wsl-deps.sources.map` rather than `wsl-deps.map`
precisely so the first pass exists: the staging reads the unnamed file on every pass.

## What is left, and why it needs the game

| Scenario | Why a unit test cannot say it |
|---|---|
| the mod is loaded and says nothing | whether the game loaded this mod at all, and whether it logged anything doing so |
| it loads after the mods it corrects | `loadAfter` is a request; only the running game shows the order it settled on |
| a def that had no level anywhere gets one | the combined document holds every active mod's patches, not just this one's; if a third mod writes the same field later, only a real load shows it |
| a def that declared its own level has it replaced | same, for the other branch |
| **an inherited level is overridden, not merely shadowed** | the one the unit tests structurally cannot reach. These amulets inherit `Medieval` from `AmuletBase` and declare nothing, so the patch *adds* a node beside an inherited value. Which of the two the loaded def reports is decided when the game resolves `ParentName` — **after** patching. A headless test sees the node appear; only the game says it won. |

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

The scenarios name defs from Alpha Books, Ancient Amulets and Additional Tools, so those three
mods have to be in the modlist for the run to mean anything. All three were installed on
2026-09-20; the file previously named Glitter-Craft and Alchemy, which have since been removed,
and would have failed for that reason alone. A scenario whose mod is absent fails on the def,
which is the run missing a mod rather than a broken correction.

## Run

- **In game**: dev mode on, debug actions menu, *Pickle*. Tick this suite, *Run selected*.
- **Unattended**: `RimWorldWin64.exe "-pickle-run=Nelim's Tech Level Fixes - Pickle tests"`. The
  filter is the companion mod's name, exactly; without it Pickle also runs its own sample
  features.

Never start a second RimWorld: one machine, one game, one runner. Take
`%LOCALAPPDATA%\rimworld-pickle-run.lock` before any launch or driven run, and move the previous
report out of `PickleReports` first — a run overwrites it, captures included. `Run-Pickle.ps1` in
ArchitectStudio is the reference script for both.

Since 2026-09-21 that lock is no longer a Pickle lock. What it protects is the **WSL machine being
busy**, not a game starting: a build, a `steamcmd`, a long copy into `~/rimworld` disturbs a run or
is disturbed by one. Any WSL work goes through `scripts/Use-Wsl.ps1` in the rimworld folder, same
queue and same journal:

```powershell
powershell.exe -ExecutionPolicy Bypass -File scripts/Use-Wsl.ps1 -Reason 'what you are doing' -Command 'the bash command'
```

`powershell.exe`, never `pwsh`: PowerShell 7 is not installed on this machine. The owner's own
reservation comes before anything a session wants.

## Status

Executed 2026-09-21, headless under WSL: **5 of 5**. The report is kept as
`results/2026-09-21-summary.md`, because the shared `pickle-reports/` directory is overwritten by
the next run. The run before it, 2026-09-20, was 4 of 5: one scenario named a def whose defName
belongs to two def types, which Pickle's `field` step refuses to guess between.

An audit session still never starts the game itself. That run happened with the machine reserved
by its owner and the run lock held.
