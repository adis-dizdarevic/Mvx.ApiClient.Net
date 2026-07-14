#nullable enable
using System.Text.Json;
using Mvx.ApiClient.Net.Infrastructure;
using Mvx.ApiClient.Net.Models.Api;
using Mvx.ApiClient.Net.Requests.Accounts;

namespace Mvx.ApiClient.Net.Clients;

internal sealed class AccountClient : IAccountClient
{
    private readonly ApiRequestExecutor _requestExecutor;

    public AccountClient(HttpClient httpClient)
    {
        _requestExecutor = new ApiRequestExecutor(httpClient);
    }

    [ApiOperation("/accounts", "AccountController_getAccounts")]
    public async Task<IReadOnlyList<Account>> GetAccountsAsync(GetAccountsOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = "accounts";
        var query = new QueryParameters();
        query.AddPagination(options?.Pagination);
        query.AddString("ownerAddress", options?.OwnerAddress);
        query.AddString("name", options?.Name);
        query.AddCollection("tags", options?.Tags);
        query.AddOptionalEnum("sort", options?.Sort);
        query.AddOptionalEnum("order", options?.Order);
        query.AddBoolean("isSmartContract", options?.IsSmartContract);
        query.AddBoolean("withOwnerAssets", options?.WithOwnerAssets);
        query.AddBoolean("withDeployInfo", options?.WithDeployInfo);
        query.AddBoolean("withTxCount", options?.WithTxCount);
        query.AddBoolean("withScrCount", options?.WithScrCount);
        query.AddCollection("excludeTags", options?.ExcludeTags);
        query.AddBoolean("hasAssets", options?.HasAssets);
        query.AddString("search", options?.Search);
        query.AddString("addresses", options?.Addresses);
        return await _requestExecutor.GetJsonAsync<IReadOnlyList<Account>>(path, query, cancellationToken);
    }

    [ApiOperation("/accounts/count", "AccountController_getAccountsCount")]
    public async Task<long> GetAccountsCountAsync(GetAccountsCountOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = "accounts/count";
        var query = new QueryParameters();
        query.AddString("ownerAddress", options?.OwnerAddress);
        query.AddBoolean("isSmartContract", options?.IsSmartContract);
        query.AddString("name", options?.Name);
        query.AddCollection("tags", options?.Tags);
        query.AddCollection("excludeTags", options?.ExcludeTags);
        query.AddBoolean("hasAssets", options?.HasAssets);
        query.AddString("search", options?.Search);
        query.AddBoolean("withBalance", options?.WithBalance);
        return await _requestExecutor.GetInt64Async(path, query, cancellationToken);
    }

    [ApiOperation("/accounts/{address}", "AccountController_getAccountDetails")]
    public async Task<AccountDetailed> GetAccountDetailsAsync(string address, GetAccountDetailsOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = $"accounts/{ApiPath.EscapeRequired(address.ToString(), nameof(address))}";
        var query = new QueryParameters();
        query.AddBoolean("withGuardianInfo", options?.WithGuardianInfo);
        query.AddBoolean("withTxCount", options?.WithTxCount);
        query.AddBoolean("withScrCount", options?.WithScrCount);
        query.AddBoolean("withTimestamp", options?.WithTimestamp);
        query.AddBoolean("withAssets", options?.WithAssets);
        query.AddOptionalNumber("timestamp", options?.Timestamp);
        return await _requestExecutor.GetJsonAsync<AccountDetailed>(path, query, cancellationToken);
    }

    [ApiOperation("/accounts/{address}/deferred", "AccountController_getAccountDeferred")]
    public async Task<IReadOnlyList<AccountDeferred>> GetAccountDeferredAsync(string address, CancellationToken cancellationToken = default)
    {
        var path = $"accounts/{ApiPath.EscapeRequired(address.ToString(), nameof(address))}/deferred";
        QueryParameters? query = null;
        return await _requestExecutor.GetJsonAsync<IReadOnlyList<AccountDeferred>>(path, query, cancellationToken);
    }

    [ApiOperation("/accounts/{address}/verification", "AccountController_getAccountVerification")]
    public async Task<AccountVerification> GetAccountVerificationAsync(string address, CancellationToken cancellationToken = default)
    {
        var path = $"accounts/{ApiPath.EscapeRequired(address.ToString(), nameof(address))}/verification";
        QueryParameters? query = null;
        return await _requestExecutor.GetJsonAsync<AccountVerification>(path, query, cancellationToken);
    }

