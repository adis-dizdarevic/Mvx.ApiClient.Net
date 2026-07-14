using System.Globalization;
using Mvx.ApiClient.Net.Infrastructure;
using Mvx.ApiClient.Net.Models.XExchange;
using Mvx.ApiClient.Net.Models.Api;

namespace Mvx.ApiClient.Net.Clients;

internal sealed class XExchangeClient : IXExchangeClient
{
    private readonly ApiRequestExecutor _requestExecutor;

    public XExchangeClient(HttpClient httpClient)
    {
        _requestExecutor = new ApiRequestExecutor(httpClient);
    }

    [ApiOperation("/mex/economics", "MexController_getMexEconomics")]
    public async Task<XExchangeEconomicsDto> GetEconomicsAsync(CancellationToken cancellationToken = default)
    {
        return await _requestExecutor.GetAsync<XExchangeEconomicsDto>(EndpointPaths.XExchangeEconomics, null, cancellationToken);
    }

    [ApiOperation("/mex/pairs", "MexController_getMexPairs")]
    public async Task<IReadOnlyList<XExchangePairDto>> GetPairsAsync(QueryOptions? queryOptions = null, CancellationToken cancellationToken = default)
    {
        return await _requestExecutor.GetAsync<IReadOnlyList<XExchangePairDto>>(EndpointPaths.XExchangePairs, queryOptions, cancellationToken);
    }

    [ApiOperation("/mex/pairs/{baseId}/{quoteId}", "MexController_getMexPair")]
    public async Task<XExchangePairDto> GetPairAsync(string baseId, string quoteId, CancellationToken cancellationToken = default)
    {
        var path = string.Format(
            CultureInfo.InvariantCulture,
            EndpointPaths.XExchangePairDetails,
            ApiPath.EscapeRequired(baseId, nameof(baseId)),
            ApiPath.EscapeRequired(quoteId, nameof(quoteId)));

        return await _requestExecutor.GetAsync<XExchangePairDto>(path, null, cancellationToken);
    }

    [ApiOperation("/mex/pairs/count", "MexController_getMexPairsCount")]
    public async Task<long> GetPairsCountAsync(CancellationToken cancellationToken = default)
    {
        return await _requestExecutor.GetInt64Async(EndpointPaths.XExchangePairsCount, null, cancellationToken);
    }

    [ApiOperation("/mex/tokens", "MexController_getMexTokens")]
    public async Task<IReadOnlyList<XExchangeTokenDto>> GetTokensAsync(QueryOptions? queryOptions = null, CancellationToken cancellationToken = default)
    {
        return await _requestExecutor.GetAsync<IReadOnlyList<XExchangeTokenDto>>(EndpointPaths.XExchangeTokens, queryOptions, cancellationToken);
    }

    [ApiOperation("/mex/tokens/{identifier}", "MexController_getMexTokenIdentifier")]
    public async Task<XExchangeTokenDto> GetTokenAsync(string identifier, CancellationToken cancellationToken = default)
    {
        var path = string.Format(
            CultureInfo.InvariantCulture,
            EndpointPaths.XExchangeTokenDetails,
            ApiPath.EscapeRequired(identifier, nameof(identifier)));

        return await _requestExecutor.GetAsync<XExchangeTokenDto>(path, null, cancellationToken);
    }

    [ApiOperation("/mex/tokens/count", "MexController_getMexTokensCount")]
    public async Task<long> GetTokensCountAsync(CancellationToken cancellationToken = default)
    {
        return await _requestExecutor.GetInt64Async(EndpointPaths.XExchangeTokensCount, null, cancellationToken);
    }

    [ApiOperation("/mex/farms", "MexController_getMexFarms")]
    public async Task<IReadOnlyList<XExchangeFarmDto>> GetFarmsAsync(QueryOptions? queryOptions = null, CancellationToken cancellationToken = default)
    {
        return await _requestExecutor.GetAsync<IReadOnlyList<XExchangeFarmDto>>(EndpointPaths.XExchangeFarms, queryOptions, cancellationToken);
    }

    [ApiOperation("/mex/farms/count", "MexController_getMexFarmsCount")]
    public async Task<long> GetFarmsCountAsync(CancellationToken cancellationToken = default)
    {
        return await _requestExecutor.GetInt64Async(EndpointPaths.XExchangeFarmsCount, null, cancellationToken);
    }

[ApiOperation("/mex/tokens/prices/hourly/{identifier}", "MexController_getTokenPricesHourResolution")]
    public async Task<IReadOnlyList<MexTokenChart>> GetTokenHourlyPricesAsync(string identifier, CancellationToken cancellationToken = default)
    {
        var path = $"mex/tokens/prices/hourly/{ApiPath.EscapeRequired(identifier.ToString(), nameof(identifier))}";
        QueryParameters? query = null;
        return await _requestExecutor.GetJsonAsync<IReadOnlyList<MexTokenChart>>(path, query, cancellationToken);
    }

    [ApiOperation("/mex/tokens/prices/daily/{identifier}", "MexController_getTokenPricesDayResolution")]
    public async Task<IReadOnlyList<MexTokenChart>> GetTokenDailyPricesAsync(string identifier, CancellationToken cancellationToken = default)
    {
        var path = $"mex/tokens/prices/daily/{ApiPath.EscapeRequired(identifier.ToString(), nameof(identifier))}";
        QueryParameters? query = null;
        return await _requestExecutor.GetJsonAsync<IReadOnlyList<MexTokenChart>>(path, query, cancellationToken);
    }
}
