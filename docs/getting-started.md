# Getting Started

## Service registration

Register the root client through dependency injection:

```csharp
using Microsoft.Extensions.DependencyInjection;
using Mvx.ApiClient.Net;

services.AddMvxApiClient(NetworkType.Mainnet);
```

The root client exposes focused endpoint groups:

```csharp
var client = provider.GetRequiredService<IMvxApiClient>();

var stats = await client.Network.GetStatsAsync();
var pairs = await client.XExchange.GetPairsAsync();
```

## Options registration

Use the options overload when you need timeout, network, or custom host configuration:

```csharp
services.AddMvxApiClient(options =>
{
    options.Network = NetworkType.Mainnet;
    options.Timeout = TimeSpan.FromSeconds(30);
});
```

Use `BaseAddress` to point the client at a compatible API host:

```csharp
services.AddMvxApiClient(options =>
{
    options.BaseAddress = new Uri("https://api.multiversx.com");
});
```

`BaseAddress` overrides `Network`.

## HttpClient customization

Use `ConfigureHttpClient` for headers or other `HttpClient` settings:

```csharp
services.AddMvxApiClient(options =>
{
    options.Network = NetworkType.Mainnet;
    options.ConfigureHttpClient = client =>
    {
        client.DefaultRequestHeaders.UserAgent.ParseAdd("my-app/1.0");
    };
});
```

The package does not add retry or rate-limit policy by default. Add resilience policy at the application boundary using `IHttpClientFactory` conventions that fit your workload.

## Direct clients

The DI registration also registers focused clients:

```csharp
public sealed class NetworkDashboard
{
    private readonly INetworkClient _network;

    public NetworkDashboard(INetworkClient network)
    {
        _network = network;
    }

    public Task<StatsDto> GetStatsAsync(CancellationToken cancellationToken)
    {
        return _network.GetStatsAsync(cancellationToken: cancellationToken);
    }
}
```

Add the model namespace when using response types directly:

```csharp
using Mvx.ApiClient.Net.Models.Network;
```