    [ApiOperation("/accounts/{address}/tokens", "AccountController_getAccountTokens")]
    public async Task<IReadOnlyList<TokenWithBalance>> GetAccountTokensAsync(string address, GetAccountTokensOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = $"accounts/{ApiPath.EscapeRequired(address.ToString(), nameof(address))}/tokens";
        var query = new QueryParameters();
        query.AddPagination(options?.Pagination);
        query.AddOptionalEnum("type", options?.Type);
        query.AddOptionalEnum("subType", options?.SubType);
        query.AddString("search", options?.Search);
        query.AddString("name", options?.Name);
        query.AddString("identifier", options?.Identifier);
        query.AddString("identifiers", options?.Identifiers);
        query.AddBoolean("includeMetaESDT", options?.IncludeMetaESDT);
        query.AddOptionalNumber("timestamp", options?.Timestamp);
        query.AddCollection("mexPairType", options?.MexPairType);
        return await _requestExecutor.GetJsonAsync<IReadOnlyList<TokenWithBalance>>(path, query, cancellationToken);
    }

    [ApiOperation("/accounts/{address}/tokens/count", "AccountController_getTokenCount")]
    public async Task<long> GetTokenCountAsync(string address, GetTokenCountOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = $"accounts/{ApiPath.EscapeRequired(address.ToString(), nameof(address))}/tokens/count";
        var query = new QueryParameters();
        query.AddOptionalEnum("type", options?.Type);
        query.AddString("search", options?.Search);
        query.AddString("name", options?.Name);
        query.AddString("identifier", options?.Identifier);
        query.AddString("identifiers", options?.Identifiers);
        query.AddBoolean("includeMetaESDT", options?.IncludeMetaESDT);
        query.AddOptionalNumber("timestamp", options?.Timestamp);
        query.AddCollection("mexPairType", options?.MexPairType);
        return await _requestExecutor.GetInt64Async(path, query, cancellationToken);
    }

    [ApiOperation("/accounts/{address}/tokens/{token}", "AccountController_getAccountToken")]
    public async Task<TokenWithBalance> GetAccountTokenAsync(string address, string token, GetAccountTokenOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = $"accounts/{ApiPath.EscapeRequired(address.ToString(), nameof(address))}/tokens/{ApiPath.EscapeRequired(token.ToString(), nameof(token))}";
        var query = new QueryParameters();
        query.AddOptionalNumber("timestamp", options?.Timestamp);
        return await _requestExecutor.GetJsonAsync<TokenWithBalance>(path, query, cancellationToken);
    }

    [ApiOperation("/accounts/{address}/roles/collections", "AccountController_getAccountCollectionsWithRoles")]
    public async Task<IReadOnlyList<NftCollectionWithRoles>> GetAccountCollectionsWithRolesAsync(string address, GetAccountCollectionsWithRolesOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = $"accounts/{ApiPath.EscapeRequired(address.ToString(), nameof(address))}/roles/collections";
        var query = new QueryParameters();
        query.AddPagination(options?.Pagination);
        query.AddString("search", options?.Search);
        query.AddCollection("type", options?.Type);
        query.AddCollection("subType", options?.SubType);
        query.AddString("owner", options?.Owner);
        query.AddBoolean("canCreate", options?.CanCreate);
        query.AddBoolean("canBurn", options?.CanBurn);
        query.AddBoolean("canAddQuantity", options?.CanAddQuantity);
        query.AddBoolean("canUpdateAttributes", options?.CanUpdateAttributes);
        query.AddBoolean("canAddUri", options?.CanAddUri);
        query.AddBoolean("canTransferRole", options?.CanTransferRole);
        query.AddBoolean("excludeMetaESDT", options?.ExcludeMetaESDT);
        return await _requestExecutor.GetJsonAsync<IReadOnlyList<NftCollectionWithRoles>>(path, query, cancellationToken);
    }

