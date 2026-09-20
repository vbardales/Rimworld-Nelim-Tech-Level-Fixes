<#
    Builds and runs this mod's unit tests.

    These are the tests to run on every change. They execute RimWorld's own patch operations over
    the shipped XML in a console process: no game, no pointer taken over, no waiting. The Pickle
    suite under Tests/Pickle covers what only a live game can show, and costs minutes and the
    machine while it runs.

    Needs the .NET SDK and a RimWorld installation to reference Assembly-CSharp; pass
    -RimWorldManaged for an installation somewhere other than the default Steam path.
#>
[CmdletBinding()]
param(
    [string]$RimWorldManaged = 'C:\Program Files (x86)\Steam\steamapps\common\RimWorld\RimWorldWin64_Data\Managed',
    [string]$Configuration = 'Release'
)

$ErrorActionPreference = 'Stop'

$project = Join-Path $PSScriptRoot 'TechLevelFixes.Tests.csproj'
$exe = Join-Path (Split-Path -Parent $PSScriptRoot) ".build\tests\bin\$Configuration\net48\TechLevelFixes.Tests.exe"

dotnet build $project -c $Configuration -p:RimWorldManaged=$RimWorldManaged
if ($LASTEXITCODE -ne 0) { throw "Build failed" }

& $exe
exit $LASTEXITCODE
