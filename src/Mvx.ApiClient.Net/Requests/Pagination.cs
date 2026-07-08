namespace Mvx.ApiClient.Net;

/// <summary>
/// Configures paged MultiversX API requests.
/// </summary>
public sealed class Pagination
{
    /// <summary>
    /// Gets or sets the number of items to retrieve.
    /// </summary>
    public int? Limit { get; set; }

    /// <summary>
    /// Gets or sets the number of items to skip.
    /// </summary>
    public int? Offset { get; set; }
}