    [ApiOperation("/accounts/{address}/roles/collections/count", "AccountController_getCollectionWithRolesCount")]
    public async Task<long> GetCollectionWithRolesCountAsync(string address, GetCollectionWithRolesCountOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = $"accounts/{ApiPath.EscapeRequired(address.ToString(), nameof(address))}/roles/collections/count";
        var query = new QueryParameters();
        query.AddString("search", options?.Search);
        query.AddCollection("type", options?.Type);
        query.AddCollection("subType", options?.SubType);
        query.AddString("owner", options?.Owner);
        query.AddBoolean("canCreate", options?.CanCreate);
        query.AddBoolean("canBurn", options?.CanBurn);
        query.AddBoolean("canAddQuantity", options?.CanAddQuantity);
        query.AddBoolean("excludeMetaESDT", options?.ExcludeMetaESDT);
        return await _requestExecutor.GetInt64Async(path, query, cancellationToken);
    }

    [ApiOperation("/accounts/{address}/roles/collections/{collection}", "AccountController_getAccountCollection")]
    public async Task<NftCollectionWithRoles> GetAccountCollectionAsync(string address, string collection, CancellationToken cancellationToken = default)
    {
        var path = $"accounts/{ApiPath.EscapeRequired(address.ToString(), nameof(address))}/roles/collections/{ApiPath.EscapeRequired(collection.ToString(), nameof(collection))}";
        QueryParameters? query = null;
        return await _requestExecutor.GetJsonAsync<NftCollectionWithRoles>(path, query, cancellationToken);
    }

    [ApiOperation("/accounts/{address}/roles/tokens", "AccountController_getAccountTokensWithRoles")]
    public async Task<IReadOnlyList<TokenWithRoles>> GetAccountTokensWithRolesAsync(string address, GetAccountTokensWithRolesOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = $"accounts/{ApiPath.EscapeRequired(address.ToString(), nameof(address))}/roles/tokens";
        var query = new QueryParameters();
        query.AddPagination(options?.Pagination);
        query.AddString("search", options?.Search);
        query.AddString("owner", options?.Owner);
        query.AddBoolean("canMint", options?.CanMint);
        query.AddBoolean("canBurn", options?.CanBurn);
        query.AddBoolean("includeMetaESDT", options?.IncludeMetaESDT);
        return await _requestExecutor.GetJsonAsync<IReadOnlyList<TokenWithRoles>>(path, query, cancellationToken);
    }

    [ApiOperation("/accounts/{address}/roles/tokens/count", "AccountController_getTokensWithRolesCount")]
    public async Task<long> GetTokensWithRolesCountAsync(string address, GetTokensWithRolesCountOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = $"accounts/{ApiPath.EscapeRequired(address.ToString(), nameof(address))}/roles/tokens/count";
        var query = new QueryParameters();
        query.AddString("search", options?.Search);
        query.AddString("owner", options?.Owner);
        query.AddBoolean("canMint", options?.CanMint);
        query.AddBoolean("canBurn", options?.CanBurn);
        query.AddBoolean("includeMetaESDT", options?.IncludeMetaESDT);
        return await _requestExecutor.GetInt64Async(path, query, cancellationToken);
    }

    [ApiOperation("/accounts/{address}/roles/tokens/{identifier}", "AccountController_getTokenWithRoles")]
    public async Task<TokenWithRoles> GetTokenWithRolesAsync(string address, string identifier, CancellationToken cancellationToken = default)
    {
        var path = $"accounts/{ApiPath.EscapeRequired(address.ToString(), nameof(address))}/roles/tokens/{ApiPath.EscapeRequired(identifier.ToString(), nameof(identifier))}";
        QueryParameters? query = null;
        return await _requestExecutor.GetJsonAsync<TokenWithRoles>(path, query, cancellationToken);
    }

    [ApiOperation("/accounts/{address}/collections", "AccountController_getAccountNftCollections")]
    public async Task<IReadOnlyList<NftCollectionAccount>> GetAccountNftCollectionsAsync(string address, GetAccountNftCollectionsOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = $"accounts/{ApiPath.EscapeRequired(address.ToString(), nameof(address))}/collections";
        var query = new QueryParameters();
        query.AddPagination(options?.Pagination);
        query.AddString("search", options?.Search);
        query.AddCollection("type", options?.Type);
        query.AddCollection("subType", options?.SubType);
        query.AddBoolean("excludeMetaESDT", options?.ExcludeMetaESDT);
        return await _requestExecutor.GetJsonAsync<IReadOnlyList<NftCollectionAccount>>(path, query, cancellationToken);
    }

