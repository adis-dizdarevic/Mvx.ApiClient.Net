# Mvx.ApiClient.Net

A modern .NET client for the public [MultiversX API](https://api.multiversx.com). It provides ready-to-use methods for all 157 current, non-obsolete GET operations in the approved upstream contract.

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

    public Task<long> GetPairCountAsync(CancellationToken cancellationToken)
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

The original xExchange list methods accept `QueryOptions`. Every other filtered route has an endpoint-specific options type so IntelliSense exposes the complete supported filter set without an unbounded property bag:

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

using Mvx.ApiClient.Net.Requests.Api;

var accounts = await client.Accounts.GetAccountsAsync(
    new AccountsGetAccountsOptions
    {
        Pagination = new Pagination { Limit = 25 },
        IsSmartContract = true,
        Sort = AccountsGetAccountsOptionsSort.Balance,
        Order = AccountsGetAccountsOptionsOrder.Desc
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

`IMvxApiClient` exposes focused groups for accounts, applications, blocks, collections, delegation, events, identities, keys, marketplace, miniblocks, network, NFTs, nodes, pool, providers, smart-contract results, rounds, shards, stake, tags, tokens, transaction batches, transactions, transfers, usernames, waiting-list data, dapp/websocket configuration, health checks, and xExchange.

Examples:

```csharp
var block = await client.Blocks.GetLatestBlockAsync();
var token = await client.Tokens.GetTokenAsync("USDC-c76f1f");
var nft = await client.Nfts.GetNftAsync("HLSR-374950-324a");
var transactions = await client.Accounts.GetAccountTransactionsAsync(address);
var logo = await client.Tokens.GetTokenLogoPngAsync("WEGLD-bd4d79");
```

JSON response models live in `Mvx.ApiClient.Net.Models.Api`. Binary/image methods return `MvxApiContent`, including bytes and response media metadata.

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

Review upstream GET drift and regenerate the complete public API contract with:

```powershell
.\eng\api-surface.ps1
python eng\generate-get-clients.py
.\eng\update-public-api.ps1
```

Operations marked deprecated or excluded in the approved upstream snapshot are intentionally not implemented. See `docs/endpoint-readiness.md` for the endpoint acceptance and model rules.

## Versioning

This package follows semantic versioning. Public API changes are guarded by an approval-style public API baseline in the test project.

## Contributing

See [CONTRIBUTING.md](./CONTRIBUTING.md).

## Security

See [SECURITY.md](./SECURITY.md) for vulnerability reporting.

## License

MIT. See [LICENSE](./LICENSE).
