#nullable enable
using System.Text.Json;
using Mvx.ApiClient.Net.Infrastructure;
using Mvx.ApiClient.Net.Models.Api;
using Mvx.ApiClient.Net.Requests.Collections;

namespace Mvx.ApiClient.Net.Clients;

internal sealed class CollectionClient : ICollectionClient
{
    private readonly ApiRequestExecutor _requestExecutor;

    public CollectionClient(HttpClient httpClient)
    {
        _requestExecutor = new ApiRequestExecutor(httpClient);
    }

    [ApiOperation("/collections", "CollectionController_getNftCollections")]
    public async Task<IReadOnlyList<NftCollection>> GetNftCollectionsAsync(GetNftCollectionsOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = "collections";
        var query = new QueryParameters();
        query.AddPagination(options?.Pagination);
        query.AddString("search", options?.Search);
        query.AddCollection("identifiers", options?.Identifiers);
        query.AddCollection("type", options?.Type);
        query.AddCollection("subType", options?.SubType);
        query.AddOptionalNumber("before", options?.Before);
        query.AddOptionalNumber("after", options?.After);
        query.AddString("canCreate", options?.CanCreate);
        query.AddString("canBurn", options?.CanBurn);
        query.AddString("canAddQuantity", options?.CanAddQuantity);
        query.AddString("canUpdateAttributes", options?.CanUpdateAttributes);
        query.AddString("canAddUri", options?.CanAddUri);
        query.AddString("canTransferRole", options?.CanTransferRole);
        query.AddBoolean("excludeMetaESDT", options?.ExcludeMetaESDT);
        query.AddOptionalEnum("sort", options?.Sort);
        query.AddOptionalEnum("order", options?.Order);
        return await _requestExecutor.GetJsonAsync<IReadOnlyList<NftCollection>>(path, query, cancellationToken);
    }

    [ApiOperation("/collections/count", "CollectionController_getCollectionCount")]
    public async Task<long> GetCollectionCountAsync(GetCollectionCountOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = "collections/count";
        var query = new QueryParameters();
        query.AddString("search", options?.Search);
        query.AddCollection("type", options?.Type);
        query.AddCollection("subType", options?.SubType);
        query.AddOptionalNumber("before", options?.Before);
        query.AddOptionalNumber("after", options?.After);
        query.AddString("canCreate", options?.CanCreate);
        query.AddString("canBurn", options?.CanBurn);
        query.AddString("canAddQuantity", options?.CanAddQuantity);
        query.AddString("canUpdateAttributes", options?.CanUpdateAttributes);
        query.AddString("canAddUri", options?.CanAddUri);
        query.AddString("canTransferRole", options?.CanTransferRole);
        query.AddBoolean("excludeMetaESDT", options?.ExcludeMetaESDT);
        return await _requestExecutor.GetInt64Async(path, query, cancellationToken);
    }

    [ApiOperation("/collections/{collection}", "CollectionController_getNftCollection")]
    public async Task<NftCollectionDetailed> GetNftCollectionAsync(string collection, CancellationToken cancellationToken = default)
    {
        var path = $"collections/{ApiPath.EscapeRequired(collection.ToString(), nameof(collection))}";
        QueryParameters? query = null;
        return await _requestExecutor.GetJsonAsync<NftCollectionDetailed>(path, query, cancellationToken);
    }

    [ApiOperation("/collections/{collection}/ranks", "CollectionController_getNftCollectionRanks")]
    public async Task<IReadOnlyList<NftRank>> GetNftCollectionRanksAsync(string collection, CancellationToken cancellationToken = default)
    {
        var path = $"collections/{ApiPath.EscapeRequired(collection.ToString(), nameof(collection))}/ranks";
        QueryParameters? query = null;
        return await _requestExecutor.GetJsonAsync<IReadOnlyList<NftRank>>(path, query, cancellationToken);
    }

