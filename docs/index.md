# Mvx.ApiClient.Net

Mvx.ApiClient.Net is a .NET wrapper around the public MultiversX API. The current scope is GET endpoints for network and xExchange data.

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

## Quick example

```csharp
using Microsoft.Extensions.DependencyInjection;
using Mvx.ApiClient.Net;

var services = new ServiceCollection();
services.AddMvxApiClient(NetworkType.Mainnet);

using var provider = services.BuildServiceProvider();
var client = provider.GetRequiredService<IMvxApiClient>();

var stats = await client.Network.GetStatsAsync(
    new DataSelection { Fields = ["accounts", "blocks"] });
```
