#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the TransactionLogEvent response returned by the MultiversX API.</summary>
public sealed class TransactionLogEvent
{
    /// <summary>Gets the upstream <c>address</c> value.</summary>
    [JsonPropertyName("address")]
    public string? Address { get; init; }

    /// <summary>Gets the upstream <c>addressAssets</c> value.</summary>
    [JsonPropertyName("addressAssets")]
    public AccountAssets? AddressAssets { get; init; }

    /// <summary>Gets the upstream <c>identifier</c> value.</summary>
    [JsonPropertyName("identifier")]
    public string? Identifier { get; init; }

    /// <summary>Gets the upstream <c>topics</c> value.</summary>
    [JsonPropertyName("topics")]
    public IReadOnlyList<string>? Topics { get; init; }

    /// <summary>Gets the upstream <c>data</c> value.</summary>
    [JsonPropertyName("data")]
    public string? Data { get; init; }

    /// <summary>Gets the upstream <c>order</c> value.</summary>
    [JsonPropertyName("order")]
    public long? Order { get; init; }

    /// <summary>Gets the upstream <c>additionalData</c> value.</summary>
    [JsonPropertyName("additionalData")]
    public JsonElement? AdditionalData { get; init; }

}
