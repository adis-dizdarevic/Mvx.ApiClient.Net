#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Tags;

/// <summary>Optional filters for /tags/count.</summary>
public sealed class GetTagCountOptions
{
    /// <summary>Gets or sets the <c>search</c> filter.</summary>
    public string? Search { get; init; }

}
