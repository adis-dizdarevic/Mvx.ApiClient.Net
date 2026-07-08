$ErrorActionPreference = "Stop"

$repoRoot = Split-Path -Parent $PSScriptRoot
$python = Join-Path $repoRoot ".venv/Scripts/python.exe"

if (-not (Test-Path $python)) {
    throw "Python virtual environment not found. Create it with: py -m venv .venv"
}

Push-Location (Join-Path $repoRoot "docs")

try {
    & $python -m zensical build
    if ($LASTEXITCODE -ne 0) {
        throw "Zensical build failed with exit code $LASTEXITCODE."
    }
}
finally {
    Pop-Location
}
