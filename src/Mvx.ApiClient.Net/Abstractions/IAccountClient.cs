#nullable enable
using System.Text.Json;
using Mvx.ApiClient.Net.Models.Api;
using Mvx.ApiClient.Net.Requests.Accounts;

namespace Mvx.ApiClient.Net;

/// <summary>Client for MultiversX Accounts GET endpoints.</summary>
public interface IAccountClient
{
    /// <summary>Accounts details.</summary>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<IReadOnlyList<Account>> GetAccountsAsync(GetAccountsOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Total number of accounts.</summary>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<long> GetAccountsCountAsync(GetAccountsCountOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Account details.</summary>
    /// <param name="address">The address value.</param>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<AccountDetailed> GetAccountDetailsAsync(string address, GetAccountDetailsOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Account deferred payment details.</summary>
    /// <param name="address">The address value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<IReadOnlyList<AccountDeferred>> GetAccountDeferredAsync(string address, CancellationToken cancellationToken = default);

    /// <summary>Account verification details.</summary>
    /// <param name="address">The address value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<AccountVerification> GetAccountVerificationAsync(string address, CancellationToken cancellationToken = default);

    /// <summary>Account tokens.</summary>
    /// <param name="address">The address value.</param>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<IReadOnlyList<TokenWithBalance>> GetAccountTokensAsync(string address, GetAccountTokensOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Account token count.</summary>
    /// <param name="address">The address value.</param>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<long> GetTokenCountAsync(string address, GetTokenCountOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Account token details.</summary>
    /// <param name="address">The address value.</param>
    /// <param name="token">The token value.</param>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<TokenWithBalance> GetAccountTokenAsync(string address, string token, GetAccountTokenOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Account collections.</summary>
    /// <param name="address">The address value.</param>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<IReadOnlyList<NftCollectionWithRoles>> GetAccountCollectionsWithRolesAsync(string address, GetAccountCollectionsWithRolesOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Account collection count.</summary>
    /// <param name="address">The address value.</param>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<long> GetCollectionWithRolesCountAsync(string address, GetCollectionWithRolesCountOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Account collection details.</summary>
    /// <param name="address">The address value.</param>
    /// <param name="collection">The collection value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<NftCollectionWithRoles> GetAccountCollectionAsync(string address, string collection, CancellationToken cancellationToken = default);

    /// <summary>Account token roles.</summary>
    /// <param name="address">The address value.</param>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<IReadOnlyList<TokenWithRoles>> GetAccountTokensWithRolesAsync(string address, GetAccountTokensWithRolesOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Account token roles count.</summary>
    /// <param name="address">The address value.</param>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<long> GetTokensWithRolesCountAsync(string address, GetTokensWithRolesCountOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Account token roles details.</summary>
    /// <param name="address">The address value.</param>
    /// <param name="identifier">The identifier value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<TokenWithRoles> GetTokenWithRolesAsync(string address, string identifier, CancellationToken cancellationToken = default);

    /// <summary>Account collections.</summary>
    /// <param name="address">The address value.</param>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<IReadOnlyList<NftCollectionAccount>> GetAccountNftCollectionsAsync(string address, GetAccountNftCollectionsOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Account collection count.</summary>
    /// <param name="address">The address value.</param>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<long> GetNftCollectionCountAsync(string address, GetNftCollectionCountOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Account collection details.</summary>
    /// <param name="address">The address value.</param>
    /// <param name="collection">The collection value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<NftCollectionAccount> GetAccountNftCollectionAsync(string address, string collection, CancellationToken cancellationToken = default);

    /// <summary>Account NFTs.</summary>
    /// <param name="address">The address value.</param>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<IReadOnlyList<NftAccount>> GetAccountNftsAsync(string address, GetAccountNftsOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Account NFT/SFT tokens count.</summary>
    /// <param name="address">The address value.</param>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<long> GetNftCountAsync(string address, GetNftCountOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Account NFT/SFT token details.</summary>
    /// <param name="address">The address value.</param>
    /// <param name="nft">The nft value.</param>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<NftAccount> GetAccountNftAsync(string address, string nft, GetAccountNftOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Account stake details.</summary>
    /// <param name="address">The address value.</param>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<ProviderStake> GetAccountStakeAsync(string address, GetAccountStakeOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Account delegations with staking providers.</summary>
    /// <param name="address">The address value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<IReadOnlyList<AccountDelegation>> GetDelegationForAddressAsync(string address, CancellationToken cancellationToken = default);

