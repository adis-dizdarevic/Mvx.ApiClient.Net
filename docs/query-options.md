# Query options

List endpoints accept `QueryOptions` for pagination.

```csharp
var pairs = await client.XExchange.GetPairsAsync(
    new QueryOptions
    {
        Pagination = new Pagination
        {
            Limit = 25,
            Offset = 50
        }
    });
```

`Limit` maps to the API's `size` parameter and `Offset` maps to `from`. Negative values and limits above `Pagination.MaximumLimit` (`10_000`) are rejected before the request is sent. Endpoints that request expensive optional details can have a smaller effective limit.

Endpoint-specific option types use the same internal query builder for invariant numbers, lowercase Booleans, explicitly mapped enums, and both comma-separated and repeated collections. This keeps complex filters consistent without turning `QueryOptions` into an unbounded property bag.

## Complete typed responses

The client deliberately does not expose the upstream `fields` or `extract` parameters through typed endpoint methods. A field projection omits properties and makes missing numeric or Boolean values indistinguishable from `0` or `false`; an extract can return a scalar instead of the documented DTO. Complete endpoint responses keep the typed API reliable.
