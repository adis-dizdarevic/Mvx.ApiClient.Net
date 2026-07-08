# Query Options

Mvx.ApiClient.Net exposes small request option types instead of asking consumers to build query strings manually.

## Pagination

List endpoints accept `QueryOptions` with optional `Pagination`.

```csharp
var tokens = await client.XExchange.GetTokensAsync(
    new QueryOptions
    {
        Pagination = new Pagination
        {
            Limit = 50,
            Offset = 100
        }
    });
```

The client maps:

- `Pagination.Limit` to `size`
- `Pagination.Offset` to `from`

Negative values are rejected before an HTTP request is sent.

## Field selection

Use `DataSelection.Fields` to ask the API for a smaller response shape:

```csharp
var pairs = await client.XExchange.GetPairsAsync(
    new QueryOptions
    {
        Data = new DataSelection
        {
            Fields = ["id", "symbol", "price", "volume24h"]
        }
    });
```

For single-resource endpoints:

```csharp
var economics = await client.Network.GetEconomicsAsync(
    new DataSelection { Fields = ["price", "marketCap"] });
```

The client maps `Fields` to the `fields` query parameter. Empty field names are rejected before an HTTP request is sent.

## Extract

Use `DataSelection.Extract` when the upstream endpoint supports extracting a scalar value:

```csharp
var stats = await client.Network.GetStatsAsync(
    new DataSelection { Extract = "accounts" });
```

The client maps `Extract` to the `extract` query parameter. Query values are URL encoded.
