# The pass without the optional mods: Core, the DLCs, Harmony, RimLogging, Pickle and this mod,
# and nothing else. No corrected mod is staged, so not one of the 166 corrections has a target.
#
# That is not a degenerate case for this mod, it is its central promise. Every generated operation
# is a PatchOperationConditional reporting success: Always, which is what lets thirty patch files
# sit in the folder while most of their mods are out of the modlist. `Tests/Run.ps1` proves the
# XML side of it - the document comes back byte-identical - but only a running game can say that
# the load itself stayed silent.
#
# The three assertions below have to be read together, and none of them is redundant:
#   - `no def ... exists` says the target really is absent, which is what makes this the bare pass
#     rather than an accident of staging;
#   - `no def ... was patched` says nothing corrected it. Alone it would prove nothing: the step
#     calls RequireAttribution, not RequirePatchable, so an absent def and a present-but-untouched
#     def are indistinguishable to it, and it passes trivially for a name nobody knows;
#   - `no warnings from mod` says it happened in silence.
# Together they are `success: Always` observed rather than assumed. A mod that did nothing at all
# would pass the last two, and fail the first the day its target is present.
Feature: Nelim's Tech Level Fixes alone

  Scenario: it loads with none of its targets present and says nothing
    Then mod "nelim.techlevelfixes" is loaded
    And no def "AMU_AmuletBarkeep" exists
    And no def "AMU_AmuletBarkeep" was patched
    # DISPLAY NAME here, not the packageId, and the difference is not cosmetic. The step compares
    # against RimLogging's `LogEntry.Mod`, which holds About.xml's <name>. Its guard, though,
    # accepts either form - so "nelim.techlevelfixes" would pass the guard, then match no warning
    # ever, and report green however loudly this mod complained. A false green on the very line
    # meant to prove the silence. Read at source by the Pickle headless mode session, 2026-09-21.
    #
    # The apostrophe is safe: a Gherkin double-quoted string crosses no shell. The 2026-09-20
    # rename was about a command line, a different path entirely.
    And no warnings from mod "Nelim's Tech Level Fixes"
    # Warnings this mod causes in vanilla code are attributed to nobody - `LogEntry.Mod` is null -
    # so they are not "from" this mod for the step above. That class needs
    # `no warning matching {string} was logged`, which is not written here because nothing yet
    # names a symptom worth matching.
    And no errors were logged
