#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the Shard response returned by the MultiversX API.</summary>
public sealed class Shard
{
    /// <summary>Gets the upstream <c>shard</c> value.</summary>
    [JsonPropertyName("shard")]
    public long? ShardValue { get; init; }

    /// <summary>Gets the upstream <c>validators</c> value.</summary>
    [JsonPropertyName("validators")]
    public long? Validators { get; init; }

    /// <summary>Gets the upstream <c>activeValidators</c> value.</summary>
    [JsonPropertyName("activeValidators")]
    public long? ActiveValidators { get; init; }

}
