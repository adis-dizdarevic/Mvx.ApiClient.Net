#nullable enable
using System.Text.Json;
using Mvx.ApiClient.Net.Models.Api;
using Mvx.ApiClient.Net.Requests.Collections;

namespace Mvx.ApiClient.Net;

/// <summary>Client for MultiversX Collections GET endpoints.</summary>
public interface ICollectionClient
{
    /// <summary>Collections.</summary>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<IReadOnlyList<NftCollection>> GetNftCollectionsAsync(GetNftCollectionsOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Collection count.</summary>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<long> GetCollectionCountAsync(GetCollectionCountOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Collection details.</summary>
    /// <param name="collection">The collection value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<NftCollectionDetailed> GetNftCollectionAsync(string collection, CancellationToken cancellationToken = default);

    /// <summary>Collection ranks.</summary>
    /// <param name="collection">The collection value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<IReadOnlyList<NftRank>> GetNftCollectionRanksAsync(string collection, CancellationToken cancellationToken = default);

    /// <summary>Collection NFTs.</summary>
    /// <param name="collection">The collection value.</param>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<IReadOnlyList<Nft>> GetNftsAsync(string collection, GetNftsOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Collection NFT count.</summary>
    /// <param name="collection">The collection value.</param>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<long> GetNftCountAsync(string collection, GetNftCountOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Collection accounts.</summary>
    /// <param name="identifier">The identifier value.</param>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<IReadOnlyList<CollectionAccount>> GetCollectionAccountsAsync(string identifier, GetCollectionAccountsOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Collection transactions.</summary>
    /// <param name="collection">The collection value.</param>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<IReadOnlyList<Transaction>> GetCollectionTransactionsAsync(string collection, GetCollectionTransactionsOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>NFT transactions count.</summary>
    /// <param name="collection">The collection value.</param>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<long> GetCollectionTransactionsCountAsync(string collection, GetCollectionTransactionsCountOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Collection transactions.</summary>
    /// <param name="collection">The collection value.</param>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<IReadOnlyList<Transaction>> GetCollectionTransfersAsync(string collection, GetCollectionTransfersOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>NFT transfers count.</summary>
    /// <param name="collection">The collection value.</param>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<long> GetCollectionTransfersCountAsync(string collection, GetCollectionTransfersCountOptions? options = null, CancellationToken cancellationToken = default);

}
