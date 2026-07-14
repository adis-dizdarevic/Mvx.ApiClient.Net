#nullable enable
using System.Text.Json;
using Mvx.ApiClient.Net.Infrastructure;
using Mvx.ApiClient.Net.Models.Api;
using Mvx.ApiClient.Net.Requests.Nfts;

namespace Mvx.ApiClient.Net.Clients;

internal sealed class NftClient : INftClient
{
    private readonly ApiRequestExecutor _requestExecutor;

    public NftClient(HttpClient httpClient)
    {
        _requestExecutor = new ApiRequestExecutor(httpClient);
    }

    [ApiOperation("/nfts", "NftController_getNfts")]
    public async Task<IReadOnlyList<Nft>> GetNftsAsync(GetNftsOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = "nfts";
        var query = new QueryParameters();
        query.AddPagination(options?.Pagination);
        query.AddString("search", options?.Search);
        query.AddCollection("identifiers", options?.Identifiers);
        query.AddCollection("type", options?.Type);
        query.AddCollection("subType", options?.SubType);
        query.AddString("collection", options?.Collection);
        query.AddCollection("collections", options?.Collections);
        query.AddString("name", options?.Name);
        query.AddCollection("tags", options?.Tags);
        query.AddString("creator", options?.Creator);
        query.AddBoolean("isWhitelistedStorage", options?.IsWhitelistedStorage);
        query.AddBoolean("hasUris", options?.HasUris);
        query.AddBoolean("isNsfw", options?.IsNsfw);
        query.AddBoolean("isScam", options?.IsScam);
        query.AddString("scamType", options?.ScamType);
        query.AddOptionalNumber("before", options?.Before);
        query.AddOptionalNumber("after", options?.After);
        query.AddBoolean("withOwner", options?.WithOwner);
        query.AddBoolean("withSupply", options?.WithSupply);
        query.AddBoolean("traits", options?.Traits);
        return await _requestExecutor.GetJsonAsync<IReadOnlyList<Nft>>(path, query, cancellationToken);
    }

    [ApiOperation("/nfts/count", "NftController_getNftCount")]
    public async Task<long> GetNftCountAsync(GetNftCountOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = "nfts/count";
        var query = new QueryParameters();
        query.AddString("search", options?.Search);
        query.AddCollection("identifiers", options?.Identifiers);
        query.AddCollection("type", options?.Type);
        query.AddCollection("subType", options?.SubType);
        query.AddString("collection", options?.Collection);
        query.AddCollection("collections", options?.Collections);
        query.AddString("name", options?.Name);
        query.AddCollection("tags", options?.Tags);
        query.AddString("creator", options?.Creator);
        query.AddBoolean("isWhitelistedStorage", options?.IsWhitelistedStorage);
        query.AddBoolean("hasUris", options?.HasUris);
        query.AddBoolean("isNsfw", options?.IsNsfw);
        query.AddOptionalNumber("before", options?.Before);
        query.AddOptionalNumber("after", options?.After);
        query.AddBoolean("isScam", options?.IsScam);
        query.AddString("scamType", options?.ScamType);
        query.AddBoolean("traits", options?.Traits);
        return await _requestExecutor.GetInt64Async(path, query, cancellationToken);
    }

    [ApiOperation("/nfts/{identifier}", "NftController_getNft")]
    public async Task<Nft> GetNftAsync(string identifier, CancellationToken cancellationToken = default)
    {
        var path = $"nfts/{ApiPath.EscapeRequired(identifier.ToString(), nameof(identifier))}";
        QueryParameters? query = null;
        return await _requestExecutor.GetJsonAsync<Nft>(path, query, cancellationToken);
    }

    [ApiOperation("/nfts/{identifier}/thumbnail", "NftController_resolveNftThumbnail")]
    public async Task<MvxApiContent> GetNftThumbnailAsync(string identifier, CancellationToken cancellationToken = default)
    {
        var path = $"nfts/{ApiPath.EscapeRequired(identifier.ToString(), nameof(identifier))}/thumbnail";
        QueryParameters? query = null;
        return await _requestExecutor.GetContentAsync(path, query, cancellationToken);
    }

