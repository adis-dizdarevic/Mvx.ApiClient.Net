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

`Limit` maps to the API's `size` parameter and `Offset` maps to `from`. Negative values are rejected before the request is sent.

## Complete typed responses

The client deliberately does not expose the upstream `fields` or `extract` parameters through typed endpoint methods. A field projection omits properties and makes missing numeric or Boolean values indistinguishable from `0` or `false`; an extract can return a scalar instead of the documented DTO. Complete endpoint responses keep the typed API reliable.
