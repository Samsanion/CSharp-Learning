param(
    [string]$RepoPath = ".",
    [string]$SolutionFile = "CSharp-Learning.slnx",
    [Parameter(Mandatory = $true)]
    [string]$TaskName
)

$ErrorActionPreference = "Stop"

function Write-Utf8NoBom {
    param(
        [string]$Path,
        [string]$Content
    )

    $utf8NoBom = New-Object System.Text.UTF8Encoding($false)
    [System.IO.File]::WriteAllText($Path, $Content, $utf8NoBom)
}

function Get-NextTaskNumber {
    param([string]$RepoPath)

    $dirs = Get-ChildItem -Path $RepoPath -Directory |
        Where-Object { $_.Name -match '^(\d+)_' }

    if (-not $dirs) {
        return 1
    }

    $nums = foreach ($dir in $dirs) {
        if ($dir.Name -match '^(\d+)_') {
            [int]$matches[1]
        }
    }

    return (($nums | Measure-Object -Maximum).Maximum + 1)
}

$RepoPath = (Resolve-Path $RepoPath).Path

if (-not (Test-Path $RepoPath)) {
    throw "Repository path not found: $RepoPath"
}

$solutionPath = Join-Path $RepoPath $SolutionFile
if (-not (Test-Path $solutionPath)) {
    throw "Solution file not found: $solutionPath"
}

$number = Get-NextTaskNumber -RepoPath $RepoPath
$prefix = $number.ToString("D2")
$folderName = "${prefix}_$TaskName"
$folderPath = Join-Path $RepoPath $folderName

if (Test-Path $folderPath) {
    throw "Task folder already exists: $folderPath"
}

Set-Location $RepoPath

dotnet new console -o $folderName -n $folderName | Out-Host
if ($LASTEXITCODE -ne 0) {
    throw "Failed to create project: $folderName"
}

dotnet sln $solutionPath add ".\$folderName\$folderName.csproj" | Out-Host
if ($LASTEXITCODE -ne 0) {
    throw "Failed to add project to solution: $folderName"
}

$readmePath = Join-Path $folderPath "README.md"
$readmeContent = @"
# $folderName

- Main file: Program.cs
- Project file: $folderName.csproj
"@
Write-Utf8NoBom -Path $readmePath -Content $readmeContent

Write-Host ""
Write-Host "Created: $folderName"
Write-Host "Project: $folderPath\$folderName.csproj"
Write-Host "GitHub link after push:"
Write-Host "https://github.com/Samsanion/CSharp-Learning/tree/main/$folderName"