    [ApiOperation("/collections/{collection}/nfts", "CollectionController_getNfts")]
    public async Task<IReadOnlyList<Nft>> GetNftsAsync(string collection, GetNftsOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = $"collections/{ApiPath.EscapeRequired(collection.ToString(), nameof(collection))}/nfts";
        var query = new QueryParameters();
        query.AddPagination(options?.Pagination);
        query.AddString("search", options?.Search);
        query.AddCollection("identifiers", options?.Identifiers);
        query.AddString("name", options?.Name);
        query.AddCollection("tags", options?.Tags);
        query.AddString("creator", options?.Creator);
        query.AddBoolean("isWhitelistedStorage", options?.IsWhitelistedStorage);
        query.AddBoolean("hasUris", options?.HasUris);
        query.AddBoolean("isNsfw", options?.IsNsfw);
        query.AddOptionalNumber("nonceBefore", options?.NonceBefore);
        query.AddOptionalNumber("nonceAfter", options?.NonceAfter);
        query.AddBoolean("withOwner", options?.WithOwner);
        query.AddBoolean("withSupply", options?.WithSupply);
        query.AddBoolean("withAssets", options?.WithAssets);
        query.AddOptionalEnum("sort", options?.Sort);
        query.AddOptionalEnum("order", options?.Order);
        query.AddBoolean("traits", options?.Traits);
        return await _requestExecutor.GetJsonAsync<IReadOnlyList<Nft>>(path, query, cancellationToken);
    }

    [ApiOperation("/collections/{collection}/nfts/count", "CollectionController_getNftCount")]
    public async Task<long> GetNftCountAsync(string collection, GetNftCountOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = $"collections/{ApiPath.EscapeRequired(collection.ToString(), nameof(collection))}/nfts/count";
        var query = new QueryParameters();
        query.AddString("search", options?.Search);
        query.AddCollection("identifiers", options?.Identifiers);
        query.AddString("name", options?.Name);
        query.AddCollection("tags", options?.Tags);
        query.AddString("creator", options?.Creator);
        query.AddBoolean("isWhitelistedStorage", options?.IsWhitelistedStorage);
        query.AddBoolean("hasUris", options?.HasUris);
        query.AddOptionalNumber("nonceBefore", options?.NonceBefore);
        query.AddOptionalNumber("nonceAfter", options?.NonceAfter);
        query.AddBoolean("traits", options?.Traits);
        return await _requestExecutor.GetInt64Async(path, query, cancellationToken);
    }

    [ApiOperation("/collections/{identifier}/accounts", "CollectionController_getNftAccounts")]
    public async Task<IReadOnlyList<CollectionAccount>> GetCollectionAccountsAsync(string identifier, GetCollectionAccountsOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = $"collections/{ApiPath.EscapeRequired(identifier.ToString(), nameof(identifier))}/accounts";
        var query = new QueryParameters();
        query.AddPagination(options?.Pagination);
        return await _requestExecutor.GetJsonAsync<IReadOnlyList<CollectionAccount>>(path, query, cancellationToken);
    }

    [ApiOperation("/collections/{collection}/transactions", "CollectionController_getCollectionTransactions")]
    public async Task<IReadOnlyList<Transaction>> GetCollectionTransactionsAsync(string collection, GetCollectionTransactionsOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = $"collections/{ApiPath.EscapeRequired(collection.ToString(), nameof(collection))}/transactions";
        var query = new QueryParameters();
        query.AddPagination(options?.Pagination);
        query.AddString("sender", options?.Sender);
        query.AddCollection("receiver", options?.Receiver);
        query.AddOptionalNumber("senderShard", options?.SenderShard);
        query.AddOptionalNumber("receiverShard", options?.ReceiverShard);
        query.AddString("miniBlockHash", options?.MiniBlockHash);
        query.AddCollection("hashes", options?.Hashes);
        query.AddOptionalEnum("status", options?.Status);
        query.AddCollection("function", options?.Function);
        query.AddOptionalNumber("before", options?.Before);
        query.AddOptionalNumber("after", options?.After);
        query.AddOptionalNumber("round", options?.Round);
        query.AddOptionalEnum("order", options?.Order);
        query.AddBoolean("withScResults", options?.WithScResults);
        query.AddBoolean("withOperations", options?.WithOperations);
        query.AddBoolean("withLogs", options?.WithLogs);
        query.AddBoolean("withScamInfo", options?.WithScamInfo);
        query.AddBoolean("withUsername", options?.WithUsername);
        query.AddBoolean("withRelayedScresults", options?.WithRelayedScresults);
        return await _requestExecutor.GetJsonAsync<IReadOnlyList<Transaction>>(path, query, cancellationToken);
    }

