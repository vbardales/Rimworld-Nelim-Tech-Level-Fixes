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
- 1 tech-level correction to a base-game research project (`Ludeon.RimWorld`): `Stonecutting`
  (Medieval -> Neolithic). Written by hand, in the same shape as the generated files, because
  cherrypick does not handle research projects.
- 8 tech-level corrections for `Mlie.Aquarium` (Aquarium (Continued)), chosen for realism rather
  than to follow the author's research chain: `AQCollagen`, `AQGelatin` and `AQFishFood` (none ->
  Neolithic: a butcher spot and a fueled stove, no research in vanilla), `AQFishBowl` (none ->
  Medieval: it costs a worked glass bowl), and the four fish tanks `AQFishTank`,
  `AQFishTankWide`, `AQFishTankLong`, `AQFishTankLarge` (none -> Industrial: power, industrial
  components, glass panels).

### Changed

- `Romyashi.AncientJunkLoot` (Ancient Junk Loot): its six corrections now set `Animal` instead of
  `Industrial` (five) and `Spacer` (one). They are relics left by the Ancients, so they can turn up
  from the very start of a game. The file was edited by hand and says so in its header.

## [1.0.0] — 2026-09-17

First version. RimWorld 1.6.

### Added

- 163 tech-level corrections across 29 source mods, one generated patch file per mod under
  `Mod/Patches/`, each arbitrated item by item with the cherrypick tool.
- Loads after every corrected mod (`loadAfter` in `About.xml`); none is a hard dependency, and a
  correction whose target item is missing does nothing.
