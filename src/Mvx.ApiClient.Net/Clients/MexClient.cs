using Mvx.ApiClient.Net.Dtos;
using Mvx.ApiClient.Net.ExtensionMethods;
using Mvx.ApiClient.Net.Interfaces.Clients;
using Mvx.ApiClient.Net.Models.Mex;

namespace Mvx.ApiClient.Net.Clients;

internal sealed class MexClient : IMexClient
{
    private readonly HttpClient _httpClient;

    public MexClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<MexEconomicsDto> GetMexEconomicsAsync(DataSelectionDto? dataSelection = null, CancellationToken cancellationToken = default)
    {
        var parameters = new QueryParametersDto { Data = dataSelection };
        var result = await _httpClient.GetWithQueryParametersAsync<MexEconomicsDto>(EndpointPaths.MexEconomics, parameters, cancellationToken);

        return result;
    }

    public async Task<IEnumerable<MexPairDto>> GetMexPairsAsync(QueryParametersDto? queryParameters = null, CancellationToken cancellationToken = default)
    {
        var parameters = new QueryParametersDto
        {
            Data = queryParameters?.Data, Pagination = queryParameters?.Pagination
        };
        var result = await _httpClient.GetWithQueryParametersAsync<IEnumerable<MexPairDto>>(EndpointPaths.MexPairs, parameters, cancellationToken);

        return result;
    }

    public async Task<MexPairDto> GetMexPairAsync(string baseId, string quoteId, DataSelectionDto? dataSelection = null, CancellationToken cancellationToken = default)
    {
        var parameters = new QueryParametersDto { Data = dataSelection };
        var result = await _httpClient.GetWithQueryParametersAsync<MexPairDto>(EndpointPaths.MexPairDetails, parameters, cancellationToken);

        return result;
    }

    public async Task<int> GetMexPairsCountAsync(CancellationToken cancellationToken = default)
    {
        var result = await _httpClient.GetWithQueryParametersAsync<int>(EndpointPaths.MexPairsCount, null, cancellationToken);

        return result;
    }

    public async Task<IEnumerable<MexTokenDto>> GetMexTokensAsync(QueryParametersDto? queryParameters = null, CancellationToken cancellationToken = default)
    {
        var parameters = new QueryParametersDto
        {
            Data = queryParameters?.Data, Pagination = queryParameters?.Pagination
        };
        var result = await _httpClient.GetWithQueryParametersAsync<IEnumerable<MexTokenDto>>(EndpointPaths.MexTokens, parameters, cancellationToken);

        return result;
    }

    public async Task<MexTokenDto> GetMexTokenAsync(string identifier, DataSelectionDto? dataSelection = null, CancellationToken cancellationToken = default)
    {
        var parameters = new QueryParametersDto { Data = dataSelection };
        var result = await _httpClient.GetWithQueryParametersAsync<MexTokenDto>(EndpointPaths.MexTokenDetails, parameters, cancellationToken);

        return result;
    }

    public async Task<int> GetMexTokensCountAsync(CancellationToken cancellationToken = default)
    {
        var result = await _httpClient.GetWithQueryParametersAsync<int>(EndpointPaths.MexTokensCount, null, cancellationToken);

        return result;
    }

    public async Task<IEnumerable<MexFarmDto>> GetMexFarmsAsync(QueryParametersDto? queryParameters = null, CancellationToken cancellationToken = default)
    {
        var parameters = new QueryParametersDto
        {
            Data = queryParameters?.Data, Pagination = queryParameters?.Pagination
        };
        var result = await _httpClient.GetWithQueryParametersAsync<IEnumerable<MexFarmDto>>(EndpointPaths.MexFarms, parameters, cancellationToken);

        return result;
    }

    public async Task<int> GetMexFarmsCountAsync(CancellationToken cancellationToken = default)
    {
        var result = await _httpClient.GetWithQueryParametersAsync<int>(EndpointPaths.MexFarmsCount, null, cancellationToken);

        return result;
    }
}
