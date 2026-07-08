using Mvx.ApiClient.Net.Models.Mex;

namespace Mvx.ApiClient.Net.Clients;

internal sealed class MexClient : IMexClient
{
    private readonly HttpClient _httpClient;

    public MexClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<MexEconomicsDto> GetMexEconomicsAsync(DataSelection? dataSelection = null, CancellationToken cancellationToken = default)
    {
        return await _httpClient.GetWithQueryOptionsAsync<MexEconomicsDto>(EndpointPaths.MexEconomics, new QueryOptions { Data = dataSelection }, cancellationToken);
    }

    public async Task<IReadOnlyList<MexPairDto>> GetMexPairsAsync(QueryOptions? queryOptions = null, CancellationToken cancellationToken = default)
    {
        return await _httpClient.GetWithQueryOptionsAsync<IReadOnlyList<MexPairDto>>(EndpointPaths.MexPairs, queryOptions, cancellationToken);
    }

    public async Task<MexPairDto> GetMexPairAsync(string baseId, string quoteId, DataSelection? dataSelection = null, CancellationToken cancellationToken = default)
    {
        ValidateRequiredPathSegment(baseId, nameof(baseId));
        ValidateRequiredPathSegment(quoteId, nameof(quoteId));

        var path = string.Format(EndpointPaths.MexPairDetails, Uri.EscapeDataString(baseId), Uri.EscapeDataString(quoteId));

        return await _httpClient.GetWithQueryOptionsAsync<MexPairDto>(path, new QueryOptions { Data = dataSelection }, cancellationToken);
    }

    public async Task<int> GetMexPairsCountAsync(CancellationToken cancellationToken = default)
    {
        return await _httpClient.GetWithQueryOptionsAsync<int>(EndpointPaths.MexPairsCount, null, cancellationToken);
    }

    public async Task<IReadOnlyList<MexTokenDto>> GetMexTokensAsync(QueryOptions? queryOptions = null, CancellationToken cancellationToken = default)
    {
        return await _httpClient.GetWithQueryOptionsAsync<IReadOnlyList<MexTokenDto>>(EndpointPaths.MexTokens, queryOptions, cancellationToken);
    }

    public async Task<MexTokenDto> GetMexTokenAsync(string identifier, DataSelection? dataSelection = null, CancellationToken cancellationToken = default)
    {
        ValidateRequiredPathSegment(identifier, nameof(identifier));

        var path = string.Format(EndpointPaths.MexTokenDetails, Uri.EscapeDataString(identifier));

        return await _httpClient.GetWithQueryOptionsAsync<MexTokenDto>(path, new QueryOptions { Data = dataSelection }, cancellationToken);
    }

    public async Task<int> GetMexTokensCountAsync(CancellationToken cancellationToken = default)
    {
        return await _httpClient.GetWithQueryOptionsAsync<int>(EndpointPaths.MexTokensCount, null, cancellationToken);
    }

    public async Task<IReadOnlyList<MexFarmDto>> GetMexFarmsAsync(QueryOptions? queryOptions = null, CancellationToken cancellationToken = default)
    {
        return await _httpClient.GetWithQueryOptionsAsync<IReadOnlyList<MexFarmDto>>(EndpointPaths.MexFarms, queryOptions, cancellationToken);
    }

    public async Task<int> GetMexFarmsCountAsync(CancellationToken cancellationToken = default)
    {
        return await _httpClient.GetWithQueryOptionsAsync<int>(EndpointPaths.MexFarmsCount, null, cancellationToken);
    }

    private static void ValidateRequiredPathSegment(string value, string parameterName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Path segment cannot be null or empty.", parameterName);
        }
    }
}
