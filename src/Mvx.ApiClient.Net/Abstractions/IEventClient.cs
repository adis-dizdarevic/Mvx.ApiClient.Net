#nullable enable
using System.Text.Json;
using Mvx.ApiClient.Net.Models.Api;
using Mvx.ApiClient.Net.Requests.Events;

namespace Mvx.ApiClient.Net;

/// <summary>Client for MultiversX Events GET endpoints.</summary>
public interface IEventClient
{
    /// <summary>Events.</summary>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<IReadOnlyList<Event>> GetEventsAsync(GetEventsOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Events count.</summary>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<long> GetEventsCountAsync(GetEventsCountOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Event.</summary>
    /// <param name="txHash">The txHash value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<Event> GetEventAsync(string txHash, CancellationToken cancellationToken = default);

}