    [ApiOperation("/accounts/{address}/collections/count", "AccountController_getNftCollectionCount")]
    public async Task<long> GetNftCollectionCountAsync(string address, GetNftCollectionCountOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = $"accounts/{ApiPath.EscapeRequired(address.ToString(), nameof(address))}/collections/count";
        var query = new QueryParameters();
        query.AddString("search", options?.Search);
        query.AddCollection("type", options?.Type);
        query.AddCollection("subType", options?.SubType);
        query.AddBoolean("excludeMetaESDT", options?.ExcludeMetaESDT);
        return await _requestExecutor.GetInt64Async(path, query, cancellationToken);
    }

    [ApiOperation("/accounts/{address}/collections/{collection}", "AccountController_getAccountNftCollection")]
    public async Task<NftCollectionAccount> GetAccountNftCollectionAsync(string address, string collection, CancellationToken cancellationToken = default)
    {
        var path = $"accounts/{ApiPath.EscapeRequired(address.ToString(), nameof(address))}/collections/{ApiPath.EscapeRequired(collection.ToString(), nameof(collection))}";
        QueryParameters? query = null;
        return await _requestExecutor.GetJsonAsync<NftCollectionAccount>(path, query, cancellationToken);
    }

    [ApiOperation("/accounts/{address}/nfts", "AccountController_getAccountNfts")]
    public async Task<IReadOnlyList<NftAccount>> GetAccountNftsAsync(string address, GetAccountNftsOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = $"accounts/{ApiPath.EscapeRequired(address.ToString(), nameof(address))}/nfts";
        var query = new QueryParameters();
        query.AddPagination(options?.Pagination);
        query.AddString("search", options?.Search);
        query.AddCollection("identifiers", options?.Identifiers);
        query.AddCollection("type", options?.Type);
        query.AddCollection("subType", options?.SubType);
        query.AddCollection("collections", options?.Collections);
        query.AddString("name", options?.Name);
        query.AddCollection("tags", options?.Tags);
        query.AddString("creator", options?.Creator);
        query.AddBoolean("hasUris", options?.HasUris);
        query.AddBoolean("includeFlagged", options?.IncludeFlagged);
        query.AddBoolean("withSupply", options?.WithSupply);
        query.AddString("source", options?.Source);
        query.AddBoolean("excludeMetaESDT", options?.ExcludeMetaESDT);
        query.AddBoolean("isScam", options?.IsScam);
        query.AddString("scamType", options?.ScamType);
        query.AddOptionalNumber("timestamp", options?.Timestamp);
        query.AddBoolean("withReceivedAt", options?.WithReceivedAt);
        query.AddBoolean("computeScamInfo", options?.ComputeScamInfo);
        query.AddBoolean("withScamInfo", options?.WithScamInfo);
        return await _requestExecutor.GetJsonAsync<IReadOnlyList<NftAccount>>(path, query, cancellationToken);
    }

    [ApiOperation("/accounts/{address}/nfts/count", "AccountController_getNftCount")]
    public async Task<long> GetNftCountAsync(string address, GetNftCountOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = $"accounts/{ApiPath.EscapeRequired(address.ToString(), nameof(address))}/nfts/count";
        var query = new QueryParameters();
        query.AddCollection("identifiers", options?.Identifiers);
        query.AddString("search", options?.Search);
        query.AddCollection("type", options?.Type);
        query.AddCollection("subType", options?.SubType);
        query.AddString("collection", options?.Collection);
        query.AddCollection("collections", options?.Collections);
        query.AddString("name", options?.Name);
        query.AddCollection("tags", options?.Tags);
        query.AddString("creator", options?.Creator);
        query.AddBoolean("hasUris", options?.HasUris);
        query.AddBoolean("includeFlagged", options?.IncludeFlagged);
        query.AddBoolean("excludeMetaESDT", options?.ExcludeMetaESDT);
        query.AddBoolean("isScam", options?.IsScam);
        query.AddString("scamType", options?.ScamType);
        query.AddOptionalNumber("timestamp", options?.Timestamp);
        return await _requestExecutor.GetInt64Async(path, query, cancellationToken);
    }

