#nullable enable
using System.Text.Json;
using Mvx.ApiClient.Net.Models.Api;
using Mvx.ApiClient.Net.Requests.WaitingList;

namespace Mvx.ApiClient.Net;

/// <summary>Client for MultiversX WaitingList GET endpoints.</summary>
public interface IWaitingListClient
{
    /// <summary>Waiting list.</summary>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<IReadOnlyList<WaitingList>> GetWaitingListAsync(GetWaitingListOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Waiting list count.</summary>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<long> GetWaitingListCountAsync(CancellationToken cancellationToken = default);

}
