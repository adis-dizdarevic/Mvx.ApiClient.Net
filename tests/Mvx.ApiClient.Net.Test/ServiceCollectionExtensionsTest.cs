using Microsoft.Extensions.DependencyInjection;
using Mvx.ApiClient.Net.Enums;
using Mvx.ApiClient.Net.ExtensionMethods;
using Mvx.ApiClient.Net.Interfaces.Clients;
using TUnit.Assertions;

namespace Mvx.ApiClient.Net.Test;

public class ServiceCollectionExtensionsTest
{
    [Test]
    public async Task AddMvxApiClient_AddClientsToServiceCollection_AllClientsAreRegistered()
    {
        // arrange
        var services = new ServiceCollection();

        // act
        var provider = services.AddMvxApiClient(NetworkType.Testnet);

        // assert
        await Assert.That(provider.SingleOrDefault(sd => sd.ServiceType == typeof(IMvxApiClient))?.Lifetime).IsEqualTo(ServiceLifetime.Transient);
        await Assert.That(provider.SingleOrDefault(sd => sd.ServiceType == typeof(IMexClient))?.Lifetime).IsEqualTo(ServiceLifetime.Transient);
        await Assert.That(provider.SingleOrDefault(sd => sd.ServiceType == typeof(INetworkClient))?.Lifetime).IsEqualTo(ServiceLifetime.Transient);
        await Assert.That(provider.SingleOrDefault(sd => sd.ServiceType == typeof(ServiceCollectionExtensions.ErrorHandler))?.Lifetime).IsEqualTo(ServiceLifetime.Transient);
    }

    [Test]
    [Arguments(NetworkType.Mainnet)]
    [Arguments(NetworkType.Devnet)]
    [Arguments(NetworkType.Testnet)]
    public async Task AddMvxApiClient_UseSpecificNetworkType_ShouldBeRegisteredWithSpecifiedNetworkType(NetworkType networkType)
    {
        // arrange
        var services = new ServiceCollection();

        // act
        var provider = services.AddMvxApiClient(networkType).BuildServiceProvider();

        // assert
        var client = provider.GetRequiredService<IMvxApiClient>();
        await Assert.That(client.NetworkType).IsEqualTo(networkType);
    }
}
