# Mvx.ApiClient.Net

Mvx.ApiClient.Net is a .NET wrapper around the public MultiversX API. The current scope is GET endpoints for network and xExchange data.

## Installation

```bash
dotnet add package Mvx.ApiClient.Net
```

## Service Registration

```csharp
using Mvx.ApiClient.Net;

services.AddMvxApiClient(NetworkType.Mainnet);
```

```csharp
services.AddMvxApiClient(options =>
{
    options.Network = NetworkType.Mainnet;
    options.Timeout = TimeSpan.FromSeconds(30);
});
```

Supported networks:

- `NetworkType.Mainnet` -> `https://api.multiversx.com`
- `NetworkType.Testnet` -> `https://testnet-api.multiversx.com`
- `NetworkType.Devnet` -> `https://devnet-api.multiversx.com`

## Usage

```csharp
using Mvx.ApiClient.Net;
using Mvx.ApiClient.Net.Models.Network;

public sealed class BlockchainService
{
    private readonly IMvxApiClient _client;

    public BlockchainService(IMvxApiClient client)
    {
        _client = client;
    }

    public Task<StatsDto> GetStatsAsync(CancellationToken cancellationToken)
    {
        return _client.Network.GetStatsAsync(cancellationToken: cancellationToken);
    }
}
```

## Notes

The public MultiversX API is rate limited. This package does not add retry or rate-limit policies by default; consumers can configure resilience around `HttpClientFactory` in their application.

Live API smoke tests are available through the integration-test project and only call the public API when `MVX_API_LIVE_TESTS=true`.
