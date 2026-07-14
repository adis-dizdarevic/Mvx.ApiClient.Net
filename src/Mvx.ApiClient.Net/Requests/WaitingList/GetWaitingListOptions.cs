#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.WaitingList;

/// <summary>Optional filters for /waiting-list.</summary>
public sealed class GetWaitingListOptions
{
    /// <summary>Gets or sets pagination for the request.</summary>
    public Pagination? Pagination { get; init; }

}
