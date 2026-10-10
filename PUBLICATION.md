# Publication sheet

**Drafted 2026-09-27; updated 2026-10-09: 1.0.0, 1.0.1 and 1.0.2 are uploaded (runs 37770622317, 37787677923 and 37789170249), the item is public, the stage is `published[1.0.2]`.** The Workshop item `3806765254` was created by the `0.1.0`
prepublication of 2026-09-23; `Mod/About/PublishedFileId.txt` is committed. Ahead: the next publication, which carries the new ModIcon and the regenerated Preview (`update_preview`).

Rules that apply, and where they are written: `PUBLISHING.md` and `AUDIT.md` (protocols repository, read versions in
`docs/PROTOCOLS-READ.md`), `Rimworld-Release-Admin/docs/OPERATIONS.md` for the CI, `WORKSHOP_COMMENTS.md` for the
thank-you register.

## Thank-you comments: none, decided by the owner 2026-09-27

Not for this mod. `WORKSHOP_COMMENTS.md`'s rule ("cela vaut même si... seulement déclarée en `loadAfter`") is written for
a mod that depends on, is inspired by, or integrates with what it names. This mod's relationship to its `loadAfter` entries is the opposite: it corrects a value on their items, with no code read or reused. No register entry,
no comment, for any of them. The Pickle/RimLogging dev-tool thanks in the description below stand as they are, since
those are actually used to test this mod.

## Steam description

Written from the current `About.xml`, with the sections `PUBLISHING.md` asks for after the body. Steam's limit is 8000
bytes; the description is trimmed to stay under it.

