# Clients

`IMvxApiClient` exposes the complete GET API through focused child clients. Every child interface is also registered directly with dependency injection.

## Endpoint groups

| Root property | Interface | Area |
| --- | --- | --- |
| `Accounts` | `IAccountsClient` | Accounts, balances, roles, history, account transactions and transfers |
| `Applications` | `IApplicationsClient` | Indexed applications |
| `Blocks` | `IBlocksClient` | Blocks, latest block, and counts |
| `Collections` | `ICollectionsClient` | NFT collections, ranks, accounts, transactions, and transfers |
| `Delegation` | `IDelegationClient` | Current and legacy global delegation data |
| `Events` | `IEventsClient` | Indexed events |
| `Identities` | `IIdentitiesClient` | Validator identities and avatars |
| `Keys` | `IKeysClient` | Validator-key unbond periods |
| `Marketplace` | `IMarketplaceClient` | Auctions and marketplace statistics |
| `Miniblocks` | `IMiniblocksClient` | Miniblock list and details |
| `Network` | `INetworkClient` | Stats, economics, constants, and deployment information |
| `Nfts` | `INftsClient` | NFTs, holders, supply, media, transactions, and transfers |
| `Nodes` | `INodesClient` | Nodes, auctions, counts, and version distribution |
| `Pool` | `IPoolClient` | Pending transaction pool |
| `Providers` | `IProvidersClient` | Delegation providers, accounts, and avatars |
| `Results` | `IResultsClient` | Smart-contract results |
| `Rounds` | `IRoundsClient` | Round list and details |
| `Shards` | `IShardsClient` | Shard status |
| `Stake` | `IStakeClient` | Global staking data |
| `Tags` | `ITagsClient` | NFT tags |
| `Tokens` | `ITokensClient` | ESDT tokens, supply, holders, media, transactions, and transfers |
| `TransactionBatches` | `ITransactionBatchesClient` | Transaction-batch status |
| `Transactions` | `ITransactionsClient` | Transactions, counts, details, and price-per-unit metadata |
| `Transfers` | `ITransfersClient` | Global transfer history |
| `Usernames` | `IUsernamesClient` | Username lookup |
| `WaitingList` | `IWaitingListClient` | Validator waiting list |
| `DappConfig` | `IDappConfigClient` | Dapp configuration |
| `Websocket` | `IWebsocketClient` | Websocket configuration |
| `HealthCheck` | `IHealthCheckClient` | API health text |
| `XExchange` | `IXExchangeClient` | xExchange economics, pairs, farms, tokens, and charts |

## Examples

```csharp
using Mvx.ApiClient.Net.Requests.Api;

var latest = await client.Blocks.GetLatestBlockAsync();

var tokens = await client.Tokens.GetTokensAsync(
    new TokensGetTokensOptions
    {
        Pagination = new Pagination { Limit = 10 },
        Search = "USDC"
    });

var token = await client.Tokens.GetTokenAsync(tokens[0].Identifier!);
var supply = await client.Tokens.GetTokenSupplyAsync(tokens[0].Identifier!);

var nfts = await client.Nfts.GetNftsAsync(
    new NftsGetNftsOptions { Pagination = new Pagination { Limit = 10 } });

var transactions = await client.Accounts.GetAccountTransactionsAsync(
    "erd1...",
    new AccountsGetAccountTransactionsOptions
    {
        Pagination = new Pagination { Limit = 25 }
    });
```

Response models for the expanded surface live under `Mvx.ApiClient.Net.Models.Api`. Atomic quantities use `BigInteger`, bounded fractional values use `decimal`, and optional upstream fields are nullable.

Image and other binary endpoints return `MvxApiContent`:

```csharp
var logo = await client.Tokens.GetTokenLogoPngAsync("WEGLD-bd4d79");
Console.WriteLine(logo.MediaType);
Console.WriteLine(logo.Content.Length);
```

The upstream API still uses `/mex/*` routes. The .NET API retains the existing `XExchange` naming and adds `GetTokenDailyPricesAsync` and `GetTokenHourlyPricesAsync` for its chart routes.

The authoritative endpoint-to-method map is guarded by `CompleteGetSurfaceTest`: each approved non-obsolete operation ID and path must map to exactly one implementation.
