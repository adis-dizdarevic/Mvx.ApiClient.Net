#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Tokens;

/// <summary>Optional filters for /tokens/{identifier}/transfers.</summary>
public sealed class GetTokenTransfersOptions
{
    /// <summary>Gets or sets pagination for the request.</summary>
    public Pagination? Pagination { get; init; }

    /// <summary>Gets or sets the <c>sender</c> filter.</summary>
    public IReadOnlyCollection<string>? Sender { get; init; }

    /// <summary>Gets or sets the <c>receiver</c> filter.</summary>
    public IReadOnlyCollection<string>? Receiver { get; init; }

    /// <summary>Gets or sets the <c>senderShard</c> filter.</summary>
    public long? SenderShard { get; init; }

    /// <summary>Gets or sets the <c>receiverShard</c> filter.</summary>
    public long? ReceiverShard { get; init; }

    /// <summary>Gets or sets the <c>miniBlockHash</c> filter.</summary>
    public string? MiniBlockHash { get; init; }

    /// <summary>Gets or sets the <c>hashes</c> filter.</summary>
    public IReadOnlyCollection<string>? Hashes { get; init; }

    /// <summary>Gets or sets the <c>status</c> filter.</summary>
    public GetTokenTransfersOptionsStatus? Status { get; init; }

    /// <summary>Gets or sets the <c>function</c> filter.</summary>
    public IReadOnlyCollection<string>? Function { get; init; }

    /// <summary>Gets or sets the <c>before</c> filter.</summary>
    public long? Before { get; init; }

    /// <summary>Gets or sets the <c>after</c> filter.</summary>
    public long? After { get; init; }

    /// <summary>Gets or sets the <c>round</c> filter.</summary>
    public long? Round { get; init; }

    /// <summary>Gets or sets the <c>order</c> filter.</summary>
    public GetTokenTransfersOptionsOrder? Order { get; init; }

    /// <summary>Gets or sets the <c>isScCall</c> filter.</summary>
    public bool? IsScCall { get; init; }

    /// <summary>Gets or sets the <c>withScamInfo</c> filter.</summary>
    public bool? WithScamInfo { get; init; }

    /// <summary>Gets or sets the <c>withUsername</c> filter.</summary>
    public bool? WithUsername { get; init; }

    /// <summary>Gets or sets the <c>withBlockInfo</c> filter.</summary>
    public bool? WithBlockInfo { get; init; }

    /// <summary>Gets or sets the <c>withActionTransferValue</c> filter.</summary>
    public bool? WithActionTransferValue { get; init; }

}
