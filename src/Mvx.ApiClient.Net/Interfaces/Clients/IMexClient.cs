using Mvx.ApiClient.Net.Dtos;
using Mvx.ApiClient.Net.Models.Mex;

namespace Mvx.ApiClient.Net.Interfaces.Clients;

/// <summary>
/// Client for retrieving information about xExchange (Mex)
/// </summary>
public interface IMexClient
{
    /// <summary>
    /// Returns economics details of xExchange
    /// </summary>
    /// <param name="dataSelection">The fields to retrieve from the response</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>A <see cref="MexEconomicsDto"/> object containing information about the economic details of xExchange</returns>
    Task<MexEconomicsDto> GetMexEconomicsAsync(DataSelectionDto? dataSelection = null, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Returns active liquidity pools available on xExchange
    /// </summary>
    /// <param name="queryParameters">The data to select with pagination</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>A list of <see cref="MexPairDto"/> containing active liquidity pools available on xExchange</returns>
    Task<IEnumerable<MexPairDto>> GetMexPairsAsync(QueryParametersDto? queryParameters = null, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Returns liquidity pool details by providing a combination of two tokens
    /// </summary>
    /// <param name="baseId">The base id of the pair</param>
    /// <param name="quoteId">The quote id of the pair</param>
    /// <param name="dataSelection">The fields to retrieve from the response</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>A <see cref="MexPairDto"/> containing all information about the pair</returns>
    Task<MexPairDto> GetMexPairAsync(string baseId, string quoteId, DataSelectionDto? dataSelection = null, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Returns active liquidity pools count available on xExchange
    /// </summary>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The number of active liquidity pools on xExchange</returns>
    Task<int> GetMexPairsCountAsync(CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Returns a list of tokens listed on xExchange
    /// </summary>
    /// <param name="queryParameters">The data to select with pagination</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>A list of <see cref="MexTokenDto"/> containing a list of tokens listed on xExchange</returns>
    Task<IEnumerable<MexTokenDto>> GetMexTokensAsync(QueryParametersDto? queryParameters = null, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Returns a specific token listed on xExchange
    /// </summary>
    /// <param name="identifier">The token identifier</param>
    /// <param name="dataSelection">The fields to retrieve from the response</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>A <see cref="MexTokenDto"/> object containing information of the token</returns>
    Task<MexTokenDto> GetMexTokenAsync(string identifier, DataSelectionDto? dataSelection = null, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Returns tokens count available on xExchange
    /// </summary>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The number of tokens</returns>
    Task<int> GetMexTokensCountAsync(CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Returns a list of farms listed on xExchange
    /// </summary>
    /// <param name="queryParameters">The data to select with pagination</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>A list of <see cref="MexFarmDto"/> listed on xExchange</returns>
    Task<IEnumerable<MexFarmDto>> GetMexFarmsAsync(QueryParametersDto? queryParameters = null, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Returns farms count available on xExchange
    /// </summary>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The number of farms</returns>
    Task<int> GetMexFarmsCountAsync(CancellationToken cancellationToken = default);
}
