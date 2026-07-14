#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the Tag response returned by the MultiversX API.</summary>
public sealed class Tag
{
    /// <summary>Gets the upstream <c>tag</c> value.</summary>
    [JsonPropertyName("tag")]
    public string? TagValue { get; init; }

    /// <summary>Gets the upstream <c>count</c> value.</summary>
    [JsonPropertyName("count")]
    public long? Count { get; init; }

}
