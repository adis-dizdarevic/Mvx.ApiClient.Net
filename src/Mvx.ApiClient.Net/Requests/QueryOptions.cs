namespace Mvx.ApiClient.Net;

/// <summary>
/// Configures optional query parameters for MultiversX API requests.
/// </summary>
public sealed class QueryOptions
{
    /// <summary>
    /// Gets or sets pagination options.
    /// </summary>
    /// <remarks>
    /// Pagination is only used by list endpoints.
    /// </remarks>
    public Pagination? Pagination { get; set; }

}
