# Changelog

Format inspired by [Keep a Changelog](https://keepachangelog.com/en/1.1.0/).
This file serves the repository and the writing of Steam patch notes; RimWorld does not display it in game.

## [Unreleased]

### Added

- Repository documentation: README, ATTRIBUTION, LICENSE (MIT), this changelog.

## [1.0.0] — 2026-09-17

First version. RimWorld 1.6.

### Added

- 163 tech-level corrections across 29 source mods, one generated patch file per mod under
  `Mod/Patches/`, each arbitrated item by item with the cherrypick tool.
- Loads after every corrected mod (`loadAfter` in `About.xml`); none is a hard dependency, and a
  correction whose target item is missing does nothing.
