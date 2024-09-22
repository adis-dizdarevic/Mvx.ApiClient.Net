using Microsoft.Extensions.DependencyInjection;
using Mvx.ApiClient.Clients;
using Mvx.ApiClient.Exceptions;
using Mvx.ApiClient.Interfaces;
using Mvx.ApiClient.Interfaces.Clients;
using System.Net.Mime;
using System.Text.Json;

namespace Mvx.ApiClient.ExtensionMethods;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMvxApiClient(this IServiceCollection services)
    {
        services.AddTransient<ErrorHandler>();
        
        RegisterClient<INetworkClient, NetworkClient>(services);

        services.AddTransient<IMvxApiClient>(provider =>
        {
            var networkClient = provider.GetRequiredService<INetworkClient>();

            return new MvxApiClient(networkClient);
        });
        
        return services;
    }

    private static void RegisterClient<TClientInterface, TClientImplementation>(this IServiceCollection services)
        where TClientInterface : class
        where TClientImplementation : class, TClientInterface
    {
        services.AddHttpClient<TClientInterface, TClientImplementation>(client =>
        {
            client.BaseAddress = new Uri("https://api.multiversx.com/");
            client.DefaultRequestHeaders.Add("Accept", MediaTypeNames.Application.Json);
        })
        .AddHttpMessageHandler<ErrorHandler>();
    }

    private class ErrorHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);

            if ((int)response.StatusCode >= 400 && (int)response.StatusCode < 500)
            {
                var content = await response.Content.ReadAsStringAsync(cancellationToken);

                var errorDetails = JsonSerializer.Deserialize<MvxApiException>(content)!;
                
                throw new MvxApiException(errorDetails.Message, errorDetails.Error, errorDetails.StatusCode);
            }

            return response;
        }
    }
}
