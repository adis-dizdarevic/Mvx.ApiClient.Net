# Clients

`IMvxApiClient` exposes endpoint groups through focused child clients.

```csharp
public interface IMvxApiClient
{
    NetworkType NetworkType { get; }
    IXExchangeClient XExchange { get; }
    INetworkClient Network { get; }
}
```

## Network

The network client wraps general MultiversX API endpoints.

```csharp
var stats = await client.Network.GetStatsAsync();
var economics = await client.Network.GetEconomicsAsync();
var constants = await client.Network.GetConstantsAsync();
var about = await client.Network.GetAboutAsync();
```

Response models live under:

```csharp
using Mvx.ApiClient.Net.Models.Network;
```

## xExchange

The xExchange client wraps the current xExchange GET endpoints exposed by the public API.

```csharp
var economics = await client.XExchange.GetEconomicsAsync();
var pairs = await client.XExchange.GetPairsAsync();
var pair = await client.XExchange.GetPairAsync("MEX-455c57", "WEGLD-bd4d79");
var pairsCount = await client.XExchange.GetPairsCountAsync();

var tokens = await client.XExchange.GetTokensAsync();
var token = await client.XExchange.GetTokenAsync("WEGLD-bd4d79");
var tokensCount = await client.XExchange.GetTokensCountAsync();

var farms = await client.XExchange.GetFarmsAsync();
var farmsCount = await client.XExchange.GetFarmsCountAsync();
```

Response models live under:

```csharp
using Mvx.ApiClient.Net.Models.XExchange;
```

The upstream API still uses `/mex/*` paths for these endpoints. The public .NET API uses xExchange naming.

## Endpoint coverage

| Client | Method | Upstream path |
| --- | --- | --- |
| `INetworkClient` | `GetStatsAsync` | `/stats` |
| `INetworkClient` | `GetEconomicsAsync` | `/economics` |
| `INetworkClient` | `GetConstantsAsync` | `/constants` |
| `INetworkClient` | `GetAboutAsync` | `/about` |
| `IXExchangeClient` | `GetEconomicsAsync` | `/mex/economics` |
| `IXExchangeClient` | `GetPairsAsync` | `/mex/pairs` |
| `IXExchangeClient` | `GetPairAsync` | `/mex/pairs/{baseId}/{quoteId}` |
| `IXExchangeClient` | `GetPairsCountAsync` | `/mex/pairs/count` |
| `IXExchangeClient` | `GetTokensAsync` | `/mex/tokens` |
| `IXExchangeClient` | `GetTokenAsync` | `/mex/tokens/{identifier}` |
| `IXExchangeClient` | `GetTokensCountAsync` | `/mex/tokens/count` |
| `IXExchangeClient` | `GetFarmsAsync` | `/mex/farms` |
| `IXExchangeClient` | `GetFarmsCountAsync` | `/mex/farms/count` |
