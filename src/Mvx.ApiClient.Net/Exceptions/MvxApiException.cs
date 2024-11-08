﻿namespace Mvx.ApiClient.Net.Exceptions;

/// <summary>
/// The exception that is thrown when the MultiversX API returns a status code between 400 and 499
/// </summary>
public sealed class MvxApiException : Exception
{
    public MvxApiException(string message, string error, int statusCode) : base(message)
    {
        Error = error;
        StatusCode = statusCode;
    }
    
    public string Error { get; set; }
    public int StatusCode { get; set; }
}
