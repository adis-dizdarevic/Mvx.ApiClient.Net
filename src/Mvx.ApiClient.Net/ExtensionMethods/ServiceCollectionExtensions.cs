using Microsoft.Extensions.DependencyInjection;
using Mvx.ApiClient.Net.Clients;
using Mvx.ApiClient.Net.Enums;
using Mvx.ApiClient.Net.Exceptions;
using Mvx.ApiClient.Net.Interfaces.Clients;
using System.Net.Mime;
using System.Text.Json;

namespace Mvx.ApiClient.Net.ExtensionMethods;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers the MultiversX API client as a transient service to the service collection
    /// </summary>
    /// <param name="services">The service collection</param>
    /// <param name="networkType">The type of network to connect to</param>
    /// <returns></returns>
    public static IServiceCollection AddMvxApiClient(this IServiceCollection services, NetworkType networkType)
    {
        services.AddTransient<ErrorHandler>();
        
        var baseAddress = networkType switch
        {
            NetworkType.Mainnet => Constants.BaseAddressMainnetApi,
            NetworkType.Testnet => Constants.BaseAddressTestnetApi,
            NetworkType.Devnet => Constants.BaseAddressDevnetApi,
            _ => throw new ArgumentOutOfRangeException(nameof(networkType), $"Unexpected network type: {networkType}")
        };
        
        RegisterClient<INetworkClient, NetworkClient>(services, baseAddress);

        services.AddTransient<IMvxApiClient>(provider =>
        {
            var networkClient = provider.GetRequiredService<INetworkClient>();
            
            return new MvxApiClient(networkType, networkClient);
        });
        
        return services;
    }

    /// <summary>
    /// Registers a custom client
    /// </summary>
    /// <param name="services">The service collection</param>
    /// <param name="baseAddress">The base address of the client</param>
    /// <typeparam name="TClientInterface">The client interface</typeparam>
    /// <typeparam name="TClientImplementation">The client implementation</typeparam>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the type of network is not valid</exception>
    private static void RegisterClient<TClientInterface, TClientImplementation>(this IServiceCollection services, string baseAddress)
        where TClientInterface : class
        where TClientImplementation : class, TClientInterface
    {
        services.AddHttpClient<TClientInterface, TClientImplementation>(client =>
        {
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Add("accept", MediaTypeNames.Application.Json);
        })
        .AddHttpMessageHandler<ErrorHandler>();
    }

    internal sealed class ErrorHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);

            if ((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
            {
                return response;
            }

            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            var errorDetails = JsonSerializer.Deserialize<MvxApiException>(content)!;
                
            throw new MvxApiException(errorDetails.Message, errorDetails.Error, errorDetails.StatusCode);
        }
    }
}