    [ApiOperation("/collections/{collection}/transactions/count", "CollectionController_getCollectionTransactionsCount")]
    public async Task<long> GetCollectionTransactionsCountAsync(string collection, GetCollectionTransactionsCountOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = $"collections/{ApiPath.EscapeRequired(collection.ToString(), nameof(collection))}/transactions/count";
        var query = new QueryParameters();
        query.AddString("sender", options?.Sender);
        query.AddCollection("receiver", options?.Receiver);
        query.AddOptionalNumber("senderShard", options?.SenderShard);
        query.AddOptionalNumber("receiverShard", options?.ReceiverShard);
        query.AddString("miniBlockHash", options?.MiniBlockHash);
        query.AddCollection("hashes", options?.Hashes);
        query.AddOptionalEnum("status", options?.Status);
        query.AddOptionalNumber("before", options?.Before);
        query.AddOptionalNumber("after", options?.After);
        query.AddOptionalNumber("round", options?.Round);
        query.AddBoolean("withRelayedScresults", options?.WithRelayedScresults);
        return await _requestExecutor.GetInt64Async(path, query, cancellationToken);
    }

    [ApiOperation("/collections/{collection}/transfers", "CollectionController_getCollectionTransfers")]
    public async Task<IReadOnlyList<Transaction>> GetCollectionTransfersAsync(string collection, GetCollectionTransfersOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = $"collections/{ApiPath.EscapeRequired(collection.ToString(), nameof(collection))}/transfers";
        var query = new QueryParameters();
        query.AddPagination(options?.Pagination);
        query.AddString("sender", options?.Sender);
        query.AddCollection("receiver", options?.Receiver);
        query.AddOptionalNumber("senderShard", options?.SenderShard);
        query.AddOptionalNumber("receiverShard", options?.ReceiverShard);
        query.AddString("miniBlockHash", options?.MiniBlockHash);
        query.AddCollection("hashes", options?.Hashes);
        query.AddOptionalEnum("status", options?.Status);
        query.AddCollection("function", options?.Function);
        query.AddOptionalNumber("before", options?.Before);
        query.AddOptionalNumber("after", options?.After);
        query.AddOptionalNumber("round", options?.Round);
        query.AddOptionalEnum("order", options?.Order);
        query.AddBoolean("withScResults", options?.WithScResults);
        query.AddBoolean("withOperations", options?.WithOperations);
        query.AddBoolean("withLogs", options?.WithLogs);
        query.AddBoolean("withScamInfo", options?.WithScamInfo);
        query.AddBoolean("withUsername", options?.WithUsername);
        return await _requestExecutor.GetJsonAsync<IReadOnlyList<Transaction>>(path, query, cancellationToken);
    }

    [ApiOperation("/collections/{collection}/transfers/count", "CollectionController_getCollectionTransfersCount")]
    public async Task<long> GetCollectionTransfersCountAsync(string collection, GetCollectionTransfersCountOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = $"collections/{ApiPath.EscapeRequired(collection.ToString(), nameof(collection))}/transfers/count";
        var query = new QueryParameters();
        query.AddCollection("function", options?.Function);
        query.AddString("sender", options?.Sender);
        query.AddCollection("receiver", options?.Receiver);
        query.AddOptionalNumber("senderShard", options?.SenderShard);
        query.AddOptionalNumber("receiverShard", options?.ReceiverShard);
        query.AddString("miniBlockHash", options?.MiniBlockHash);
        query.AddCollection("hashes", options?.Hashes);
        query.AddOptionalEnum("status", options?.Status);
        query.AddOptionalNumber("before", options?.Before);
        query.AddOptionalNumber("after", options?.After);
        query.AddOptionalNumber("round", options?.Round);
        return await _requestExecutor.GetInt64Async(path, query, cancellationToken);
    }

}
