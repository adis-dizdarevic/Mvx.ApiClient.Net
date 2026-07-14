#nullable enable
using System.Text.Json;
using Mvx.ApiClient.Net.Models.Api;
using Mvx.ApiClient.Net.Requests.Providers;

namespace Mvx.ApiClient.Net;

/// <summary>Client for MultiversX Providers GET endpoints.</summary>
public interface IProviderClient
{
    /// <summary>Providers.</summary>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<IReadOnlyList<Provider>> GetProvidersAsync(GetProvidersOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Provider.</summary>
    /// <param name="address">The address value.</param>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<IReadOnlyList<ProviderAccount>> GetProviderAccountsAsync(string address, GetProviderAccountsOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Provider.</summary>
    /// <param name="address">The address value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<long> GetProviderAccountsCountAsync(string address, CancellationToken cancellationToken = default);

    /// <summary>Provider.</summary>
    /// <param name="address">The address value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<Provider> GetProviderAsync(string address, CancellationToken cancellationToken = default);

    /// <summary>Provider avatar.</summary>
    /// <param name="address">The address value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<MvxApiContent> GetProviderAvatarAsync(string address, CancellationToken cancellationToken = default);

}
