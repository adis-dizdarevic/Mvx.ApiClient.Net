#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Applications;

/// <summary>Optional filters for /applications.</summary>
public sealed class GetApplicationsOptions
{
    /// <summary>Gets or sets pagination for the request.</summary>
    public Pagination? Pagination { get; init; }

    /// <summary>Gets or sets the <c>before</c> filter.</summary>
    public long? Before { get; init; }

    /// <summary>Gets or sets the <c>after</c> filter.</summary>
    public long? After { get; init; }

    /// <summary>Gets or sets the <c>withTxCount</c> filter.</summary>
    public bool? WithTxCount { get; init; }

}
