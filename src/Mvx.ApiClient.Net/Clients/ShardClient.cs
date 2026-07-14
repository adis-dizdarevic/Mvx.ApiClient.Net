#nullable enable
using System.Text.Json;
using Mvx.ApiClient.Net.Infrastructure;
using Mvx.ApiClient.Net.Models.Api;
using Mvx.ApiClient.Net.Requests.Shards;

namespace Mvx.ApiClient.Net.Clients;

internal sealed class ShardClient : IShardClient
{
    private readonly ApiRequestExecutor _requestExecutor;

    public ShardClient(HttpClient httpClient)
    {
        _requestExecutor = new ApiRequestExecutor(httpClient);
    }

    [ApiOperation("/shards", "ShardController_getShards")]
    public async Task<IReadOnlyList<Shard>> GetShardsAsync(GetShardsOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = "shards";
        var query = new QueryParameters();
        query.AddPagination(options?.Pagination);
        return await _requestExecutor.GetJsonAsync<IReadOnlyList<Shard>>(path, query, cancellationToken);
    }

}
