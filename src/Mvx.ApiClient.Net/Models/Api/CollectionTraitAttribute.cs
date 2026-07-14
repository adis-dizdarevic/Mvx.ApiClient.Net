#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the CollectionTraitAttribute response returned by the MultiversX API.</summary>
public sealed class CollectionTraitAttribute
{
    /// <summary>Gets the upstream <c>name</c> value.</summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>Gets the upstream <c>occurrenceCount</c> value.</summary>
    [JsonPropertyName("occurrenceCount")]
    public long? OccurrenceCount { get; init; }

    /// <summary>Gets the upstream <c>occurrencePercentage</c> value.</summary>
    [JsonPropertyName("occurrencePercentage")]
    public decimal? OccurrencePercentage { get; init; }

}
