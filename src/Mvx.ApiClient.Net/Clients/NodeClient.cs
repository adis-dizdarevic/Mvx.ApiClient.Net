#nullable enable
using System.Text.Json;
using Mvx.ApiClient.Net.Infrastructure;
using Mvx.ApiClient.Net.Models.Api;
using Mvx.ApiClient.Net.Requests.Nodes;

namespace Mvx.ApiClient.Net.Clients;

internal sealed class NodeClient : INodeClient
{
    private readonly ApiRequestExecutor _requestExecutor;

    public NodeClient(HttpClient httpClient)
    {
        _requestExecutor = new ApiRequestExecutor(httpClient);
    }

    [ApiOperation("/nodes", "NodeController_getNodes")]
    public async Task<IReadOnlyList<Node>> GetNodesAsync(GetNodesOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = "nodes";
        var query = new QueryParameters();
        query.AddPagination(options?.Pagination);
        query.AddString("search", options?.Search);
        query.AddCollection("keys", options?.Keys);
        query.AddBoolean("online", options?.Online);
        query.AddOptionalEnum("type", options?.Type);
        query.AddOptionalEnum("status", options?.Status);
        query.AddOptionalNumber("shard", options?.Shard);
        query.AddBoolean("issues", options?.Issues);
        query.AddString("identity", options?.Identity);
        query.AddString("provider", options?.Provider);
        query.AddString("owner", options?.Owner);
        query.AddBoolean("auctioned", options?.Auctioned);
        query.AddBoolean("fullHistory", options?.FullHistory);
        query.AddOptionalEnum("sort", options?.Sort);
        query.AddOptionalEnum("order", options?.Order);
        query.AddBoolean("withIdentityInfo", options?.WithIdentityInfo);
        query.AddBoolean("isQualified", options?.IsQualified);
        query.AddBoolean("isAuctioned", options?.IsAuctioned);
        query.AddBoolean("isAuctionDangerZone", options?.IsAuctionDangerZone);
        return await _requestExecutor.GetJsonAsync<IReadOnlyList<Node>>(path, query, cancellationToken);
    }

    [ApiOperation("/nodes/versions", "NodeController_getNodeVersions")]
    public async Task<IReadOnlyDictionary<string, decimal>> GetNodeVersionsAsync(CancellationToken cancellationToken = default)
    {
        var path = "nodes/versions";
        QueryParameters? query = null;
        return await _requestExecutor.GetJsonAsync<IReadOnlyDictionary<string, decimal>>(path, query, cancellationToken);
    }

    [ApiOperation("/nodes/count", "NodeController_getNodeCount")]
    public async Task<long> GetNodeCountAsync(GetNodeCountOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = "nodes/count";
        var query = new QueryParameters();
        query.AddString("search", options?.Search);
        query.AddBoolean("online", options?.Online);
        query.AddOptionalEnum("type", options?.Type);
        query.AddOptionalEnum("status", options?.Status);
        query.AddOptionalNumber("shard", options?.Shard);
        query.AddBoolean("issues", options?.Issues);
        query.AddString("identity", options?.Identity);
        query.AddString("provider", options?.Provider);
        query.AddString("owner", options?.Owner);
        query.AddBoolean("auctioned", options?.Auctioned);
        query.AddBoolean("fullHistory", options?.FullHistory);
        query.AddOptionalEnum("sort", options?.Sort);
        query.AddOptionalEnum("order", options?.Order);
        query.AddBoolean("isQualified", options?.IsQualified);
        query.AddBoolean("isAuctioned", options?.IsAuctioned);
        query.AddBoolean("isAuctionDangerZone", options?.IsAuctionDangerZone);
        return await _requestExecutor.GetInt64Async(path, query, cancellationToken);
    }

    [ApiOperation("/nodes/auctions", "NodeController_getNodesAuctions")]
    public async Task<IReadOnlyList<NodeAuction>> GetNodesAuctionsAsync(GetNodesAuctionsOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = "nodes/auctions";
        var query = new QueryParameters();
        query.AddPagination(options?.Pagination);
        query.AddOptionalEnum("sort", options?.Sort);
        query.AddOptionalEnum("order", options?.Order);
        return await _requestExecutor.GetJsonAsync<IReadOnlyList<NodeAuction>>(path, query, cancellationToken);
    }

    [ApiOperation("/nodes/{bls}", "NodeController_getNode")]
    public async Task<Node> GetNodeAsync(string bls, CancellationToken cancellationToken = default)
    {
        var path = $"nodes/{ApiPath.EscapeRequired(bls.ToString(), nameof(bls))}";
        QueryParameters? query = null;
        return await _requestExecutor.GetJsonAsync<Node>(path, query, cancellationToken);
    }

}
