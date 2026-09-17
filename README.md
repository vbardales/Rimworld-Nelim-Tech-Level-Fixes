# Nelim's Tech Level Fixes

A RimWorld 1.6 mod that rewrites the tech level of items from other mods, one correction at a
time, arbitrated for each item with the **cherrypick** tool.

RimWorld uses `techLevel` to gate raid loot, trade stock, quest rewards and research-adjacent
content by era. Many mods leave it at its default, or pick a level that does not match the item's
actual place in the tech tree, which quietly puts things where they should not appear. This mod
corrects that, item by item, without touching the mods it corrects.

## How it works

Every file under `Mod/Patches/` is **generated**, one per source mod, named after that mod's
`packageId`. Each file is a small set of `PatchOperationConditional` operations that set or
replace a single def's `<techLevel>`. Deleting a file undoes that mod's corrections; deleting the
whole folder undoes everything. Do not hand-edit a generated file: the next cherrypick pass over
its source mod rewrites it in full.

The mod loads after every mod it corrects, declared in `About.xml`'s `loadAfter`, so their own
patches have already run. None of them is a dependency: a correction whose target item is missing
simply does nothing.

## Mods corrected in this release

29 source mods, one file each under `Mod/Patches/`:

`AKN.Decorations`, `Ali.CookingTable`, `Ali.CraftingTable`, `AmateurLLTechBox.AmatuerLLsToys.0001`,
`AR13S.AnimalCaps`, `cedaro.animalcommander`, `Dipsy.Diapers`, `hlx.UltratechAlteredCarbon`,
`IronSniper.WindowsSkylights`, `LadyElizabeth.AdditionalToolsMod`, `leafzxg.AlphaThrumboExtension`,
`Mlie.AdvancedRaiders`, `moncho.AlcoholRehabSobrix`, `Newton.AKN.CaretakerApparel`,
`overpl.AnimalSarcophagus`, `Romyashi.AncientJunkLoot`, `Romyashi.AncientRelics`,
`rye.animalrepeller`, `sarg.alphabooks`, `starter.beeer`, `TurboPickle.GlitterCraft`,
`Udon.AnimalSimpleCommand`, `Vanya.Outsource.BodyTypeExtend`, `zal.alchemy`,
`zal.alternativepowersolutions`, `zal.ancientamulets`, `zal.angelarm`, `zal.crystalbodyparts`,
`zal.easternarmory`.

See [ATTRIBUTION.md](ATTRIBUTION.md) for how these mods relate to this one.

## Layout

Only `Mod/` is published. RimWorld's uploader hands Steam the mod directory as-is
(`SteamUGC.SetItemContent` on `ModMetaData.RootDir`, with no filtering whatsoever), so anything
sitting in that folder is downloaded by every subscriber.

```
Mod/              <- the published mod
  About/            metadata
  Patches/          one generated file per corrected mod, named after its packageId
  LICENSE           MIT requires the notice to travel with the distribution
```

There is no `Source/`: this mod ships no assembly, only data-driven XML patches.

## Licence

MIT — see [LICENSE](LICENSE). This mod's patches are original: they only reference other mods'
`defName`s to set a `techLevel` value. No third-party code, text or art is included; see
[ATTRIBUTION.md](ATTRIBUTION.md).
