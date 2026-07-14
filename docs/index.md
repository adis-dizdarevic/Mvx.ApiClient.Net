# Mvx.ApiClient.Net

Mvx.ApiClient.Net is a typed .NET wrapper around the public MultiversX API. It is intended for application and library authors who want a NuGet package with dependency-injection support, typed response models, cancellation tokens, predictable errors, and package-ready metadata.

The package implements all 157 current, non-obsolete GET operations in the approved MultiversX OpenAPI contract. Endpoint groups cover accounts, chain data, tokens and NFTs, staking, marketplace data, transaction history, xExchange, configuration, media, and supporting lookup APIs.

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
var accounts = await client.Accounts.GetAccountsAsync(
    new AccountsGetAccountsOptions
    {
        Pagination = new Pagination { Limit = 10 }
    });
```

## Package goals

- Keep the large upstream surface discoverable through focused clients and endpoint-specific options.
- Preserve HTTP status and response details when the API returns errors.
- Validate obvious invalid input before making HTTP calls.
- Keep retry and rate-limit policy configurable by consumers through `HttpClientFactory`.
- Keep generated XML documentation and README examples useful for NuGet consumers.
- Expose only current, contract-validated GET operations and reject deprecated or temporary routes.
