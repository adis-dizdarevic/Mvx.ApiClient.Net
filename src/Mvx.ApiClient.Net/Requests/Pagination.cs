namespace Mvx.ApiClient.Net;

/// <summary>
/// Configures paged MultiversX API requests.
/// </summary>
public sealed class Pagination
{
    /// <summary>
    /// Gets or sets the number of items to retrieve.
    /// </summary>
    /// <remarks>
    /// Values are sent through the API's <c>size</c> query parameter. Negative values are rejected before a request is sent.
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
