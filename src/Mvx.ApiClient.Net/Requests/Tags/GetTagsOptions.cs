#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Tags;

/// <summary>Optional filters for /tags.</summary>
public sealed class GetTagsOptions
{
    /// <summary>Gets or sets pagination for the request.</summary>
    public Pagination? Pagination { get; init; }

    /// <summary>Gets or sets the <c>search</c> filter.</summary>
    public string? Search { get; init; }

}
