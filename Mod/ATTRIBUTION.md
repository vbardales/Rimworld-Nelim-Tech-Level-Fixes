# Attributions

## Nothing copied

This mod contains no third-party code, text or art. Every file under `Mod/Patches/` is generated
by the author's own **cherrypick** tool, and contains only `PatchOperationConditional` operations
that set or replace a single def's `<techLevel>` value, addressed by `defName`. No asset, class,
description or other creative content from any corrected mod is reproduced here.

## Mods this one corrects

The 30 mods below are the *targets* of a correction, not a source this mod is derived from or
studied. Each is referenced only by its `packageId` and the `defName`s of the items it defines;
this mod does not ship, alter or redistribute any of their files.

- `AKN.Decorations`
- `Ali.CookingTable`
- `Ali.CraftingTable`
- `AmateurLLTechBox.AmatuerLLsToys.0001`
- `AR13S.AnimalCaps`
- `brrainz.zombieland`
- `cedaro.animalcommander`
- `Dipsy.Diapers`
- `hlx.UltratechAlteredCarbon`
- `IronSniper.WindowsSkylights`
- `LadyElizabeth.AdditionalToolsMod`
- `leafzxg.AlphaThrumboExtension`
- `Mlie.AdvancedRaiders`
- `moncho.AlcoholRehabSobrix`
- `Newton.AKN.CaretakerApparel`
- `overpl.AnimalSarcophagus`
- `Romyashi.AncientJunkLoot`
- `Romyashi.AncientRelics`
- `rye.animalrepeller`
- `sarg.alphabooks`
- `starter.beeer`
- `TurboPickle.GlitterCraft`
- `Udon.AnimalSimpleCommand`
- `Vanya.Outsource.BodyTypeExtend`
- `zal.alchemy`
- `zal.alternativepowersolutions`
- `zal.ancientamulets`
- `zal.angelarm`
- `zal.crystalbodyparts`
- `zal.easternarmory`

None of them is a dependency: this mod loads after all of them (see `loadAfter` in `About.xml`),
but a correction whose target item is missing simply does nothing.

## Generation

Every correction was arbitrated per item with the author's own cherrypick tool, not copied from
any external tech-level list or another mod's compatibility patch.
