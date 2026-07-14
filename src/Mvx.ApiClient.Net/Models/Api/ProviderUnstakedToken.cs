#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the ProviderUnstakedToken response returned by the MultiversX API.</summary>
public sealed class ProviderUnstakedToken
{
    /// <summary>Gets the upstream <c>amount</c> value.</summary>
    [JsonPropertyName("amount")]
    public BigInteger? Amount { get; init; }

    /// <summary>Gets the upstream <c>expires</c> value.</summary>
    [JsonPropertyName("expires")]
    public long? Expires { get; init; }

    /// <summary>Gets the upstream <c>epochs</c> value.</summary>
    [JsonPropertyName("epochs")]
    public long? Epochs { get; init; }

}
