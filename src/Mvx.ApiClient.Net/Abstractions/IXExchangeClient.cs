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
    Task<XExchangeEconomicsDto> GetEconomicsAsync(DataSelection? dataSelection = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns active liquidity pools available on xExchange.
    /// </summary>
    Task<IReadOnlyList<XExchangePairDto>> GetPairsAsync(QueryOptions? queryOptions = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns liquidity pool details by providing a combination of two tokens.
    /// </summary>
    Task<XExchangePairDto> GetPairAsync(string baseId, string quoteId, DataSelection? dataSelection = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns active liquidity pools count available on xExchange.
    /// </summary>
    Task<int> GetPairsCountAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a list of tokens listed on xExchange.
    /// </summary>
    Task<IReadOnlyList<XExchangeTokenDto>> GetTokensAsync(QueryOptions? queryOptions = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a specific token listed on xExchange.
    /// </summary>
    Task<XExchangeTokenDto> GetTokenAsync(string identifier, DataSelection? dataSelection = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns tokens count available on xExchange.
    /// </summary>
    Task<int> GetTokensCountAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a list of farms listed on xExchange.
    /// </summary>
    Task<IReadOnlyList<XExchangeFarmDto>> GetFarmsAsync(QueryOptions? queryOptions = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns farms count available on xExchange.
    /// </summary>
    Task<int> GetFarmsCountAsync(CancellationToken cancellationToken = default);
}
