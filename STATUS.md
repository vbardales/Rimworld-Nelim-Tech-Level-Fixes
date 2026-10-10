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
workflow_stage: followUp[1.0.2]
licence:      original
upstream_mod_remotes:
  - N/A  # no origin project: the patches are original, the source mods are only the targets of a correction (audit 2026-10-07)
licence_at:   2026-09-17, verified by inspection: the shipped content is a set of original XML patches (techLevel corrections keyed by other mods' defNames), no third-party code, text or art copied in. User-stated convention: a `Nelim`-prefixed mod name defaults to private; user explicitly validated a one-off exception to public for this mod on 2026-09-17
dependencies: none  # verified 2026-09-20: no modDependencies declared and none used
showcase:     complete
tested_on:    2026-10-08, tree of `324e9ec` (49 patch files), Pickle in the WSL: bare pass 1 of 1 and sources pass 5 of 5, both `exitReason: passed`, scenario names read; reports in `Tests/Pickle/Evidence/2026-10-08-bare` and `-sources`. Logs read: no error or warning attributed to this mod (only the companion test mod's missing dependency URL); the sources log's errors come from other mods (KCSG, VEF, Alpha Books cross-references)
workshop:      3806765254  # the item: 0.1.0 pre-publication of 2026-09-23, 1.0.0, 1.0.1 and 1.0.2 uploaded 2026-10-08; public
remaining:
  - for the next release, owner decision 2026-10-10 (no version for images alone): publish the transparent `Mod/About/ModIcon.png` and the regenerated `Mod/About/Preview.png` (badge `translate` -12.5%, 12.5%; `Art/Gallery/0-preview.png` is its byte copy). Not on Steam yet: the CI sends the Preview only with `update_preview=true` in the dry-run and `--preview` in the dispatch (the ModIcon leaves with `Mod/`), so it needs a version number, its dry-run on the exact commit and the owner approval of `steam-production`. Changelog entry waits under `[Unreleased]`
  - reservation 2026-10-08, not a defect: Better Cribs (`Capi.bettercribs.biotech`) and BetterManger (`Eiten.BetterManger`) stop at RimWorld 1.4, so on 1.6 their defs are not loaded and the corrections for `BasicCrib`, `PillowCrib`, `EtnManger` and `EtnMangerSingle` stay inert. The unit suite checks their defNames against their 1.4 folder (`EffectiveVersion` in `Tests/PatchTests.cs`)
  - unverified 2026-09-26: the sources pass mounts 3 of the 45 source mods this mod lists in `loadAfter`; AUDIT.md defines the pass "with the optional mods" as all of them. A reservation, not a defect: the unit tests cover the others (15 against their real defs, the rest against fixtures)
  - partial, for transition 10 (`tested -> prepublished`), not a defect of `done`: the manual publish workflow is now generated (`.github/`, template stamp `a8ca11cdd9a3`) and `About.xml`'s description is synced from `PUBLICATION.md` (68/68 CI script tests pass). Dry-run green: run 37768986059 on 80606e8e5208004f82114340701ba5961e53488b (1.0.0, nothing sent to Steam; the repo default branch was renamed master to main first, the workflow checks origin/main). Not done: `steam-production` (the owner's alone), and `tested` itself
  - reservation, visual, not a defect: at 32 px the ModIcon's face and gear rim are distinguishable but its engraved text strip is not readable; the owner asked on 2026-09-20 to keep that text
accepted:
  - accepted 2026-09-21 by the user (23 uninstalled source mods then, 30 of 45 on 2026-09-26): the corrected defNames of the uninstalled source mods have never been confronted with their sources; only the 7 installed mods’ defNames were, and all resolved. Knowingly accepted rather than closed: the gap shuts by itself when a mod returns to the modlist, and the check reruns then. See "Patches outlive their mods"
  - accepted 2026-09-21 by the user (23 of 30 then, 30 of 45 on 2026-09-26): the unit tests check the uninstalled source mods against synthetic fixtures only; the real-def and starting-level checks ran for the 7 installed on 2026-09-20 and report the rest as SKIP rather than passing them. Knowingly accepted on the same ground, and the SKIP is deliberate - the suite never reports an unchecked mod as passing
session:      local_6110f62e-6527-4fc1-abea-12d73abe74f0
updated:      2026-10-10: ModIcon and Preview publication kept in `remaining` for the next release, owner decision (no version for images alone). Previous: 2026-10-08: Mod/About/ModIcon.png recropped at the owner's request (black border background made transparent, canvas trimmed to the art, 128x128, 21.9 KB, from Art/ModIcon-source.png); not deployed yet, ships with the next publish together with the Preview (update_preview). Previous: 2026-10-08: 1.0.2 uploaded (publish run 37789170249 approved by the owner; tag v1.0.2 and release by the CI on b5036b67ce2b18bb4be488220ec3396d151ca77f); item public, description links fixed. Previous: 2026-10-08: 1.0.2 prepared to fix description links shown as raw Markdown (converter and the underscore of `lime_time`): dry-run green, run 37788999704 on b5036b67ce2b18bb4be488220ec3396d151ca77f, 7974 bytes; publish run awaits approval. Previous: 2026-10-08: item set public by the owner, stage `published`. Previous: 2026-10-08: 1.0.1 uploaded to Steam by publish run 37787677923 (approved by the owner; tag v1.0.1 and release created by the CI on 0c6e4fffad615a8bf2d3b0e0b1d2325d30f82419); the page description now names the corrected mods; item still private, stage stays `prepublished`. Previous: 2026-10-08: 1.0.1 prepared (description names the corrected mods with links and authors): dry-run green, run 37787478553 on 0c6e4fffad615a8bf2d3b0e0b1d2325d30f82419 (after the wording review; supersedes earlier 1.0.1 dry-runs), update_description=true, 7981 bytes; not published yet. Previous: 2026-10-08: 1.0.0 uploaded to Steam by publish run 37770622317 (approved by the owner; tag v1.0.0 and release created by the CI on 80606e8e5208004f82114340701ba5961e53488b); item still private, stage stays `prepublished` until subscription test and public switch by hand. Previous: 2026-10-08: stage `prepublished` set before the publish run 37770622317 is approved (dry-run 37768986059 green on 80606e8; the run was dispatched a few minutes before this field was set). Previous: 2026-10-08: both Pickle passes green on `324e9ec` (bare 1/1, sources 5/5); step 9 criteria met (no `@wip`, no conditional scenario, no manual test left): stage `tested`. Next: `tested -> prepublished` (dry-run of the exact commit, `steam-production` by the owner)
code_review_sha: 28b3f7e571361bcfb3f400d12f15a6e0da201640  # 2026-10-10, range e3c58cd..28b3f7e, no findings: no patch file, no code touched; Preview.config.json badge translate, regenerated Preview/ICO, docs only; one corrupted character fixed in CHANGELOG (1.0.2 entry)
publication_changelog_review_sha: e6178082334aec4511697edac8e561c4781c0913  # owner review of PUBLICATION.md + CHANGELOG.md, confirmed in chat 2026-10-10. Covers the Steam description of 1.0.2 and the [Unreleased] ModIcon/Preview entry
protocols_read_sha: 80ee01299918bd5fd757286ce3489a370cb4351d
social_preview_sha256: 07def70bc9f87fe63a79d03a4b5373a3a47b78689ad322ebe504aac665e4d0a3  # 2026-10-10, GitHub og:image checked byte-identical to Mod/About/Preview.png
echo_review_sha: fe2f03190044a52bc5f069bd9e57fc42071da3ef  # 2026-10-10, validated by the owner: echo.png (workbench of tools line-art) kept, conceptual, the mod has no gallery capture
---

# Nelim's Tech Level Fixes: status

Current state only. The dated journal (audits, runs, repairs, standing decisions such as "Patches outlive their mods") is in [`docs/runs/status-journal-to-2026-10-09.md`](docs/runs/status-journal-to-2026-10-09.md); run proofs in `docs/runs/history.md`.

- Published: 1.0.2 on Steam item 3806765254, public. Tag v1.0.2 by the CI.
- New `ModIcon.png` and `Preview.png`: owner decision 2026-10-10, not worth a version of their own, so they wait in `remaining` for the next release. They are in the repository and GitHub; Steam still shows the previous ones until the next release carries them (`[Unreleased]` in CHANGELOG.md, `update_preview` then).
- Owner review of PUBLICATION.md + CHANGELOG.md: confirmed 2026-10-10 (`publication_changelog_review_sha`).
- Last green: unit 190/0 and both Pickle passes on `324e9ec` (2026-10-08).
- Source mods to integrate later (not installed, levels provisional): BEER (Fermenting Tank) 3793220704, Belt Flashlight 3403230282, Beds Plus [v18] 1360708265, Better Survival Meals (Continued) 2063417558, BetterCoolers 1430093399, Better Tool Cabinet 3538193748. Details in the journal, "Mods to integrate later".

## Audit: 2026-10-10

Revision audited: `a2d40bc` (clean tree, `main` = `origin/main`). `AUDIT.md` and `AGENTS.md` read; `protocols_read_sha` 06263cb0. No RimWorld, no Pickle process launched.

Stage kept: `followUp[1.0.2]` (was `published[1.0.2]`, same state, new vocabulary). No `Mod/` change since the audited review range, so `code_review_sha` stays valid.

| Control | Result |
|---|---|
| `Tests/Check-Patches.ps1` | PASS: 49 files, 240 corrections, 49 `loadAfter`, 2 shared defNames in agreement |
| `Tests/Run.ps1` | 190 passed, 0 failed; the uninstalled source mods are reported SKIP (accepted, see journal) |
| `.github/tests` | 71 of 71 pass |
| `Check-Status.ps1` | 0 error, 1 warning (`publication_changelog_review_sha` stale) |
| `Preview.png` vs `Art/Gallery/0-preview.png` | identical sha256 `e77fdf63…3879` |
| `LICENSE`, `ATTRIBUTION.md` | identical to `Mod/` copies |
| ModIcon | `ModIcon.png` (23:03:16) newer than `ModIcon-source.png` (23:03:15): derivative current |
| Root and `Mod/` hygiene | `desktop.ini` ignored, none tracked; only `Art/ModIcon.ico` and `Art/Preview.ico` tracked, outside `Mod/` |
| `About.xml` | 1.6 only, no `modDependencies`, URL on the canonical repository |

Open, none a defect of `followUp`:
- Owner re-review of PUBLICATION.md + CHANGELOG.md (`publication_changelog_review_sha`).
- Publish the new `ModIcon.png` and `Preview.png` (see `remaining`).
- Branches (14.d), done 2026-10-10: `origin/ci/add-publish-workflow` deleted (its commit a05da63 is superseded by `.github/` on `main`: 24 files identical, 3 newer on `main`); `origin/master` was already gone. Only `main` remains.
- Before `dormant` (14.a, 14.c): non-regression replay, WSL cleanup, `TESTING.md` and `PUBLICATION.md` trimming.
- `social_preview_sha256` set 2026-10-10 (GitHub social preview verified identical to the current Preview). `echo_review_sha` set 2026-10-10: the owner validated the echo (kept, conceptual: no gallery capture shows the subject).

### Full audit, second pass: 2026-10-10 (HEAD `fe4f675`, protocols read at `80ee0129`)

Stage kept: `followUp[1.0.2]`. Not `dormant`. No RimWorld, no Pickle launched.

| Control | Result |
|---|---|
| `Check-Patches.ps1`, `Run.ps1`, `.github/tests`, `Check-Status.ps1` | PASS; 190/0 (20 of 49 source mods installed, the rest SKIP); 71/71; 0 error, 0 warning |
| `workflow_stage` vocabulary, `stage` field | current (`followUp[1.0.2]`), retired field removed |
| Reviews | `code_review_sha` current (no `Mod/` commit since, AUDIT 8.m); `publication_changelog_review_sha` confirmed by the owner in chat; `echo_review_sha` set; `social_preview_sha256` set and verified against GitHub `og:image` |
| Em dash rule (2026-10-10) | none in `About.xml`, the Steam description, README, CHANGELOG, PUBLICATION, STATUS, TESTING, the Pickle READMEs, PROTOCOLS-READ. Left: two generated `.github/tests` files and the archived journal |
| 13 (`publish -> followUp`) | `PublishedFileId.txt` committed (3806765254), item public, runs recorded; the subscription test of the item is not recorded in this repository (unverified) |
| 14.d branches | only `main`, local and remote |
| `Mod/` since the Pickle passes (`324e9ec`) | only `About.xml` (description text), `ModIcon.png`, `Preview.png`; no patch file |

Open before `dormant`, none a defect:
- 14.a: post-publication non-regression replay not played (`docs/runs/history.md`); 1.0.1 and 1.0.2 touched no patch file.
- 14.c: WSL cleanup (mods downloaded by this mod's sessions) not done or not recorded; `TESTING.md` "What has run" and `docs/runs/` to trim when going dormant.
- Next release: ModIcon and Preview (see `remaining`).
