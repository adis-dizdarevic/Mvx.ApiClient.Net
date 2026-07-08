# Getting Started

## Service registration

Register the client through dependency injection:

```csharp
using Microsoft.Extensions.DependencyInjection;
using Mvx.ApiClient.Net;

services.AddMvxApiClient(NetworkType.Mainnet);
```

For advanced configuration, use the options overload:

```csharp
services.AddMvxApiClient(options =>
{
    options.Network = NetworkType.Mainnet;
    options.Timeout = TimeSpan.FromSeconds(30);
});
```

## Query options

Use `DataSelection`, `Pagination`, and `QueryOptions` to select fields and page list endpoints:

```csharp
var pairs = await client.XExchange.GetPairsAsync(
    new QueryOptions
    {
        Pagination = new Pagination { Limit = 25 },
        Data = new DataSelection { Fields = ["id", "symbol"] }
    });
```

## Error handling

Non-success responses are thrown as `MvxApiException`:

```csharp
try
{
    var token = await client.XExchange.GetTokenAsync("WEGLD-bd4d79");
}
catch (MvxApiException exception)
{
    Console.WriteLine(exception.StatusCode);
    Console.WriteLine(exception.ResponseContent);
}
```
