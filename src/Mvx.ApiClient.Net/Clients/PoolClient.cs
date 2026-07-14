#nullable enable
using System.Text.Json;
using Mvx.ApiClient.Net.Infrastructure;
using Mvx.ApiClient.Net.Models.Api;
using Mvx.ApiClient.Net.Requests.Pool;

namespace Mvx.ApiClient.Net.Clients;

internal sealed class PoolClient : IPoolClient
{
    private readonly ApiRequestExecutor _requestExecutor;

    public PoolClient(HttpClient httpClient)
    {
        _requestExecutor = new ApiRequestExecutor(httpClient);
    }

    [ApiOperation("/pool", "PoolController_getTransactionPool")]
    public async Task<IReadOnlyList<TransactionInPool>> GetTransactionPoolAsync(GetTransactionPoolOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = "pool";
        var query = new QueryParameters();
        query.AddPagination(options?.Pagination);
        query.AddString("sender", options?.Sender);
        query.AddString("receiver", options?.Receiver);
        query.AddOptionalNumber("senderShard", options?.SenderShard);
        query.AddOptionalNumber("receiverShard", options?.ReceiverShard);
        query.AddString("type", options?.Type);
        query.AddCollection("function", options?.Function);
        return await _requestExecutor.GetJsonAsync<IReadOnlyList<TransactionInPool>>(path, query, cancellationToken);
    }

    [ApiOperation("/pool/count", "PoolController_getTransactionPoolCount")]
    public async Task<long> GetTransactionPoolCountAsync(GetTransactionPoolCountOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = "pool/count";
        var query = new QueryParameters();
        query.AddString("sender", options?.Sender);
        query.AddString("receiver", options?.Receiver);
        query.AddOptionalNumber("senderShard", options?.SenderShard);
        query.AddOptionalNumber("receiverShard", options?.ReceiverShard);
        query.AddString("type", options?.Type);
        return await _requestExecutor.GetInt64Async(path, query, cancellationToken);
    }

    [ApiOperation("/pool/{txhash}", "PoolController_getTransactionFromPool")]
    public async Task<TransactionInPool> GetTransactionFromPoolAsync(string txhash, CancellationToken cancellationToken = default)
    {
        var path = $"pool/{ApiPath.EscapeRequired(txhash.ToString(), nameof(txhash))}";
        QueryParameters? query = null;
        return await _requestExecutor.GetJsonAsync<TransactionInPool>(path, query, cancellationToken);
    }

}
