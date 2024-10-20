namespace Mvx.ApiClient.Net.Dtos;

/// <summary>
/// Dto for selecting specific fields and/or extracting scalar values from the response
/// </summary>
public sealed class DataSelectionDto
{
    /// <summary>
    /// The specific fields to retrieve
    /// </summary>
    public IEnumerable<string>? Fields { get; set; }
    
    /// <summary>
    /// The scalar value to extract
    /// </summary>
    public string? Extract { get; set; }
}
