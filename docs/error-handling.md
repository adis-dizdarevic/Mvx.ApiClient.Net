# Error Handling

Mvx.ApiClient.Net throws `MvxApiException` when the MultiversX API returns a non-success HTTP status code.

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

## Exception details

`MvxApiException` exposes:

- `StatusCode`: the HTTP status code.
- `Error`: the API error label or HTTP reason phrase when available.
- `ResponseContent`: raw response content when available.
- `RequestUri`: request URI when available.
- `RequestMethod`: request HTTP method when available.

The client handles empty and non-JSON error responses. It preserves useful response content instead of assuming every error body matches the normal API error shape.

## Input validation

The client validates obvious invalid input before sending requests:

- Null or empty token identifiers.
- Null or empty pair token identifiers.
- Negative pagination values.
- Empty field names.

Invalid local input throws standard argument exceptions. API failures throw `MvxApiException`.
