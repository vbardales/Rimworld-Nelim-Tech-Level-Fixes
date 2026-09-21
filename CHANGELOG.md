# Changelog

Format inspired by [Keep a Changelog](https://keepachangelog.com/en/1.1.0/).
This file serves the repository and the writing of Steam patch notes; RimWorld does not display it in game.

## [Unreleased]

### Added

- Repository documentation: README, ATTRIBUTION, LICENSE (MIT), this changelog.
- 3 tech-level corrections for `brrainz.zombieland` (Zombieland): `Thumper` (none -> Medieval,
  matching its `Smithing` research prerequisite), `ZombieSerumSimple` (Neolithic -> Industrial,
  aligning it with its ten `ZombieSerumCore`-derived siblings), `ZombieShocker` (none ->
  Industrial, matching its `Electricity` research prerequisite and `ComponentIndustrial` cost).
- 2 tech-level corrections to base-game research projects (`Ludeon.RimWorld`): `Stonecutting`
  (Medieval -> Neolithic) and `Prosthetics` (Industrial -> Medieval). Written by hand, in the same
  shape as the generated files, because cherrypick does not handle research projects.

## [1.0.0] — 2026-09-17

First version. RimWorld 1.6.

### Added

- 163 tech-level corrections across 29 source mods, one generated patch file per mod under
  `Mod/Patches/`, each arbitrated item by item with the cherrypick tool.
- Loads after every corrected mod (`loadAfter` in `About.xml`); none is a hard dependency, and a
  correction whose target item is missing does nothing.
