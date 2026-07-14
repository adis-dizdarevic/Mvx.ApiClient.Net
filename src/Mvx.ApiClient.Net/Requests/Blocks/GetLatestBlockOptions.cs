#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Blocks;

/// <summary>Optional filters for /blocks/latest.</summary>
public sealed class GetLatestBlockOptions
{
    /// <summary>Gets or sets the <c>ttl</c> filter.</summary>
    public long? Ttl { get; init; }

}
