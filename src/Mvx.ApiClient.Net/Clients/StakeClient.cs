#nullable enable
using System.Text.Json;
using Mvx.ApiClient.Net.Infrastructure;
using Mvx.ApiClient.Net.Models.Api;

namespace Mvx.ApiClient.Net.Clients;

internal sealed class StakeClient : IStakeClient
{
    private readonly ApiRequestExecutor _requestExecutor;

    public StakeClient(HttpClient httpClient)
    {
        _requestExecutor = new ApiRequestExecutor(httpClient);
    }

    [ApiOperation("/stake", "StakeController_getGlobalStake")]
    public async Task<GlobalStake> GetGlobalStakeAsync(CancellationToken cancellationToken = default)
    {
        var path = "stake";
        QueryParameters? query = null;
        return await _requestExecutor.GetJsonAsync<GlobalStake>(path, query, cancellationToken);
    }

}
