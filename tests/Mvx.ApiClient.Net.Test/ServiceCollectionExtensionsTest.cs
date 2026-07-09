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
        await Assert.That(provider.SingleOrDefault(sd => sd.ServiceType == typeof(IXExchangeClient))?.Lifetime).IsEqualTo(ServiceLifetime.Transient);
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
        await Assert.That(client.XExchange).IsNotNull();

        var factory = provider.GetRequiredService<IHttpClientFactory>();
        var httpClient = factory.CreateClient(nameof(INetworkClient));
        await Assert.That(httpClient.BaseAddress).IsEqualTo(new Uri("https://example.com"));
        await Assert.That(httpClient.Timeout).IsEqualTo(TimeSpan.FromSeconds(12));
        await Assert.That(httpClient.DefaultRequestHeaders.Contains("x-test")).IsTrue();
    }

    [Test]
    public async Task AddMvxApiClient_WithCustomBasePath_PreservesBasePathForRequests()
    {
        var services = new ServiceCollection();
        var provider = services.AddMvxApiClient(options => options.BaseAddress = new Uri("https://example.com/api")).BuildServiceProvider();
        var factory = provider.GetRequiredService<IHttpClientFactory>();

        var httpClient = factory.CreateClient(nameof(INetworkClient));

        await Assert.That(httpClient.BaseAddress).IsEqualTo(new Uri("https://example.com/api/"));
    }

    [Test]
    public async Task AddMvxApiClient_WithInvalidBaseAddress_ThrowsArgumentException()
    {
        var services = new ServiceCollection();

        var exception = Assert.Throws<ArgumentException>(() => services.AddMvxApiClient(options => options.BaseAddress = new Uri("ftp://example.com")));

        await Assert.That(exception.Message).Contains("absolute HTTP or HTTPS URI");
    }

    [Test]
    public async Task AddMvxApiClient_WithInvalidTimeout_ThrowsArgumentOutOfRangeException()
    {
        var services = new ServiceCollection();

        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => services.AddMvxApiClient(options => options.Timeout = TimeSpan.Zero));

        await Assert.That(exception.Message).Contains("Timeout must be positive or infinite.");
    }
}
