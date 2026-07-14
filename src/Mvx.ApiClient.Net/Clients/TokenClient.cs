#nullable enable
using System.Text.Json;
using Mvx.ApiClient.Net.Infrastructure;
using Mvx.ApiClient.Net.Models.Api;
using Mvx.ApiClient.Net.Requests.Tokens;

namespace Mvx.ApiClient.Net.Clients;

internal sealed class TokenClient : ITokenClient
{
    private readonly ApiRequestExecutor _requestExecutor;

    public TokenClient(HttpClient httpClient)
    {
        _requestExecutor = new ApiRequestExecutor(httpClient);
    }

    [ApiOperation("/tokens", "TokenController_getTokens")]
    public async Task<IReadOnlyList<TokenDetailed>> GetTokensAsync(GetTokensOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = "tokens";
        var query = new QueryParameters();
        query.AddPagination(options?.Pagination);
        query.AddOptionalEnum("type", options?.Type);
        query.AddString("search", options?.Search);
        query.AddString("name", options?.Name);
        query.AddString("identifier", options?.Identifier);
        query.AddCollection("identifiers", options?.Identifiers);
        query.AddOptionalEnum("sort", options?.Sort);
        query.AddOptionalEnum("order", options?.Order);
        query.AddBoolean("includeMetaESDT", options?.IncludeMetaESDT);
        query.AddCollection("mexPairType", options?.MexPairType);
        query.AddOptionalEnum("priceSource", options?.PriceSource);
        return await _requestExecutor.GetJsonAsync<IReadOnlyList<TokenDetailed>>(path, query, cancellationToken);
    }

    [ApiOperation("/tokens/count", "TokenController_getTokenCount")]
    public async Task<long> GetTokenCountAsync(GetTokenCountOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = "tokens/count";
        var query = new QueryParameters();
        query.AddString("search", options?.Search);
        query.AddString("name", options?.Name);
        query.AddOptionalEnum("type", options?.Type);
        query.AddString("identifier", options?.Identifier);
        query.AddCollection("identifiers", options?.Identifiers);
        query.AddBoolean("includeMetaESDT", options?.IncludeMetaESDT);
        query.AddCollection("mexPairType", options?.MexPairType);
        query.AddOptionalEnum("priceSource", options?.PriceSource);
        return await _requestExecutor.GetInt64Async(path, query, cancellationToken);
    }

    [ApiOperation("/tokens/{identifier}", "TokenController_getToken")]
    public async Task<TokenDetailed> GetTokenAsync(string identifier, GetTokenOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = $"tokens/{ApiPath.EscapeRequired(identifier.ToString(), nameof(identifier))}";
        var query = new QueryParameters();
        query.AddBoolean("denominated", options?.Denominated);
        return await _requestExecutor.GetJsonAsync<TokenDetailed>(path, query, cancellationToken);
    }

    [ApiOperation("/tokens/{identifier}/supply", "TokenController_getTokenSupply")]
    public async Task<EsdtSupply> GetTokenSupplyAsync(string identifier, GetTokenSupplyOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = $"tokens/{ApiPath.EscapeRequired(identifier.ToString(), nameof(identifier))}/supply";
        var query = new QueryParameters();
        query.AddBoolean("denominated", options?.Denominated);
        return await _requestExecutor.GetJsonAsync<EsdtSupply>(path, query, cancellationToken);
    }

    [ApiOperation("/tokens/{identifier}/accounts", "TokenController_getTokenAccounts")]
    public async Task<IReadOnlyList<TokenAccount>> GetTokenAccountsAsync(string identifier, GetTokenAccountsOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = $"tokens/{ApiPath.EscapeRequired(identifier.ToString(), nameof(identifier))}/accounts";
        var query = new QueryParameters();
        query.AddPagination(options?.Pagination);
        query.AddOptionalEnum("accountType", options?.AccountType);
        return await _requestExecutor.GetJsonAsync<IReadOnlyList<TokenAccount>>(path, query, cancellationToken);
    }

    [ApiOperation("/tokens/{identifier}/accounts/count", "TokenController_getTokenAccountsCount")]
    public async Task<long> GetTokenAccountsCountAsync(string identifier, GetTokenAccountsCountOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = $"tokens/{ApiPath.EscapeRequired(identifier.ToString(), nameof(identifier))}/accounts/count";
        var query = new QueryParameters();
        query.AddOptionalEnum("accountType", options?.AccountType);
        return await _requestExecutor.GetInt64Async(path, query, cancellationToken);
    }

