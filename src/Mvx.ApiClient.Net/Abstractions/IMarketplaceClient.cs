#nullable enable
using System.Text.Json;
using Mvx.ApiClient.Net.Models.Api;
using Mvx.ApiClient.Net.Requests.Marketplace;

namespace Mvx.ApiClient.Net;

/// <summary>Client for MultiversX Marketplace GET endpoints.</summary>
public interface IMarketplaceClient
{
    /// <summary>Explore auctions.</summary>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<IReadOnlyList<AuctionSummary>> GetAuctionsAsync(GetAuctionsOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Auctions count.</summary>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<long> GetAuctionsCountAsync(GetAuctionsCountOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Auction details.</summary>
    /// <param name="id">The id value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<AuctionSummary> GetAuctionAsync(long id, CancellationToken cancellationToken = default);

    /// <summary>Account stats.</summary>
    /// <param name="address">The address value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<AccountAuctionStats> GetAccountStatsAsync(string address, CancellationToken cancellationToken = default);

    /// <summary>Account auctions.</summary>
    /// <param name="address">The address value.</param>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<Auction> GetAccountAuctionsAsync(string address, GetAccountAuctionsOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Address auctions count.</summary>
    /// <param name="address">The address value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<long> GetAccountAuctionsCountAsync(string address, CancellationToken cancellationToken = default);

    /// <summary>Collection stats.</summary>
    /// <param name="collection">The collection value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<CollectionAuctionStats> GetCollectionStatsAsync(string collection, CancellationToken cancellationToken = default);

    /// <summary>Collection auctions.</summary>
    /// <param name="collection">The collection value.</param>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<IReadOnlyList<AuctionSummary>> GetCollectionAuctionsAsync(string collection, GetCollectionAuctionsOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Collection auctions count.</summary>
    /// <param name="collection">The collection value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<long> GetCollectionAuctionsCountAsync(string collection, CancellationToken cancellationToken = default);

}
