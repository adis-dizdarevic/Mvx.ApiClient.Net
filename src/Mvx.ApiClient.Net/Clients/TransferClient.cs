#nullable enable
using System.Text.Json;
using Mvx.ApiClient.Net.Infrastructure;
using Mvx.ApiClient.Net.Models.Api;
using Mvx.ApiClient.Net.Requests.Transfers;

namespace Mvx.ApiClient.Net.Clients;

internal sealed class TransferClient : ITransferClient
{
    private readonly ApiRequestExecutor _requestExecutor;

    public TransferClient(HttpClient httpClient)
    {
        _requestExecutor = new ApiRequestExecutor(httpClient);
    }

    [ApiOperation("/transfers", "TransferController_getAccountTransfers")]
    public async Task<IReadOnlyList<Transaction>> GetTransfersAsync(GetTransfersOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = "transfers";
        var query = new QueryParameters();
        query.AddPagination(options?.Pagination);
        query.AddCollection("receiver", options?.Receiver);
        query.AddCollection("sender", options?.Sender);
        query.AddString("token", options?.Token);
        query.AddCollection("function", options?.Function);
        query.AddOptionalNumber("senderShard", options?.SenderShard);
        query.AddOptionalNumber("receiverShard", options?.ReceiverShard);
        query.AddString("miniBlockHash", options?.MiniBlockHash);
        query.AddCollection("hashes", options?.Hashes);
        query.AddOptionalEnum("status", options?.Status);
        query.AddOptionalNumber("before", options?.Before);
        query.AddOptionalNumber("after", options?.After);
        query.AddOptionalNumber("round", options?.Round);
        query.AddOptionalEnum("order", options?.Order);
        query.AddString("relayer", options?.Relayer);
        query.AddBoolean("isRelayed", options?.IsRelayed);
        query.AddBoolean("isScCall", options?.IsScCall);
        query.AddBoolean("withScamInfo", options?.WithScamInfo);
        query.AddBoolean("withUsername", options?.WithUsername);
        query.AddBoolean("withBlockInfo", options?.WithBlockInfo);
        query.AddBoolean("withLogs", options?.WithLogs);
        query.AddBoolean("withOperations", options?.WithOperations);
        query.AddBoolean("withActionTransferValue", options?.WithActionTransferValue);
        query.AddBoolean("withTxsOrder", options?.WithTxsOrder);
        query.AddBoolean("withRefunds", options?.WithRefunds);
        return await _requestExecutor.GetJsonAsync<IReadOnlyList<Transaction>>(path, query, cancellationToken);
    }

    [ApiOperation("/transfers/count", "TransferController_getAccountTransfersCount")]
    public async Task<long> GetTransfersCountAsync(GetTransfersCountOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = "transfers/count";
        var query = new QueryParameters();
        query.AddCollection("sender", options?.Sender);
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
        query.AddBoolean("withRefunds", options?.WithRefunds);
        return await _requestExecutor.GetInt64Async(path, query, cancellationToken);
    }

}