```markdown
Rewrites the tech level of items from other mods, and of a few base-game research projects, to the level chosen for
each one with the **cherrypick** tool.

RimWorld uses `techLevel` to gate raid loot, trade stock, quest rewards and research-adjacent content by era. Many mods
leave it at its default, or pick a level that does not match its actual place in the tech tree. This mod corrects
that, item by item, without touching the mods it corrects.

Every file under `Patches/` is generated: there is one per source mod, named after its `packageId`. Deleting a file undoes that
mod's corrections; deleting the whole folder undoes everything. It loads after every mod it corrects: none of them is a
dependency, and a correction whose target item is missing simply does nothing.

## Mods it corrects

- [Akeron - Decorations](https://steamcommunity.com/sharedfiles/filedetails/?id=2755025925) by Newton-Zephyr
- [Akeron - Caretaker Apparel](https://steamcommunity.com/sharedfiles/filedetails/?id=2799570243) by Newton-Zephyr
- [Alcohol Rehab - Sobrix](https://steamcommunity.com/sharedfiles/filedetails/?id=3342864295) by Moncho
- [Ali's Cooking Table](https://steamcommunity.com/sharedfiles/filedetails/?id=2554726284) and [Ali's Crafting Table](https://steamcommunity.com/sharedfiles/filedetails/?id=2554727801) by Ranger Ali
- [Alpha Books](https://steamcommunity.com/sharedfiles/filedetails/?id=3403180654) by Sarg Bjornson
- [Alpha Thrumbo Extension](https://steamcommunity.com/sharedfiles/filedetails/?id=3522618217) by leafzxg
- [Altered Carbon 2: ReSleeved](https://steamcommunity.com/sharedfiles/filedetails/?id=2196278117) by Helixien
- [AmateurLL's Toys](https://steamcommunity.com/sharedfiles/filedetails/?id=3523484895) by AmateurLL
- [Ancient Junk Loot](https://steamcommunity.com/sharedfiles/filedetails/?id=3023180229) and [Ancient Relics](https://steamcommunity.com/sharedfiles/filedetails/?id=2961505444) by Romyashi
- [Animal Commander](https://steamcommunity.com/sharedfiles/filedetails/?id=3420966134) by cedaro
- [Animal Diapers](https://steamcommunity.com/sharedfiles/filedetails/?id=2817510684) by Dipsy
- [Animal Repeller](https://steamcommunity.com/sharedfiles/filedetails/?id=3672487181) by Rye
- [Animal Sarcophagus](https://steamcommunity.com/sharedfiles/filedetails/?id=2876565401) by OverPL
- [Animal Simple Command](https://steamcommunity.com/sharedfiles/filedetails/?id=2581711499) by Udon
- [Ari's Psychoid Essence & Sweets](https://steamcommunity.com/sharedfiles/filedetails/?id=3553351533) by araikoskis
- [Armor is Uncomfortable 3](https://steamcommunity.com/sharedfiles/filedetails/?id=3536380924) by Nationality
- [Armor Racks](https://steamcommunity.com/sharedfiles/filedetails/?id=1875828205) by khamenman
- [Artificial Water Place](https://steamcommunity.com/sharedfiles/filedetails/?id=2382789361) by Si-Cafe
- [BallGames](https://steamcommunity.com/sharedfiles/filedetails/?id=2845856763) by kaitorisenkou
- [Batman Utility Belt](https://steamcommunity.com/sharedfiles/filedetails/?id=3629298626) by Drake
- [Battle Maid Dress](https://steamcommunity.com/sharedfiles/filedetails/?id=3624591057) by Soap
- [Bean's Security Pack](https://steamcommunity.com/sharedfiles/filedetails/?id=3740917483) by Bean
- [Beautiful Mech Node](https://steamcommunity.com/sharedfiles/filedetails/?id=2572197137) by Damian Pauaqq Pawlak
- [Better Cribs](https://steamcommunity.com/sharedfiles/filedetails/?id=2879002756) by Capi
- [BetterManger](https://steamcommunity.com/sharedfiles/filedetails/?id=2886437690) by Eiten
- [BetterStuffs](https://steamcommunity.com/sharedfiles/filedetails/?id=2176932921) by 1ow.com
- [Additional Tools Mod](https://steamcommunity.com/sharedfiles/filedetails/?id=1443002973) by Lady Elizabeth
- [27 Club](https://steamcommunity.com/sharedfiles/filedetails/?id=3806997445) by Avos
- [Zombieland](https://steamcommunity.com/sharedfiles/filedetails/?id=928376710) by Brrainz
- [All That Glitters: Glitter-Craft](https://steamcommunity.com/sharedfiles/filedetails/?id=3507135086) by TurboPickle
- Continued by Mlie: [Advanced Raiders](https://steamcommunity.com/sharedfiles/filedetails/?id=2894402265), original by saloid ([original](https://steamcommunity.com/sharedfiles/filedetails/?id=2628440891)); [Aquarium](https://steamcommunity.com/sharedfiles/filedetails/?id=3544186181), original by pelador ([original](https://steamcommunity.com/sharedfiles/filedetails/?id=2120551963)); [Basic Mirrors](https://steamcommunity.com/sharedfiles/filedetails/?id=2597543500), original by trublucaribou ([original](https://steamcommunity.com/sharedfiles/filedetails/?id=2230124203)); [Beam me up Scotty](https://steamcommunity.com/sharedfiles/filedetails/?id=3328183029), original by Gouda quiche ([original](https://steamcommunity.com/sharedfiles/filedetails/?id=1507132557))
- Continued by Zaljerem: [Alchemy](https://steamcommunity.com/sharedfiles/filedetails/?id=3132057783), original by jeonggihun, then Zoura3025; [Alternative Power Solutions](https://steamcommunity.com/sharedfiles/filedetails/?id=3798865548), original by OptimusPrimordial ([original](https://steamcommunity.com/sharedfiles/filedetails/?id=2589973108)); [Ancient Amulets](https://steamcommunity.com/sharedfiles/filedetails/?id=2955419294), original by cuproPanda; [Ancient Eastern Armory](https://steamcommunity.com/sharedfiles/filedetails/?id=3132059139), original by Gemi ningen ([original](https://steamcommunity.com/sharedfiles/filedetails/?id=2393395676)); [Angel Arm Revolver](https://steamcommunity.com/sharedfiles/filedetails/?id=2777764256), original by Honshitsu ([original](https://steamcommunity.com/sharedfiles/filedetails/?id=948130856)); [Crystal Bodyparts](https://steamcommunity.com/sharedfiles/filedetails/?id=2855968478), original by FantasyFan ([original](https://steamcommunity.com/sharedfiles/filedetails/?id=1941242146))
- [Animal Caps! 1.6 (Fork)](https://steamcommunity.com/sharedfiles/filedetails/?id=3535814912) and [Bandage Wraps 1.6 (Fork)](https://steamcommunity.com/sharedfiles/filedetails/?id=3535716415) by pookiemaru, the latter from [Bandage Wraps (Continued)](https://steamcommunity.com/sharedfiles/filedetails/?id=2576978480) by ShiningKakera
- [Archotech Duality](https://steamcommunity.com/sharedfiles/filedetails/?id=3747031051), [Alpine's Window Walls & Skylights](https://steamcommunity.com/sharedfiles/filedetails/?id=3798320864), [BEER (Advanced Brewery)](https://steamcommunity.com/sharedfiles/filedetails/?id=3792841220) and [[RF]Body Type Extend](https://steamcommunity.com/sharedfiles/filedetails/?id=1905332152) by RicoFox233

## IF I GO QUIET

If I do not answer within a reasonable time after being contacted, anyone may freely update this or any other of my
mods, including publishing a continuation of it. All credit must be preserved.

## AI-GENERATED

Written and tested with Claude Code (Anthropic), under human direction and review, across several models (Claude Opus 5,
Claude Sonnet 5) over the course of the project.

## THANKS

Pickle (RimWorks), used to test this mod inside the game: a development tool only, never a dependency of the mod.
RimLogging too, for the same reason.

Thanks to every author above.

See ATTRIBUTION.md in the repository below for the list of source mods this one corrects.

[Source code on GitHub](https://github.com/vbardales/Rimworld-Nelim-Tech-Level-Fixes)
```