    [ApiOperation("/accounts/{address}/nfts/{nft}", "AccountController_getAccountNft")]
    public async Task<NftAccount> GetAccountNftAsync(string address, string nft, GetAccountNftOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = $"accounts/{ApiPath.EscapeRequired(address.ToString(), nameof(address))}/nfts/{ApiPath.EscapeRequired(nft.ToString(), nameof(nft))}";
        var query = new QueryParameters();
        query.AddOptionalNumber("timestamp", options?.Timestamp);
        return await _requestExecutor.GetJsonAsync<NftAccount>(path, query, cancellationToken);
    }

    [ApiOperation("/accounts/{address}/stake", "AccountController_getAccountStake")]
    public async Task<ProviderStake> GetAccountStakeAsync(string address, GetAccountStakeOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = $"accounts/{ApiPath.EscapeRequired(address.ToString(), nameof(address))}/stake";
        var query = new QueryParameters();
        query.AddOptionalNumber("timestamp", options?.Timestamp);
        return await _requestExecutor.GetJsonAsync<ProviderStake>(path, query, cancellationToken);
    }

    [ApiOperation("/accounts/{address}/delegation", "AccountController_getDelegationForAddress")]
    public async Task<IReadOnlyList<AccountDelegation>> GetDelegationForAddressAsync(string address, CancellationToken cancellationToken = default)
    {
        var path = $"accounts/{ApiPath.EscapeRequired(address.ToString(), nameof(address))}/delegation";
        QueryParameters? query = null;
        return await _requestExecutor.GetJsonAsync<IReadOnlyList<AccountDelegation>>(path, query, cancellationToken);
    }

    [ApiOperation("/accounts/{address}/delegation-legacy", "AccountController_getAccountDelegationLegacy")]
    public async Task<AccountDelegationLegacy> GetAccountDelegationLegacyAsync(string address, GetAccountDelegationLegacyOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = $"accounts/{ApiPath.EscapeRequired(address.ToString(), nameof(address))}/delegation-legacy";
        var query = new QueryParameters();
        query.AddOptionalNumber("timestamp", options?.Timestamp);
        return await _requestExecutor.GetJsonAsync<AccountDelegationLegacy>(path, query, cancellationToken);
    }

    [ApiOperation("/accounts/{address}/keys", "AccountController_getAccountKeys")]
    public async Task<IReadOnlyList<AccountKey>> GetAccountKeysAsync(string address, GetAccountKeysOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = $"accounts/{ApiPath.EscapeRequired(address.ToString(), nameof(address))}/keys";
        var query = new QueryParameters();
        query.AddPagination(options?.Pagination);
        query.AddCollection("status", options?.Status);
        return await _requestExecutor.GetJsonAsync<IReadOnlyList<AccountKey>>(path, query, cancellationToken);
    }

    [ApiOperation("/accounts/{address}/waiting-list", "AccountController_getAccountWaitingList")]
    public async Task<IReadOnlyList<WaitingList>> GetAccountWaitingListAsync(string address, CancellationToken cancellationToken = default)
    {
        var path = $"accounts/{ApiPath.EscapeRequired(address.ToString(), nameof(address))}/waiting-list";
        QueryParameters? query = null;
        return await _requestExecutor.GetJsonAsync<IReadOnlyList<WaitingList>>(path, query, cancellationToken);
    }

    [ApiOperation("/accounts/{address}/transactions", "AccountController_getAccountTransactions")]
    public async Task<IReadOnlyList<Transaction>> GetAccountTransactionsAsync(string address, GetAccountTransactionsOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = $"accounts/{ApiPath.EscapeRequired(address.ToString(), nameof(address))}/transactions";
        var query = new QueryParameters();
        query.AddPagination(options?.Pagination);
        query.AddString("sender", options?.Sender);
        query.AddCollection("receiver", options?.Receiver);
        query.AddString("token", options?.Token);
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
        query.AddBoolean("withBlockInfo", options?.WithBlockInfo);
        query.AddString("senderOrReceiver", options?.SenderOrReceiver);
        query.AddBoolean("isRelayed", options?.IsRelayed);
        query.AddBoolean("isScCall", options?.IsScCall);
        query.AddBoolean("withActionTransferValue", options?.WithActionTransferValue);
        query.AddBoolean("withRelayedScresults", options?.WithRelayedScresults);
        query.AddBoolean("computeScamInfo", options?.ComputeScamInfo);
        return await _requestExecutor.GetJsonAsync<IReadOnlyList<Transaction>>(path, query, cancellationToken);
    }

