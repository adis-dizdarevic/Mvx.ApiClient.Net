#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the TransactionInPool response returned by the MultiversX API.</summary>
public sealed class TransactionInPool
{
    /// <summary>Gets the upstream <c>txHash</c> value.</summary>
    [JsonPropertyName("txHash")]
    public string? TxHash { get; init; }

    /// <summary>Gets the upstream <c>sender</c> value.</summary>
    [JsonPropertyName("sender")]
    public string? Sender { get; init; }

    /// <summary>Gets the upstream <c>receiver</c> value.</summary>
    [JsonPropertyName("receiver")]
    public string? Receiver { get; init; }

    /// <summary>Gets the upstream <c>receiverUsername</c> value.</summary>
    [JsonPropertyName("receiverUsername")]
    public string? ReceiverUsername { get; init; }

    /// <summary>Gets the upstream <c>guardian</c> value.</summary>
    [JsonPropertyName("guardian")]
    public string? Guardian { get; init; }

    /// <summary>Gets the upstream <c>guardianSignature</c> value.</summary>
    [JsonPropertyName("guardianSignature")]
    public string? GuardianSignature { get; init; }

    /// <summary>Gets the upstream <c>nonce</c> value.</summary>
    [JsonPropertyName("nonce")]
    public long? Nonce { get; init; }

    /// <summary>Gets the upstream <c>value</c> value.</summary>
    [JsonPropertyName("value")]
    public BigInteger? Value { get; init; }

    /// <summary>Gets the upstream <c>data</c> value.</summary>
    [JsonPropertyName("data")]
    public string? Data { get; init; }

    /// <summary>Gets the upstream <c>gasPrice</c> value.</summary>
    [JsonPropertyName("gasPrice")]
    public long? GasPrice { get; init; }

    /// <summary>Gets the upstream <c>gasLimit</c> value.</summary>
    [JsonPropertyName("gasLimit")]
    public long? GasLimit { get; init; }

    /// <summary>Gets the upstream <c>senderShard</c> value.</summary>
    [JsonPropertyName("senderShard")]
    public long? SenderShard { get; init; }

    /// <summary>Gets the upstream <c>receiverShard</c> value.</summary>
    [JsonPropertyName("receiverShard")]
    public long? ReceiverShard { get; init; }

    /// <summary>Gets the upstream <c>signature</c> value.</summary>
    [JsonPropertyName("signature")]
    public string? Signature { get; init; }

    /// <summary>Gets the upstream <c>function</c> value.</summary>
    [JsonPropertyName("function")]
    public string? Function { get; init; }

    /// <summary>Gets the upstream <c>type</c> value.</summary>
    [JsonPropertyName("type")]
    public string? Type { get; init; }

}
