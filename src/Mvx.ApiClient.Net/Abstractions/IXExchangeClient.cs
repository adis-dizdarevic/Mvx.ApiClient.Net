using Mvx.ApiClient.Net.Models.XExchange;

namespace Mvx.ApiClient.Net;

/// <summary>
/// Client for retrieving information about xExchange.
/// </summary>
public interface IXExchangeClient
{
    /// <summary>
    /// Returns xExchange economics details.
    /// </summary>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>Current xExchange economics information.</returns>
    Task<XExchangeEconomicsDto> GetEconomicsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns active liquidity pools available on xExchange.
    /// </summary>
    /// <param name="queryOptions">Optional pagination settings.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The active xExchange liquidity pools returned by the API.</returns>
    Task<IReadOnlyList<XExchangePairDto>> GetPairsAsync(QueryOptions? queryOptions = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns liquidity pool details by providing a combination of two tokens.
    /// </summary>
    /// <param name="baseId">The base token identifier, for example <c>MEX-455c57</c>.</param>
    /// <param name="quoteId">The quote token identifier, for example <c>WEGLD-bd4d79</c>.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The xExchange liquidity pool matching the token pair.</returns>
    Task<XExchangePairDto> GetPairAsync(string baseId, string quoteId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns active liquidity pools count available on xExchange.
    /// </summary>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The number of active xExchange liquidity pools.</returns>
    Task<int> GetPairsCountAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a list of tokens listed on xExchange.
    /// </summary>
    /// <param name="queryOptions">Optional pagination settings.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The xExchange tokens returned by the API.</returns>
    Task<IReadOnlyList<XExchangeTokenDto>> GetTokensAsync(QueryOptions? queryOptions = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a specific token listed on xExchange.
    /// </summary>
    /// <param name="identifier">The token identifier, for example <c>WEGLD-bd4d79</c>.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The xExchange token matching <paramref name="identifier"/>.</returns>
    Task<XExchangeTokenDto> GetTokenAsync(string identifier, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns tokens count available on xExchange.
    /// </summary>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The number of tokens listed on xExchange.</returns>
    Task<int> GetTokensCountAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a list of farms listed on xExchange.
    /// </summary>
    /// <param name="queryOptions">Optional pagination settings.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The xExchange farms returned by the API.</returns>
    Task<IReadOnlyList<XExchangeFarmDto>> GetFarmsAsync(QueryOptions? queryOptions = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns farms count available on xExchange.
    /// </summary>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The number of farms listed on xExchange.</returns>
    Task<int> GetFarmsCountAsync(CancellationToken cancellationToken = default);
}
