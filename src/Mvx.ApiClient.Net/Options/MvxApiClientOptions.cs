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
}
