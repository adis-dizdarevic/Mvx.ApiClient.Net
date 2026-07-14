using System.Globalization;
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

    public async Task<XExchangeEconomicsDto> GetEconomicsAsync(CancellationToken cancellationToken = default)
    {
        return await _requestExecutor.GetAsync<XExchangeEconomicsDto>(EndpointPaths.XExchangeEconomics, null, cancellationToken);
    }

    public async Task<IReadOnlyList<XExchangePairDto>> GetPairsAsync(QueryOptions? queryOptions = null, CancellationToken cancellationToken = default)
    {
        return await _requestExecutor.GetAsync<IReadOnlyList<XExchangePairDto>>(EndpointPaths.XExchangePairs, queryOptions, cancellationToken);
    }

    public async Task<XExchangePairDto> GetPairAsync(string baseId, string quoteId, CancellationToken cancellationToken = default)
    {
        var path = string.Format(
            CultureInfo.InvariantCulture,
            EndpointPaths.XExchangePairDetails,
            ApiPath.EscapeRequired(baseId, nameof(baseId)),
            ApiPath.EscapeRequired(quoteId, nameof(quoteId)));

        return await _requestExecutor.GetAsync<XExchangePairDto>(path, null, cancellationToken);
    }

    public async Task<int> GetPairsCountAsync(CancellationToken cancellationToken = default)
    {
        return await _requestExecutor.GetAsync<int>(EndpointPaths.XExchangePairsCount, null, cancellationToken);
    }

    public async Task<IReadOnlyList<XExchangeTokenDto>> GetTokensAsync(QueryOptions? queryOptions = null, CancellationToken cancellationToken = default)
    {
        return await _requestExecutor.GetAsync<IReadOnlyList<XExchangeTokenDto>>(EndpointPaths.XExchangeTokens, queryOptions, cancellationToken);
    }

    public async Task<XExchangeTokenDto> GetTokenAsync(string identifier, CancellationToken cancellationToken = default)
    {
        var path = string.Format(
            CultureInfo.InvariantCulture,
            EndpointPaths.XExchangeTokenDetails,
            ApiPath.EscapeRequired(identifier, nameof(identifier)));

        return await _requestExecutor.GetAsync<XExchangeTokenDto>(path, null, cancellationToken);
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
}
