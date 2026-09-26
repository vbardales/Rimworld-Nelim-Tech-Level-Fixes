---
settings_audit: not_applicable
localization: not_applicable
translation_en: not_applicable
translation_fr: not_applicable
mod:          Nelim's Tech Level Fixes
packageId:    nelim.techlevelfixes
repo:         Rimworld-Nelim-Tech-Level-Fixes
visibility:   public
detached:     yes
stage:        done
workflow_stage: done
licence:      original
licence_at:   2026-09-17, verified by inspection: the shipped content is a set of original XML patches (techLevel corrections keyed by other mods' defNames), no third-party code, text or art copied in. User-stated convention: a `Nelim`-prefixed mod name defaults to private; user explicitly validated a one-off exception to public for this mod on 2026-09-17
dependencies: none  # verified 2026-09-20: no modDependencies declared and none used
showcase:     complete
tested_on:
workshop:      3806765254  # the 0.1.0 pre-publication of 2026-09-23: a private item, not published
remaining:
  - unverified 2026-09-26: no Pickle run is on the shipped revision. The suite last ran on the tree of `a37ff89` (31 patch files) and `Mod/` now holds 45. `tested` needs the two requests of TESTING.md (bare pass, sources pass) played on a frozen tree, with `exitReason` and the discovered-against-played count read first. Nothing else is left for `tested`: no `@wip`, no `@requires`, no `@review`, and no manual scenario (5, 6 and 8 are not applicable, see TESTING.md)
  - unverified 2026-09-26: the sources pass mounts 3 of the 45 source mods this mod lists in `loadAfter`; AUDIT.md defines the pass "with the optional mods" as all of them. A reservation, not a defect: the unit tests cover the others (15 against their real defs, the rest against fixtures)
  - not started, for transition 10 (`tested -> prepublished`) and not a defect of `done`: `PUBLICATION.md` does not exist; the 0.1.0 item's description came from About.xml at creation and lacks `IF I GO QUIET`, `AI-GENERATED` and `THANKS`, so it has to be corrected through the CI (`update_description`) from a `## Steam description` block; the mod lists 45 source mods and none has an entry in the WORKSHOP_COMMENTS.md register; neither README.md nor ATTRIBUTION.md names the AI tool used; there is no `Source/*.csproj` and no `Mod/README.template.md`, so `bootstrap-release.sh` skips this repository and the manual workflow is the route (with `--require Patches`, this mod having no `Defs`)
  - reservation, visual, not a defect: at 32 px the ModIcon's face and gear rim are distinguishable but its engraved text strip is not readable; the owner asked on 2026-09-20 to keep that text
accepted:
  - accepted 2026-09-21 by the user (23 uninstalled source mods then, 30 of 45 on 2026-09-26): the corrected defNames of the uninstalled source mods have never been confronted with their sources; only the 7 installed mods’ defNames were, and all resolved. Knowingly accepted rather than closed: the gap shuts by itself when a mod returns to the modlist, and the check reruns then. See "Patches outlive their mods"
  - accepted 2026-09-21 by the user (23 of 30 then, 30 of 45 on 2026-09-26): the unit tests check the uninstalled source mods against synthetic fixtures only; the real-def and starting-level checks ran for the 7 installed on 2026-09-20 and report the rest as SKIP rather than passing them. Knowingly accepted on the same ground, and the SKIP is deliberate - the suite never reports an unchecked mod as passing
session:      local_bda06393-deee-42a0-8f7b-5796fbec672f
updated:      2026-09-26, audited against the AUDIT.md of that day: stage stays `done` (out-of-game suites green on the current revision), `tested` not reached (no Pickle run on the shipped revision). 0.1.0 recorded, evidence out of git, scenarios 5, 6 and 8 not applicable
---

# Nelim's Tech Level Fixes — status

## Workflow audit — 2026-09-26

**Decision: the stage stays `done`. `tested` is not reached.** The out-of-game suites are green on the current revision, and no
Pickle run is. Nothing found today lowers the stage; two earlier claims of this file were false and are corrected below.

### Audited revision and scope

- Repository root `C:/Users/nelim/Documents/rimworld/TechLevelFixes`, distributed folder `Mod/`. At the start `HEAD` was
  `9640d92` (`Add Beautiful.Mechnode tech-level corrections`), fourteen commits after `a37ff89`, the last one this file had
  audited. Those fourteen add source mods; none of them was made by this session.
- Local state found: `STATUS.md` and `TESTING.md` carried uncommitted work of 2026-09-22 (folded in below, and corrected where the
  tree disagreed); `Tests/manual-evidence/README.md` was untracked (removed, see below); `Mod/About/PublishedFileId.txt` was
  untracked (committed, `fa3d7c8`).
- `AUDIT.md` read at `4f034f5` (2026-09-26). The other documents and their versions are in `docs/PROTOCOLS-READ.md`.
- No RimWorld and no Pickle process was launched by this session.

### Controls run, and what they gave

| Control | Result |
|---|---|
| `Tests/Check-Patches.ps1` | PASS: 45 patch files, 229 corrections, 45 `loadAfter` entries, 2 defNames corrected by more than one source mod, all in agreement; `LICENSE` and `ATTRIBUTION.md` identical to their `Mod/` copies |
| `Tests/Run.ps1` (unit) | 168 passed, 0 failed. `Installed source mods found: 15 of 45`; the others are covered by fixtures only, and reported as `SKIP`, never as passed |
| `ModIcon.png` | 128 x 128, 19,025 bytes, unchanged since 2026-09-20. **Opened and looked at, at 32 px**: the winking face and the gear rim are distinguishable; the engraved text strip under it is not readable at that size. Recorded as a reservation: the owner asked to keep that text |
| `Preview.png` | 896 x 504, 648,828 bytes (under 1 MB), unchanged since 2026-09-20. **Opened at 268 px**: title, `1.6` badge and summary line all readable, one small figure, no face. The text block is at the bottom-left, where the 2026-09-25 spec says top-left or bottom-right; already-engraved previews keep their layout until the mod is reworked, so not a defect |
| Structure | `Mod/` holds `About/` and `Patches/` only: no assembly, no `Defs`, no `Languages`. No `incompatibleWith`, `loadBefore` or `modDependencies`. `loadAfter` names mods, never a patch file. No `<label>` or `<description>` in any patch |
| Features | No `@wip`, no `@requires`, no `@review`, no `@allow-errors` in `Tests/Pickle/Mod/Pickle/Features/` |
| GitHub links | `https://github.com/vbardales/rimworld-nelim-tech-level-fixes` and `.../Rimworld-Nelim-Tech-Level-Fixes` both answer 200 (GitHub ignores case). `About.xml` now uses the canonical spelling, in `<url>` and in the closing description line |
| Not run | Pickle, and anything in the game. The tree is not frozen (source mods keep arriving), so a request would not test a stable revision |

### Ordered result

| Destination | Result | Evidence |
|---|---|---|
| horsMonoRepo | Validated | Public repository `Rimworld-Nelim-Tech-Level-Fixes`, `origin` at `HEAD`, English documentation, `LICENSE` and `ATTRIBUTION.md` duplicated in `Mod/` |
| ModIcon générée | Validated, with a reservation | Direct checks above; the text strip does not read at 32 px |
| Preview générée | Validated | Direct check above |
| preOptions | Validated | Description in English, ends with the `Source code on GitHub` link, now on the canonical repository name. The defect the 2026-09-22 audit raised (lowercase spelling) is fixed by `9dfcdd9` |
| options | Not applicable, justified | No assembly, no settings, no page and no shortcut: checked against the tree |
| l10n | Not applicable, justified | The patches write `techLevel` values and no text: no `Keyed`, no `DefInjected`, no label |
| preTest | Validated | No dependency declared or used; `loadAfter` and `Patches/` match exactly (XML suite); no `LoadFolders` needed for a single version |
| done | **Validated on the current revision** | Scenarios written (`TESTING.md`), unit suite 168/0, XML suite PASS, Pickle suite written. Results correspond to the shipped revision for every out-of-game suite |
| tested | Not reached | Both Pickle passes have to be played on the shipped revision; see below |
| prepublished, published | Not started | The 0.1.0 pre-publication exists (item `3806765254`, private); it is not the `prepublished` state |

### Required for `tested`

1. Freeze the tree, then file two requests (`TESTING.md` gives the exact ones): the bare pass, and the sources pass. A request
   carries no SHA, so no commit may land before their `RUN_DONE`.
2. Read `exitReason`, the suite name and the discovered-against-played count of each report before its figures.
3. Record both in `docs/runs/history.md` and here.

Nothing else: no `@wip`, no `@requires`, no `@review` capture, no manual scenario.

### Judgements made today, for the owner to confirm or overturn

- **Scenarios 5, 6 and 8 are not applicable** (delete one patch file, delete the folder, save and reload or add and remove the
  mod). `AUDIT.md` "On ne teste pas le jeu" puts the game's handling of an absent file, and of a mod added to or removed from a
  save, outside what a mod answers for; the mod declares no file and stores nothing. The reasons are in `TESTING.md`. This
  replaces the 2026-09-22 plan that asked for recorded videos, and it withdraws `Tests/manual-evidence/`, which was never
  tracked and held only that plan. If the owner disagrees, the three come back as manual and `tested` waits for them.
- **The sources pass mounts 3 of 45 `loadAfter` mods.** A reservation against the letter of `AUDIT.md`, not a defect; extending
  the map is the owner's call.

### Corrections to earlier claims

- **The 2026-09-22 follow-up says `About.xml`'s `<url>` and description link were corrected to the new spelling. They were not in
  the tree**: on 2026-09-26 both the working file and `HEAD` still carried the lowercase form of `a37ff89`. Whether the edit
  was lost or never saved is not established. It is done now, by `9dfcdd9`.
- **`Tests/Pickle/results/2026-09-20-summary.md` was not this mod's report.** It lists three trouser scenarios that belong to
  TailorMade Waistlines: a copy of the shared `pickle-reports/` folder taken after that mod's run had overwritten ours. The
  "4 of 5" of that day has no valid report behind it. The file is removed and the run is recorded as such in `docs/runs/history.md`.
- **The 2026-09-22 note says the bare pass was not yet re-established on Pickle v4.8.4.** A launcher log of 2026-09-23 00:08 shows
  it was: 1 of 1, `exitReason: passed`. It had not been written down.
- **The 2026-09-22 "Manual-evidence plan" is withdrawn** (see above).

### What changed in the repository today

`fa3d7c8` the published file ID; `9dfcdd9` the changelog (`[0.1.0]` is the publishIdFile, `1.0.0` stays under `[Unreleased]`) and the
canonical links; then the evidence moved out of git (`Tests/Pickle/results/` removed, one line per run in `docs/runs/history.md`,
the latest proofs kept in `Tests/Pickle/Evidence/`, ignored), `docs/PROTOCOLS-READ.md` with its checking script, `TESTING.md`
rewritten, and this file.


## Manual-evidence plan — 2026-09-22 (withdrawn 2026-09-26)

**Withdrawn.** Scenarios 5, 6 and 8 are not applicable and the others are automated; see "Workflow audit — 2026-09-26" above and
`TESTING.md`. What follows is kept as it was written.

`TESTING.md` now makes every scenario auditable by a human: stable end states require named PNG
captures; state transitions require unedited MP4 recordings; each run records its active mod list,
game state and relevant Player.log excerpt in `Tests/manual-evidence/README.md`. The plan applies
to all eight scenarios, while the remaining evidence gate for `tested` is scenarios 5, 6 and 8:
only a human can alter the installed copy, change the mod list, and save/reload across those
changes. The README now exists as the ready-to-fill evidence register. No capture/video has been
fabricated or claimed as observed.

## Pickle revalidation — 2026-09-22

The two required headless WSL passes completed through `scripts/Run-PickleWsl.ps1`, each after
the launcher obtained its ticket and released the lock in `finally`. A subsequent sources-only
revalidation repeated the live source assertions.

| Pass | Invocation scope | Verdict | Evidence |
| --- | --- | --- | --- |
| Minimal | `-Filter 01-alone.feature`; no corrected source mod staged | 1/1 passed, `exitReason: passed` | Launcher log, removed 2026-09-26 (one line in `docs/runs/history.md`). The mod loaded with all targets absent and logged no warning or error. |
| Sources | `-Filter 02-with-sources.feature -DepMap wsl-deps.sources.map` | 5/5 passed, `exitReason: passed` | The archived report, purged by the launcher's retention (one line in `docs/runs/history.md`). It staged Alpha Books, Additional Tools and Ancient Amulets, then established real load order, add branch, replace branch and inherited-level override. |
| Sources revalidation | Same sources filter and map; ticket 40916, started 17:24 and ran 17:33 | 5/5 passed, `exitReason: passed` | Launcher log and archived report, both removed (one line in `docs/runs/history.md`). It staged 14 mods and released the lock after the verdict. |
| Sources, Pickle v4.8.4 | `-Filter 02-with-sources.feature -DepMap wsl-deps.sources.map -PickleSrc .build/Pickle-4.8.4/Pickle` | 5/5 passed, `exitReason: passed` | Official GitHub release `v4.8.4` (published 2026-09-22, includes patching fix PR #20 / `0bc6960`); downloaded archive SHA-256 `088911EA5C29FE91D2AEE5C668BCDEF60061955AE75D38E1EA29E0B39CDBD93C`; launcher log, kept as `Tests/Pickle/Evidence/2026-09-22-v4.8.4-sources.out.log`, confirms `override: rimworks.pickle` from that extracted release; the archived report itself is gone. |

An earlier 2/6 result is not a mod defect: the complete suite was mistakenly run in the minimal
pass, so its real-modlist feature necessarily lacked its three source mods. A subsequent
zero-scenario infrastructure result was likewise discarded: the filter was passed with literal
apostrophes and matched no feature. Neither run is evidence for or against the mod; the two
passes above are the valid revalidation evidence.

`rg -n "@review" Tests/Pickle/Mod/Pickle/Features Tests/Pickle/README.md` found no review-tagged
TechLevelFixes scenario. The shared archive contains screenshots from other queued runs; none
was treated as a TechLevelFixes capture. `tested` remains unreached: the eight manual scenarios
recorded in `TESTING.md` were not all executed; scenarios 5, 6 and 8 remain explicitly
`unverified` pending their required human-reviewable videos.

The v4.8.4 result is a precise **sources-pass** proof only: it validates the five live-def/load-order
assertions with the released PR #20 backend, but does not yet re-establish the separate
`sans-facultatifs` no-target guarantee on that release.

## Workflow follow-up — 2026-09-22

**Corrected 2026-09-26:** the `About.xml` edit described below was not in the tree. See "Corrections to earlier claims" above.

**Decision: `Preview générée` -> `done`.** The blocker from this audit's first pass was
corrected in the distributed `Mod/About/About.xml`: both `<url>` and the final description link
now use `https://github.com/vbardales/rimworld-Nelim-Tech-Level-Fixes`, matching `origin`
apart from its `.git` suffix. The top-level `repo` field was corrected to the same kebab-case
spelling. The `Preview générée -> preOptions` criterion is therefore validated.

The independently established `options` (`settings_audit: not_applicable`) and `l10n`
(`localization`, `translation_en`, `translation_fr: not_applicable`) results remain valid. The
current out-of-game XML and unit-test controls, the already-written functional scenarios, and
the existing Pickle suite establish `preTest -> done` under AUDIT.md's rule that a live-game run
is not required for `done`. `tested` remains unreached: this follow-up launched no RimWorld or
Pickle process and makes no new gameplay, persistence, UI, or language-display claim.

## Workflow audit — 2026-09-22

**Decision: `done` -> `Preview générée` (project stage: `showcase`).** This is a
documentation/metadata rollback, not a claim that the patch content or its independent
test results are defective. The ordered `Preview générée -> preOptions` transition requires
the final `Source code on GitHub` target and `<url>` in the distributed `About.xml` to match
the autonomous GitHub remote exactly. On revision `a37ff89d`, both still use
`rimworld-nelim-tech-level-fixes`, while the corrected `origin` is
`https://github.com/vbardales/rimworld-Nelim-Tech-Level-Fixes.git` (fetch and push).
That is a concrete metadata defect, so `preOptions` and every sequential later stage are
not currently established.

### Scope and controls

- Audited repository root: `C:/Users/nelim/Documents/rimworld/TechLevelFixes`; distributed
  folder: `Mod/`; revision: `a37ff89d1459bd41120bd5022007b07b6d8dfcc0` (`Ancient Junk Loot:
  all six corrections go to Animal`). The working tree was clean before this audit; the only
  audit edit is this STATUS.md update. `origin` was corrected locally to the kebab-case URL
  above before the check.
- Direct artefact inspection: `Mod/About/ModIcon.png` is a 128x128 PNG (19,025 bytes), and
  `Mod/About/Preview.png` is an 896x504 PNG (648,828 bytes, below 1 MB). Both were opened and
  reviewed directly; the preview has a readable overlay, a high-oblique workshop scene, and a
  visible 1.6 badge. No new visual defect was observed.
- `powershell.exe -ExecutionPolicy Bypass -File Tests/Check-Patches.ps1`: pass — 31 patch
  files, 167 corrections and 31 `loadAfter` entries; the one shared defName agrees. The script
  also verifies that the shipped LICENSE and ATTRIBUTION copies match the root copies.
- `powershell.exe -ExecutionPolicy Bypass -File Tests/Run.ps1`: build and test process exited
  successfully after the required local Windows SDK access was available. Build: 0 warnings,
  0 errors. This remains an out-of-game test only; it does not validate game UI, loading or
  save behaviour.
- Settings and localization were re-inventoried: the shipped mod has no C# or assembly and its
  31 patch XML files only write `techLevel` enum values. No player settings, empty settings
  page, MainButtons shortcut, Keyed text or DefInjected text exists. `settings_audit` and all
  three localization fields therefore remain justified `not_applicable`.
- No RimWorld or Pickle process was launched by this audit. All prior in-game/Pickle evidence is
  historical only and no new gameplay, English/French display, persistence, log or screenshot
  assertion is made here.

### Ordered result

| Transition destination | Result in this audit | Evidence |
| --- | --- | --- |
| horsMonoRepo | Validated | Autonomous Git repository, public GitHub remote and required English root/distributed documentation remain present. |
| ModIcon générée | Validated | Direct 128x128 PNG inspection above; no build artefact applies to this XML-only mod. |
| Preview générée | Validated | Direct 896x504, sub-1-MB Preview inspection above. |
| preOptions | Defect | About.xml's repository URL and final description link do not use the corrected kebab-case origin spelling. |
| options | Not applicable, justified | Independent static settings inventory remains valid. |
| l10n | Not applicable, justified | Independent player-facing-text inventory remains valid. |
| preTest | Independently validated | Patch-shape/XML validation and out-of-game unit test execution are recorded above; sequential entry remains blocked by preOptions. |
| done | Independently unmodified, sequentially not current | Existing test scenarios and historical results are preserved, but `done` cannot be the current workflow stage while preOptions is blocked. |
| tested | Not reached in this audit | No new game validation was run. |

### Required next transition

Correct the two distributed `About.xml` repository references to
`https://github.com/vbardales/rimworld-Nelim-Tech-Level-Fixes`, then verify that the final
description link, `<url>`, and `origin` are byte-for-byte coherent. No code, image, settings,
translation, or RimWorld run is required for that transition.

## Workflow audit — 2026-09-17

**Decision: (no prior status) -> `dansMonoRepo` -> `horsMonoRepo`.** This is the
first STATUS.md this mod has ever had, so there was no previous declared stage to
correct — the initial audit on 2026-09-17 established a baseline of `dansMonoRepo`
from the actual repository and filesystem state, not from a claim in a file. In the
same session, at the user's explicit direction, the repository, decisions and
documentation this transition requires were created (see below), and the
`horsMonoRepo` transition is now validated. `workflow_stage` tracks the nine-step
chain audited here (`dansMonoRepo -> horsMonoRepo -> ModIcon générée -> Preview
générée -> preOptions -> options -> l10n -> preTest -> done -> tested`); `stage`
keeps this project's own vocabulary (`port`, `showcase`, `preTest`, `done`,
`tested`, `published`) for continuity with every other mod's STATUS.md. `port`
remains the closest existing value: the patch content itself is finished, and
none of the downstream gates (showcase images, settings, localization, tests)
has started.

### Audited revision and scope

- Autonomous Git root: `C:/Users/nelim/Documents/rimworld/TechLevelFixes`. Shipped
  folder: `Mod/`. This is already a separate git repository from the monorepo (its
  own `.git`, its own single commit `e34adc4`, "Import Nelim's Tech Level Fixes as
  generated by CherryPick"), but that alone does not satisfy `horsMonoRepo` — see below.
- `git status`: clean, nothing uncommitted. `git remote -v`: no remote configured,
  in this repo or towards the monorepo. `gh repo list vbardales --limit 300`,
  searched for "tech", "fixes" and "level": no matching repository among the 141
  repositories returned. No GitHub repository exists for this mod under this account.
- Tracked files (`git ls-files`): `Mod/About/About.xml` and 27 files under
  `Mod/Patches/`. Nothing else is tracked or present at the repository root: no
  `README.md`, `ATTRIBUTION.md`, `LICENSE`, `CHANGELOG.md`, `.gitignore`,
  `.gitattributes`, no `Mod/About/ModIcon.png`, no `Mod/About/Preview.png`.
- Read `../PUBLISHING.md`, `../STYLE_RIMWORLD.md`, `../MOD_SETTINGS.md`,
  `../TRANSLATIONS.md`, `../AGENTS.md`, and prior STATUS.md examples
  (`AncientSalvage`, `EdenGarden`, `RabbieGearRenew`) for field conventions.

### Ordered transitions

| Transition destination | Result | Evidence |
| --- | --- | --- |
| horsMonoRepo | Validated | As of 2026-09-17: GitHub repository `vbardales/rimworld-nelim-tech-level-fixes` created (public, user-validated exception to the "Nelim-prefixed = private" default), remote `origin` configured, commits pushed. STATUS.md exists. README.md, ATTRIBUTION.md, LICENSE (MIT) and CHANGELOG.md exist in English at the repository root, with LICENSE and ATTRIBUTION.md duplicated into `Mod/`. `.gitignore` and `.gitattributes` added. `packageId` (`nelim.techlevelfixes`), the displayed name (`Nelim's Tech Level Fixes`), the folder name (`TechLevelFixes`) and the repository name are mutually coherent. |
| ModIcon generated | Validated | Development is finished (30 generated patch files, no build applicable: no C#). `Mod/About/ModIcon.png` is a 128x128 PNG, 19,025 bytes, produced on 2026-09-20 from the user's raw 1254x1254 generation (kept as `Art/ModIcon-source.png`, byte-identical to what was dropped in), the whole image reduced with the lettering "TECH LEVEL FIXES" kept, as the user wants. A crop without the lettering was tried and reverted the same day (see "Icon re-crop, reverted"). Directly inspected at 128 px and at a 32 px copy enlarged 6x: the winking orange mascot and its gear stay identifiable at 32 px; the lettering does not (see reservations). The first raw drop (1254x1254, 1,114,566 bytes) was a defect and is superseded. |
| Preview generated | Validated | `Mod/About/Preview.png` is a 896x504 (16:9) PNG, 868,710 bytes, under both the 900 KB target and the 1 MB hard limit. It is the top 1536x864 band of the user's raw 1536x1024 generation (kept unchanged as `Art/Preview.png`), reduced with high-quality bicubic resampling; the crop removes only floor at the bottom. Directly inspected at full size and at a 268 px thumbnail: high oblique camera, tiled floor, one lamp pool, one dark settler from behind, four objects still identifiable at 268 px; no camera defect observed, no readable text. No overlay yet: title and badge belong to preOptions. The first raw drop (1536x1024, 2,070,420 bytes) was a defect and is superseded. |
| preOptions | Validated | Preview adjusted on 2026-09-20 (see "Preview overlay"): accent `#3AAEF0` (blue family) is clearly separate from the secondary ink `#E0A870` (warm brown family), 172 degrees apart in hue, checked visually at 896x504 and at a 268 px thumbnail. Description is in English and ends, after the feature text, with exactly `[url=https://github.com/vbardales/rimworld-nelim-tech-level-fixes]Source code on GitHub[/url]` as its last element; that target equals the `origin` remote and the `<url>` field, and `gh repo view` confirmed the repository exists and is public. Naming: `Nelim's` is the prefix (reduced to 65% in secondary ink), `Tech Level Fixes` keeps 100% in primary ink; no `Renew`/`Extended`/`Plus` suffix applies to an original mod, and the title has no connecting word to reduce. No `(prohibited)`/`(unofficial)` tag applies (public, licence `original`). |
| options | Validated (not applicable, justified) | `settings_audit: not_applicable`, established by static inventory: no C# and no assembly anywhere in the tree, and the only XML besides About.xml is patch files writing `<techLevel>`, so no settings owner, page or MainButtons shortcut can exist (see "Settings audit"). Re-checked against the full 30-file tree after the Zombieland addition. No in-game integration is claimed as tested; none is required for this step. |
| l10n | Validated (not applicable, justified) | `localization`, `translation_en`, `translation_fr: not_applicable`: an inventory of every `<value>` across the 30 patch files (332 `<value>` and 332 `<techLevel>` tags) shows the mod writes only a `techLevel` enum whose display text the base game already localizes; no Keyed, DefInjected or code-generated text exists (see "Translation audit"). About metadata is outside this gate per TRANSLATIONS.md. |
| preTest | Validated | Dependencies actually used: none, and `About.xml` declares none. Established rather than assumed: only vanilla `PatchOperationAdd`/`Replace`/`Conditional` classes appear anywhere (no framework namespace), the mod ships no assembly, and all 166 corrections are proven no-ops against a document lacking their target, leaving it byte-identical (`Tests/Run.ps1`). Identifiers: all 30 `loadAfter` ids exist in `../Rimworld-Cherry-Pick-App/data/mod-labels.json`, a registry independent of the patches themselves, so none is a typo - including the 23 whose mods are not installed. Casing differs from that registry for 19 of them and does not matter: the game normalises, as its own `ModsConfig.xml` shows, holding 124 ids without a single uppercase character while `Udon.AnimalSimpleCommand` declares itself in mixed case. Load order: `loadAfter` and `Mod/Patches/` are the same 30 names in both directions. Mandatory versus optional: nothing is declared mandatory, every relationship is a `loadAfter`, and the description says so. LoadFolders: none shipped and none needed - one flat `Patches/` folder, no version or DLC gating - consistent with conditional patches that all report `success: Always`. |
| done | Validated | All four kinds written, executed and green on 2026-09-21: automated `Tests/Run.ps1` 107/0, XML `Tests/Check-Patches.ps1` pass, pickles `Tests/Pickle/` 5/5 headless in the WSL game, and `TESTING.md` carrying 8 functional scenarios with preconditions, actions and expected results. Nothing claimed not-applicable. |
| tested | Not reached | No in-game validation of any kind has been performed or claimed. |

### What is actually in the shipped folder

`Mod/About/About.xml` declares `nelim.techlevelfixes`, author `Nelim`,
`supportedVersions: 1.6`, and 28 `loadAfter` entries (all optional — the
description states explicitly that none of the corrected mods is required).
`Mod/Patches/` holds 27 generated `PatchOperationConditional` files, one per
source mod's `packageId`, each rewriting one or more `techLevel` fields (verified
by reading `zal.alchemy.xml` in full: two corrections, `Industrial -> Medieval`
and `(none) -> Medieval`, applied via replace-or-add against explicit defName
xpaths). Every file carries a French comment stating it is generated by the
"cherrypick" tool and should not be hand-edited. No textures, no compiled
assembly, no third-party text or assets are present anywhere in the tree — the
content is exclusively original XML patch logic referencing other mods'
`defName`s.

### Licence and visibility — flagged, not decided

This is not a defect in the mod; it is an undecided, mandatory input to
`horsMonoRepo`. Direct inspection supports treating this content as `original`
under this workflow's vocabulary (owing nothing to anyone — no name, idea or
asset value is traceable to a single upstream mod; the patches only reference
generic `defName`s and set a `techLevel` value). That is a factual observation
from the files, not a substitute for the visibility/licence decision itself,
which also determines whether a `(prohibited)` or no suffix applies, and is left
to the user to record in STATUS.md.

### `dansMonoRepo -> horsMonoRepo`: now validated

Completed on 2026-09-17, at the user's explicit request, across this session:
GitHub repository created and pushed to; visibility (`public`) and licence
(`original`) decided and recorded, including the user-validated one-off
exception to the "Nelim-prefixed mod = private" default; README.md,
ATTRIBUTION.md, LICENSE and CHANGELOG.md written in English, with LICENSE and
ATTRIBUTION.md duplicated into `Mod/`; `.gitignore` and `.gitattributes` added.

### Historical: before `horsMonoRepo -> ModIcon générée` (superseded 2026-09-20, see "Resize")

- Generate and install `Mod/About/ModIcon.png` at the expected dimensions and
  format. No image was generated by this session; the user generated both
  `ModIcon.png` and `Preview.png` on 2026-09-20.
  `../PROMPT_TECHLEVELFIXES.md` (parent `rimworld` folder, outside this
  repository, moved there 2026-09-20) holds the Preview
  prompt prepared on 2026-09-17.

### Preemptively closed, ahead of `preOptions`

`About.xml` now declares `<url>https://github.com/vbardales/rimworld-nelim-tech-level-fixes</url>`
and the `<description>` closes with
`[url=https://github.com/vbardales/rimworld-nelim-tech-level-fixes]Source code on GitHub[/url]`,
satisfying PUBLISHING.md's description-link criterion ahead of time. Safe to do now because
no `About/PublishedFileId.txt` exists yet: the Workshop item has never been created, so this
description has not been sent to Steam and is not yet a "one shot" already spent.

### Settings audit — 2026-09-17, autonomous follow-up

`settings_audit: not_applicable`, independently established regardless of overall
`workflow_stage` (still gated behind ModIcon générée/Preview générée/preOptions
in transition order — see interpretation rules).

- Inventory: `git ls-files` and a directory walk confirm the entire repository
  contains only `Mod/About/About.xml`, 29 generated XML patch files, and
  documentation. There is no `Source/`, no `Assemblies/`, no `.dll`, no C# file
  anywhere in the tree.
- Since no assembly is shipped, there is no possible owner for `ModSettings`,
  `Mod`, `MainButtonDef`, `MainTabWindow` or any settings window: none of these
  types can exist without compiled code. This is a structural impossibility, not
  an inference from a missing settings page alone (MOD_SETTINGS.md warns
  against that shortcut; here the absence of *any* C# closes the question
  completely, for every RimWorld/HugsLib/RIMMSQOL settings mechanism, not just
  the ones checked for by name).
- Consequently: no empty settings page, no MainButtons shortcut, visible or
  hidden, exists or could exist. Both required absences are verified.
- No player configuration is needed or possible: the only "configuration"
  surface is documented in README.md — deleting one file under `Mod/Patches/`
  undoes that mod's corrections, deleting the folder undoes all of them. That is
  a file-system mechanism, not an in-game settings UI, and PUBLISHING.md/
  MOD_SETTINGS.md do not ask data-only mods to grow one where none is useful.

## Translation audit — 2026-09-17, autonomous follow-up

`localization`, `translation_en`, `translation_fr`: all three `not_applicable`,
independently established, same caveat on `workflow_stage` as above.

- Inventory command: `grep -oE '<value><[a-zA-Z]+>' Mod/Patches/*.xml`, cross-checked
  by counting `<value>`, `<techLevel>` and `Operation Class="..."` occurrences
  across all 29 patch files: 163 `PatchOperationConditional` operations, 326
  `<value>` tags, 326 `<techLevel>` tags — an exact match, and every single
  `Operation Class` in the tree is `PatchOperationConditional`. No other field
  (`label`, `description`, or anything else) is ever written by any patch.
- `About.xml` carries no `Keyed` folder, no `DefInjected` folder, and (per the
  above) no C# — so no `.Translate()` call, no interpolated string, no
  runtime-generated text exists anywhere in this mod's own code.
- The only thing this mod ever changes is the `techLevel` enum value on other
  mods' existing defs. `techLevel`'s display string (`Neolithic`, `Medieval`,
  `Industrial`, etc.) is owned and already localized by the base game in both
  English and French; this mod does not introduce, override or duplicate that
  text anywhere.
- Conclusion: this mod adds or changes no player-facing text of its own. The
  `<url>`/description source-code link added this session is About metadata,
  explicitly outside the in-game translation gate per TRANSLATIONS.md.

## XML tests — 2026-09-17

`Tests/Check-Patches.ps1` written and run this session. Pure XML/XPath validation,
no RimWorld installation, no assembly reference: it does not use the shared
`../scripts/Check-DefRefs.ps1` / `Check-XmlFields.ps1` family, because those walk
actual Def XML (`<ThingDef>`, `<ResearchProjectDef>`, ...) and this mod ships none
of its own — only `<Patch>` operation files. What it checks, per file:

- well-formed XML, root element is exactly `<Patch>` (case-sensitive);
- the header comment's `Corrections : N` matches the actual `<Operation>` count;
- every top-level operation is `PatchOperationConditional` with
  `<success>Always</success>`, and its outer `xpath` has the shape
  `/Defs/<DefType>[defName="..."]`;
- the nested conditional's `xpath` is the *same* outer xpath plus `/techLevel`
  (exact string equality, so whatever casing the outer xpath used carries
  through), its `match` is `PatchOperationReplace` and its `nomatch` is
  `PatchOperationAdd`, each with the expected xpath;
- the replace branch's and the add branch's `<techLevel>` value are identical, and
  is one of the seven values the game defines (`Undefined`, `Animal`, `Neolithic`,
  `Medieval`, `Industrial`, `Spacer`, `Ultra`, `Archotech`);
- no `defName` is corrected twice within one file;
- every patch file's own name (the source mod's `packageId`) has a matching
  `<loadAfter><li>` entry in `About.xml`, and vice versa — exactly 29 both ways.

