#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the TransactionAction response returned by the MultiversX API.</summary>
public sealed class TransactionAction
{
    /// <summary>Gets the upstream <c>category</c> value.</summary>
    [JsonPropertyName("category")]
    public string? Category { get; init; }

    /// <summary>Gets the upstream <c>name</c> value.</summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>Gets the upstream <c>description</c> value.</summary>
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    /// <summary>Gets the upstream <c>arguments</c> value.</summary>
    [JsonPropertyName("arguments")]
    public JsonElement? Arguments { get; init; }

}
