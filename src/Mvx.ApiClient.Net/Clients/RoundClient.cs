#nullable enable
using System.Text.Json;
using Mvx.ApiClient.Net.Infrastructure;
using Mvx.ApiClient.Net.Models.Api;
using Mvx.ApiClient.Net.Requests.Rounds;

namespace Mvx.ApiClient.Net.Clients;

internal sealed class RoundClient : IRoundClient
{
    private readonly ApiRequestExecutor _requestExecutor;

    public RoundClient(HttpClient httpClient)
    {
        _requestExecutor = new ApiRequestExecutor(httpClient);
    }

    [ApiOperation("/rounds", "RoundController_getRounds")]
    public async Task<IReadOnlyList<Round>> GetRoundsAsync(GetRoundsOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = "rounds";
        var query = new QueryParameters();
        query.AddPagination(options?.Pagination);
        query.AddString("validator", options?.Validator);
        query.AddString("condition", options?.Condition);
        query.AddOptionalNumber("shard", options?.Shard);
        query.AddOptionalNumber("epoch", options?.Epoch);
        return await _requestExecutor.GetJsonAsync<IReadOnlyList<Round>>(path, query, cancellationToken);
    }

    [ApiOperation("/rounds/count", "RoundController_getRoundCount")]
    public async Task<long> GetRoundCountAsync(GetRoundCountOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = "rounds/count";
        var query = new QueryParameters();
        query.AddString("validator", options?.Validator);
        query.AddString("condition", options?.Condition);
        query.AddOptionalNumber("shard", options?.Shard);
        query.AddOptionalNumber("epoch", options?.Epoch);
        return await _requestExecutor.GetInt64Async(path, query, cancellationToken);
    }

    [ApiOperation("/rounds/{shard}/{round}", "RoundController_getRound")]
    public async Task<RoundDetailed> GetRoundAsync(long shard, long round, CancellationToken cancellationToken = default)
    {
        var path = $"rounds/{ApiPath.EscapeRequired(shard.ToString(), nameof(shard))}/{ApiPath.EscapeRequired(round.ToString(), nameof(round))}";
        QueryParameters? query = null;
        return await _requestExecutor.GetJsonAsync<RoundDetailed>(path, query, cancellationToken);
    }

}
