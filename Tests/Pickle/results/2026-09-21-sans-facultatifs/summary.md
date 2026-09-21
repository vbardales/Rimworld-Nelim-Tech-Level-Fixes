# The bare pass — sans-facultatifs, 2026-09-21

`Run-PickleWsl.ps1 -Mod TechLevelFixes -Filter '01-alone.feature'`, no `-DepMap`, headless under
WSL, queued behind six other sessions and run at 11:33 (09:33 UTC in the game's own log).

```
total      : 1      exitReason : passed
passed     : 1      setName    : sans-facultatifs
failed     : 0
```

## What was staged, which is the whole point

11 mods, and **not one of the thirty this mod corrects**:

    brrainz.harmony, ludeon.rimworld + the five DLCs, rimworks.rimlogging, rimworks.pickle,
    nelim.techlevelfixes, nelim.techlevelfixes.pickletests

So all 166 corrections ran against a game holding none of their targets. That is what the pass
exists to exercise: every operation is a `PatchOperationConditional` reporting `success: Always`,
and the claim is that such an operation does nothing and says nothing. `Tests/Run.ps1` proves the
XML half of it — the document comes back byte-identical. Only a loaded game proves the silence.

## The checks AUDIT.md asks for, before the numbers

- **`exitReason: passed`**, not `in-progress`. A run killed in flight leaves a report that reads
  like a result; this one went to the end.
- **Scenarios played against features discovered**: `SuiteScanner` found **2 features** in this
  suite, `01-alone.feature` and `02-with-sources.feature`, and **1 scenario ran**. That gap is the
  filter doing its job, not the silent truncation `-pickle-include-wip` once produced: with no
  source mod staged, `02-with-sources.feature` would fail on defs that are absent by design, which
  would be a missing mod rather than a broken correction.
- **0 errors** in the whole log.

## Two warnings, both unattributed, neither from this mod

    [WARN] [Vanilla] SteamAPI.Init() failed. …
    [WARN] [Vanilla] Mod TechLevelFixes - Pickle tests dependency (nelim.techlevelfixes) needs to
                     have <downloadUrl> and/or <steamWorkshopUrl> specified.

The first is WSL with no Steam client, expected everywhere here. The second is real, and it is
about the **companion test mod**, not the shipped one: its `About.xml` declares
`nelim.techlevelfixes` in `modDependencies` without a URL, because that mod is a sibling folder
and never downloaded. The companion is development-only and never published, so nothing reaches a
user this way — but the shipped mod's own silence is what this pass claims, and this warning is
not it.

Both are `[Vanilla]` with no attribution, so `LogEntry.Mod` is null for them and they are not
"from" this mod in the sense the `no warnings from mod` step uses.

## What this does not prove

Not one `techLevel` value. With no source mod staged there is no def to read; every value
assertion lives in the `sources` pass. And the scenario as played was still the weak form — `mod
is loaded` plus `no errors were logged` — which a mod doing nothing at all would also pass. The
strengthened form, asserting that the target is absent and that nothing patched it, was drafted
during the wait and deliberately not applied while the ticket was queued.

## Oddity, recorded rather than smoothed over

The launcher printed `le jeu est sorti en` with no exit code, then kept the report because it was
complete. The Linux game's exit status did not reach the script. The report itself is coherent —
`exitReason: passed`, one scenario, two steps, both `PASSED` in `messages.ndjson` — so the result
stands, but the empty status is not explained here.

`Player.log` is not beside these files: the next session's run archived it, with the rest of that
report, to `pickle-reports-archive/0921-1133/`.
