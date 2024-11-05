using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Mvx.ApiClient.Net.Enums;
using Mvx.ApiClient.Net.ExtensionMethods;
using Mvx.ApiClient.Net.Interfaces.Clients;

namespace Mvx.ApiClient.Net.Test;

public class ServiceCollectionExtensionsTest
{
    [Fact]
    public void AddMvxApiClient_AddClientsToServiceCollection_AllClientsAreRegistered()
    {
        // arrange
        var services = new ServiceCollection();
        
        // act
        var provider = services.AddMvxApiClient(NetworkType.Testnet);

        // assert
        provider.Should().ContainSingle(sd => sd.ServiceType == typeof(IMvxApiClient) && sd.Lifetime == ServiceLifetime.Transient);
        provider.Should().ContainSingle(sd => sd.ServiceType == typeof(IMexClient) && sd.Lifetime == ServiceLifetime.Transient);
        provider.Should().ContainSingle(sd => sd.ServiceType == typeof(INetworkClient) && sd.Lifetime == ServiceLifetime.Transient);
        provider.Should().ContainSingle(sd => sd.ServiceType == typeof(ServiceCollectionExtensions.ErrorHandler) && sd.Lifetime == ServiceLifetime.Transient);
    }
    
    [Theory]
    [InlineData(NetworkType.Mainnet)]
    [InlineData(NetworkType.Devnet)]
    [InlineData(NetworkType.Testnet)]
    public void AddMvxApiClient_UseSpecificNetworkType_ShouldBeRegisteredWithSpecifiedNetworkType(NetworkType networkType)
    {
        // arrange
        var services = new ServiceCollection();
        
        // act
        var provider = services.AddMvxApiClient(networkType).BuildServiceProvider();

        // assert
        var client = provider.GetRequiredService<IMvxApiClient>();
        client.NetworkType.Should().Be(networkType);
    }
}