    [ApiOperation("/accounts/{address}/transactions/count", "AccountController_getAccountTransactionsCount")]
    public async Task<long> GetAccountTransactionsCountAsync(string address, GetAccountTransactionsCountOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = $"accounts/{ApiPath.EscapeRequired(address.ToString(), nameof(address))}/transactions/count";
        var query = new QueryParameters();
        query.AddString("sender", options?.Sender);
        query.AddCollection("receiver", options?.Receiver);
        query.AddString("token", options?.Token);
        query.AddOptionalNumber("senderShard", options?.SenderShard);
        query.AddOptionalNumber("receiverShard", options?.ReceiverShard);
        query.AddString("miniBlockHash", options?.MiniBlockHash);
        query.AddCollection("hashes", options?.Hashes);
        query.AddOptionalEnum("status", options?.Status);
        query.AddCollection("function", options?.Function);
        query.AddOptionalNumber("before", options?.Before);
        query.AddOptionalNumber("after", options?.After);
        query.AddOptionalNumber("round", options?.Round);
        query.AddString("senderOrReceiver", options?.SenderOrReceiver);
        query.AddBoolean("isRelayed", options?.IsRelayed);
        query.AddBoolean("isScCall", options?.IsScCall);
        query.AddBoolean("withRelayedScresults", options?.WithRelayedScresults);
        return await _requestExecutor.GetInt64Async(path, query, cancellationToken);
    }

    [ApiOperation("/accounts/{address}/transfers", "AccountController_getAccountTransfers")]
    public async Task<IReadOnlyList<Transaction>> GetAccountTransfersAsync(string address, GetAccountTransfersOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = $"accounts/{ApiPath.EscapeRequired(address.ToString(), nameof(address))}/transfers";
        var query = new QueryParameters();
        query.AddPagination(options?.Pagination);
        query.AddCollection("sender", options?.Sender);
        query.AddCollection("receiver", options?.Receiver);
        query.AddString("token", options?.Token);
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
        query.AddString("relayer", options?.Relayer);
        query.AddBoolean("withScamInfo", options?.WithScamInfo);
        query.AddBoolean("withUsername", options?.WithUsername);
        query.AddBoolean("withBlockInfo", options?.WithBlockInfo);
        query.AddString("senderOrReceiver", options?.SenderOrReceiver);
        query.AddBoolean("isScCall", options?.IsScCall);
        query.AddBoolean("withLogs", options?.WithLogs);
        query.AddBoolean("withOperations", options?.WithOperations);
        query.AddBoolean("withActionTransferValue", options?.WithActionTransferValue);
        query.AddBoolean("withRefunds", options?.WithRefunds);
        query.AddBoolean("withTxsRelayedByAddress", options?.WithTxsRelayedByAddress);
        return await _requestExecutor.GetJsonAsync<IReadOnlyList<Transaction>>(path, query, cancellationToken);
    }

    [ApiOperation("/accounts/{address}/transfers/count", "AccountController_getAccountTransfersCount")]
    public async Task<long> GetAccountTransfersCountAsync(string address, GetAccountTransfersCountOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = $"accounts/{ApiPath.EscapeRequired(address.ToString(), nameof(address))}/transfers/count";
        var query = new QueryParameters();
        query.AddCollection("sender", options?.Sender);
        query.AddCollection("receiver", options?.Receiver);
        query.AddString("token", options?.Token);
        query.AddOptionalNumber("senderShard", options?.SenderShard);
        query.AddOptionalNumber("receiverShard", options?.ReceiverShard);
        query.AddString("miniBlockHash", options?.MiniBlockHash);
        query.AddCollection("hashes", options?.Hashes);
        query.AddOptionalEnum("status", options?.Status);
        query.AddCollection("function", options?.Function);
        query.AddOptionalNumber("before", options?.Before);
        query.AddOptionalNumber("after", options?.After);
        query.AddOptionalNumber("round", options?.Round);
        query.AddString("senderOrReceiver", options?.SenderOrReceiver);
        query.AddBoolean("isScCall", options?.IsScCall);
        query.AddBoolean("withRefunds", options?.WithRefunds);
        query.AddBoolean("withTxsRelayedByAddress", options?.WithTxsRelayedByAddress);
        return await _requestExecutor.GetInt64Async(path, query, cancellationToken);
    }