Run with `.\Tests\Check-Patches.ps1` from the repository root (Windows PowerShell
5.1; no `pwsh`/PowerShell 7 available in this environment). **Result: 29 files,
163 corrections, 29 loadAfter entries, 0 problems — green.**

**A false positive along the way, corrected rather than reported as a defect.**
The first version hard-required the outer xpath's def-type tag to be exactly
`ThingDef` or `ResearchProjectDef`, case-sensitively, and flagged
`zal.alchemy.xml`'s `AlchemyBench` correction (`/Defs/thingDef[...]`, lowercase)
as a defect on that basis. At the user's prompt ("alchemy est là"), checked
against the actually-installed source mod on disk
(`.../workshop/content/294100/3132057783/Defs/ThingDefs/Buildings_Alchemy.xml`):
Alchemy (Continued) itself declares `AlchemyBench` under a **lowercase**
`<thingDef ParentName="BenchBase">`, and RimWorld's own def loader resolves Def
types case-insensitively, so that source file loads correctly. The patch's xpath
correctly mirrors the source file's own literal casing — XPath matching against
the raw DOM *is* case-sensitive, so the xpath has to match whatever the source
wrote, not a fixed canonical spelling. The hard-coded `ThingDef`/`ResearchProjectDef`
requirement was the actual bug, not the patch. Loosened to accept any def-type tag
shape and rely on internal consistency (every xpath for one operation is compared
against the others by exact string equality) instead of a fixed list; reran green.
No hand-edit was made to any `Mod/Patches/*.xml` file at any point, correctly or
not — only the checker's own assumption changed.

