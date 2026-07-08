using Mvx.ApiClient.Net.Models.Mex;

namespace Mvx.ApiClient.Net;

/// <summary>
/// Client for retrieving information about xExchange.
/// </summary>
public interface IMexClient
{
    /// <summary>
    /// Returns economics details of xExchange.
    /// </summary>
    /// <param name="dataSelection">The fields to retrieve from the response.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="MexEconomicsDto"/> object containing information about xExchange economics.</returns>
    Task<MexEconomicsDto> GetMexEconomicsAsync(DataSelection? dataSelection = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns active liquidity pools available on xExchange.
    /// </summary>
    /// <param name="queryOptions">The data selection and pagination options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A list of active liquidity pools available on xExchange.</returns>
    Task<IReadOnlyList<MexPairDto>> GetMexPairsAsync(QueryOptions? queryOptions = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns liquidity pool details by providing a combination of two tokens.
    /// </summary>
    /// <param name="baseId">The base token identifier of the pair.</param>
    /// <param name="quoteId">The quote token identifier of the pair.</param>
    /// <param name="dataSelection">The fields to retrieve from the response.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="MexPairDto"/> containing pair details.</returns>
    Task<MexPairDto> GetMexPairAsync(string baseId, string quoteId, DataSelection? dataSelection = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns active liquidity pools count available on xExchange.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The number of active liquidity pools on xExchange.</returns>
    Task<int> GetMexPairsCountAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a list of tokens listed on xExchange.
    /// </summary>
    /// <param name="queryOptions">The data selection and pagination options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A list of tokens listed on xExchange.</returns>
    Task<IReadOnlyList<MexTokenDto>> GetMexTokensAsync(QueryOptions? queryOptions = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a specific token listed on xExchange.
    /// </summary>
    /// <param name="identifier">The token identifier.</param>
    /// <param name="dataSelection">The fields to retrieve from the response.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="MexTokenDto"/> object containing token information.</returns>
    Task<MexTokenDto> GetMexTokenAsync(string identifier, DataSelection? dataSelection = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns tokens count available on xExchange.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The number of tokens.</returns>
    Task<int> GetMexTokensCountAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a list of farms listed on xExchange.
    /// </summary>
    /// <param name="queryOptions">The data selection and pagination options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A list of farms listed on xExchange.</returns>
    Task<IReadOnlyList<MexFarmDto>> GetMexFarmsAsync(QueryOptions? queryOptions = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns farms count available on xExchange.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The number of farms.</returns>
    Task<int> GetMexFarmsCountAsync(CancellationToken cancellationToken = default);
}
