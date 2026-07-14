#nullable enable
using System.Text.Json;
using Mvx.ApiClient.Net.Infrastructure;
using Mvx.ApiClient.Net.Models.Api;
using Mvx.ApiClient.Net.Requests.Miniblocks;

namespace Mvx.ApiClient.Net.Clients;

internal sealed class MiniblockClient : IMiniblockClient
{
    private readonly ApiRequestExecutor _requestExecutor;

    public MiniblockClient(HttpClient httpClient)
    {
        _requestExecutor = new ApiRequestExecutor(httpClient);
    }

    [ApiOperation("/miniblocks", "MiniBlockController_getMiniBlocks")]
    public async Task<IReadOnlyList<MiniBlockDetailed>> GetMiniBlocksAsync(GetMiniBlocksOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = "miniblocks";
        var query = new QueryParameters();
        query.AddPagination(options?.Pagination);
        query.AddCollection("hashes", options?.Hashes);
        query.AddOptionalEnum("type", options?.Type);
        return await _requestExecutor.GetJsonAsync<IReadOnlyList<MiniBlockDetailed>>(path, query, cancellationToken);
    }

    [ApiOperation("/miniblocks/{miniBlockHash}", "MiniBlockController_getBlock")]
    public async Task<MiniBlockDetailed> GetMiniBlockAsync(string miniBlockHash, CancellationToken cancellationToken = default)
    {
        var path = $"miniblocks/{ApiPath.EscapeRequired(miniBlockHash.ToString(), nameof(miniBlockHash))}";
        QueryParameters? query = null;
        return await _requestExecutor.GetJsonAsync<MiniBlockDetailed>(path, query, cancellationToken);
    }

}
