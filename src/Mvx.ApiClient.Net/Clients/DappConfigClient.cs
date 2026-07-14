#nullable enable
using System.Text.Json;
using Mvx.ApiClient.Net.Infrastructure;
using Mvx.ApiClient.Net.Models.Api;

namespace Mvx.ApiClient.Net.Clients;

internal sealed class DappConfigClient : IDappConfigClient
{
    private readonly ApiRequestExecutor _requestExecutor;

    public DappConfigClient(HttpClient httpClient)
    {
        _requestExecutor = new ApiRequestExecutor(httpClient);
    }

    [ApiOperation("/dapp/config", "DappConfigController_getDappConfiguration")]
    public async Task<DappConfig> GetDappConfigurationAsync(CancellationToken cancellationToken = default)
    {
        var path = "dapp/config";
        QueryParameters? query = null;
        return await _requestExecutor.GetJsonAsync<DappConfig>(path, query, cancellationToken);
    }

}
