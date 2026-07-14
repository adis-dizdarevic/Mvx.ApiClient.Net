#nullable enable
using System.Text.Json;
using Mvx.ApiClient.Net.Infrastructure;
using Mvx.ApiClient.Net.Models.Api;
using Mvx.ApiClient.Net.Requests.Transactions;

namespace Mvx.ApiClient.Net.Clients;

internal sealed class TransactionClient : ITransactionClient
{
    private readonly ApiRequestExecutor _requestExecutor;

    public TransactionClient(HttpClient httpClient)
    {
        _requestExecutor = new ApiRequestExecutor(httpClient);
    }

    [ApiOperation("/transactions", "TransactionController_getTransactions")]
    public async Task<IReadOnlyList<Transaction>> GetTransactionsAsync(GetTransactionsOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = "transactions";
        var query = new QueryParameters();
        query.AddPagination(options?.Pagination);
        query.AddString("sender", options?.Sender);
        query.AddCollection("receiver", options?.Receiver);
        query.AddString("relayer", options?.Relayer);
        query.AddString("token", options?.Token);
        query.AddOptionalNumber("senderShard", options?.SenderShard);
        query.AddOptionalNumber("receiverShard", options?.ReceiverShard);
        query.AddString("miniBlockHash", options?.MiniBlockHash);
        query.AddCollection("hashes", options?.Hashes);
        query.AddOptionalEnum("status", options?.Status);
        query.AddCollection("function", options?.Function);
        query.AddOptionalNumber("before", options?.Before);
        query.AddOptionalNumber("after", options?.After);
        query.AddOptionalNumber("round", options?.Round);
        query.AddOptionalEnum("order", options?.Order);
        query.AddBoolean("withScResults", options?.WithScResults);
        query.AddBoolean("withOperations", options?.WithOperations);
        query.AddBoolean("withLogs", options?.WithLogs);
        query.AddBoolean("withScamInfo", options?.WithScamInfo);
        query.AddBoolean("withUsername", options?.WithUsername);
        query.AddBoolean("withBlockInfo", options?.WithBlockInfo);
        query.AddBoolean("isRelayed", options?.IsRelayed);
        query.AddBoolean("isScCall", options?.IsScCall);
        query.AddBoolean("withActionTransferValue", options?.WithActionTransferValue);
        query.AddBoolean("withRelayedScresults", options?.WithRelayedScresults);
        return await _requestExecutor.GetJsonAsync<IReadOnlyList<Transaction>>(path, query, cancellationToken);
    }

    [ApiOperation("/transactions/count", "TransactionController_getTransactionCount")]
    public async Task<long> GetTransactionCountAsync(GetTransactionCountOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = "transactions/count";
        var query = new QueryParameters();
        query.AddString("sender", options?.Sender);
        query.AddCollection("receiver", options?.Receiver);
        query.AddString("token", options?.Token);
        query.AddOptionalNumber("senderShard", options?.SenderShard);
        query.AddOptionalNumber("receiverShard", options?.ReceiverShard);
        query.AddString("miniBlockHash", options?.MiniBlockHash);
        query.AddCollection("hashes", options?.Hashes);
        query.AddOptionalEnum("status", options?.Status);
        query.AddCollection("function", options?.Function);
        query.AddOptionalNumber("before", options?.Before);
        query.AddOptionalNumber("after", options?.After);
        query.AddOptionalNumber("round", options?.Round);
        query.AddString("relayer", options?.Relayer);
        query.AddBoolean("isRelayed", options?.IsRelayed);
        query.AddBoolean("isScCall", options?.IsScCall);
        query.AddBoolean("withRelayedScresults", options?.WithRelayedScresults);
        return await _requestExecutor.GetInt64Async(path, query, cancellationToken);
    }

    [ApiOperation("/transactions/{txHash}", "TransactionController_getTransaction")]
    public async Task<TransactionDetailed> GetTransactionAsync(string txHash, GetTransactionOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = $"transactions/{ApiPath.EscapeRequired(txHash.ToString(), nameof(txHash))}";
        var query = new QueryParameters();
        query.AddBoolean("withActionTransferValue", options?.WithActionTransferValue);
        return await _requestExecutor.GetJsonAsync<TransactionDetailed>(path, query, cancellationToken);
    }

    [ApiOperation("/transactions/ppu/{shardId}", "TransactionController_getPpuByShardId")]
    public async Task<ProcessingUnitMetadata> GetPpuByShardIdAsync(long shardId, CancellationToken cancellationToken = default)
    {
        var path = $"transactions/ppu/{ApiPath.EscapeRequired(shardId.ToString(), nameof(shardId))}";
        QueryParameters? query = null;
        return await _requestExecutor.GetJsonAsync<ProcessingUnitMetadata>(path, query, cancellationToken);
    }

}
