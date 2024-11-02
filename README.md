# MultiversX ApiClient

## Introduction

Mvx.ApiClient.Net is a C# wrapper for the MultiversX API, designed for querying data from the blockchain. It provides a simple and efficient interface to interact with the API, making it easy to retrieve relevant information for your applications. The client is built with performance and scalability in mind, allowing developers to easily integrate with the MultiversX network.

## Getting started

To integrate Mvx.ApiClient.Net into your C# application, follow these setup steps.

1. Installation: Add the package via NuGet Package Manager or the .NET CLI:
   ```
   dotnet add package Mvx.ApiClient.Net
   ```
   
2. Configuration: Configure the client by registering it with your application's `IServiceCollection`. Specify the desired network environment — Mainnet, Testnet or Devnet — during setup using the `AddMvxApiClient` extension method. This will register the required services.
   ```csharp
   using Mvx.ApiClient.Net;

   public void ConfigureServices(IServiceCollection services)
   {
       // Configure client for the MultiversX Mainnet
       services.AddMvxApiClient(NetworkType.Mainnet);
   }
   ```

3. Usage: With the client configured and registered, inject and use `IMvxApiClient` wherever you need access to the MultiversX API.
   ```csharp
   public class BlockchainService
   {
       private readonly IMvxApiClient _mvxApiClient;
    
       public BlockchainService(IMvxApiClient mvxApiClient)
       {
           _mvxApiClient = mvxApiClient;
       }
    
       public async Task GetNetworkStats()
       {
           var networkStats = await _mvxApiClient.Network.GetNetworkStatsAsync();
           
           // Process network stats as needed ...
       }
   }
   ```
   
For more examples and advanced usage, consult the [docs](https://github.com/adis-dizdarevic/Mvx.ApiClient.Net/wiki).

## Build and Test

To build the project locally, ensure you have the following tools installed:
- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)

After cloning the repository, you can build the project with `dotnet build` and run all tests with `dotnet test`

## Versioning

Mvx.ApiClient.Net follows semantic versioning.

## Changelog

The changelog is available in the [CHANGELOG.md](./CHANGELOG.md) file.

## License

The code under this repository is available under the MIT license.
For more details, please refer yourself to the [license](./LICENSE) file.