**Done 2026-10-08 (1.0.1, `update_description`): the page carries this description. It carried the `0.1.0` one before**, sent once at creation from the `About.xml` of that day (no `IF I GO
QUIET`, `AI-GENERATED` or `THANKS`). Replacing it needs the CI's `update_description`, in a `publish` run, never a hand
edit, which the manual workflow's next dry-run would then diff against and flag as unexpectedly different.

The manual publish workflow is generated in `.github/` (template stamp `a8ca11cdd9a3`, history in `docs/runs/`); never edit it by hand, regenerate it with the script. `About.xml`'s description is the plain text of the block above (`node .github/scripts/sync-about-description.mjs`, no diff). All 71 of `.github/tests/*.test.mjs` pass.

Dry-run green before each upload (1.0.0: run 37768986059; 1.0.2: run 37788999704, exact commit). `steam-production` stays the owner's alone
(`Rimworld-Release-Admin/docs/OPERATIONS.md`).

## Dependencies and DLC

None. `About.xml` declares no `modDependencies` and no DLC-conditional `LoadFolders` branch; every corrected mod is
optional, in `loadAfter` only (`Tests/Check-Patches.ps1` verifies the two lists match). Verified in the sources, not in
the intention, as `AUDIT.md` asks.

## Content boxes (adult content, violence)

No. The mod contains no images, no text and no new content of its own: every file writes a `techLevel` enum value.

## Gallery (manual: no tool of the chain can send it)

Only `Art/Gallery/0-preview.png`, the byte copy of the Preview (regenerated with it on 2026-10-08). No capture planned. This mod has no gameplay screen worth a screenshot of its own: what it changes is a value inspected in
Dev Mode (`TESTING.md`), not something visibly different on the map. The Preview image is the only image.

## Change notes (Steam), one block per version

Template (the first line carries the version, PUBLISHING.md):

```
[b]x.y.z[/b]

One or two sentences on what changes for the player.
```

The notes already sent (1.0.0 to 1.0.2) are in `docs/runs/change-notes-sent.md`.

## Next publication

The ModIcon and the Preview change (`CHANGELOG.md`, `[Unreleased]`): send with `update_preview` in the dry-run and `--preview` in the dispatch. A change note for that version goes above once its number is chosen.
