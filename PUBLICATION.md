# Publication sheet

**Drafted 2026-09-27. The mod is at `done`.** The Workshop item `3806765254` exists, private, created by the `0.1.0`
prepublication of 2026-09-23; `Mod/About/PublishedFileId.txt` is committed. Ahead: `tested` (two Pickle passes on a frozen
tree, see `TESTING.md`), the `1.0.0` publication through the CI, the switch to public (by the owner). Nothing below has
been posted or pasted anywhere yet.

Rules that apply, and where they are written: `PUBLISHING.md` and `AUDIT.md` (protocols repository, read versions in
`docs/PROTOCOLS-READ.md`), `Rimworld-Release-Admin/docs/OPERATIONS.md` for the CI, `WORKSHOP_COMMENTS.md` for the
thank-you register.

## Thank-you comments: none, decided by the owner 2026-09-27

Not for this mod. `WORKSHOP_COMMENTS.md`'s rule ("cela vaut même si... seulement déclarée en `loadAfter`") is written for
a mod that depends on, is inspired by, or integrates with what it names. This mod's relationship to its 49 (and growing)
`loadAfter` entries is the opposite: it corrects a value on their items, with no code read or reused. No register entry,
no comment, for any of them. The Pickle/RimLogging dev-tool thanks in the description below stand as they are, since
those are actually used to test this mod.

## Steam description

Written from the current `About.xml`, with the sections `PUBLISHING.md` asks for after the body. Steam's limit is 8000
bytes; this is under 1 KB.

```markdown
Rewrites the tech level of items from other mods, and of a few base-game research projects, to the level arbitrated for
each one with the **cherrypick** tool.

RimWorld uses `techLevel` to gate raid loot, trade stock, quest rewards and research-adjacent content by era. Many mods
leave it at its default, or pick a level that does not match the item's actual place in the tech tree. This mod corrects
that, item by item, without touching the mods it corrects.

Every file under `Patches/` is generated, one per source mod, named after its `packageId`. Deleting a file undoes that
mod's corrections; deleting the whole folder undoes everything. It loads after every mod it corrects: none of them is a
dependency, and a correction whose target item is missing simply does nothing.

## IF I GO QUIET

If I do not answer within a reasonable time after being contacted, anyone may freely update this or any other of my
mods, including publishing a continuation of it. All credit must be preserved.

## AI-GENERATED

Written and tested with Claude Code (Anthropic), under human direction and review, across several models (Claude Opus 5,
Claude Sonnet 5) over the course of the project.

## THANKS

Pickle (RimWorks), used to test this mod inside the game: a development tool only, never a dependency of the mod.
RimLogging too, for the same reason.

See ATTRIBUTION.md in the repository below for the list of source mods this one corrects.

[Source code on GitHub](https://github.com/vbardales/Rimworld-Nelim-Tech-Level-Fixes)
```

**The page still carries the `0.1.0` description**, sent once at creation from the `About.xml` of that day (no `IF I GO
QUIET`, `AI-GENERATED` or `THANKS`). Replacing it needs the CI's `update_description`, in a `publish` run — never a hand
edit, which the manual workflow's next dry-run would then diff against and flag as unexpectedly different.

**Done, 2026-09-27:** the manual publish workflow is generated in this repository (`.github/workflows/publish-tag.yml`,
`script-tests.yml`, `.github/publish.config.json`, `.github/scripts/`, `.github/tests/`, template stamp `a8ca11cdd9a3`,
via `generate-publish-workflow.sh . --workshop-id 3806765254 --package-id nelim.techlevelfixes --release-title "Nelim's
Tech Level Fixes {version}" --require Patches --require About/About.xml --forbid Assemblies --description-markdown
PUBLICATION.md --description-heading '^## Steam description$' --about-from-description`). `About.xml`'s description is
already the plain text of the block above (`node .github/scripts/sync-about-description.mjs`, no diff). All 68 of
`.github/tests/*.test.mjs` pass. Never edit `.github/` by hand: regenerate with the script instead.

Dry-run green: run 37768986059 on 80606e8e5208004f82114340701ba5961e53488b, version 1.0.0. Not done: and `steam-production` itself
(secrets, required reviewer — the owner's alone, `Rimworld-Release-Admin/docs/OPERATIONS.md`).

## Dependencies and DLC

None. `About.xml` declares no `modDependencies` and no DLC-conditional `LoadFolders` branch; every corrected mod is
optional, in `loadAfter` only (`Tests/Check-Patches.ps1` verifies the two lists match). Verified in the sources, not in
the intention, as `AUDIT.md` asks.

## Content boxes (adult content, violence)

No. The mod contains no images, no text and no new content of its own: every file writes a `techLevel` enum value.

## Gallery (manual: no tool of the chain can send it)

None planned. This mod has no gameplay screen worth a screenshot of its own: what it changes is a value inspected in
Dev Mode (`TESTING.md`), not something visibly different on the map. The Preview image is the only image.

## Change notes (Steam), one block per version

### 1.0.0

```
[b]1.0.0[/b]

First tested release. See CHANGELOG.md for the full list of corrections.
```

## Still to do before `prepublished`

1. `tested` itself: the two Pickle passes on a frozen tree (`TESTING.md`).
2. A dry-run of the exact commit, its run ID and SHA recorded here and in `STATUS.md`.
3. `steam-production` created with its two secrets and the owner as required reviewer (her alone).
4. Everything `AUDIT.md`'s `tested -> prepublished` transition lists: gallery, thank-you comments (none owed here, see
   above), dependencies/DLC (none), content boxes (no), rollback target chosen ahead of the `publish`.
