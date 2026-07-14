#nullable enable
using System.Text.Json;
using Mvx.ApiClient.Net.Infrastructure;
using Mvx.ApiClient.Net.Models.Api;
using Mvx.ApiClient.Net.Requests.Marketplace;

namespace Mvx.ApiClient.Net.Clients;

internal sealed class MarketplaceClient : IMarketplaceClient
{
    private readonly ApiRequestExecutor _requestExecutor;

    public MarketplaceClient(HttpClient httpClient)
    {
        _requestExecutor = new ApiRequestExecutor(httpClient);
    }

    [ApiOperation("/auctions", "NftMarketplaceController_getAuctions")]
    public async Task<IReadOnlyList<AuctionSummary>> GetAuctionsAsync(GetAuctionsOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = "auctions";
        var query = new QueryParameters();
        query.AddOptionalNumber("size", options?.Size);
        return await _requestExecutor.GetJsonAsync<IReadOnlyList<AuctionSummary>>(path, query, cancellationToken);
    }

    [ApiOperation("/auctions/count", "NftMarketplaceController_getAuctionsCount")]
    public async Task<long> GetAuctionsCountAsync(GetAuctionsCountOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = "auctions/count";
        var query = new QueryParameters();
        query.AddString("status", options?.Status);
        return await _requestExecutor.GetInt64Async(path, query, cancellationToken);
    }

    [ApiOperation("/auctions/{id}", "NftMarketplaceController_getAuctionId")]
    public async Task<AuctionSummary> GetAuctionAsync(long id, CancellationToken cancellationToken = default)
    {
        var path = $"auctions/{ApiPath.EscapeRequired(id.ToString(), nameof(id))}";
        QueryParameters? query = null;
        return await _requestExecutor.GetJsonAsync<AuctionSummary>(path, query, cancellationToken);
    }

    [ApiOperation("/accounts/{address}/auction/stats", "NftMarketplaceController_getAccountStats")]
    public async Task<AccountAuctionStats> GetAccountStatsAsync(string address, CancellationToken cancellationToken = default)
    {
        var path = $"accounts/{ApiPath.EscapeRequired(address.ToString(), nameof(address))}/auction/stats";
        QueryParameters? query = null;
        return await _requestExecutor.GetJsonAsync<AccountAuctionStats>(path, query, cancellationToken);
    }

    [ApiOperation("/accounts/{address}/auctions", "NftMarketplaceController_getAccountAuctions")]
    public async Task<Auction> GetAccountAuctionsAsync(string address, GetAccountAuctionsOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = $"accounts/{ApiPath.EscapeRequired(address.ToString(), nameof(address))}/auctions";
        var query = new QueryParameters();
        query.AddPagination(options?.Pagination);
        query.AddString("status", options?.Status);
        return await _requestExecutor.GetJsonAsync<Auction>(path, query, cancellationToken);
    }

    [ApiOperation("/accounts/{address}/auctions/count", "NftMarketplaceController_getAccountAuctionsCount")]
    public async Task<long> GetAccountAuctionsCountAsync(string address, CancellationToken cancellationToken = default)
    {
        var path = $"accounts/{ApiPath.EscapeRequired(address.ToString(), nameof(address))}/auctions/count";
        QueryParameters? query = null;
        return await _requestExecutor.GetInt64Async(path, query, cancellationToken);
    }

    [ApiOperation("/collections/{collection}/auction/stats", "NftMarketplaceController_getCollectionStats")]
    public async Task<CollectionAuctionStats> GetCollectionStatsAsync(string collection, CancellationToken cancellationToken = default)
    {
        var path = $"collections/{ApiPath.EscapeRequired(collection.ToString(), nameof(collection))}/auction/stats";
        QueryParameters? query = null;
        return await _requestExecutor.GetJsonAsync<CollectionAuctionStats>(path, query, cancellationToken);
    }

    [ApiOperation("/collections/{collection}/auctions", "NftMarketplaceController_getCollectionAuctions")]
    public async Task<IReadOnlyList<AuctionSummary>> GetCollectionAuctionsAsync(string collection, GetCollectionAuctionsOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = $"collections/{ApiPath.EscapeRequired(collection.ToString(), nameof(collection))}/auctions";
        var query = new QueryParameters();
        query.AddOptionalNumber("size", options?.Size);
        return await _requestExecutor.GetJsonAsync<IReadOnlyList<AuctionSummary>>(path, query, cancellationToken);
    }

    [ApiOperation("/collections/{collection}/auctions/count", "NftMarketplaceController_getCollectionAuctionsCount")]
    public async Task<long> GetCollectionAuctionsCountAsync(string collection, CancellationToken cancellationToken = default)
    {
        var path = $"collections/{ApiPath.EscapeRequired(collection.ToString(), nameof(collection))}/auctions/count";
        QueryParameters? query = null;
        return await _requestExecutor.GetInt64Async(path, query, cancellationToken);
    }

}
