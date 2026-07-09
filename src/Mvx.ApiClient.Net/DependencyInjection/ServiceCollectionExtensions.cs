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
    /// <param name="services">The service collection to add the client registrations to.</param>
    /// <param name="networkType">The public MultiversX network to use.</param>
    /// <returns>The same service collection so calls can be chained.</returns>
    public static IServiceCollection AddMvxApiClient(this IServiceCollection services, NetworkType networkType)
    {
        ArgumentNullException.ThrowIfNull(services);

        return services.AddMvxApiClient(options => options.Network = networkType);
    }

    /// <summary>
    /// Registers the MultiversX API client.
    /// </summary>
    /// <param name="services">The service collection to add the client registrations to.</param>
    /// <param name="configureOptions">A callback that configures the MultiversX API client.</param>
    /// <returns>The same service collection so calls can be chained.</returns>
    public static IServiceCollection AddMvxApiClient(this IServiceCollection services, Action<MvxApiClientOptions> configureOptions)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configureOptions);

        services.AddTransient<ErrorHandler>();

        var options = new MvxApiClientOptions();
        configureOptions(options);

        var networkType = options.Network;
        var baseAddress = NormalizeBaseAddress(options.BaseAddress ?? GetBaseAddress(networkType));
        ValidateTimeout(options.Timeout);

        RegisterClient<IXExchangeClient, XExchangeClient>(services, baseAddress, options);
        RegisterClient<INetworkClient, NetworkClient>(services, baseAddress, options);

        services.AddTransient<IMvxApiClient>(provider =>
        {
            var xExchangeClient = provider.GetRequiredService<IXExchangeClient>();
            var networkClient = provider.GetRequiredService<INetworkClient>();

            return new MvxApiClient(networkType, xExchangeClient, networkClient);
        });

        return services;
    }

    private static void RegisterClient<TClientInterface, TClientImplementation>(IServiceCollection services, Uri baseAddress, MvxApiClientOptions options)
        where TClientInterface : class
        where TClientImplementation : class, TClientInterface
    {
        var builder = services.AddHttpClient<TClientInterface, TClientImplementation>(client =>
        {
            client.BaseAddress = baseAddress;
            if (options.Timeout is not null)
            {
                client.Timeout = options.Timeout.Value;
            }

            client.DefaultRequestHeaders.Add("accept", MediaTypeNames.Application.Json);
            options.ConfigureHttpClient?.Invoke(client);
        });

        options.ConfigureHttpClientBuilder?.Invoke(builder);
        builder.AddHttpMessageHandler<ErrorHandler>();
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

        return new Uri(baseAddress, UriKind.Absolute);
    }

    private static Uri NormalizeBaseAddress(Uri baseAddress)
    {
        if (!baseAddress.IsAbsoluteUri || (baseAddress.Scheme != Uri.UriSchemeHttp && baseAddress.Scheme != Uri.UriSchemeHttps))
        {
            throw new ArgumentException("Base address must be an absolute HTTP or HTTPS URI.", nameof(baseAddress));
        }

        return baseAddress.AbsoluteUri.EndsWith("/", StringComparison.Ordinal)
            ? baseAddress
            : new Uri($"{baseAddress.AbsoluteUri}/", UriKind.Absolute);
    }

    private static void ValidateTimeout(TimeSpan? timeout)
    {
        if (timeout is { } value && value != Timeout.InfiniteTimeSpan && value <= TimeSpan.Zero)
        {
            throw new ArgumentOutOfRangeException(nameof(timeout), "Timeout must be positive or infinite.");
        }
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

            string? content = null;

            try
            {
                var statusCode = response.StatusCode;
                var statusCodeNumber = (int)statusCode;
                var retryAfter = GetRetryAfter(response);
                content = await response.Content.ReadAsStringAsync(cancellationToken);
                var fallbackMessage = $"MultiversX API request failed with status code {statusCodeNumber} ({statusCode}).";
                var fallbackError = response.ReasonPhrase ?? statusCode.ToString();

                if (string.IsNullOrWhiteSpace(content))
                {
                    throw new MvxApiException(fallbackMessage, fallbackError, statusCode, request.RequestUri, request.Method, retryAfter: retryAfter);
                }

                var errorDetails = JsonSerializer.Deserialize<ApiErrorResponse>(content, ErrorJsonSerializerOptions);
                var message = string.IsNullOrWhiteSpace(errorDetails?.Message) ? fallbackMessage : errorDetails.Message;
                var error = string.IsNullOrWhiteSpace(errorDetails?.Error) ? fallbackError : errorDetails.Error;

                throw new MvxApiException(message, error, statusCode, request.RequestUri, request.Method, content, retryAfter);
            }
            catch (JsonException)
            {
                throw new MvxApiException(
                    $"MultiversX API request failed with status code {(int)response.StatusCode} ({response.StatusCode}). Response content: {content}",
                    response.ReasonPhrase ?? response.StatusCode.ToString(),
                    response.StatusCode,
                    request.RequestUri,
                    request.Method,
                    content,
                    GetRetryAfter(response));
            }
            finally
            {
                response.Dispose();
            }
        }

        private static TimeSpan? GetRetryAfter(HttpResponseMessage response)
        {
            var retryAfter = response.Headers.RetryAfter?.Delta
                ?? (response.Headers.RetryAfter?.Date - DateTimeOffset.UtcNow);

            return retryAfter is { } value && value > TimeSpan.Zero ? value : null;
        }

        private static JsonSerializerOptions ErrorJsonSerializerOptions { get; } = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        private sealed record ApiErrorResponse(
            [property: JsonPropertyName("message")] string? Message,
            [property: JsonPropertyName("error")] string? Error);
    }
}
