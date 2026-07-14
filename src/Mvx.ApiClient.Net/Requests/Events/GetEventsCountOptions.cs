#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Events;

/// <summary>Optional filters for /events/count.</summary>
public sealed class GetEventsCountOptions
{
    /// <summary>Gets or sets the <c>address</c> filter.</summary>
    public string? Address { get; init; }

    /// <summary>Gets or sets the <c>identifier</c> filter.</summary>
    public string? Identifier { get; init; }

    /// <summary>Gets or sets the <c>txHash</c> filter.</summary>
    public string? TxHash { get; init; }

    /// <summary>Gets or sets the <c>shard</c> filter.</summary>
    public long? Shard { get; init; }

    /// <summary>Gets or sets the <c>before</c> filter.</summary>
    public long? Before { get; init; }

    /// <summary>Gets or sets the <c>after</c> filter.</summary>
    public long? After { get; init; }

    /// <summary>Gets or sets the <c>topics</c> filter.</summary>
    public IReadOnlyCollection<string>? Topics { get; init; }

}
