#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Miniblocks;

/// <summary>Optional filters for /miniblocks.</summary>
public sealed class GetMiniBlocksOptions
{
    /// <summary>Gets or sets pagination for the request.</summary>
    public Pagination? Pagination { get; init; }

    /// <summary>Gets or sets the <c>hashes</c> filter.</summary>
    public IReadOnlyCollection<string>? Hashes { get; init; }

    /// <summary>Gets or sets the <c>type</c> filter.</summary>
    public GetMiniBlocksOptionsType? Type { get; init; }

}
