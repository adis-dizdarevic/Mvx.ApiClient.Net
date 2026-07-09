param(
    [string] $PackageDirectory = "src/Mvx.ApiClient.Net/bin/Release",
    [string] $TargetFramework = "net8.0"
)

$ErrorActionPreference = "Stop"

$resolvedPackageDirectory = Resolve-Path $PackageDirectory
$package = Get-ChildItem $resolvedPackageDirectory -Filter "Mvx.ApiClient.Net.*.nupkg" |
    Where-Object { $_.Name -notlike "*.snupkg" } |
    Sort-Object LastWriteTime -Descending |
    Select-Object -First 1

if (-not $package) {
    throw "No Mvx.ApiClient.Net package found in $resolvedPackageDirectory."
}

if ($package.BaseName -notmatch "^Mvx\.ApiClient\.Net\.(?<version>.+)$") {
    throw "Could not determine package version from $($package.Name)."
}

$packageVersion = $Matches.version
$smokeRoot = Join-Path ([System.IO.Path]::GetTempPath()) "mvx-api-client-package-smoke"
if (Test-Path $smokeRoot) {
    Remove-Item -LiteralPath $smokeRoot -Recurse -Force
}

New-Item -ItemType Directory -Path $smokeRoot | Out-Null
$isolatedProfile = Join-Path $smokeRoot "profile"
New-Item -ItemType Directory -Path $isolatedProfile | Out-Null

$previousDotnetCliHome = $env:DOTNET_CLI_HOME
$previousNugetPackages = $env:NUGET_PACKAGES
$previousNugetHttpCachePath = $env:NUGET_HTTP_CACHE_PATH
$previousAppData = $env:APPDATA

$env:DOTNET_CLI_HOME = $isolatedProfile
$env:NUGET_PACKAGES = Join-Path $smokeRoot "packages"
$env:NUGET_HTTP_CACHE_PATH = Join-Path $smokeRoot "http-cache"
$env:APPDATA = Join-Path $isolatedProfile "appdata"
New-Item -ItemType Directory -Path $env:APPDATA | Out-Null

function Invoke-DotNet {
    dotnet @args
    if ($LASTEXITCODE -ne 0) {
        throw "dotnet $args failed with exit code $LASTEXITCODE."
    }
}

Push-Location $smokeRoot

try {
    Invoke-DotNet new console --name Consumer --no-restore
    Set-Location Consumer

    @"
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <clear />
    <add key="local" value="$($resolvedPackageDirectory.Path)" />
    <add key="nuget.org" value="https://api.nuget.org/v3/index.json" />
  </packageSources>
</configuration>
"@ | Set-Content -Path "nuget.config" -Encoding UTF8

    @"
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>$TargetFramework</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
    <TreatWarningsAsErrors>true</TreatWarningsAsErrors>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="Mvx.ApiClient.Net" Version="$packageVersion" />
  </ItemGroup>
</Project>
"@ | Set-Content -Path "Consumer.csproj" -Encoding UTF8

    @"
using Microsoft.Extensions.DependencyInjection;
using Mvx.ApiClient.Net;
using Mvx.ApiClient.Net.Models.Network;
using Mvx.ApiClient.Net.Models.XExchange;

var services = new ServiceCollection();
services.AddMvxApiClient(options =>
{
    options.Network = NetworkType.Mainnet;
    options.Timeout = TimeSpan.FromSeconds(30);
});

using var provider = services.BuildServiceProvider();
var client = provider.GetRequiredService<IMvxApiClient>();

Task<StatsDto> stats = client.Network.GetStatsAsync();
Task<IReadOnlyList<XExchangePairDto>> pairs = client.XExchange.GetPairsAsync(new QueryOptions
{
    Pagination = new Pagination { Limit = 25 }
});

Console.WriteLine($"{client.NetworkType}: {stats.GetType().Name}, {pairs.GetType().Name}");
"@ | Set-Content -Path "Program.cs" -Encoding UTF8

    Invoke-DotNet restore --configfile nuget.config
    Invoke-DotNet build --configuration Release --no-restore
}
finally {
    Pop-Location
    $env:DOTNET_CLI_HOME = $previousDotnetCliHome
    $env:NUGET_PACKAGES = $previousNugetPackages
    $env:NUGET_HTTP_CACHE_PATH = $previousNugetHttpCachePath
    $env:APPDATA = $previousAppData
}
