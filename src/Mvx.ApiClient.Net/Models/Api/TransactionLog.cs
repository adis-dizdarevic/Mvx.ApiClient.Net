#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the TransactionLog response returned by the MultiversX API.</summary>
public sealed class TransactionLog
{
    /// <summary>Gets the upstream <c>id</c> value.</summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>Gets the upstream <c>address</c> value.</summary>
    [JsonPropertyName("address")]
    public string? Address { get; init; }

    /// <summary>Gets the upstream <c>addressAssets</c> value.</summary>
    [JsonPropertyName("addressAssets")]
    public AccountAssets? AddressAssets { get; init; }

    /// <summary>Gets the upstream <c>events</c> value.</summary>
    [JsonPropertyName("events")]
    public IReadOnlyList<TransactionLogEvent>? Events { get; init; }

}
