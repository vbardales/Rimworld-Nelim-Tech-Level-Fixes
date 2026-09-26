# Protocols and documents read, and in which version

Written by the session of this mod on 2026-09-26, at the request of the owner, so that a document that has not moved is not read
twice.

**How to use it.** `docs/Check-ProtocolsRead.ps1` recomputes the SHA-256 (first 12 hex) of every file in the tables below and prints
the ones that moved. Read again only those, and the ones marked "read every time". The *version* column is the last commit that
touched the file. For the protocol documents it was read with
`git --git-dir=../rimworld-protocols.git --work-tree=. log -1`: `WELCOME.md`, point 5, says a plain `git log` from the monorepo
returns the commit that *removed* them, a plausible hash pointing the wrong way. The first pass of this session fell for it and
was redone. The others were read with `git log -1` in the repository that carries them.

Paths are relative to the collection root, `Documents\rimworld`. Everything below was read in full. **Useful now** is a judgement
about this mod at its present stage (`done`, `tested` not reached), not about the document.

## Protocols (repository `vbardales/Rimworld-protocols`, work tree = the collection root)

| File | Version (commit, date) | SHA-256 | Useful now | What was retained |
|---|---|---|---|---|
| `AGENTS.md` | `3a1d2cb` 2026-09-24 | `36631e730433` | yes, every session | Evidence: keep the latest report per scenario **for the revision now in the repository** and delete the rest as soon as a newer one replaces it; reports are gitignored and the disk is full; delete an archive of one's own run and leave the others (`keep.txt` marks one held); history is **one text line per run in `docs/runs/`, never folders**; never delete a report a `STATUS.md` field points to (repoint first); list what goes and what stays before deleting. Publishing goes through CI: a session may launch `publish` with `dispatch-publish.sh`, only Virginie approves it |
| `AUDIT.md` | `4f034f5` 2026-09-26 | `d5dc23b06e35` | yes, read every time | The chain now ends `tested -> prepublished -> published`. `done` needs the Pickle scenarios *written*; `tested` needs them *run and green* on the shipped revision, the `@review` captures opened, no `@wip`, every `@requires` played in a pass that mounts it, and **no manual test left** (automated and green, or listed not applicable with its reason). **"On ne teste pas le jeu"**: what RimWorld does by itself (activating or removing a mod, loading a save) is not the mod's to test. At least two passes (without / with the optional mods), one more per exclusive combination and per declared incompatibility. Runs are **requests** (`Submit-PickleRun.ps1`), never launched by a session; a request carries no SHA, so the tree stays frozen until `RUN_DONE`. A `0.1.0` prepublication may come at any moment: `CHANGELOG.md` then gets `## [0.1.0]` "creation of a publishIdFile" and `1.0.0` stays unreleased above it. The session title is `<mod name> / <stage>` |
| `PUBLISHING.md` | `4f034f5` 2026-09-26 | `7d34f55d583d` | yes now; the rest at transition 10 | **A pathspec goes on `git commit`, not on `git add`; the index is shared between sessions** (three sessions lost commits to it on 2026-09-04), and `git status` is re-read after the commit. `PublishedFileId.txt` is committed at once. The description is sent **once, at creation**: the 0.1.0 item carries whatever About.xml said then. It must end with `[url=...]Source code on GitHub[/url]` and carry `IF I GO QUIET`, `AI-GENERATED`, `THANKS`. Documentation, commits and comments in English. Both `ATTRIBUTION.md` copies compared by hash |
| `TRANSLATIONS.md` | `f5c2d9d` 2026-09-25 | `298f74d226da` | no, already applied | Inventory of every player-facing text; the three `STATUS.md` fields. This mod adds none (only `techLevel` values), so `not_applicable` stands |
| `MOD_SETTINGS.md` | `b83933b` 2026-09-23 | `404916bc99a7` | no, already applied | `settings_audit`; the absence of C# alone is not evidence. This mod has no settings, and neither an empty page nor a shortcut: checked against the tree (no assembly, no Defs, no Languages) |
| `STYLE_RIMWORLD.md` | `7311308` 2026-09-25 | `de13cbe5e1f9` | partly | The 32 px icon check is a control, never a generation (done today, see `STATUS.md`). The overlay rules of 2026-09-25 postdate this mod's Preview (engraved 2026-09-20, text at the bottom-left, where the spec now says top-left or bottom-right). Already-engraved previews keep their veil until the mod is reworked, so this is not treated as a defect |
| `WORKSHOP_COMMENTS.md` | `968de6f` 2026-09-26 | `6c69a05bb424` | later (transition 10) | One thank-you comment per Workshop page across the whole collection; **every integration named or listed in `loadAfter` needs a register entry**. This mod lists 45 source mods and none of them is in the register yet. Voice, 150 to 350 characters, at most three a day |
| `scripts/SEARCHING.md` | `372c447` 2026-09-23 | `9dbd52b2bcd4` | no | Use `scripts/Search-Workshop.sh` for a corpus search, never a hand-rolled `grep -r`. Not needed: this audit searches no corpus |

