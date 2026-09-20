# TESTING.md scenario 1. No save needed: defs are settled at the main menu.
#
# This file is written by hand; 02-corrections.feature is generated.
Feature: Nelim's Tech Level Fixes loads and its patches apply

  Scenario: the mod is loaded
    Then mod "nelim.techlevelfixes" is loaded

  Scenario: nothing in the log since startup
    # The mod ships no assembly, so the only way it can speak is a patch that failed to apply.
    # An xpath that matches nothing is silent by design - see 02-corrections.feature for whether
    # the corrections actually landed - so this scenario catches malformed XML, not a missed target.
    Then no errors were logged
