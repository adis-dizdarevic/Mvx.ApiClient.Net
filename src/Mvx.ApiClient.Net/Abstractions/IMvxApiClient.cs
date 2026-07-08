namespace Mvx.ApiClient.Net;

/// <summary>
/// Root client that exposes MultiversX API endpoint groups.
/// </summary>
public interface IMvxApiClient
{
    /// <summary>
    /// The configured MultiversX network.
    /// </summary>
    NetworkType NetworkType { get; }

    /// <summary>
    /// Client for xExchange endpoints.
    /// </summary>
    IXExchangeClient XExchange { get; }

    /// <summary>
    /// Client for network information endpoints.
    /// </summary>
    INetworkClient Network { get; }
}
