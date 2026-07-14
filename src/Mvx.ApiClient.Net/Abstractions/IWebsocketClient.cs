#nullable enable
using System.Text.Json;
using Mvx.ApiClient.Net.Models.Api;

namespace Mvx.ApiClient.Net;

/// <summary>Client for MultiversX Websocket GET endpoints.</summary>
public interface IWebsocketClient
{
    /// <summary>Websocket configuration.</summary>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<WebsocketConfig> GetConfigurationAsync(CancellationToken cancellationToken = default);

}
