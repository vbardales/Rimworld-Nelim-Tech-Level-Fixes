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
- 3 tech-level corrections to research projects of other mods, all Medieval -> Neolithic, written
  by hand (realism first, even where a prerequisite is more advanced): `AQFishPets` and
  `AQGelatin` in `Mlie.Aquarium` (fish keeping and gelatine need no smithing), and
  `SWB_BuildShallowWater` in `SC.waterplace` (Artificial Water Place, new file: drawing water with
  a bucket). A cherrypick pass over Aquarium would rewrite its file and lose the two.
- 3 tech-level corrections for `kaitorisenkou.BallGames` (BallGames), all none -> a level, chosen by
  what the item needs rather than by the `ComplexFurniture` research the author attached: the
  soccer goal and the basketball goal (Neolithic: cloth and a wood or stone frame, no power) and
  the volleyball net (Medieval: it costs 50 steel).
- 4 tech-level corrections for `SK.BandageWrap` (Bandage Wraps (Continued)), chosen by what each
  item needs (they had no level of their own, so they read as Medieval): the plain body wrap and
  head bandage (Neolithic: strips of cloth, made even at a crafting spot, no research) and their
  aseptic versions (Industrial: each takes a `MedicineIndustrial`).
- 2 tech-level corrections for `Mlie.BasicMirrors` (Basic Mirrors (Continued)), both none ->
  Medieval, as cherrypick proposed: the mirror and the wall mirror, each 40 silver (a polished
  metal, so the metal age) and no power.
- 1 tech-level correction for `DrAke.BatmanUtilityBelt` (Batman Utility Belt): the belt (none ->
  Spacer, as cherrypick proposed). 60 plasteel and 2 `ComponentSpacer` at a fabrication bench,
  behind a Spacer research.
- 2 tech-level corrections for `soap.BattleMaid` (Battle Maid Dress), both Medieval -> Industrial,
  as cherrypick proposed: the two armoured dresses `battle_maid_A` and `battle_maid_d` (100 steel
  and 3 `ComponentIndustrial` at the machining table, behind the Industrial `FlakArmor` research).
  Read as Medieval before, since apparel inherits that level. The sabre was already correct.
- 4 tech-level corrections for `bean.security.pack` (Bean's Security Pack), all none -> Industrial,
  as cherrypick proposed: the Hesco wall, the chain-link fence, the razorwire and the kevlar. Real
  dates agree: chain-link 1844, barbed wire 1867, kevlar 1965, Hesco 1990. The pack's ten armours
  and guns were already Industrial and correct.
- 5 tech-level corrections for `Mlie.BeamMeUpScotty` (Beam me up Scotty (Continued)), all none -> a
  level, as cherrypick proposed: the teleport spot, box and catcher (Industrial: the box and the
  catcher need no power themselves, but do nothing without a powered spot) and the teleporter
  ministation and workstation (Spacer: power, uranium and industrial components behind the Spacer
  `LTF_Research_TpBench`). The bed was already Industrial.

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
