# MultiversX ApiClient

## Roadmap
> [!IMPORTANT]
> This project currently focuses on GET endpoints exposed by the public MultiversX API. Additional clients are planned incrementally.

- [x] Network Client
- [x] xExchange Client
- [ ] Account Client
- [ ] Block Client
- [ ] Collection Client
- [ ] NFT Client
- [ ] Tags Client
- [ ] Node Client
- [ ] Provider Client
- [ ] Token Client
- [ ] Transaction Client
- [ ] Marketplace Client
- [ ] Delegation Client

## Introduction

Mvx.ApiClient.Net is a C# wrapper for the MultiversX API, designed for querying data from the blockchain. It provides a simple and efficient interface to interact with the API, making it easy to retrieve relevant information for your applications. The client is built with performance and scalability in mind, allowing developers to easily integrate with the MultiversX network.

The supported public API hosts are:
- Mainnet: `https://api.multiversx.com`
- Testnet: `https://testnet-api.multiversx.com`
- Devnet: `https://devnet-api.multiversx.com`

## Getting started

To integrate Mvx.ApiClient.Net into your C# application, follow these setup steps.

1. Installation: Add the package via NuGet Package Manager or the .NET CLI:
   ```
   dotnet add package Mvx.ApiClient.Net
   ```
   
2. Configuration: Configure the client by registering it with your application's `IServiceCollection`. Specify the desired network environment — Mainnet, Testnet or Devnet — during setup using the `AddMvxApiClient` extension method. This will register the required services.
   ```csharp
   using Microsoft.Extensions.DependencyInjection;
   using Mvx.ApiClient.Net;

   public void ConfigureServices(IServiceCollection services)
   {
       // Configure client for the MultiversX Mainnet
       services.AddMvxApiClient(NetworkType.Mainnet);
   }
   ```

3. Usage: With the client configured and registered, inject and use `IMvxApiClient` wherever you need access to the MultiversX API.
   ```csharp
   using Mvx.ApiClient.Net;

   public class BlockchainService
   {
       private readonly IMvxApiClient _mvxApiClient;
    
       public BlockchainService(IMvxApiClient mvxApiClient)
       {
           _mvxApiClient = mvxApiClient;
       }
    
       public async Task GetNetworkStats()
       {
           var networkStats = await _mvxApiClient.Network.GetStatsAsync(
               new DataSelection { Fields = ["accounts", "blocks"] });
           
           // Process network stats as needed ...
       }
   }
   ```

   xExchange endpoints are available through the `XExchange` client:

   ```csharp
   var pairs = await _mvxApiClient.XExchange.GetPairsAsync(
       new QueryOptions
       {
           Pagination = new Pagination { Limit = 25 },
           Data = new DataSelection { Fields = ["id", "symbol"] }
       });
   ```

For advanced configuration, use the options overload:

```csharp
services.AddMvxApiClient(options =>
{
    options.Network = NetworkType.Mainnet;
    options.Timeout = TimeSpan.FromSeconds(30);
});
```
   
The public MultiversX API is rate limited. See the official MultiversX API documentation for current limits and infrastructure details.

## Build and Test

To build the project locally, ensure you have the following tools installed:
- [.NET SDK 10.0](https://dotnet.microsoft.com/download/dotnet/10.0)

The package targets `net8.0` and `net10.0`.

After cloning the repository, you can build the project with `dotnet build Mvx.ApiClient.Net.slnx` and run all tests with `dotnet test Mvx.ApiClient.Net.slnx`.

Live API smoke tests are included in a separate integration-test project and are disabled by default. Set `MVX_API_LIVE_TESTS=true` before running tests to enable calls against the public MultiversX API.

`eng/package-smoke-test.ps1` validates the packed NuGet as a fresh consumer would use it: it creates a temporary console app, restores the local package, and compiles README-style usage.

## Contributing Endpoint Groups

New GET endpoint groups should follow the existing structure:

- Add the public interface in `src/Mvx.ApiClient.Net/Abstractions`.
- Add the internal implementation in `src/Mvx.ApiClient.Net/Clients`.
- Add response models in `src/Mvx.ApiClient.Net/Models/<Domain>`.
- Add request paths in `EndpointPaths`.
- Use `ApiRequestExecutor` for HTTP, query encoding, validation, and JSON deserialization.
- Register the client in `ServiceCollectionExtensions`.
- Add HTTP-handler unit tests and update `PublicApi.Shipped.txt` when the public surface changes.

## Versioning

Mvx.ApiClient.Net follows semantic versioning.

## Documentation

Project documentation lives in `docs/` and is built with Zensical.

## Changelog

The changelog is available in the [CHANGELOG.md](./CHANGELOG.md) file.

## License

The code under this repository is available under the MIT license.
For more details, please refer yourself to the [license](./LICENSE) file.
