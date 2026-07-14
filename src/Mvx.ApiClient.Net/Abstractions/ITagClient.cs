#nullable enable
using System.Text.Json;
using Mvx.ApiClient.Net.Models.Api;
using Mvx.ApiClient.Net.Requests.Tags;

namespace Mvx.ApiClient.Net;

/// <summary>Client for MultiversX Tags GET endpoints.</summary>
public interface ITagClient
{
    /// <summary>NFT Tags.</summary>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<IReadOnlyList<Tag>> GetTagsAsync(GetTagsOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Total number of NFT Tags.</summary>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<long> GetTagCountAsync(GetTagCountOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Tag details.</summary>
    /// <param name="tag">The tag value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<Tag> GetTagDetailsAsync(string tag, CancellationToken cancellationToken = default);

}
