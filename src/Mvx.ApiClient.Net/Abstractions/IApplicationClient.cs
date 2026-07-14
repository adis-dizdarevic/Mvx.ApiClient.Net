#nullable enable
using System.Text.Json;
using Mvx.ApiClient.Net.Models.Api;
using Mvx.ApiClient.Net.Requests.Applications;

namespace Mvx.ApiClient.Net;

/// <summary>Client for MultiversX Applications GET endpoints.</summary>
public interface IApplicationClient
{
    /// <summary>Applications details.</summary>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<IReadOnlyList<Application>> GetApplicationsAsync(GetApplicationsOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Applications count.</summary>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<long> GetApplicationsCountAsync(GetApplicationsCountOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Application details.</summary>
    /// <param name="address">The address value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<Application> GetApplicationAsync(string address, CancellationToken cancellationToken = default);

}
