namespace Mvx.ApiClient.Dtos;

/// <summary>
/// Dto for specifying optional parameters in API queries
/// </summary>
public sealed class QueryParametersDto
{
    /// <summary>
    /// The number of items to retrieve and skip
    /// </summary>
    public PaginationParametersDto? Pagination { get; set; }
    
    /// <summary>
    /// The fields to return from the api
    /// </summary>
    public DataSelectionDto? Data { get; set; }
}
