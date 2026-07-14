#nullable enable
using System.Text.Json;
using Mvx.ApiClient.Net.Infrastructure;
using Mvx.ApiClient.Net.Models.Api;

namespace Mvx.ApiClient.Net.Clients;

internal sealed class WebsocketClient : IWebsocketClient
{
    private readonly ApiRequestExecutor _requestExecutor;

    public WebsocketClient(HttpClient httpClient)
    {
        _requestExecutor = new ApiRequestExecutor(httpClient);
    }

    [ApiOperation("/websocket/config", "WebsocketController_getConfiguration")]
    public async Task<WebsocketConfig> GetConfigurationAsync(CancellationToken cancellationToken = default)
    {
        var path = "websocket/config";
        QueryParameters? query = null;
        return await _requestExecutor.GetJsonAsync<WebsocketConfig>(path, query, cancellationToken);
    }

}
