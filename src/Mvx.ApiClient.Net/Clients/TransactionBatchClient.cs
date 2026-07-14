#nullable enable
using System.Text.Json;
using Mvx.ApiClient.Net.Infrastructure;
using Mvx.ApiClient.Net.Models.Api;

namespace Mvx.ApiClient.Net.Clients;

internal sealed class TransactionBatchClient : ITransactionBatchClient
{
    private readonly ApiRequestExecutor _requestExecutor;

    public TransactionBatchClient(HttpClient httpClient)
    {
        _requestExecutor = new ApiRequestExecutor(httpClient);
    }

    [ApiOperation("/batch/{address}/{id}", "TransactionsBatchController_getTransactionBatch")]
    public async Task<TransactionBatchResult> GetTransactionBatchAsync(string address, string id, CancellationToken cancellationToken = default)
    {
        var path = $"batch/{ApiPath.EscapeRequired(address.ToString(), nameof(address))}/{ApiPath.EscapeRequired(id.ToString(), nameof(id))}";
        QueryParameters? query = null;
        return await _requestExecutor.GetJsonAsync<TransactionBatchResult>(path, query, cancellationToken);
    }

    [ApiOperation("/batch/{address}", "TransactionsBatchController_getTransactionBatches")]
    public async Task<IReadOnlyList<TransactionBatchResult>> GetTransactionBatchesAsync(string address, CancellationToken cancellationToken = default)
    {
        var path = $"batch/{ApiPath.EscapeRequired(address.ToString(), nameof(address))}";
        QueryParameters? query = null;
        return await _requestExecutor.GetJsonAsync<IReadOnlyList<TransactionBatchResult>>(path, query, cancellationToken);
    }

}
