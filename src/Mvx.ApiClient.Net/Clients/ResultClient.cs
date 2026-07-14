#nullable enable
using System.Text.Json;
using Mvx.ApiClient.Net.Infrastructure;
using Mvx.ApiClient.Net.Models.Api;
using Mvx.ApiClient.Net.Requests.Results;

namespace Mvx.ApiClient.Net.Clients;

internal sealed class ResultClient : IResultClient
{
    private readonly ApiRequestExecutor _requestExecutor;

    public ResultClient(HttpClient httpClient)
    {
        _requestExecutor = new ApiRequestExecutor(httpClient);
    }

    [ApiOperation("/results", "SmartContractResultController_getScResults")]
    public async Task<IReadOnlyList<SmartContractResult>> GetScResultsAsync(GetScResultsOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = "results";
        var query = new QueryParameters();
        query.AddPagination(options?.Pagination);
        query.AddString("miniBlockHash", options?.MiniBlockHash);
        query.AddCollection("originalTxHashes", options?.OriginalTxHashes);
        query.AddString("sender", options?.Sender);
        query.AddString("receiver", options?.Receiver);
        query.AddCollection("function", options?.Function);
        query.AddBoolean("withActionTransferValue", options?.WithActionTransferValue);
        return await _requestExecutor.GetJsonAsync<IReadOnlyList<SmartContractResult>>(path, query, cancellationToken);
    }

    [ApiOperation("/results/count", "SmartContractResultController_getScResultsCount")]
    public async Task<long> GetScResultsCountAsync(GetScResultsCountOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = "results/count";
        var query = new QueryParameters();
        query.AddString("sender", options?.Sender);
        query.AddString("receiver", options?.Receiver);
        query.AddCollection("function", options?.Function);
        return await _requestExecutor.GetInt64Async(path, query, cancellationToken);
    }

    [ApiOperation("/results/{scHash}", "SmartContractResultController_getScResult")]
    public async Task<SmartContractResult> GetScResultAsync(string scHash, CancellationToken cancellationToken = default)
    {
        var path = $"results/{ApiPath.EscapeRequired(scHash.ToString(), nameof(scHash))}";
        QueryParameters? query = null;
        return await _requestExecutor.GetJsonAsync<SmartContractResult>(path, query, cancellationToken);
    }

}
