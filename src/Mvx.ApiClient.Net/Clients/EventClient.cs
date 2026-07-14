#nullable enable
using System.Text.Json;
using Mvx.ApiClient.Net.Infrastructure;
using Mvx.ApiClient.Net.Models.Api;
using Mvx.ApiClient.Net.Requests.Events;

namespace Mvx.ApiClient.Net.Clients;

internal sealed class EventClient : IEventClient
{
    private readonly ApiRequestExecutor _requestExecutor;

    public EventClient(HttpClient httpClient)
    {
        _requestExecutor = new ApiRequestExecutor(httpClient);
    }

    [ApiOperation("/events", "EventsController_getEvents")]
    public async Task<IReadOnlyList<Event>> GetEventsAsync(GetEventsOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = "events";
        var query = new QueryParameters();
        query.AddPagination(options?.Pagination);
        query.AddString("address", options?.Address);
        query.AddString("logAddress", options?.LogAddress);
        query.AddString("identifier", options?.Identifier);
        query.AddString("txHash", options?.TxHash);
        query.AddOptionalNumber("shard", options?.Shard);
        query.AddOptionalNumber("before", options?.Before);
        query.AddOptionalNumber("after", options?.After);
        query.AddOptionalNumber("order", options?.Order);
        query.AddCollection("topics", options?.Topics);
        return await _requestExecutor.GetJsonAsync<IReadOnlyList<Event>>(path, query, cancellationToken);
    }

    [ApiOperation("/events/count", "EventsController_getEventsCount")]
    public async Task<long> GetEventsCountAsync(GetEventsCountOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = "events/count";
        var query = new QueryParameters();
        query.AddString("address", options?.Address);
        query.AddString("identifier", options?.Identifier);
        query.AddString("txHash", options?.TxHash);
        query.AddOptionalNumber("shard", options?.Shard);
        query.AddOptionalNumber("before", options?.Before);
        query.AddOptionalNumber("after", options?.After);
        query.AddCollection("topics", options?.Topics);
        return await _requestExecutor.GetInt64Async(path, query, cancellationToken);
    }

    [ApiOperation("/events/{txHash}", "EventsController_getEvent")]
    public async Task<Event> GetEventAsync(string txHash, CancellationToken cancellationToken = default)
    {
        var path = $"events/{ApiPath.EscapeRequired(txHash.ToString(), nameof(txHash))}";
        QueryParameters? query = null;
        return await _requestExecutor.GetJsonAsync<Event>(path, query, cancellationToken);
    }

}
