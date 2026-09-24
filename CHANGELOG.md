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
- 3 tech-level corrections for `dot.atlas` (Archotech Duality): the aerogel resources `Atlas_Aerogel`
  and `Atlas_AntiAerogel` and the `Atlas_ChemicalDryer` that makes them (none -> Industrial: dried
  from stone and chemfuel, and a powered bench with industrial components). Its Spacer gear was
  already correct.
- 20 tech-level corrections for `ARIS.PSES` (Ari's Psychoid Essence And Sweets): its eight essences
  and five sweets were declared Neolithic but need the drug lab or the electric stove and the
  Industrial `PsychiteRefining` research, so they go to Industrial, as do the refined must and the
  five Psy-Essence pipe-network buildings (none -> Industrial). `Psychoidmust` (none -> Neolithic):
  a fermented must made at the brewery, which needs no power and only Neolithic `Brewing`.
- 1 tech-level correction for `Nationality.ArmorIsUncomfortable3` (Armor is Uncomfortable 3):
  `AIU3_TalcumPowder` (Medieval -> Neolithic). It is a stone chunk ground at a crafting spot, with
  no power and no components; the Medieval `ComplexClothing` research the author attached is
  thematic, not a requirement.
- 3 tech-level corrections for `khamenman.armorracks` (Armor Racks), all none -> a level: the armor
  rack (Medieval: wood or metal, `ComplexFurniture`), the mechanized rack (Industrial: power and
  industrial components) and the mending rack (Spacer: a `ComponentSpacer`). Cherrypick wrote
  each object twice, because the mod ships a `v1.1` folder duplicating its defs; the file was
  deduplicated by hand and says so in its header.

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