Before trusting this green run, the checker was verified negatively twice, on
temporary in-place edits reverted immediately after (`git status` confirmed no
residual change both times): a deliberately mismatched replace/add pair, and
(during the false-positive episode) the lowercase-xpath case itself. Both were
caught when they should have been; only the second one turned out not to be a
real defect once checked against the actual installed source.

## Re-audit after brrainz.zombieland addition — 2026-09-17

A separate local session (commit `28c5d0d`, "Add brrainz.zombieland tech-level
corrections", `Co-Authored-By: Claude Opus 5`) added a 30th correction file while
this audit was in progress. Everything above this section describes the mod as it
stood at 29 files/163 corrections; **current totals are 30 files, 166
corrections.** Re-verified rather than assumed unchanged:

- `Mod/About/About.xml` still declares `<url>` and the description's closing
  GitHub link — the other session's commit message notes cherrypick's
  regeneration of `About.xml` had dropped both, and restored them by hand.
  Confirmed present by direct read of the file.
- `Mod/Patches/brrainz.zombieland.xml` (3 corrections: `Thumper`, `ZombieSerumSimple`,
  `ZombieShocker`) matches the same generated shape as every other file: header
  comment, `PatchOperationConditional`/`Replace`/`Add`, `ThingDef` xpaths, only
  `<techLevel>` ever set.
- `Tests/Check-Patches.ps1` rerun: **30 files, 166 corrections, 30 loadAfter
  entries, 0 problems — still green.**
- `settings_audit` and `localization`/`translation_en`/`translation_fr`: their
  `not_applicable` basis was re-checked against the full current tree rather than
  left on the stale 163-tag count, per TRANSLATIONS.md/MOD_SETTINGS.md's rule to
  revalidate after a relevant change. Full tree still holds no `Source/`, no
  `Assemblies/`, no C# anywhere; every `<value>` across all 30 files is still a
  `<techLevel>` and nothing else (332 `<value>`/`<techLevel>` tags, exact parity).
  Both verdicts stand unchanged, now against the current tree.
- Dependency-class check (only vanilla `PatchOperationAdd`/`Replace`/`Conditional`,
  no framework-namespaced `Class`) reconfirmed across all 30 files.
- `README.md`, `ATTRIBUTION.md`, `CHANGELOG.md` already updated by the other
  session's commit to name `brrainz.zombieland` and the new "30 source mods"
  count; not further edited here.
- `TESTING.md`'s framing counts (30 corrected mods, 166 corrections) updated to
  match; no new scenario was needed since `brrainz.zombieland.xml` introduces no
  shape TESTING.md's existing 8 scenarios don't already cover.

No transition changes as a result: `workflow_stage` stays `horsMonoRepo`, still
blocked on ModIcon/Preview generation (2026-09-20) ahead of `preOptions`.

## The shipped ATTRIBUTION had drifted — found and fixed 2026-09-20

`LICENSE` and `ATTRIBUTION.md` exist twice on purpose: at the repository root, and inside `Mod/`
because Steam ships that folder as it stands. PUBLISHING.md warns that the two copies
desynchronise without a sound. They had: the Zombieland addition of 2026-09-17 updated the root
copy to 30 mods, and `Mod/ATTRIBUTION.md` still said 29 and omitted `brrainz.zombieland`. Three
days in which the file every subscriber would receive was wrong about what the mod corrects.

Recopied, and the two copies now hash identically. `Tests/Check-Patches.ps1` compares both
duplicated files by SHA-256 on every run, so the next drift fails a test instead of waiting for
someone to notice: verified by appending a line to the shipped copy and watching it fail, then
restoring it.

## A defName corrected by two mods — found 2026-09-20

Cross-checking the generated Pickle assertions against the patch files turned up 166 corrections
for 165 distinct defNames. The repeat is `ASC_ManualLeader`, corrected by both
`cedaro.animalcommander.xml` (Animal Commander) and `Udon.AnimalSimpleCommand.xml` (Animal
Simple Command) — the `ASC_` prefix and the shared defName suggest one continues the other.

**Not a defect: both corrections set `Neolithic`.** Both are `ThingDef`s of that name, and a
defName is unique within a def type, so if both mods are enabled the one loading last owns it.
Since the two corrections agree, the final techLevel is the same either way; had they disagreed,
the result would silently depend on the mod order the player happens to have.

(This paragraph first said defNames are global. They are not — they are unique per def type, as
the Pickle run of 2026-09-20 established when `ABooks_ArmyManual` turned out to be both a
`ThingDef` and a `HediffDef`. The conclusion above survives because both defs here are
`ThingDef`s, but the reason given for it was wrong.)

`Tests/Check-Patches.ps1` only looked for duplicate defNames *within* one file, so it could not
have seen this. It now also groups corrections by defName *across* files and fails when a shared
defName is given different values, while reporting agreeing repeats as a counted note rather
than a problem. Verified negatively: flipping one of the two to `Medieval` in a working copy
produced `defName "ASC_ManualLeader" is corrected by several source mods with different values`,
and the copy was restored (`git status` clean). The check is green on the real tree, with the
note "1 defName(s) corrected by more than one source mod, all in agreement".

## preTest — validated 2026-09-20

The blocker recorded earlier that day was misread. It said the 23 uninstalled mods made preTest
unverifiable, but that conflated two different things: whether the **declarations** are right,
which is what this transition asks, and whether each correction's **target** exists, which is not.
The second stays open and is recorded in `remaining`; the first can be settled for all 30.

- **Dependencies actually used: none, and none declared.** Not assumed: no assembly ships, only
  vanilla `PatchOperationAdd`/`Replace`/`Conditional` classes appear in any file, and every one of
  the 166 corrections is proven a no-op against a document without its target, returning it
  byte-identical (`Tests/Run.ps1`).
- **Identifiers: all 30 exist.** Checked against
  `../Rimworld-Cherry-Pick-App/data/mod-labels.json`, a classification of the installed corpus
  that is independent of these patch files, so a typo shared between a filename and its
  `loadAfter` entry would still show. None is missing, including the 23 whose mods are gone.
- **Casing does not matter, and this is evidence rather than lore.** That registry stores ids
  lowercased, so 19 of the 30 differ from it in case. RimWorld normalises: its own
  `ModsConfig.xml` holds 124 ids without a single uppercase letter, while `Udon.AnimalSimpleCommand`
  declares itself in mixed case in its `About.xml`. The game writes back what it parsed, lowercased.
- **Load order, and mandatory versus optional.** `loadAfter` and `Mod/Patches/` are the same 30
  names in both directions. Nothing is declared mandatory, which is correct: no mod is required,
  and the description says so.
- **LoadFolders: none, and none needed.** One flat `Patches/` folder, no version or DLC gating,
  consistent with conditional patches that all report `success: Always`.

## No other installed mod competes for these fields — checked 2026-09-20

TESTING.md scenario 7 worries that a third mod patching the same `techLevel` later in the load
order would silently win. Searched every installed mod's XML for the three defs that had drifted.
Two do patch them: `ferny.BetterArchitect` (through its bundled Animal Sarcophagus patch) and
`zal.mausoleum`. Both touch `designationCategory` only, neither touches `techLevel`, so neither
competes with this mod and neither explains the `Animal_Sarcophagus` value recorded as
`Medieval`. That value still matches nothing in the current data.

This covers the installed mods only, and one field on three defs. It is not a general proof that
nothing ever overrides a correction; the Pickle suite is where that would show, in a real load.

## The suite said "not installed" about the base game — fixed 2026-09-21

`Ludeon.RimWorld` became a source mod today (a hand-written patch for `Stonecutting`, by another
session). The unit suite printed `SKIP  Ludeon.RimWorld: not installed`, which was **false**: the
game is installed. My lookup of installed mods read the Workshop and `Mods` folders only, written
when no source mod was Core, and never looked in `Data/`, where Core and the DLCs live. A missing
root, reported as a missing mod.

Fixed by listing `RimWorld/Data` as a root. The run now reports `Installed source mods found: 8 of 31`
(7 before), and Core's checks run against the real def. **A correction to a figure I gave:** I first
wrote "112 -> 114 passed". A clean HEAD gives 112, and I could not reproduce 114; it was measured on a
working tree another session was editing at the time. The 8-of-31 line is the evidence, the test
count is not. Core's checks now run against the real def: `Stonecutting` declares `Medieval` itself in Core, which is the value the patch
records and the branch it takes. Before the fix that agreement had only been read by hand.

## Both passes have now run — 2026-09-21

`AUDIT.md` gained a rule the same day: a mod is validated over at least two passes, one **without**
its optional mods and one **with**, each named in the report, and the mod's TESTING.md has to say
how many there are and what each covers.

Read against that rule, the 5/5 below is **the "with" pass, and only that**. It was run before the
rule existed; calling it a named pass afterwards describes what it staged, it adds no evidence.

This mod makes the rule land oddly, and the odd part is the useful part. It declares no dependency
at all by design, so the pass *without* the optional mods corrects nothing and cannot prove a
single value. What it can prove is the promise the whole design rests on — that 166 corrections
with no target load, apply and log nothing — which until now was only ever checked in fixtures by
`Tests/Run.ps1`. **That pass ran at 11:33 the same day: 1 of 1, `exitReason: passed`, `setName: sans-facultatifs`.**
Eleven mods staged, not one of the thirty corrected, so all 166 corrections met a game holding
none of their targets: no error logged. `SuiteScanner` found 2 features in the suite and 1
scenario ran, which is the filter keeping `02-with-sources.feature` out of a staging where its
defs are absent by design - checked deliberately, because AUDIT.md records a case where that same
gap was silent truncation reporting green. Report kept in
one line in `docs/runs/history.md`; the report was not kept.

**Then replayed in the strengthened form, 12:08 the same day: 1 of 1, 5 steps of 5 PASSED**, against 2
in the morning. Target absent, nothing patched it, no warning attributed to this mod, no error.
`Tests/Pickle/Evidence/2026-09-21-bare-strengthened/` (`summary.json` and `junit.xml`). Only `no def ... exists` could
have failed for a mod that did nothing at all; `no warnings from mod` was never shown able to
fail, since none was produced to catch.

What the *first* run left open, kept for the record: two things it does not settle, and neither is hidden. It proves no `techLevel` value at all -
there is no def to read - and the scenario as played was still the weak form, `mod is loaded`
plus `no errors were logged`, which a mod doing nothing whatever would also pass. A strengthened
form was drafted while the ticket was queued and deliberately not applied: editing a feature with
a ticket in the queue plays something other than what was submitted. Applying it needs another
pass, and a pass costs the shared machine 45 minutes of queue.

One thing had to change before it even became reachable: the suite's map was named
`wsl-deps.map`, which `stage-pickle-wsl.sh` stages on *every* pass. With that name the three
source mods are present whether asked for or not, and a bare pass does not exist. Renamed
`wsl-deps.sources.map` and selected with `-DepMap`. The feature file was split to match:
`01-alone.feature` holds what holds with no targets, `02-with-sources.feature` the rest.

Two faults in the shared harness turned up while checking that rule, both reported and both fixed
the same day by the session that owns it: `Run-PickleWsl.ps1` had been committed in a state
PowerShell refuses to parse at all, and the empty `PICKLE_DEPMAP` above fell through `:-` to the
default map, so **no mod owning a `wsl-deps.map` could have a bare pass**. Rebuilt at `b8a78203`,
with `none` as an explicit sentinel; re-checked here with `[Parser]::ParseFile`, which now reports
no errors. The flag is `-DepMap`, singular - the near-duplicate `-DepsMap` is gone.

Not measured, and not to be implied either way: whether the 30 corrected mods can coexist. Three
are staged, 23 are not installed. If an incompatibility turns up it earns its own named map.

## The Pickle suite is green — 2026-09-21, 5 of 5

Run headless in the WSL game through `scripts/Run-PickleWsl.ps1 -Mod TechLevelFixes`.
Report kept as text at `Tests/Pickle/Evidence/2026-09-21-sources/summary.md`. The 4-of-5 run of the day before has no valid
report: the file saved for it belonged to another mod (see "Corrections to earlier claims" above).

| Scenario | Outcome |
|---|---|
| the mod is loaded and says nothing | Passed |
| it loads after the mods it corrects | Passed |
| a def that had no level anywhere gets one | Passed |
| a def that declared its own level has it replaced | Passed |
| an inherited level is overridden, not merely shadowed | Passed |

**The one that justified running a game at all.** The 36 Ancient Amulets defs declare no
`techLevel` and inherit `Medieval` from `AmuletBase`. The patch adds a node beside that inherited
value, and which of the two the loaded def reports is settled when the game resolves `ParentName`,
after patching. The added node wins. No headless test could establish that: `Tests/Run.ps1` sees
the node appear in the XML, and asserting it also wins would only test this repository's own
inheritance model against itself.

**What the earlier failure was, and what it taught.** The 4-of-5 run failed on an assertion of
mine, not on the mod: `ABooks_ArmyManual` names both a `ThingDef` and a `HediffDef`, and Pickle's
`field` step takes no def type. Its error message suggests an `of type` form, which exists only
for `exists` — following it produced an undefined step, one wasted run. 12 of the 23 corrected
Alpha Books names are shared with a hediff that way, so the assertion moved to
`ABooks_PsychologyBook`, a `ThingDef` and nothing else. The patches were never exposed to this:
every generated xpath names its def type, which is precisely what makes them right, and
`Tests/Run.ps1` requires a single match for that typed xpath.

**Four faults stood between the suite and its first run**, none of them in this mod: the staging
script did not carry `loadAfter` mods; an apostrophe in the companion mod's display name killed
bash; the run filter arrived truncated at its first space; and the machine was contended all
evening. The first and third were fixed by the session that owns the shared tooling, the second
here, and the fourth by waiting.

## preTest -> done, validated 2026-09-21

All four kinds of test are written, executed and green against the shipped tree:

| Kind | Result |
|---|---|
| Functional scenarios | `TESTING.md`, 8 with preconditions, actions and expected results |
| Automated | `Tests/Run.ps1` — **107 passed, 0 failed** |
| XML | `Tests/Check-Patches.ps1` — **pass**, 30 files, 166 corrections |
| Pickles / Gherkin | `Tests/Pickle/` — **5 passed, 0 failed** |

Nothing is claimed not-applicable. `done` means ready for final functional validation in game,
not already played through: the 8 scenarios of `TESTING.md` remain for a human to walk, and that
is what `done -> tested` asks for.
## Patches outlive their mods, on purpose

Stated by the user on 2026-09-20: the patches and recorded values for mods that are not currently
installed are **kept**, because those mods go back in when the playthrough reaches the tech level
they belong to. The modlist is gated by tech level and moves over time; this mod's corrections are
written once and wait.

So "23 of the 30 source mods are not installed" is not content to prune, and an audit must not
propose pruning it — an earlier version of this session did, wrongly. It is a checking gap that
closes by itself when a mod comes back.

**Accepted by the user on 2026-09-21.** Both gaps that follow from this - the 23 uninstalled
mods' defNames never confronted with their sources, and the unit tests covering those 23 by
fixture only - were put to the user and knowingly accepted. They move to `accepted:` in the front
matter, unchanged in substance: neither was measured, and accepting one is not the same as closing
it. What makes them acceptable is that they shut by themselves, a mod at a time, as the playthrough
advances and each returning mod is checked against its own source. The suite keeps printing SKIP
for them rather than PASS, so the record stays honest about what was never checked.

This also makes one property load-bearing rather than incidental. Every generated operation is a
`PatchOperationConditional` reporting `success: Always`, so a correction whose target is absent
does nothing and says nothing. That is what lets thirty files sit in the folder while most of
their mods are out of the list. `Tests/Run.ps1` exercises it for all 166 corrections, against a
document that does not contain the def, asserting both that `Apply` reports no failure and that
the document comes back byte-identical.

## Stale starting levels — measured against cherrypick itself, 2026-09-20

Each generated correction carries a `defName : from -> to` comment recording the level the def
had when cherrypick arbitrated it. The user confirmed those values are meant to match current
sources, and then asked for cherrypick to be re-run on the current list.

**Re-running it means `scan`, not regeneration.** The engine at
`../Rimworld-Cherry-Pick-App/engine` offers `list`, `scan`, `view`, `close` and `toggle`. There
is no generate command; `picker/README.md` still lists *la génération du mod* under what is to
come. So the patch files under `Mod/Patches/` cannot be rebuilt by the tool today, and nothing
here was rewritten. What the tool can do is report the level each def resolves to now, which is
exactly the oracle these corrections were written against.

`dotnet engine/bin/Release/net8.0/cherrypick.dll scan <packageId>` over the seven installed
source mods, compared against the recorded values:

| source mod | corrections | agree |
|---|---|---|
| `LadyElizabeth.AdditionalToolsMod` | 6 | all |
| `Romyashi.AncientJunkLoot` | 6 | all |
| `sarg.alphabooks` | 23 | all |
| `Udon.AnimalSimpleCommand` | 4 | all |
| `Mlie.AdvancedRaiders` | 1 | **none** |
| `overpl.AnimalSarcophagus` | 2 | **none** |
| `zal.ancientamulets` | 36 | **none** |

**39 of 78 checkable corrections disagree**, and they cluster by mod rather than scattering.

**Two shapes, and only one of them has an explanation.** The 37 that read *recorded none, now
Medieval* are all defs that inherit their level: cherrypick reports `TechLevelFrom` as
`AmuletBase` for the amulets and `ApparelNoQualityBase` for the belt. A generation pass that
read the def’s own XML rather than the resolved value would record exactly that, which points at
those files predating the inheritance resolution the picker now advertises. The two
`Animal_Sarcophagus` entries run the other way — *recorded Medieval, now none* — and that fits
neither: the def declares no level in any of its four version folders, and `BuildingBase` gives
it none either, so `Medieval` is unreachable from the current data by any route.

**The harness agrees with the tool, def for def.** Every value in the "now" column above was
produced independently by `Tests/Run.ps1`, resolving `ParentName` itself, before cherrypick was
consulted. The two match on all 78. That is worth more than either alone: the unit tests can be
trusted as a standing check without the engine, and the engine confirms they are not measuring
their own assumptions.

The tests are left failing rather than relaxed. They now list every drifted def per mod instead
of stopping at the first, which is what turned "three defs" into three dozen.

### Repaired by hand, 2026-09-20

At the user’s instruction, since the tool cannot regenerate. **Only the recorded `from` value in
each comment was rewritten** — 39 comments across three files, nothing else. Verified two ways:
the files differ from their previous state only on comment lines, and the operations below them
are byte-identical.

That the operations needed no change is the design working as intended. Each one already carries
both branches, `PatchOperationReplace` when the def has a level and `PatchOperationAdd` when it
does not, and the game picks between them at load time. So whether the def started with a level
never affected the outcome; it only affected what the comment claimed. None of the 39 became a
no-op either: the amulets now read `Medieval -> Neolithic` instead of `(aucun) -> Neolithic`, the
belt `Medieval -> Industrial`, the two sarcophagi `(aucun) -> Neolithic`. Every correction still
changes something.

Both suites are green: unit tests **107 passed, 0 failed**; the XML suite passes. Re-checked
against `cherrypick scan` afterwards as well — 39 re-checked, 0 still disagreeing — so the
repair matches the engine, not just the harness that found the drift.

**These files say they are generated and must not be hand-edited**, and that warning still holds
for anyone else: the next cherrypick pass over these three mods will rewrite them whole, and
should then produce these same values by itself, since it resolves inheritance. This edit is
recorded here so that a later reader does not mistake it for generator output.

## Unit tests — 2026-09-20

`Tests/Run.ps1` builds and runs `Tests/TechLevelFixes.Tests.csproj`: **104 passed, 3 failed,
44 seconds**, against the working tree. The three failures are the finding above, not a fault in
the harness. Written after the user’s correction that unit tests
come first and Pickle does not replace them, for two concrete reasons — a Pickle run takes over
the machine with real pointer input, and it takes minutes.

**What is genuinely under test.** The suite builds the shipped `<Operation>` blocks into
RimWorld’s own `PatchOperationConditional` / `Replace` / `Add` objects by reflection and calls
`Apply`. The operations, their xpaths, their branch structure and their execution are the
game’s; only the documents are ours. Per source mod:

- the **replace** branch, from a fixture whose techLevel is deliberately never the answer;
- the **add** branch, from a fixture with no techLevel, checking the rest of the def survives;
- a **missing target**, checking `Apply` reports no failure and leaves the document byte-identical
  — the executable form of README.md’s promise that a correction whose item is missing does nothing;
- for the source mods installed, the operations against that mod’s **real def XML**, assembled
  from the folders 1.6 would actually load. This is the check that would catch a renamed defName
  or an xpath whose casing no longer matches upstream.

`PatchOperation.Apply` opens a `DeepProfiler` section that needs the game’s infrastructure, so
the profiler is Harmony-patched to a no-op for the run. That is the only thing bent to make these
headless, and it is outside the operations themselves.

**A tautology found and removed.** The first version drew both the operation and the expected
value from the same file, so flipping a correction’s techLevel in a working copy still passed:
it only asserted that the patch does what the patch says. The generated files also carry a
`defName : from -> to` comment, which is written independently of the XML below it, so the suite
now asserts the comment and the XML agree. Verified: the same flip is now caught as
`sarg.alphabooks/ABooks_AdventuringLogs: comment and XML disagree`. A renamed defName is caught
too, against real data: `Apparel_BlueScreenBeltX should exist exactly once ... got <0>`.

**The starting-level check, dropped then restored.** Comparing the comment’s recorded *starting*
level against the installed mod was written, then removed as unreproducible, then restored once
the user confirmed those values must match current sources. It resolves `ParentName` the way the
game does, through the mod’s own abstract bases first and vanilla’s after. Walking every vanilla
def file for that map cost 65 of the run’s 106 seconds, so the map — a name, a level, a parent —
is cached beside the build output and rebuilt only when the game’s data changes; the run is back
to 44 seconds. It currently reports the three corrections above.

**Scope limit, not a pass.** The real-def check ran for the 7 source mods installed on this
machine on 2026-09-20 and prints `SKIP` with a reason for the other 23, which are covered by
fixtures only. The installed set is moving: `starter.beeer` and `zal.alchemy` were present on
2026-09-17 and their Workshop folders are gone today.

## Pickle tests — written, then cut back 2026-09-20

**First a false claim, corrected.** On 2026-09-17 this file claimed the pickles gate was written
and green, on the strength of a `Run-Gherkin.ps1` of my own. Reading `../AUDIT.md` settled that
Pickle is a real RimWorld mod playing Gherkin inside the running game; my script was a static XML
checker in Gherkin syntax, duplicating `Tests/Check-Patches.ps1`. Deleted (recoverable at
`80f3e48`), and a real suite written in its place.

**Then most of that suite deleted too.** The replacement generated one scenario per corrected mod
from `Mod/Patches/`: 30 scenarios, 166 assertions. `AUDIT.md` at `d89fcce1` then made the rule
explicit — keep in Gherkin only what a running game alone can show, and a scenario restating what
a unit test proves *is to be deleted, not kept just in case*, because every run confiscates the
machine. The unit tests of the same day prove all 166 corrections headless in under a minute, so
the generated feature and its generator were removed.

**What is left**, `Tests/Pickle/`, five scenarios: the mod is loaded and logged nothing; the load
order the game actually settled on; and three corrections checked in a **full modlist**, where
every active mod's patches meet in one document.

The third of those is the one that earns its keep, and it was only spotted while retargeting the
file on 2026-09-20. The 36 Ancient Amulets corrections declare no `techLevel` of their own and
**inherit** `Medieval` from `AmuletBase`, so the patch fires its add branch and places a node
*beside* an inherited value. Which of the two the loaded def reports is settled when the game
resolves `ParentName`, which happens **after** patching. A headless test can watch the node
appear — and `Tests/Run.ps1` does — but it cannot say the node won; asserting that with this
repository's own inheritance code would only test the model against itself. That is a live-game
question, and now the only structural gap the unit tests leave.

Retargeting was itself a repair: the file named Glitter-Craft and Alchemy, both since removed
from the modlist, so it could not have run at all. Every assertion in it is now re-checked
against the shipped patches.

It compiles nothing: `mod is loaded`, `loads after`, `def field is` and `no errors were logged`
are all built into Pickle, which is how a mod with no C# of its own can have a suite at all.

**Executed 2026-09-21: 5 of 5.** Run headless under WSL, with the machine reserved and the
run lock held; see "The Pickle suite is green" above and `docs/runs/history.md`.

### Reservations (non-blocking)

- (2026-09-17, superseded 2026-09-20: both images now exist and were inspected;
  see "Images audit" and "Resize" above.)
- The `loadAfter` list is long (29 entries) but every one is declared optional in
  the description; `dependencies: none` reflects that as read. Confirmed
  2026-09-17: every patch operation across the tree uses only the vanilla
  `PatchOperationAdd`/`PatchOperationReplace`/`PatchOperationConditional`
  classes, no framework-namespaced `Class` attribute, so there is no hidden
  technical dependency either — this has not been re-verified against each
  source mod's current `packageId` on Steam, only against the patch XML itself.
