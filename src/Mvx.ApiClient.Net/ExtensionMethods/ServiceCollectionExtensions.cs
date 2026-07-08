using Microsoft.Extensions.DependencyInjection;
using Mvx.ApiClient.Net.Clients;
using Mvx.ApiClient.Net.Exceptions;
using System.Net;
using System.Net.Mime;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net;

/// <summary>
/// Extension methods for registering MultiversX API services.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers the MultiversX API client using a public MultiversX network.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="networkType">The type of network to connect to.</param>
    /// <returns>The configured service collection.</returns>
    public static IServiceCollection AddMvxApiClient(this IServiceCollection services, NetworkType networkType)
    {
        return services.AddMvxApiClient(options => options.Network = networkType);
    }

    /// <summary>
    /// Registers the MultiversX API client.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configureOptions">A callback for configuring the API client.</param>
    /// <returns>The configured service collection.</returns>
    public static IServiceCollection AddMvxApiClient(this IServiceCollection services, Action<MvxApiClientOptions> configureOptions)
    {
        services.AddTransient<ErrorHandler>();

        var options = new MvxApiClientOptions();
        configureOptions(options);

        var baseAddress = options.BaseAddress ?? GetBaseAddress(options.Network);

        RegisterClient<IMexClient, MexClient>(services, baseAddress, options);
        RegisterClient<INetworkClient, NetworkClient>(services, baseAddress, options);

        services.AddTransient<IMvxApiClient>(provider =>
        {
            var mexClient = provider.GetRequiredService<IMexClient>();
            var networkClient = provider.GetRequiredService<INetworkClient>();

            return new MvxApiClient(options.Network, mexClient, networkClient);
        });

        return services;
    }

    private static void RegisterClient<TClientInterface, TClientImplementation>(IServiceCollection services, Uri baseAddress, MvxApiClientOptions options)
        where TClientInterface : class
        where TClientImplementation : class, TClientInterface
    {
        services.AddHttpClient<TClientInterface, TClientImplementation>(client =>
        {
            client.BaseAddress = baseAddress;
            if (options.Timeout is not null)
            {
                client.Timeout = options.Timeout.Value;
            }

            client.DefaultRequestHeaders.Add("accept", MediaTypeNames.Application.Json);
            options.ConfigureHttpClient?.Invoke(client);
        })
        .AddHttpMessageHandler<ErrorHandler>();
    }

    private static Uri GetBaseAddress(NetworkType networkType)
    {
        var baseAddress = networkType switch
        {
            NetworkType.Mainnet => Constants.BaseAddressMainnetApi,
            NetworkType.Testnet => Constants.BaseAddressTestnetApi,
            NetworkType.Devnet => Constants.BaseAddressDevnetApi,
            _ => throw new ArgumentOutOfRangeException(nameof(networkType), $"Unexpected network type: {networkType}")
        };

        return new Uri(baseAddress);
    }

    internal sealed class ErrorHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                return response;
            }

            var statusCode = response.StatusCode;
            var statusCodeNumber = (int)statusCode;
            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            var fallbackMessage = $"MultiversX API request failed with status code {statusCodeNumber} ({statusCode}).";
            var fallbackError = response.ReasonPhrase ?? statusCode.ToString();

            if (string.IsNullOrWhiteSpace(content))
            {
                throw new MvxApiException(fallbackMessage, fallbackError, statusCode, request.RequestUri, request.Method);
            }

            try
            {
                var errorDetails = JsonSerializer.Deserialize<ApiErrorResponse>(content, ErrorJsonSerializerOptions);
                var message = string.IsNullOrWhiteSpace(errorDetails?.Message) ? fallbackMessage : errorDetails.Message;
                var error = string.IsNullOrWhiteSpace(errorDetails?.Error) ? fallbackError : errorDetails.Error;
                var apiStatusCode = errorDetails?.StatusCode is > 0 ? (HttpStatusCode)errorDetails.StatusCode : statusCode;

                throw new MvxApiException(message, error, apiStatusCode, request.RequestUri, request.Method, content);
            }
            catch (JsonException)
            {
                throw new MvxApiException($"{fallbackMessage} Response content: {content}", fallbackError, statusCode, request.RequestUri, request.Method, content);
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
