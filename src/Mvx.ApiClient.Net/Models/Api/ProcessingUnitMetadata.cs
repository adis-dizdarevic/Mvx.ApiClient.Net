#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the ProcessingUnitMetadata response returned by the MultiversX API.</summary>
public sealed class ProcessingUnitMetadata
{
    /// <summary>Gets the upstream <c>lastBlock</c> value.</summary>
    [JsonPropertyName("lastBlock")]
    public long? LastBlock { get; init; }

    /// <summary>Gets the upstream <c>fast</c> value.</summary>
    [JsonPropertyName("fast")]
    public long? Fast { get; init; }

    /// <summary>Gets the upstream <c>faster</c> value.</summary>
    [JsonPropertyName("faster")]
    public long? Faster { get; init; }

}