    /// <summary>Account legacy delegation details.</summary>
    /// <param name="address">The address value.</param>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<AccountDelegationLegacy> GetAccountDelegationLegacyAsync(string address, GetAccountDelegationLegacyOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Account nodes.</summary>
    /// <param name="address">The address value.</param>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<IReadOnlyList<AccountKey>> GetAccountKeysAsync(string address, GetAccountKeysOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Account queued nodes.</summary>
    /// <param name="address">The address value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<IReadOnlyList<WaitingList>> GetAccountWaitingListAsync(string address, CancellationToken cancellationToken = default);

    /// <summary>Account transaction list.</summary>
    /// <param name="address">The address value.</param>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<IReadOnlyList<Transaction>> GetAccountTransactionsAsync(string address, GetAccountTransactionsOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Account transactions count.</summary>
    /// <param name="address">The address value.</param>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<long> GetAccountTransactionsCountAsync(string address, GetAccountTransactionsCountOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Account value transfers.</summary>
    /// <param name="address">The address value.</param>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<IReadOnlyList<Transaction>> GetAccountTransfersAsync(string address, GetAccountTransfersOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Account transfer count.</summary>
    /// <param name="address">The address value.</param>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<long> GetAccountTransfersCountAsync(string address, GetAccountTransfersCountOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Account deploys details.</summary>
    /// <param name="address">The address value.</param>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<IReadOnlyList<DeployedContract>> GetAccountDeploysAsync(string address, GetAccountDeploysOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Account deploys count.</summary>
    /// <param name="address">The address value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<long> GetAccountDeploysCountAsync(string address, CancellationToken cancellationToken = default);

    /// <summary>Account contracts details.</summary>
    /// <param name="address">The address value.</param>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<IReadOnlyList<DeployedContract>> GetAccountContractsAsync(string address, GetAccountContractsOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Account contracts count.</summary>
    /// <param name="address">The address value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<long> GetAccountContractsCountAsync(string address, CancellationToken cancellationToken = default);

    /// <summary>Account upgrades details.</summary>
    /// <param name="address">The address value.</param>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<IReadOnlyList<ContractUpgrades>> GetContractUpgradesAsync(string address, GetContractUpgradesOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Account smart contract results.</summary>
    /// <param name="address">The address value.</param>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<IReadOnlyList<SmartContractResult>> GetAccountScResultsAsync(string address, GetAccountScResultsOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Account smart contracts results count.</summary>
    /// <param name="address">The address value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<long> GetAccountScResultsCountAsync(string address, CancellationToken cancellationToken = default);

    /// <summary>Account smart contract result.</summary>
    /// <param name="address">The address value.</param>
    /// <param name="scHash">The scHash value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<SmartContractResult> GetAccountScResultAsync(string address, string scHash, CancellationToken cancellationToken = default);

    /// <summary>Account history.</summary>
    /// <param name="address">The address value.</param>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<IReadOnlyList<AccountHistory>> GetAccountHistoryAsync(string address, GetAccountHistoryOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Account history count.</summary>
    /// <param name="address">The address value.</param>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<long> GetAccountHistoryCountAsync(string address, GetAccountHistoryCountOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Account token history count.</summary>
    /// <param name="address">The address value.</param>
    /// <param name="tokenIdentifier">The tokenIdentifier value.</param>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<long> GetAccountTokenHistoryCountAsync(string address, string tokenIdentifier, GetAccountTokenHistoryCountOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Account esdts history.</summary>
    /// <param name="address">The address value.</param>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<IReadOnlyList<AccountEsdtHistory>> GetAccountEsdtHistoryAsync(string address, GetAccountEsdtHistoryOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Account esdts history count.</summary>
    /// <param name="address">The address value.</param>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<long> GetAccountEsdtHistoryCountAsync(string address, GetAccountEsdtHistoryCountOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Account token history.</summary>
    /// <param name="address">The address value.</param>
    /// <param name="tokenIdentifier">The tokenIdentifier value.</param>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<IReadOnlyList<AccountEsdtHistory>> GetAccountTokenHistoryAsync(string address, string tokenIdentifier, GetAccountTokenHistoryOptions? options = null, CancellationToken cancellationToken = default);

}
