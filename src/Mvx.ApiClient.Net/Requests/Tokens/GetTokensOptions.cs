#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Tokens;

/// <summary>Optional filters for /tokens.</summary>
public sealed class GetTokensOptions
{
    /// <summary>Gets or sets pagination for the request.</summary>
    public Pagination? Pagination { get; init; }

    /// <summary>Gets or sets the <c>type</c> filter.</summary>
    public GetTokensOptionsType? Type { get; init; }

    /// <summary>Gets or sets the <c>search</c> filter.</summary>
    public string? Search { get; init; }

    /// <summary>Gets or sets the <c>name</c> filter.</summary>
    public string? Name { get; init; }

    /// <summary>Gets or sets the <c>identifier</c> filter.</summary>
    public string? Identifier { get; init; }

    /// <summary>Gets or sets the <c>identifiers</c> filter.</summary>
    public IReadOnlyCollection<string>? Identifiers { get; init; }

    /// <summary>Gets or sets the <c>sort</c> filter.</summary>
    public GetTokensOptionsSort? Sort { get; init; }

    /// <summary>Gets or sets the <c>order</c> filter.</summary>
    public GetTokensOptionsOrder? Order { get; init; }

    /// <summary>Gets or sets the <c>includeMetaESDT</c> filter.</summary>
    public bool? IncludeMetaESDT { get; init; }

    /// <summary>Gets or sets the <c>mexPairType</c> filter.</summary>
    public IReadOnlyCollection<string>? MexPairType { get; init; }

    /// <summary>Gets or sets the <c>priceSource</c> filter.</summary>
    public GetTokensOptionsPriceSource? PriceSource { get; init; }

}
