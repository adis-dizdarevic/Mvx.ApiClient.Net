#nullable enable
using System.Text.Json;
using Mvx.ApiClient.Net.Infrastructure;
using Mvx.ApiClient.Net.Models.Api;
using Mvx.ApiClient.Net.Requests.Blocks;

namespace Mvx.ApiClient.Net.Clients;

internal sealed class BlockClient : IBlockClient
{
    private readonly ApiRequestExecutor _requestExecutor;

    public BlockClient(HttpClient httpClient)
    {
        _requestExecutor = new ApiRequestExecutor(httpClient);
    }

    [ApiOperation("/blocks", "BlockController_getBlocks")]
    public async Task<IReadOnlyList<Block>> GetBlocksAsync(GetBlocksOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = "blocks";
        var query = new QueryParameters();
        query.AddPagination(options?.Pagination);
        query.AddOptionalNumber("shard", options?.Shard);
        query.AddString("proposer", options?.Proposer);
        query.AddString("validator", options?.Validator);
        query.AddOptionalNumber("epoch", options?.Epoch);
        query.AddOptionalNumber("nonce", options?.Nonce);
        query.AddCollection("hashes", options?.Hashes);
        query.AddOptionalEnum("order", options?.Order);
        query.AddBoolean("withProposerIdentity", options?.WithProposerIdentity);
        return await _requestExecutor.GetJsonAsync<IReadOnlyList<Block>>(path, query, cancellationToken);
    }

    [ApiOperation("/blocks/count", "BlockController_getBlocksCount")]
    public async Task<long> GetBlocksCountAsync(GetBlocksCountOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = "blocks/count";
        var query = new QueryParameters();
        query.AddOptionalNumber("shard", options?.Shard);
        query.AddString("proposer", options?.Proposer);
        query.AddString("validator", options?.Validator);
        query.AddOptionalNumber("epoch", options?.Epoch);
        query.AddOptionalNumber("nonce", options?.Nonce);
        return await _requestExecutor.GetInt64Async(path, query, cancellationToken);
    }

    [ApiOperation("/blocks/latest", "BlockController_getLatestBlock")]
    public async Task<BlockDetailed> GetLatestBlockAsync(GetLatestBlockOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = "blocks/latest";
        var query = new QueryParameters();
        query.AddOptionalNumber("ttl", options?.Ttl);
        return await _requestExecutor.GetJsonAsync<BlockDetailed>(path, query, cancellationToken);
    }

    [ApiOperation("/blocks/{hash}", "BlockController_getBlock")]
    public async Task<BlockDetailed> GetBlockAsync(string hash, CancellationToken cancellationToken = default)
    {
        var path = $"blocks/{ApiPath.EscapeRequired(hash.ToString(), nameof(hash))}";
        QueryParameters? query = null;
        return await _requestExecutor.GetJsonAsync<BlockDetailed>(path, query, cancellationToken);
    }

}
