# The pass without the optional mods: Core, the DLCs, Harmony, RimLogging, Pickle and this mod,
# and nothing else. No corrected mod is staged, so not one of the 166 corrections has a target.
#
# That is not a degenerate case for this mod, it is its central promise. Every generated operation
# is a PatchOperationConditional reporting success: Always, which is what lets thirty patch files
# sit in the folder while most of their mods are out of the modlist. `Tests/Run.ps1` proves the
# XML side of it - the document comes back byte-identical - but only a running game can say that
# the load itself stayed silent.
#
# Nothing here asserts a techLevel: with no source mod staged there is no def to read. A scenario
# that named one would fail on the mod being absent, which is a missing mod rather than a broken
# correction, and it belongs in 02-with-sources.feature.
Feature: Nelim's Tech Level Fixes alone

  Scenario: it loads with none of its targets present and says nothing
    Then mod "nelim.techlevelfixes" is loaded
    # The mod ships no assembly, so the only way it can speak is a patch that failed to parse, or
    # an operation that reported a failure against a document holding none of its defs.
    And no errors were logged
