#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the Event response returned by the MultiversX API.</summary>
public sealed class Event
{
    /// <summary>Gets the upstream <c>txHash</c> value.</summary>
    [JsonPropertyName("txHash")]
    public string? TxHash { get; init; }

    /// <summary>Gets the upstream <c>logAddress</c> value.</summary>
    [JsonPropertyName("logAddress")]
    public string? LogAddress { get; init; }

    /// <summary>Gets the upstream <c>identifier</c> value.</summary>
    [JsonPropertyName("identifier")]
    public string? Identifier { get; init; }

    /// <summary>Gets the upstream <c>address</c> value.</summary>
    [JsonPropertyName("address")]
    public string? Address { get; init; }

    /// <summary>Gets the upstream <c>data</c> value.</summary>
    [JsonPropertyName("data")]
    public string? Data { get; init; }

    /// <summary>Gets the upstream <c>topics</c> value.</summary>
    [JsonPropertyName("topics")]
    public IReadOnlyList<string>? Topics { get; init; }

    /// <summary>Gets the upstream <c>shardID</c> value.</summary>
    [JsonPropertyName("shardID")]
    public long? ShardID { get; init; }

    /// <summary>Gets the upstream <c>additionalData</c> value.</summary>
    [JsonPropertyName("additionalData")]
    public IReadOnlyList<string>? AdditionalData { get; init; }

    /// <summary>Gets the upstream <c>txOrder</c> value.</summary>
    [JsonPropertyName("txOrder")]
    public long? TxOrder { get; init; }

    /// <summary>Gets the upstream <c>order</c> value.</summary>
    [JsonPropertyName("order")]
    public long? Order { get; init; }

    /// <summary>Gets the upstream <c>timestamp</c> value.</summary>
    [JsonPropertyName("timestamp")]
    public long? Timestamp { get; init; }

    /// <summary>Gets the upstream <c>timestampMs</c> value.</summary>
    [JsonPropertyName("timestampMs")]
    public long? TimestampMs { get; init; }

}
