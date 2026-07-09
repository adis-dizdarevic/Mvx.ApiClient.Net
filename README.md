# Mvx.ApiClient.Net

A modern .NET client for the public [MultiversX API](https://api.multiversx.com). The current package focuses on GET endpoints and provides typed clients for network and xExchange data.

## Install

```bash
dotnet add package Mvx.ApiClient.Net
```

## Supported frameworks

- `net8.0`
- `net10.0`

## Supported networks

- Mainnet: `https://api.multiversx.com`
- Testnet: `https://testnet-api.multiversx.com`
- Devnet: `https://devnet-api.multiversx.com`

You can also provide a custom API base address when using a proxy, local gateway, or private-compatible deployment.

## Quick start

```csharp
using Microsoft.Extensions.DependencyInjection;
using Mvx.ApiClient.Net;

var services = new ServiceCollection();
services.AddMvxApiClient(NetworkType.Mainnet);

using var provider = services.BuildServiceProvider();
var client = provider.GetRequiredService<IMvxApiClient>();

var stats = await client.Network.GetStatsAsync();

Console.WriteLine($"Accounts: {stats.Accounts}");
```

## ASP.NET Core registration

```csharp
using Mvx.ApiClient.Net;

builder.Services.AddMvxApiClient(options =>
{
    options.Network = NetworkType.Mainnet;
    options.Timeout = TimeSpan.FromSeconds(30);
});
```

Inject the root client:

```csharp
using Mvx.ApiClient.Net;

public sealed class DashboardService
{
    private readonly IMvxApiClient _client;

    public DashboardService(IMvxApiClient client)
    {
        _client = client;
    }

    public Task<int> GetPairCountAsync(CancellationToken cancellationToken)
    {
        return _client.XExchange.GetPairsCountAsync(cancellationToken);
    }
}
```

You can also inject focused clients directly:

```csharp
public sealed class NetworkService
{
    private readonly INetworkClient _network;

    public NetworkService(INetworkClient network)
    {
        _network = network;
    }
}
```

## Query options

List endpoints accept `QueryOptions`:

```csharp
var pairs = await client.XExchange.GetPairsAsync(
    new QueryOptions
    {
        Pagination = new Pagination
        {
            Limit = 25,
            Offset = 0
        }
    });
```

Typed endpoint methods always request and return their complete documented response shape. This avoids silently treating fields omitted by server-side projections as zero or `false`.

```csharp
var token = await client.XExchange.GetTokenAsync("WEGLD-bd4d79");
```

The client validates obvious invalid input, such as negative pagination values, before sending HTTP requests.

## Error handling

Non-success API responses throw `MvxApiException`:

```csharp
using Mvx.ApiClient.Net.Exceptions;

try
{
    var token = await client.XExchange.GetTokenAsync("WEGLD-bd4d79");
}
catch (MvxApiException exception)
{
    Console.WriteLine(exception.StatusCode);
    Console.WriteLine(exception.Error);
    Console.WriteLine(exception.ResponseContent);
}
```

The exception preserves the HTTP status code, API error label when available, raw response content, request URI, and request method.

## Available clients

`IMvxApiClient` exposes:

- `Network`: network stats, economics, constants, and API deployment information.
- `XExchange`: xExchange economics, pairs, tokens, farms, and count endpoints.

The upstream MultiversX API still exposes xExchange data under `/mex/*` routes. This package uses xExchange naming in the .NET API.

## Documentation

Documentation lives in `docs/` and is built with Zensical.

```powershell
py -m venv .venv
.\.venv\Scripts\python.exe -m pip install zensical
.\eng\docs.ps1
```

Serve locally:

```powershell
cd docs
..\.venv\Scripts\python.exe -m zensical serve
```

Open `http://localhost:8000`.

## Development

```powershell
dotnet restore Mvx.ApiClient.Net.slnx
dotnet build Mvx.ApiClient.Net.slnx --configuration Release --no-restore
dotnet test Mvx.ApiClient.Net.slnx --configuration Release --no-build
dotnet pack src/Mvx.ApiClient.Net/Mvx.ApiClient.Net.csproj --configuration Release --no-build
.\eng\package-smoke-test.ps1 -TargetFramework net8.0
.\eng\package-smoke-test.ps1 -TargetFramework net10.0
```

Live API smoke tests are disabled by default. Set `MVX_API_LIVE_TESTS=true` to enable the integration test project against the public MultiversX API.

## Versioning

This package follows semantic versioning. Public API changes are guarded by an approval-style public API baseline in the test project.

## Contributing

See [CONTRIBUTING.md](./CONTRIBUTING.md).

## Security

See [SECURITY.md](./SECURITY.md) for vulnerability reporting.

## License

MIT. See [LICENSE](./LICENSE).
