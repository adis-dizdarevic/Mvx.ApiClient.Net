#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the TransactionOperation response returned by the MultiversX API.</summary>
public sealed class TransactionOperation
{
    /// <summary>Gets the upstream <c>id</c> value.</summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>Gets the upstream <c>action</c> value.</summary>
    [JsonPropertyName("action")]
    public TransactionOperationAction? Action { get; init; }

    /// <summary>Gets the upstream <c>type</c> value.</summary>
    [JsonPropertyName("type")]
    public TransactionOperationType? Type { get; init; }

    /// <summary>Gets the upstream <c>esdtType</c> value.</summary>
    [JsonPropertyName("esdtType")]
    public TransactionOperationEsdtType? EsdtType { get; init; }

    /// <summary>Gets the upstream <c>identifier</c> value.</summary>
    [JsonPropertyName("identifier")]
    public string? Identifier { get; init; }

    /// <summary>Gets the upstream <c>ticker</c> value.</summary>
    [JsonPropertyName("ticker")]
    public string? Ticker { get; init; }

    /// <summary>Gets the upstream <c>collection</c> value.</summary>
    [JsonPropertyName("collection")]
    public string? Collection { get; init; }

    /// <summary>Gets the upstream <c>name</c> value.</summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>Gets the upstream <c>value</c> value.</summary>
    [JsonPropertyName("value")]
    public BigInteger? Value { get; init; }

    /// <summary>Gets the upstream <c>valueUSD</c> value.</summary>
    [JsonPropertyName("valueUSD")]
    public decimal? ValueUSD { get; init; }

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

    /// <summary>Gets the upstream <c>decimals</c> value.</summary>
    [JsonPropertyName("decimals")]
    public long? Decimals { get; init; }

    /// <summary>Gets the upstream <c>data</c> value.</summary>
    [JsonPropertyName("data")]
    public string? Data { get; init; }

    /// <summary>Gets the upstream <c>additionalData</c> value.</summary>
    [JsonPropertyName("additionalData")]
    public IReadOnlyList<string>? AdditionalData { get; init; }

    /// <summary>Gets the upstream <c>message</c> value.</summary>
    [JsonPropertyName("message")]
    public string? Message { get; init; }

    /// <summary>Gets the upstream <c>svgUrl</c> value.</summary>
    [JsonPropertyName("svgUrl")]
    public string? SvgUrl { get; init; }

}
