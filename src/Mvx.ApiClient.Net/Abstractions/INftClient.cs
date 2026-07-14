#nullable enable
using System.Text.Json;
using Mvx.ApiClient.Net.Models.Api;
using Mvx.ApiClient.Net.Requests.Nfts;

namespace Mvx.ApiClient.Net;

/// <summary>Client for MultiversX Nfts GET endpoints.</summary>
public interface INftClient
{
    /// <summary>Global NFTs.</summary>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<IReadOnlyList<Nft>> GetNftsAsync(GetNftsOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Global NFT count.</summary>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<long> GetNftCountAsync(GetNftCountOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>NFT details.</summary>
    /// <param name="identifier">The identifier value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<Nft> GetNftAsync(string identifier, CancellationToken cancellationToken = default);

    /// <summary>NFT thumbnail.</summary>
    /// <param name="identifier">The identifier value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<MvxApiContent> GetNftThumbnailAsync(string identifier, CancellationToken cancellationToken = default);

    /// <summary>NFT supply.</summary>
    /// <param name="identifier">The identifier value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<NftSupply> GetNftSupplyAsync(string identifier, CancellationToken cancellationToken = default);

    /// <summary>NFT accounts.</summary>
    /// <param name="identifier">The identifier value.</param>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<IReadOnlyList<NftOwner>> GetNftAccountsAsync(string identifier, GetNftAccountsOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>NFT accounts count.</summary>
    /// <param name="identifier">The identifier value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<long> GetNftAccountsCountAsync(string identifier, CancellationToken cancellationToken = default);

    /// <summary>NFT transactions.</summary>
    /// <param name="identifier">The identifier value.</param>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<IReadOnlyList<Transaction>> GetNftTransactionsAsync(string identifier, GetNftTransactionsOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>NFT transactions count.</summary>
    /// <param name="identifier">The identifier value.</param>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<long> GetNftTransactionsCountAsync(string identifier, GetNftTransactionsCountOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>NFT transfers.</summary>
    /// <param name="identifier">The identifier value.</param>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<IReadOnlyList<Transaction>> GetNftTransfersAsync(string identifier, GetNftTransfersOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>NFT transfers count.</summary>
    /// <param name="identifier">The identifier value.</param>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<long> GetNftTransfersCountAsync(string identifier, GetNftTransfersCountOptions? options = null, CancellationToken cancellationToken = default);

}