    [ApiOperation("/nfts/{identifier}/supply", "NftController_getNftSupply")]
    public async Task<NftSupply> GetNftSupplyAsync(string identifier, CancellationToken cancellationToken = default)
    {
        var path = $"nfts/{ApiPath.EscapeRequired(identifier.ToString(), nameof(identifier))}/supply";
        QueryParameters? query = null;
        return await _requestExecutor.GetJsonAsync<NftSupply>(path, query, cancellationToken);
    }

    [ApiOperation("/nfts/{identifier}/accounts", "NftController_getNftAccounts")]
    public async Task<IReadOnlyList<NftOwner>> GetNftAccountsAsync(string identifier, GetNftAccountsOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = $"nfts/{ApiPath.EscapeRequired(identifier.ToString(), nameof(identifier))}/accounts";
        var query = new QueryParameters();
        query.AddPagination(options?.Pagination);
        return await _requestExecutor.GetJsonAsync<IReadOnlyList<NftOwner>>(path, query, cancellationToken);
    }

    [ApiOperation("/nfts/{identifier}/accounts/count", "NftController_getNftAccountsCount")]
    public async Task<long> GetNftAccountsCountAsync(string identifier, CancellationToken cancellationToken = default)
    {
        var path = $"nfts/{ApiPath.EscapeRequired(identifier.ToString(), nameof(identifier))}/accounts/count";
        QueryParameters? query = null;
        return await _requestExecutor.GetInt64Async(path, query, cancellationToken);
    }

    [ApiOperation("/nfts/{identifier}/transactions", "NftController_getNftTransactions")]
    public async Task<IReadOnlyList<Transaction>> GetNftTransactionsAsync(string identifier, GetNftTransactionsOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = $"nfts/{ApiPath.EscapeRequired(identifier.ToString(), nameof(identifier))}/transactions";
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
        query.AddOptionalEnum("order", options?.Order);
        query.AddBoolean("withScResults", options?.WithScResults);
        query.AddBoolean("withOperations", options?.WithOperations);
        query.AddBoolean("withLogs", options?.WithLogs);
        query.AddBoolean("withScamInfo", options?.WithScamInfo);
        query.AddBoolean("withUsername", options?.WithUsername);
        query.AddBoolean("withRelayedScresults", options?.WithRelayedScresults);
        return await _requestExecutor.GetJsonAsync<IReadOnlyList<Transaction>>(path, query, cancellationToken);
    }

    [ApiOperation("/nfts/{identifier}/transactions/count", "NftController_getNftTransactionsCount")]
    public async Task<long> GetNftTransactionsCountAsync(string identifier, GetNftTransactionsCountOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = $"nfts/{ApiPath.EscapeRequired(identifier.ToString(), nameof(identifier))}/transactions/count";
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
        query.AddBoolean("withRelayedScresults", options?.WithRelayedScresults);
        return await _requestExecutor.GetInt64Async(path, query, cancellationToken);
    }

    [ApiOperation("/nfts/{identifier}/transfers", "NftController_getNftTransfers")]
    public async Task<IReadOnlyList<Transaction>> GetNftTransfersAsync(string identifier, GetNftTransfersOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = $"nfts/{ApiPath.EscapeRequired(identifier.ToString(), nameof(identifier))}/transfers";
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
        query.AddOptionalEnum("order", options?.Order);
        query.AddBoolean("withScResults", options?.WithScResults);
        query.AddBoolean("withOperations", options?.WithOperations);
        query.AddBoolean("withLogs", options?.WithLogs);
        query.AddBoolean("withScamInfo", options?.WithScamInfo);
        query.AddBoolean("withUsername", options?.WithUsername);
        return await _requestExecutor.GetJsonAsync<IReadOnlyList<Transaction>>(path, query, cancellationToken);
    }

    [ApiOperation("/nfts/{identifier}/transfers/count", "NftController_getNftTransfersCount")]
    public async Task<long> GetNftTransfersCountAsync(string identifier, GetNftTransfersCountOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = $"nfts/{ApiPath.EscapeRequired(identifier.ToString(), nameof(identifier))}/transfers/count";
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
        return await _requestExecutor.GetInt64Async(path, query, cancellationToken);
    }

}
