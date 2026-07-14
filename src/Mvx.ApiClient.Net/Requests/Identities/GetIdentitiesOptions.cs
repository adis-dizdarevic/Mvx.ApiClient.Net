#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Identities;

/// <summary>Optional filters for /identities.</summary>
public sealed class GetIdentitiesOptions
{
    /// <summary>Gets or sets pagination for the request.</summary>
    public Pagination? Pagination { get; init; }

    /// <summary>Gets or sets the <c>identities</c> filter.</summary>
    public IReadOnlyCollection<string>? Identities { get; init; }

    /// <summary>Gets or sets the <c>sort</c> filter.</summary>
    public IReadOnlyCollection<string>? Sort { get; init; }

}
