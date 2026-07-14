#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Accounts;

/// <summary>Optional filters for /accounts/{address}/tokens/count.</summary>
public sealed class GetTokenCountOptions
{
    /// <summary>Gets or sets the <c>type</c> filter.</summary>
    public GetTokenCountOptionsType? Type { get; init; }

    /// <summary>Gets or sets the <c>search</c> filter.</summary>
    public string? Search { get; init; }

    /// <summary>Gets or sets the <c>name</c> filter.</summary>
    public string? Name { get; init; }

    /// <summary>Gets or sets the <c>identifier</c> filter.</summary>
    public string? Identifier { get; init; }

    /// <summary>Gets or sets the <c>identifiers</c> filter.</summary>
    public string? Identifiers { get; init; }

    /// <summary>Gets or sets the <c>includeMetaESDT</c> filter.</summary>
    public bool? IncludeMetaESDT { get; init; }

    /// <summary>Gets or sets the <c>timestamp</c> filter.</summary>
    public long? Timestamp { get; init; }

    /// <summary>Gets or sets the <c>mexPairType</c> filter.</summary>
    public IReadOnlyCollection<string>? MexPairType { get; init; }

}