    [ApiOperation("/tokens/{identifier}/transactions", "TokenController_getTokenTransactions")]
    public async Task<IReadOnlyList<Transaction>> GetTokenTransactionsAsync(string identifier, GetTokenTransactionsOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = $"tokens/{ApiPath.EscapeRequired(identifier.ToString(), nameof(identifier))}/transactions";
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
        query.AddBoolean("isScCall", options?.IsScCall);
        query.AddBoolean("withScResults", options?.WithScResults);
        query.AddBoolean("withOperations", options?.WithOperations);
        query.AddBoolean("withLogs", options?.WithLogs);
        query.AddBoolean("withScamInfo", options?.WithScamInfo);
        query.AddBoolean("withUsername", options?.WithUsername);
        query.AddBoolean("withBlockInfo", options?.WithBlockInfo);
        query.AddBoolean("withActionTransferValue", options?.WithActionTransferValue);
        query.AddBoolean("withRelayedScresults", options?.WithRelayedScresults);
        return await _requestExecutor.GetJsonAsync<IReadOnlyList<Transaction>>(path, query, cancellationToken);
    }

    [ApiOperation("/tokens/{identifier}/transactions/count", "TokenController_getTokenTransactionsCount")]
    public async Task<long> GetTokenTransactionsCountAsync(string identifier, GetTokenTransactionsCountOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = $"tokens/{ApiPath.EscapeRequired(identifier.ToString(), nameof(identifier))}/transactions/count";
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
        query.AddBoolean("isScCall", options?.IsScCall);
        return await _requestExecutor.GetInt64Async(path, query, cancellationToken);
    }

    [ApiOperation("/tokens/{identifier}/transfers", "TokenController_getTokenTransfers")]
    public async Task<IReadOnlyList<Transaction>> GetTokenTransfersAsync(string identifier, GetTokenTransfersOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = $"tokens/{ApiPath.EscapeRequired(identifier.ToString(), nameof(identifier))}/transfers";
        var query = new QueryParameters();
        query.AddPagination(options?.Pagination);
        query.AddCollection("sender", options?.Sender);
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
        query.AddBoolean("isScCall", options?.IsScCall);
        query.AddBoolean("withScamInfo", options?.WithScamInfo);
        query.AddBoolean("withUsername", options?.WithUsername);
        query.AddBoolean("withBlockInfo", options?.WithBlockInfo);
        query.AddBoolean("withActionTransferValue", options?.WithActionTransferValue);
        return await _requestExecutor.GetJsonAsync<IReadOnlyList<Transaction>>(path, query, cancellationToken);
    }

    [ApiOperation("/tokens/{identifier}/transfers/count", "TokenController_getTokenTransfersCount")]
    public async Task<long> GetTokenTransfersCountAsync(string identifier, GetTokenTransfersCountOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = $"tokens/{ApiPath.EscapeRequired(identifier.ToString(), nameof(identifier))}/transfers/count";
        var query = new QueryParameters();
        query.AddCollection("sender", options?.Sender);
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
        query.AddBoolean("isScCall", options?.IsScCall);
        return await _requestExecutor.GetInt64Async(path, query, cancellationToken);
    }

    [ApiOperation("/tokens/{identifier}/logo/png", "TokenController_getTokenLogoPng")]
    public async Task<MvxApiContent> GetTokenLogoPngAsync(string identifier, CancellationToken cancellationToken = default)
    {
        var path = $"tokens/{ApiPath.EscapeRequired(identifier.ToString(), nameof(identifier))}/logo/png";
        QueryParameters? query = null;
        return await _requestExecutor.GetContentAsync(path, query, cancellationToken);
    }

    [ApiOperation("/tokens/{identifier}/logo/svg", "TokenController_getTokenLogoSvg")]
    public async Task<MvxApiContent> GetTokenLogoSvgAsync(string identifier, CancellationToken cancellationToken = default)
    {
        var path = $"tokens/{ApiPath.EscapeRequired(identifier.ToString(), nameof(identifier))}/logo/svg";
        QueryParameters? query = null;
        return await _requestExecutor.GetContentAsync(path, query, cancellationToken);
    }

}
