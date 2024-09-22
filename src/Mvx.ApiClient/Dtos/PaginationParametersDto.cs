namespace Mvx.ApiClient.Dtos;

/// <summary>
/// Dto for handling pagination parameters
/// </summary>
public class PaginationParametersDto
{
    /// <summary>
    /// The number of items to retrieve
    /// </summary>
    public int? Limit { get; set; }
    
    /// <summary>
    /// The number of items to skip
    /// </summary>
    public int? Offset { get; set; }
}
