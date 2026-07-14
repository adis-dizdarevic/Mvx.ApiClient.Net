param()

$ErrorActionPreference = "Stop"
$repositoryRoot = Split-Path -Parent $PSScriptRoot
$previousValue = $env:MVX_UPDATE_PUBLIC_API

try {
    $env:MVX_UPDATE_PUBLIC_API = "true"
    dotnet test "$repositoryRoot/tests/Mvx.ApiClient.Net.Test/Mvx.ApiClient.Net.Test.csproj" --framework net10.0 --configuration Release --no-restore --no-build
    if ($LASTEXITCODE -ne 0) {
        throw "Public API baseline generation failed with exit code $LASTEXITCODE."
    }
}
finally {
    $env:MVX_UPDATE_PUBLIC_API = $previousValue
}
