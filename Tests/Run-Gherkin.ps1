<#
.SYNOPSIS
  Executes Tests/techlevelfixes.feature against the real Mod/Patches/ tree and About.xml.

.DESCRIPTION
  No Cucumber/SpecFlow/Reqnroll is installed in this environment (Pester here is 3.4.0,
  which predates Gherkin support), and this mod has no C# to host step definitions in even
  if one were. Rather than install new tooling for a single small feature file, or skip
  pickles/Gherkin testing with an unjustified "not applicable", this is a minimal, honest
  substitute: it reads the real .feature file for its human-readable Given/When/Then/So text
  (that text is not duplicated here - drift between the spec and what runs is not possible),
  prints it back scenario by scenario, and executes one real check per scenario title against
  the actual repository. It is not a general-purpose Gherkin engine; it recognises exactly the
  five scenario titles this repository's one feature file declares, and fails loudly if a
  title in the .feature file has no matching check below, so the file and the runner cannot
  silently drift apart.

.EXAMPLE
  .\Tests\Run-Gherkin.ps1
#>
param(
    [string]$RepoRoot = (Split-Path -Parent $PSScriptRoot)
)

$ErrorActionPreference = 'Stop'

$featurePath = Join-Path $PSScriptRoot 'techlevelfixes.feature'
$patchesDir  = Join-Path $RepoRoot 'Mod/Patches'
$aboutPath   = Join-Path $RepoRoot 'Mod/About/About.xml'

# --- Load the real corrections and load-order declarations once, shared by every scenario. ---

$corrections = New-Object System.Collections.Generic.List[object]
foreach ($file in Get-ChildItem -Path $patchesDir -Filter '*.xml' | Sort-Object Name) {
    [xml]$xml = Get-Content -Raw -Path $file.FullName
    $sourceName = [System.IO.Path]::GetFileNameWithoutExtension($file.Name)
    $ops = $xml.Patch.Operation
    if ($null -eq $ops) { $ops = @() } elseif ($ops -isnot [System.Array]) { $ops = @($ops) }
    foreach ($op in $ops) {
        if ($op.xpath -notmatch '^/Defs/([A-Za-z]+)\[defName="([^"]+)"\]$') { continue }
        $defName = $Matches[2]
        $inner = $op.match
        $replace = $inner.match
        $add = $inner.nomatch
        $corrections.Add([pscustomobject]@{
            File         = $sourceName
            DefName      = $defName
            Success      = $op.success
            ReplaceValue = $replace.value.techLevel
            AddValue     = $add.value.techLevel
        })
    }
}

[xml]$about = Get-Content -Raw -Path $aboutPath
$loadAfter = @($about.ModMetaData.loadAfter.li | ForEach-Object { [string]$_ })
$sourceFiles = @(Get-ChildItem -Path $patchesDir -Filter '*.xml' |
    ForEach-Object { [System.IO.Path]::GetFileNameWithoutExtension($_.Name) })

# --- One check function per Scenario title in the .feature file. Each returns a list of ---
# --- human-readable failure strings; an empty list means the scenario passes.            ---

$ValidTechLevels = @('Undefined','Animal','Neolithic','Medieval','Industrial','Spacer','Ultra','Archotech')

