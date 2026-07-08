using Mvx.ApiClient.Net.Infrastructure;
using Mvx.ApiClient.Net.Models.XExchange;

namespace Mvx.ApiClient.Net.Clients;

internal sealed class XExchangeClient : IXExchangeClient
{
    private readonly ApiRequestExecutor _requestExecutor;

    public XExchangeClient(HttpClient httpClient)
    {
        _requestExecutor = new ApiRequestExecutor(httpClient);
    }

    public async Task<XExchangeEconomicsDto> GetEconomicsAsync(DataSelection? dataSelection = null, CancellationToken cancellationToken = default)
    {
        return await _requestExecutor.GetAsync<XExchangeEconomicsDto>(EndpointPaths.XExchangeEconomics, new QueryOptions { Data = dataSelection }, cancellationToken);
    }

    public async Task<IReadOnlyList<XExchangePairDto>> GetPairsAsync(QueryOptions? queryOptions = null, CancellationToken cancellationToken = default)
    {
        return await _requestExecutor.GetAsync<IReadOnlyList<XExchangePairDto>>(EndpointPaths.XExchangePairs, queryOptions, cancellationToken);
    }

    public async Task<XExchangePairDto> GetPairAsync(string baseId, string quoteId, DataSelection? dataSelection = null, CancellationToken cancellationToken = default)
    {
        ValidateRequiredPathSegment(baseId, nameof(baseId));
        ValidateRequiredPathSegment(quoteId, nameof(quoteId));

        var path = string.Format(EndpointPaths.XExchangePairDetails, Uri.EscapeDataString(baseId), Uri.EscapeDataString(quoteId));

        return await _requestExecutor.GetAsync<XExchangePairDto>(path, new QueryOptions { Data = dataSelection }, cancellationToken);
    }

    public async Task<int> GetPairsCountAsync(CancellationToken cancellationToken = default)
    {
        return await _requestExecutor.GetAsync<int>(EndpointPaths.XExchangePairsCount, null, cancellationToken);
    }

    public async Task<IReadOnlyList<XExchangeTokenDto>> GetTokensAsync(QueryOptions? queryOptions = null, CancellationToken cancellationToken = default)
    {
        return await _requestExecutor.GetAsync<IReadOnlyList<XExchangeTokenDto>>(EndpointPaths.XExchangeTokens, queryOptions, cancellationToken);
    }

    public async Task<XExchangeTokenDto> GetTokenAsync(string identifier, DataSelection? dataSelection = null, CancellationToken cancellationToken = default)
    {
        ValidateRequiredPathSegment(identifier, nameof(identifier));

        var path = string.Format(EndpointPaths.XExchangeTokenDetails, Uri.EscapeDataString(identifier));

        return await _requestExecutor.GetAsync<XExchangeTokenDto>(path, new QueryOptions { Data = dataSelection }, cancellationToken);
    }

    public async Task<int> GetTokensCountAsync(CancellationToken cancellationToken = default)
    {
        return await _requestExecutor.GetAsync<int>(EndpointPaths.XExchangeTokensCount, null, cancellationToken);
    }

    public async Task<IReadOnlyList<XExchangeFarmDto>> GetFarmsAsync(QueryOptions? queryOptions = null, CancellationToken cancellationToken = default)
    {
        return await _requestExecutor.GetAsync<IReadOnlyList<XExchangeFarmDto>>(EndpointPaths.XExchangeFarms, queryOptions, cancellationToken);
    }

    public async Task<int> GetFarmsCountAsync(CancellationToken cancellationToken = default)
    {
        return await _requestExecutor.GetAsync<int>(EndpointPaths.XExchangeFarmsCount, null, cancellationToken);
    }

    private static void ValidateRequiredPathSegment(string value, string parameterName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Path segment cannot be null or empty.", parameterName);
        }
    }
}
