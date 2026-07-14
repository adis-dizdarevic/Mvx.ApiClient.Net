#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Applications;

/// <summary>Optional filters for /applications/count.</summary>
public sealed class GetApplicationsCountOptions
{
    /// <summary>Gets or sets the <c>before</c> filter.</summary>
    public long? Before { get; init; }

    /// <summary>Gets or sets the <c>after</c> filter.</summary>
    public long? After { get; init; }

}
