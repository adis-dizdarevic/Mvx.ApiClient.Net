#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the ContractUpgrades response returned by the MultiversX API.</summary>
public sealed class ContractUpgrades
{
    /// <summary>Gets the upstream <c>address</c> value.</summary>
    [JsonPropertyName("address")]
    public string? Address { get; init; }

    /// <summary>Gets the upstream <c>txHash</c> value.</summary>
    [JsonPropertyName("txHash")]
    public string? TxHash { get; init; }

    /// <summary>Gets the upstream <c>codeHash</c> value.</summary>
    [JsonPropertyName("codeHash")]
    public string? CodeHash { get; init; }

    /// <summary>Gets the upstream <c>timestamp</c> value.</summary>
    [JsonPropertyName("timestamp")]
    public long? Timestamp { get; init; }

}
