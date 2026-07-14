namespace Mvx.ApiClient.Net;

/// <summary>
/// Configures paged MultiversX API requests.
/// </summary>
public sealed class Pagination
{
    /// <summary>
    /// The maximum number of entries accepted by the public MultiversX API for a single list request.
    /// </summary>
    public const int MaximumLimit = 10_000;

    /// <summary>
    /// Gets or sets the number of items to retrieve.
    /// </summary>
    /// <remarks>
    /// Values are sent through the API's <c>size</c> query parameter. Values outside the range from zero through
    /// <see cref="MaximumLimit"/> are rejected before a request is sent. Individual endpoints can impose a smaller
    /// effective limit when expensive optional response details are requested.
    /// </remarks>
    public int? Limit { get; set; }

    /// <summary>
    /// Gets or sets the number of items to skip.
    /// </summary>
    /// <remarks>
    /// Values are sent through the API's <c>from</c> query parameter. Negative values are rejected before a request is sent.
    /// </remarks>
    public int? Offset { get; set; }
}
