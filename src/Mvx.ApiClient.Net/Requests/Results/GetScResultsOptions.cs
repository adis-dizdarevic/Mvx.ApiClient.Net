#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Results;

/// <summary>Optional filters for /results.</summary>
public sealed class GetScResultsOptions
{
    /// <summary>Gets or sets pagination for the request.</summary>
    public Pagination? Pagination { get; init; }

    /// <summary>Gets or sets the <c>miniBlockHash</c> filter.</summary>
    public string? MiniBlockHash { get; init; }

    /// <summary>Gets or sets the <c>originalTxHashes</c> filter.</summary>
    public IReadOnlyCollection<string>? OriginalTxHashes { get; init; }

    /// <summary>Gets or sets the <c>sender</c> filter.</summary>
    public string? Sender { get; init; }

    /// <summary>Gets or sets the <c>receiver</c> filter.</summary>
    public string? Receiver { get; init; }

    /// <summary>Gets or sets the <c>function</c> filter.</summary>
    public IReadOnlyCollection<string>? Function { get; init; }

    /// <summary>Gets or sets the <c>withActionTransferValue</c> filter.</summary>
    public bool? WithActionTransferValue { get; init; }

}