    [ApiOperation("/accounts/{address}/deploys", "AccountController_getAccountDeploys")]
    public async Task<IReadOnlyList<DeployedContract>> GetAccountDeploysAsync(string address, GetAccountDeploysOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = $"accounts/{ApiPath.EscapeRequired(address.ToString(), nameof(address))}/deploys";
        var query = new QueryParameters();
        query.AddPagination(options?.Pagination);
        return await _requestExecutor.GetJsonAsync<IReadOnlyList<DeployedContract>>(path, query, cancellationToken);
    }

    [ApiOperation("/accounts/{address}/deploys/count", "AccountController_getAccountDeploysCount")]
    public async Task<long> GetAccountDeploysCountAsync(string address, CancellationToken cancellationToken = default)
    {
        var path = $"accounts/{ApiPath.EscapeRequired(address.ToString(), nameof(address))}/deploys/count";
        QueryParameters? query = null;
        return await _requestExecutor.GetInt64Async(path, query, cancellationToken);
    }

    [ApiOperation("/accounts/{address}/contracts", "AccountController_getAccountContracts")]
    public async Task<IReadOnlyList<DeployedContract>> GetAccountContractsAsync(string address, GetAccountContractsOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = $"accounts/{ApiPath.EscapeRequired(address.ToString(), nameof(address))}/contracts";
        var query = new QueryParameters();
        query.AddPagination(options?.Pagination);
        return await _requestExecutor.GetJsonAsync<IReadOnlyList<DeployedContract>>(path, query, cancellationToken);
    }

    [ApiOperation("/accounts/{address}/contracts/count", "AccountController_getAccountContractsCount")]
    public async Task<long> GetAccountContractsCountAsync(string address, CancellationToken cancellationToken = default)
    {
        var path = $"accounts/{ApiPath.EscapeRequired(address.ToString(), nameof(address))}/contracts/count";
        QueryParameters? query = null;
        return await _requestExecutor.GetInt64Async(path, query, cancellationToken);
    }

    [ApiOperation("/accounts/{address}/upgrades", "AccountController_getContractUpgrades")]
    public async Task<IReadOnlyList<ContractUpgrades>> GetContractUpgradesAsync(string address, GetContractUpgradesOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = $"accounts/{ApiPath.EscapeRequired(address.ToString(), nameof(address))}/upgrades";
        var query = new QueryParameters();
        query.AddPagination(options?.Pagination);
        return await _requestExecutor.GetJsonAsync<IReadOnlyList<ContractUpgrades>>(path, query, cancellationToken);
    }

    [ApiOperation("/accounts/{address}/results", "AccountController_getAccountScResults")]
    public async Task<IReadOnlyList<SmartContractResult>> GetAccountScResultsAsync(string address, GetAccountScResultsOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = $"accounts/{ApiPath.EscapeRequired(address.ToString(), nameof(address))}/results";
        var query = new QueryParameters();
        query.AddPagination(options?.Pagination);
        return await _requestExecutor.GetJsonAsync<IReadOnlyList<SmartContractResult>>(path, query, cancellationToken);
    }

    [ApiOperation("/accounts/{address}/results/count", "AccountController_getAccountScResultsCount")]
    public async Task<long> GetAccountScResultsCountAsync(string address, CancellationToken cancellationToken = default)
    {
        var path = $"accounts/{ApiPath.EscapeRequired(address.ToString(), nameof(address))}/results/count";
        QueryParameters? query = null;
        return await _requestExecutor.GetInt64Async(path, query, cancellationToken);
    }

    [ApiOperation("/accounts/{address}/results/{scHash}", "AccountController_getAccountScResult")]
    public async Task<SmartContractResult> GetAccountScResultAsync(string address, string scHash, CancellationToken cancellationToken = default)
    {
        var path = $"accounts/{ApiPath.EscapeRequired(address.ToString(), nameof(address))}/results/{ApiPath.EscapeRequired(scHash.ToString(), nameof(scHash))}";
        QueryParameters? query = null;
        return await _requestExecutor.GetJsonAsync<SmartContractResult>(path, query, cancellationToken);
    }

