# Mvx.ApiClient.Net

Mvx.ApiClient.Net is a typed .NET wrapper around the public MultiversX API. It is intended for application and library authors who want a NuGet package with dependency-injection support, typed response models, cancellation tokens, predictable errors, and package-ready metadata.

The current scope is GET endpoints for:

- Network data
- xExchange data

## Supported frameworks

- `net8.0`
- `net10.0`

## Supported networks

- Mainnet: `https://api.multiversx.com`
- Testnet: `https://testnet-api.multiversx.com`
- Devnet: `https://devnet-api.multiversx.com`

## Install

```bash
dotnet add package Mvx.ApiClient.Net
```

## Minimal example

```csharp
using Microsoft.Extensions.DependencyInjection;
using Mvx.ApiClient.Net;

var services = new ServiceCollection();
services.AddMvxApiClient(NetworkType.Mainnet);

using var provider = services.BuildServiceProvider();
var client = provider.GetRequiredService<IMvxApiClient>();

var stats = await client.Network.GetStatsAsync();
var pairs = await client.XExchange.GetPairsAsync(
    new QueryOptions
    {
        Pagination = new Pagination { Limit = 10 }
    });
```

## Package goals

- Keep the public API small and discoverable.
- Preserve HTTP status and response details when the API returns errors.
- Validate obvious invalid input before making HTTP calls.
- Keep retry and rate-limit policy configurable by consumers through `HttpClientFactory`.
- Keep generated XML documentation and README examples useful for NuGet consumers.
- Expose only current, contract-validated GET operations and reject deprecated or temporary routes.
