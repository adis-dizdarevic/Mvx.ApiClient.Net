using Microsoft.Extensions.DependencyInjection;

namespace Mvx.ApiClient.Net;

/// <summary>
/// Configures the MultiversX API client registration.
/// </summary>
public sealed class MvxApiClientOptions
{
    /// <summary>
    /// Gets or sets the MultiversX network to use.
    /// </summary>
    public NetworkType Network { get; set; } = NetworkType.Mainnet;

    /// <summary>
    /// Gets or sets a custom API base address. When set, this value overrides <see cref="Network"/>.
    /// </summary>
    public Uri? BaseAddress { get; set; }

    /// <summary>
    /// Gets or sets the HTTP timeout applied to registered clients.
    /// </summary>
    public TimeSpan? Timeout { get; set; }

    /// <summary>
    /// Gets or sets an optional callback for additional <see cref="HttpClient"/> configuration.
    /// </summary>
    public Action<HttpClient>? ConfigureHttpClient { get; set; }

    /// <summary>
    /// Gets or sets an optional callback for configuring the underlying HTTP client builders.
    /// </summary>
    /// <remarks>
    /// Use this callback to add resilient handlers, logging, or other <see cref="IHttpClientBuilder"/> configuration.
    /// The callback is applied to every client registered by <c>AddMvxApiClient</c>.
    /// </remarks>
    public Action<IHttpClientBuilder>? ConfigureHttpClientBuilder { get; set; }
}
