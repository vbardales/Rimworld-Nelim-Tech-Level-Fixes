# The bare pass, strengthened form — 2026-09-21, 12:08

`Run-PickleWsl.ps1 -Mod TechLevelFixes -Filter '01-alone.feature'`, no `-DepMap`, headless under
WSL, after about 25 minutes in the shared queue. Feature file at `bf9d8d7`.

```
total      : 1      exitReason : passed
passed     : 1      setName    : sans-facultatifs
failed     : 0      durationMs : 604
```

**5 steps, 5 `PASSED`** in `messages.ndjson` — the morning's run played 2. That is the difference:

    Then mod "nelim.techlevelfixes" is loaded
    And no def "AMU_AmuletBarkeep" exists
    And no def "AMU_AmuletBarkeep" was patched
    And no warnings from mod "Nelim's Tech Level Fixes"
    And no errors were logged

## Checked before the numbers

- `exitReason: passed`, not `in-progress`.
- `SuiteScanner`: 2 features discovered, 1 scenario played — the filter keeping
  `02-with-sources.feature` out of a staging where its defs are absent by design.
- Same staging as the first bare pass: 11 mods, none of the thirty corrected. The log names
  neither Alpha Books, Ancient Amulets nor Additional Tools.
- 0 errors. Two warnings, both `[Vanilla]` and unattributed: Steam absent under WSL, and the
  companion test mod's dependency with no download URL (about the test mod, never published).
- The three new step forms were all defined: none reported as undefined. They came from the
  catalogue in AUDIT.md, not from Pickle's sources, which are not on this machine.

## What each new line actually contributes

- `no def ... exists` is the one that makes this the bare pass rather than an accident of
  staging, and the only one of the three that would fail if the target were present.
- `no def ... was patched` is trivially true for a def nobody knows (it checks attribution, not
  that the def exists). It adds nothing alone; it is the trio that is meaningful.
- `no warnings from mod` was written with the display name. It could not be shown to fail: this
  mod produced no attributed warning to catch, and no scenario here can assert that a step
  fails. Its worth is that the wrong form (packageId) would have been a false green, and was not
  used.

## Still not proved

No `techLevel` value: no def is staged to read. The `sources` pass holds every value assertion.
