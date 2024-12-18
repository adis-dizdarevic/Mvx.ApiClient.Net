﻿namespace Mvx.ApiClient.Net.Dtos;

/// <summary>
/// Dto for handling pagination parameters
/// </summary>
public sealed class PaginationParametersDto
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
