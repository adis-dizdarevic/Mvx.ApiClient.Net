using Microsoft.Extensions.DependencyInjection;
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

    [Test]
    public async Task AddMvxApiClient_WithOptions_RegistersConfiguredNetworkAndHttpClient()
    {
        // arrange
        var services = new ServiceCollection();

        // act
        var provider = services.AddMvxApiClient(options =>
        {
            options.Network = NetworkType.Devnet;
            options.BaseAddress = new Uri("https://example.com");
            options.Timeout = TimeSpan.FromSeconds(12);
            options.ConfigureHttpClient = client => client.DefaultRequestHeaders.Add("x-test", "configured");
        }).BuildServiceProvider();

        // assert
        var client = provider.GetRequiredService<IMvxApiClient>();
        await Assert.That(client.NetworkType).IsEqualTo(NetworkType.Devnet);

        var factory = provider.GetRequiredService<IHttpClientFactory>();
        var httpClient = factory.CreateClient(nameof(INetworkClient));
        await Assert.That(httpClient.BaseAddress).IsEqualTo(new Uri("https://example.com"));
        await Assert.That(httpClient.Timeout).IsEqualTo(TimeSpan.FromSeconds(12));
        await Assert.That(httpClient.DefaultRequestHeaders.Contains("x-test")).IsTrue();
    }
}