$Checks = @{
    'A correction sets the same tech level however the target def already looked' = {
        $failures = @()
        foreach ($c in $corrections) {
            if ($c.ReplaceValue -cne $c.AddValue) {
                $failures += "$($c.File)/$($c.DefName): replace=$($c.ReplaceValue) add=$($c.AddValue)"
            }
        }
        $failures
    }
    "A correction only ever names one of the game's own tech levels" = {
        $failures = @()
        foreach ($c in $corrections) {
            if ($ValidTechLevels -cnotcontains $c.ReplaceValue) {
                $failures += "$($c.File)/$($c.DefName): techLevel=`"$($c.ReplaceValue)`""
            }
        }
        $failures
    }
    'A defName is corrected at most once per source mod' = {
        $failures = @()
        $corrections | Group-Object File | ForEach-Object {
            $dupes = $_.Group | Group-Object DefName | Where-Object { $_.Count -gt 1 }
            foreach ($d in $dupes) { $failures += "$($_.Name): defName `"$($d.Name)`" appears $($d.Count) times" }
        }
        $failures
    }
    "A missing source mod's correction is harmless by construction" = {
        $failures = @()
        foreach ($c in $corrections) {
            if ($c.Success -cne 'Always') {
                $failures += "$($c.File)/$($c.DefName): success=`"$($c.Success)`""
            }
        }
        $failures
    }
    'Nothing but techLevel is ever written' = {
        $failures = @()
        foreach ($file in Get-ChildItem -Path $patchesDir -Filter '*.xml') {
            $raw = Get-Content -Raw -Path $file.FullName
            $valueBlocks = [regex]::Matches($raw, '<value>(.*?)</value>', 'Singleline')
            foreach ($v in $valueBlocks) {
                $inner = $v.Groups[1].Value.Trim()
                if ($inner -cnotmatch '^<techLevel>[A-Za-z]+</techLevel>$') {
                    $failures += "$($file.Name): <value> contains `"$inner`", expected exactly one <techLevel>"
                }
            }
        }
        $failures
    }
    'Every corrected mod is declared, and only once' = {
        $failures = @()
        $loadAfterSet = [System.Collections.Generic.HashSet[string]]::new([string[]]$loadAfter)
        $sourceSet = [System.Collections.Generic.HashSet[string]]::new([string[]]$sourceFiles)
        foreach ($s in $sourceFiles) {
            if (-not $loadAfterSet.Contains($s)) { $failures += "Mod/Patches/$s.xml has no loadAfter entry" }
        }
        foreach ($l in $loadAfter) {
            if (-not $sourceSet.Contains($l)) { $failures += "loadAfter `"$l`" has no matching Mod/Patches/$l.xml" }
        }
        if (($loadAfter | Group-Object | Where-Object { $_.Count -gt 1 })) {
            $failures += 'loadAfter lists a mod more than once'
        }
        $failures
    }
}

# --- Parse the .feature file just for its readable text and scenario titles; the titles ---
# --- drive which check above runs, so the spec and the runner cannot silently diverge.   ---

$featureText = Get-Content -Raw -Path $featurePath
$scenarioBlocks = [regex]::Matches($featureText, '(?m)^  Scenario: (.+?)\r?\n((?:^(?!  Scenario:).*\r?\n?)*)')

if ($scenarioBlocks.Count -eq 0) { throw "No 'Scenario:' blocks found in $featurePath" }

$anyFailed = $false
foreach ($block in $scenarioBlocks) {
    $title = $block.Groups[1].Value.Trim()
    $body = $block.Groups[2].Value.TrimEnd()

    Write-Host ''
    Write-Host "Scenario: $title" -ForegroundColor Cyan
    Write-Host $body

    $check = $Checks[$title]
    if ($null -eq $check) {
        Write-Host "NO CHECK MAPPED for this scenario title - the .feature file and Run-Gherkin.ps1 have drifted apart" -ForegroundColor Red
        $anyFailed = $true
        continue
    }

    $failures = & $check
    if ($failures.Count -eq 0) {
        Write-Host 'PASS' -ForegroundColor Green
    } else {
        Write-Host "FAIL ($($failures.Count)):" -ForegroundColor Red
        foreach ($f in $failures) { Write-Host "  - $f" -ForegroundColor Red }
        $anyFailed = $true
    }
}

Write-Host ''
if ($anyFailed) {
    Write-Host 'One or more scenarios failed.' -ForegroundColor Red
    exit 1
}
Write-Host "All $($scenarioBlocks.Count) scenarios passed, against $($corrections.Count) corrections across $($sourceFiles.Count) source mods." -ForegroundColor Green
exit 0