    [ApiOperation("/accounts/{address}/history", "AccountController_getAccountHistory")]
    public async Task<IReadOnlyList<AccountHistory>> GetAccountHistoryAsync(string address, GetAccountHistoryOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = $"accounts/{ApiPath.EscapeRequired(address.ToString(), nameof(address))}/history";
        var query = new QueryParameters();
        query.AddPagination(options?.Pagination);
        query.AddOptionalNumber("before", options?.Before);
        query.AddOptionalNumber("after", options?.After);
        return await _requestExecutor.GetJsonAsync<IReadOnlyList<AccountHistory>>(path, query, cancellationToken);
    }

    [ApiOperation("/accounts/{address}/history/count", "AccountController_getAccountHistoryCount")]
    public async Task<long> GetAccountHistoryCountAsync(string address, GetAccountHistoryCountOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = $"accounts/{ApiPath.EscapeRequired(address.ToString(), nameof(address))}/history/count";
        var query = new QueryParameters();
        query.AddOptionalNumber("before", options?.Before);
        query.AddOptionalNumber("after", options?.After);
        return await _requestExecutor.GetInt64Async(path, query, cancellationToken);
    }

    [ApiOperation("/accounts/{address}/history/{tokenIdentifier}/count", "AccountController_getAccountTokenHistoryCount")]
    public async Task<long> GetAccountTokenHistoryCountAsync(string address, string tokenIdentifier, GetAccountTokenHistoryCountOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = $"accounts/{ApiPath.EscapeRequired(address.ToString(), nameof(address))}/history/{ApiPath.EscapeRequired(tokenIdentifier.ToString(), nameof(tokenIdentifier))}/count";
        var query = new QueryParameters();
        query.AddOptionalNumber("before", options?.Before);
        query.AddOptionalNumber("after", options?.After);
        return await _requestExecutor.GetInt64Async(path, query, cancellationToken);
    }

    [ApiOperation("/accounts/{address}/esdthistory", "AccountController_getAccountEsdtHistory")]
    public async Task<IReadOnlyList<AccountEsdtHistory>> GetAccountEsdtHistoryAsync(string address, GetAccountEsdtHistoryOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = $"accounts/{ApiPath.EscapeRequired(address.ToString(), nameof(address))}/esdthistory";
        var query = new QueryParameters();
        query.AddPagination(options?.Pagination);
        query.AddOptionalNumber("before", options?.Before);
        query.AddOptionalNumber("after", options?.After);
        query.AddCollection("identifier", options?.Identifier);
        query.AddString("token", options?.Token);
        return await _requestExecutor.GetJsonAsync<IReadOnlyList<AccountEsdtHistory>>(path, query, cancellationToken);
    }

    [ApiOperation("/accounts/{address}/esdthistory/count", "AccountController_getAccountEsdtHistoryCount")]
    public async Task<long> GetAccountEsdtHistoryCountAsync(string address, GetAccountEsdtHistoryCountOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = $"accounts/{ApiPath.EscapeRequired(address.ToString(), nameof(address))}/esdthistory/count";
        var query = new QueryParameters();
        query.AddOptionalNumber("before", options?.Before);
        query.AddOptionalNumber("after", options?.After);
        query.AddCollection("identifier", options?.Identifier);
        query.AddString("token", options?.Token);
        return await _requestExecutor.GetInt64Async(path, query, cancellationToken);
    }

    [ApiOperation("/accounts/{address}/history/{tokenIdentifier}", "AccountController_getAccountTokenHistory")]
    public async Task<IReadOnlyList<AccountEsdtHistory>> GetAccountTokenHistoryAsync(string address, string tokenIdentifier, GetAccountTokenHistoryOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = $"accounts/{ApiPath.EscapeRequired(address.ToString(), nameof(address))}/history/{ApiPath.EscapeRequired(tokenIdentifier.ToString(), nameof(tokenIdentifier))}";
        var query = new QueryParameters();
        query.AddPagination(options?.Pagination);
        query.AddOptionalNumber("before", options?.Before);
        query.AddOptionalNumber("after", options?.After);
        return await _requestExecutor.GetJsonAsync<IReadOnlyList<AccountEsdtHistory>>(path, query, cancellationToken);
    }

}
