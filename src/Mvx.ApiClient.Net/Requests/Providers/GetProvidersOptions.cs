#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Providers;

/// <summary>Optional filters for /providers.</summary>
public sealed class GetProvidersOptions
{
    /// <summary>Gets or sets the <c>identity</c> filter.</summary>
    public string? Identity { get; init; }

    /// <summary>Gets or sets the <c>owner</c> filter.</summary>
    public string? Owner { get; init; }

    /// <summary>Gets or sets the <c>providers</c> filter.</summary>
    public IReadOnlyCollection<string>? Providers { get; init; }

    /// <summary>Gets or sets the <c>withIdentityInfo</c> filter.</summary>
    public bool? WithIdentityInfo { get; init; }

    /// <summary>Gets or sets the <c>withLatestInfo</c> filter.</summary>
    public bool? WithLatestInfo { get; init; }

}
