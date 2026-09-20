# What only a running game can show for this mod. Everything provable outside the game is proved
# outside it, by Tests/Run.ps1, which applies these same patch operations headless in seconds.
#
# The unit tests apply one source mod's patches to that source mod's defs, in isolation. A real
# game applies every active mod's patches to one combined document, in load order. What is left
# here is exactly that difference, and the mod's own arrival: a handful of spot checks, not a
# restatement of the 166 assertions the unit tests already make.
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

  Scenario: a correction survives the whole modlist, add branch
    # Alpha Books declares no techLevel for this one, so the add branch fires. If another active
    # mod patches the same field after this one, the value here is the one that lost.
    Then def "ABooks_AdventuringLogs" field "techLevel" is "Medieval"
    And def "ABooks_ArmyManual" field "techLevel" is "Industrial"

  Scenario: a correction survives the whole modlist, replace branch
    Then def "GlitterCraft_BrawlerArmor" field "techLevel" is "Spacer"

  Scenario: a corrected research project keeps its level
    # The only ResearchProjectDef among the 166, and the only one the research tree lays out.
    Then def "AlchemyAlchemy" field "techLevel" is "Medieval"
