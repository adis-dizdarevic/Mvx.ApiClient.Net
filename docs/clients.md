# Clients

`IMvxApiClient` exposes endpoint groups through focused child clients.

## Network

```csharp
var stats = await client.Network.GetStatsAsync();
var economics = await client.Network.GetEconomicsAsync();
var constants = await client.Network.GetConstantsAsync();
var about = await client.Network.GetAboutAsync();
```

## xExchange

```csharp
var economics = await client.XExchange.GetEconomicsAsync();
var pairs = await client.XExchange.GetPairsAsync();
var pair = await client.XExchange.GetPairAsync("MEX-455c57", "WEGLD-bd4d79");
var tokens = await client.XExchange.GetTokensAsync();
var token = await client.XExchange.GetTokenAsync("WEGLD-bd4d79");
var farms = await client.XExchange.GetFarmsAsync();
```

The upstream API still uses `/mex/*` paths for these endpoints. The public .NET API uses xExchange naming.
