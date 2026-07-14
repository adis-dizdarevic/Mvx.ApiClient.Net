#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the NetworkConstants response returned by the MultiversX API.</summary>
public sealed class NetworkConstants
{
    /// <summary>Gets the upstream <c>chainId</c> value.</summary>
    [JsonPropertyName("chainId")]
    public string? ChainId { get; init; }

    /// <summary>Gets the upstream <c>gasPerDataByte</c> value.</summary>
    [JsonPropertyName("gasPerDataByte")]
    public long? GasPerDataByte { get; init; }

    /// <summary>Gets the upstream <c>minGasLimit</c> value.</summary>
    [JsonPropertyName("minGasLimit")]
    public long? MinGasLimit { get; init; }

    /// <summary>Gets the upstream <c>minGasPrice</c> value.</summary>
    [JsonPropertyName("minGasPrice")]
    public long? MinGasPrice { get; init; }

    /// <summary>Gets the upstream <c>minTransactionVersion</c> value.</summary>
    [JsonPropertyName("minTransactionVersion")]
    public long? MinTransactionVersion { get; init; }

    /// <summary>Gets the upstream <c>gasPriceModifier</c> value.</summary>
    [JsonPropertyName("gasPriceModifier")]
    public string? GasPriceModifier { get; init; }

}
