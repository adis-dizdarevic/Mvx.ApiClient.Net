#nullable enable
using System.Text.Json;
using Mvx.ApiClient.Net.Infrastructure;
using Mvx.ApiClient.Net.Models.Api;
using Mvx.ApiClient.Net.Requests.WaitingList;

namespace Mvx.ApiClient.Net.Clients;

internal sealed class WaitingListClient : IWaitingListClient
{
    private readonly ApiRequestExecutor _requestExecutor;

    public WaitingListClient(HttpClient httpClient)
    {
        _requestExecutor = new ApiRequestExecutor(httpClient);
    }

    [ApiOperation("/waiting-list", "WaitingListController_getWaitingList")]
    public async Task<IReadOnlyList<WaitingList>> GetWaitingListAsync(GetWaitingListOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = "waiting-list";
        var query = new QueryParameters();
        query.AddPagination(options?.Pagination);
        return await _requestExecutor.GetJsonAsync<IReadOnlyList<WaitingList>>(path, query, cancellationToken);
    }

    [ApiOperation("/waiting-list/count", "WaitingListController_getWaitingListCount")]
    public async Task<long> GetWaitingListCountAsync(CancellationToken cancellationToken = default)
    {
        var path = "waiting-list/count";
        QueryParameters? query = null;
        return await _requestExecutor.GetInt64Async(path, query, cancellationToken);
    }

}