## Pickle and dispatcher documents (their own repositories)

| File | Version (commit, date) | SHA-256 | Useful now | What was retained |
|---|---|---|---|---|
| `PickleTools/README.md` | `c771bef` 2026-09-25 | `628350c7bcc3` | partly | The tools are companion mods staged by one line of a pass map; this suite stages none. `LoadAudit` asserts a clean mod load and is not adopted: the built-in `no errors were logged` and `no warnings from mod` are used instead |
| `PickleTools/Headless/README.md` | `cfa7aac` 2026-09-26 | `488a0bb2ca83` | yes, read when a run is planned | Launcher exit codes (0 is not a validation; 7 is an abandoned queue, replayed; 2 machine busy). `-DepMap` picks a pass and **nothing is read without it, not even a `wsl-deps.map`**; a map must end with a newline or its last line is silently lost. `-EvidenceDir`; keep `summary.json` and `junit.xml`, not `report.html`. `-Then` and `-ThenWithout` are for restart and removed-mod tests, which "On ne teste pas le jeu" rules out here |
| `PickleTools/docs/steps.md` | `cba3ca1` 2026-09-25 | `0f897b4557a9` | no | Generated catalogue of the tools' steps. None is used. Pickle's own steps are in its catalogue |
| `Rimworld-Release-Admin/docs/OPERATIONS.md` | `f196148` 2026-09-25 | `f6f85474f6d3` | later (transitions 10 and 11) | Dry-run of the exact commit first, run ID and SHA recorded; `publish` with a 40-character SHA, approved by Virginie only. `bootstrap-release.sh` skips a repository without `Source/*.csproj` and `Mod/README.template.md`, which is this mod's case, so the manual workflow (`generate-publish-workflow.sh`) is the route. Its `--require` example names `Defs` and this mod has no `Defs`, only `Patches`. The gallery is manual |
| `Rimworld-Ticket-Dispatcher/docs/WELCOME.md` | `84a20e6` 2026-09-26 | `ab7e316c745b` | yes, read every time | Small fix tickets, a complete pass only for an initial or final validation; `Submit-PickleRun.ps1`; no monitor, no cron; a request carries no SHA (put it in `-Label`); **`REGISTER local_<id> <Mod>` to TicketDispatcher on first use**; delete evidence with `robocopy <empty> <target> /MIR`; point 5, the note this file answers |
| `Rimworld-Ticket-Dispatcher/docs/SUBMIT.md` | `c0a73a2` 2026-09-25 | `90b7385b1bda` | yes, when a request is filed | Every option. `-DepMap` takes a file name, never a relative path (two TailorMade runs were lost to that); a request with no `-DepMap` is the bare pass; `-EvidenceDir` must be a fresh folder; exit code 0 is not a validation |

## This mod's own documents

| File | Version | SHA-256 (n/a: changes with every session) | Status |
|---|---|---|---|
| `TechLevelFixes/STATUS.md` | rewritten 2026-09-26 | n/a | Kept by this session. The uncommitted work of 2026-09-22 was folded in and corrected where the tree disagreed |
| `TechLevelFixes/README.md` | see `git log` | `48f11960b6c5` | Read |
| `TechLevelFixes/CHANGELOG.md` | restructured 2026-09-26 | n/a | `[0.1.0]` is the publishIdFile; `1.0.0` stays under `[Unreleased]` |
| `TechLevelFixes/ATTRIBUTION.md` | see `git log` | `fed142408c3e` | Read. Identical to `Mod/ATTRIBUTION.md` (compared by hash) |
| `TechLevelFixes/LICENSE` | see `git log` | `ae6ae5fa894c` | Read. Identical to `Mod/LICENSE` (compared by hash) |
| `TechLevelFixes/TESTING.md` | rewritten 2026-09-26 | n/a | Three families of passes; scenarios 5, 6 and 8 not applicable with their reasons |
| `TechLevelFixes/Mod/About/About.xml` | see `git log` | `50d9d95fe1d5` | Read. Its description lacks `IF I GO QUIET`, `AI-GENERATED` and `THANKS`, and the 0.1.0 item already carries it: to be corrected through `PUBLICATION.md` and the CI at transition 10 |
| `TechLevelFixes/docs/runs/history.md` | created 2026-09-26 | n/a | One line per run |
| `TechLevelFixes/Tests/Pickle/README.md` | updated 2026-09-26 | n/a | Evidence is no longer in git |

Named in the request and **absent from this repository**: `PUBLICATION.md` (required at transition 10, nothing to do before),
`BACKLOG.md`, `NOTES.md` and `BUGS.md` (no protocol read requires them; the monorepo's own `BACKLOG.md` is not this mod's).
