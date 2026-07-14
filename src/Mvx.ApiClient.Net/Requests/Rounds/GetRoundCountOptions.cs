#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Rounds;

/// <summary>Optional filters for /rounds/count.</summary>
public sealed class GetRoundCountOptions
{
    /// <summary>Gets or sets the <c>validator</c> filter.</summary>
    public string? Validator { get; init; }

    /// <summary>Gets or sets the <c>condition</c> filter.</summary>
    public string? Condition { get; init; }

    /// <summary>Gets or sets the <c>shard</c> filter.</summary>
    public long? Shard { get; init; }

    /// <summary>Gets or sets the <c>epoch</c> filter.</summary>
    public long? Epoch { get; init; }

}
