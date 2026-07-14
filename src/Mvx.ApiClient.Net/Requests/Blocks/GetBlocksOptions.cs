#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Blocks;

/// <summary>Optional filters for /blocks.</summary>
public sealed class GetBlocksOptions
{
    /// <summary>Gets or sets pagination for the request.</summary>
    public Pagination? Pagination { get; init; }

    /// <summary>Gets or sets the <c>shard</c> filter.</summary>
    public long? Shard { get; init; }

    /// <summary>Gets or sets the <c>proposer</c> filter.</summary>
    public string? Proposer { get; init; }

    /// <summary>Gets or sets the <c>validator</c> filter.</summary>
    public string? Validator { get; init; }

    /// <summary>Gets or sets the <c>epoch</c> filter.</summary>
    public long? Epoch { get; init; }

    /// <summary>Gets or sets the <c>nonce</c> filter.</summary>
    public long? Nonce { get; init; }

    /// <summary>Gets or sets the <c>hashes</c> filter.</summary>
    public IReadOnlyCollection<string>? Hashes { get; init; }

    /// <summary>Gets or sets the <c>order</c> filter.</summary>
    public GetBlocksOptionsOrder? Order { get; init; }

    /// <summary>Gets or sets the <c>withProposerIdentity</c> filter.</summary>
    public bool? WithProposerIdentity { get; init; }

}
