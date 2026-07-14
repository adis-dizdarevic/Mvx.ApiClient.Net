#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the MexTokenChart response returned by the MultiversX API.</summary>
public sealed class MexTokenChart
{
    /// <summary>Gets the upstream <c>timestamp</c> value.</summary>
    [JsonPropertyName("timestamp")]
    public long? Timestamp { get; init; }

    /// <summary>Gets the upstream <c>value</c> value.</summary>
    [JsonPropertyName("value")]
    public decimal? Value { get; init; }

}
