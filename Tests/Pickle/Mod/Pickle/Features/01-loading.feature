# What only a running game can show for this mod. Everything provable outside the game is proved
# outside it, by Tests/Run.ps1, which applies these same patch operations headless in seconds.
#
# Two things are left over after those unit tests, and both need a real load:
#   - the game's own load order, which loadAfter only requests;
#   - the value a def ends up with once inheritance is resolved, which happens after patching.
#     The unit tests see a techLevel node appear in the XML; only the game says what the loaded
#     def then reports.
#
# Every def named here belongs to a mod installed on the development machine as of 2026-09-20.
# The earlier version of this file named Glitter-Craft and Alchemy, which have since been removed
# from the modlist, so it could not have run.
#
# No save needed: defs are settled at the main menu.
Feature: Nelim's Tech Level Fixes in a real modlist

  Scenario: the mod is loaded and says nothing
    Then mod "nelim.techlevelfixes" is loaded
    # The mod ships no assembly, so the only way it can speak is a patch that failed to parse.
    And no errors were logged

  Scenario: it loads after the mods it corrects
    # loadAfter is a request; the game decides. Only the running game shows what it decided.
    Then mod "nelim.techlevelfixes" loads after "sarg.alphabooks"
    And mod "nelim.techlevelfixes" loads after "zal.ancientamulets"

  Scenario: a def that had no level anywhere gets one
    # Alpha Books declares no techLevel and inherits none, so the add branch fires into a gap.
    #
    # The type is spelled out because defNames are unique per def type, not globally:
    # "ABooks_ArmyManual" is both a ThingDef and a HediffDef here, and an untyped step refuses to
    # guess. The patches were never ambiguous - their xpath names the type - but this step was.
    Then def "ABooks_AdventuringLogs" of type "ThingDef" field "techLevel" is "Medieval"
    And def "ABooks_ArmyManual" of type "ThingDef" field "techLevel" is "Industrial"

  Scenario: a def that declared its own level has it replaced
    # Additional Tools writes Industrial on this one itself, so the replace branch fires.
    Then def "Bucket_Generic" field "techLevel" is "Medieval"

  Scenario: an inherited level is overridden, not merely shadowed
    # The one case no unit test can settle. These amulets declare no techLevel of their own and
    # inherit Medieval from AmuletBase, so the patch adds a node rather than replacing one. Whether
    # the added node wins over the inherited value is decided when the game resolves ParentName,
    # which happens after patching and only in a running game.
    Then def "AMU_AmuletBarkeep" field "techLevel" is "Neolithic"
    And def "AMU_MedalSurgeon" field "techLevel" is "Neolithic"
