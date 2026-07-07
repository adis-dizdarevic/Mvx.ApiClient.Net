using Microsoft.Extensions.DependencyInjection;
using Mvx.ApiClient.Net.Clients;
using Mvx.ApiClient.Net.Enums;
using Mvx.ApiClient.Net.Exceptions;
using Mvx.ApiClient.Net.Interfaces.Clients;
using System.Net.Mime;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.ExtensionMethods;

/// <summary>
/// Extension methods for registering MultiversX API services.
/// </summary>
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
        
        RegisterClient<IMexClient, MexClient>(services, baseAddress);
        RegisterClient<INetworkClient, NetworkClient>(services, baseAddress);

        services.AddTransient<IMvxApiClient>(provider =>
        {
            var mexClient = provider.GetRequiredService<IMexClient>();
            var networkClient = provider.GetRequiredService<INetworkClient>();
            
            return new MvxApiClient(networkType, mexClient, networkClient);
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

            var statusCode = (int)response.StatusCode;
            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            var fallbackMessage = $"MultiversX API request failed with status code {statusCode} ({response.StatusCode}).";
            var fallbackError = response.ReasonPhrase ?? response.StatusCode.ToString();

            if (string.IsNullOrWhiteSpace(content))
            {
                throw new MvxApiException(fallbackMessage, fallbackError, statusCode);
            }

            try
            {
                var errorDetails = JsonSerializer.Deserialize<ApiErrorResponse>(content, ErrorJsonSerializerOptions);
                var message = string.IsNullOrWhiteSpace(errorDetails?.Message) ? fallbackMessage : errorDetails.Message;
                var error = string.IsNullOrWhiteSpace(errorDetails?.Error) ? fallbackError : errorDetails.Error;
                var apiStatusCode = errorDetails?.StatusCode is > 0 ? errorDetails.StatusCode : statusCode;

                throw new MvxApiException(message, error, apiStatusCode, content);
            }
            catch (JsonException)
            {
                throw new MvxApiException($"{fallbackMessage} Response content: {content}", fallbackError, statusCode, content);
            }
        }

        private static JsonSerializerOptions ErrorJsonSerializerOptions { get; } = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        private sealed record ApiErrorResponse(
            [property: JsonPropertyName("message")] string? Message,
            [property: JsonPropertyName("error")] string? Error,
            [property: JsonPropertyName("statusCode")] int StatusCode);
    }
}
