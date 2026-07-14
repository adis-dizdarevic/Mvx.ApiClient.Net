#nullable enable
using System.Text.Json;
using Mvx.ApiClient.Net.Models.Api;
using Mvx.ApiClient.Net.Requests.Identities;

namespace Mvx.ApiClient.Net;

/// <summary>Client for MultiversX Identities GET endpoints.</summary>
public interface IIdentityClient
{
    /// <summary>Identities.</summary>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<IReadOnlyList<Identity>> GetIdentitiesAsync(GetIdentitiesOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Identity details.</summary>
    /// <param name="identifier">The identifier value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<Identity> GetIdentityAsync(string identifier, CancellationToken cancellationToken = default);

    /// <summary>Identity avatar.</summary>
    /// <param name="identifier">The identifier value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<MvxApiContent> GetIdentityAvatarAsync(string identifier, CancellationToken cancellationToken = default);

}
