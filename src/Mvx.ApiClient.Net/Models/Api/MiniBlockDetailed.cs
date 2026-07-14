#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the MiniBlockDetailed response returned by the MultiversX API.</summary>
public sealed class MiniBlockDetailed
{
    /// <summary>Gets the upstream <c>miniBlockHash</c> value.</summary>
    [JsonPropertyName("miniBlockHash")]
    public string? MiniBlockHash { get; init; }

    /// <summary>Gets the upstream <c>receiverBlockHash</c> value.</summary>
    [JsonPropertyName("receiverBlockHash")]
    public string? ReceiverBlockHash { get; init; }

    /// <summary>Gets the upstream <c>receiverShard</c> value.</summary>
    [JsonPropertyName("receiverShard")]
    public long? ReceiverShard { get; init; }

    /// <summary>Gets the upstream <c>senderBlockHash</c> value.</summary>
    [JsonPropertyName("senderBlockHash")]
    public string? SenderBlockHash { get; init; }

    /// <summary>Gets the upstream <c>senderShard</c> value.</summary>
    [JsonPropertyName("senderShard")]
    public long? SenderShard { get; init; }

    /// <summary>Gets the upstream <c>timestamp</c> value.</summary>
    [JsonPropertyName("timestamp")]
    public long? Timestamp { get; init; }

    /// <summary>Gets the upstream <c>type</c> value.</summary>
    [JsonPropertyName("type")]
    public string? Type { get; init; }

}
