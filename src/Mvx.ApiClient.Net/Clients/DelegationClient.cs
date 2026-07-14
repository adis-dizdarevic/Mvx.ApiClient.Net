#nullable enable
using System.Text.Json;
using Mvx.ApiClient.Net.Infrastructure;
using Mvx.ApiClient.Net.Models.Api;

namespace Mvx.ApiClient.Net.Clients;

internal sealed class DelegationClient : IDelegationClient
{
    private readonly ApiRequestExecutor _requestExecutor;

    public DelegationClient(HttpClient httpClient)
    {
        _requestExecutor = new ApiRequestExecutor(httpClient);
    }

    [ApiOperation("/delegation", "DelegationController_getDelegationDetails")]
    public async Task<Delegation> GetDelegationDetailsAsync(CancellationToken cancellationToken = default)
    {
        var path = "delegation";
        QueryParameters? query = null;
        return await _requestExecutor.GetJsonAsync<Delegation>(path, query, cancellationToken);
    }

    [ApiOperation("/delegation-legacy", "DelegationLegacyController_getBlock")]
    public async Task<DelegationLegacy> GetDelegationLegacyAsync(CancellationToken cancellationToken = default)
    {
        var path = "delegation-legacy";
        QueryParameters? query = null;
        return await _requestExecutor.GetJsonAsync<DelegationLegacy>(path, query, cancellationToken);
    }

}
