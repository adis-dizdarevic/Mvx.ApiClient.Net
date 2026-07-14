#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the SmartContractResult response returned by the MultiversX API.</summary>
public sealed class SmartContractResult
{
    /// <summary>Gets the upstream <c>hash</c> value.</summary>
    [JsonPropertyName("hash")]
    public string? Hash { get; init; }

    /// <summary>Gets the upstream <c>timestamp</c> value.</summary>
    [JsonPropertyName("timestamp")]
    public long? Timestamp { get; init; }

    /// <summary>Gets the upstream <c>nonce</c> value.</summary>
    [JsonPropertyName("nonce")]
    public long? Nonce { get; init; }

    /// <summary>Gets the upstream <c>gasLimit</c> value.</summary>
    [JsonPropertyName("gasLimit")]
    public long? GasLimit { get; init; }

    /// <summary>Gets the upstream <c>gasPrice</c> value.</summary>
    [JsonPropertyName("gasPrice")]
    public long? GasPrice { get; init; }

    /// <summary>Gets the upstream <c>value</c> value.</summary>
    [JsonPropertyName("value")]
    public BigInteger? Value { get; init; }

    /// <summary>Gets the upstream <c>sender</c> value.</summary>
    [JsonPropertyName("sender")]
    public string? Sender { get; init; }

    /// <summary>Gets the upstream <c>receiver</c> value.</summary>
    [JsonPropertyName("receiver")]
    public string? Receiver { get; init; }

    /// <summary>Gets the upstream <c>senderAssets</c> value.</summary>
    [JsonPropertyName("senderAssets")]
    public AccountAssets? SenderAssets { get; init; }

    /// <summary>Gets the upstream <c>receiverAssets</c> value.</summary>
    [JsonPropertyName("receiverAssets")]
    public AccountAssets? ReceiverAssets { get; init; }

    /// <summary>Gets the upstream <c>relayedValue</c> value.</summary>
    [JsonPropertyName("relayedValue")]
    public BigInteger? RelayedValue { get; init; }

    /// <summary>Gets the upstream <c>data</c> value.</summary>
    [JsonPropertyName("data")]
    public string? Data { get; init; }

    /// <summary>Gets the upstream <c>prevTxHash</c> value.</summary>
    [JsonPropertyName("prevTxHash")]
    public string? PrevTxHash { get; init; }

    /// <summary>Gets the upstream <c>originalTxHash</c> value.</summary>
    [JsonPropertyName("originalTxHash")]
    public string? OriginalTxHash { get; init; }

    /// <summary>Gets the upstream <c>callType</c> value.</summary>
    [JsonPropertyName("callType")]
    public string? CallType { get; init; }

    /// <summary>Gets the upstream <c>miniBlockHash</c> value.</summary>
    [JsonPropertyName("miniBlockHash")]
    public string? MiniBlockHash { get; init; }

    /// <summary>Gets the upstream <c>logs</c> value.</summary>
    [JsonPropertyName("logs")]
    public TransactionLog? Logs { get; init; }

    /// <summary>Gets the upstream <c>returnMessage</c> value.</summary>
    [JsonPropertyName("returnMessage")]
    public string? ReturnMessage { get; init; }

    /// <summary>Gets the upstream <c>action</c> value.</summary>
    [JsonPropertyName("action")]
    public TransactionAction? Action { get; init; }

    /// <summary>Gets the upstream <c>function</c> value.</summary>
    [JsonPropertyName("function")]
    public string? Function { get; init; }

    /// <summary>Gets the upstream <c>status</c> value.</summary>
    [JsonPropertyName("status")]
    public string? Status { get; init; }

}
