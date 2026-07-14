#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Shards;

/// <summary>Optional filters for /shards.</summary>
public sealed class GetShardsOptions
{
    /// <summary>Gets or sets pagination for the request.</summary>
    public Pagination? Pagination { get; init; }

}
