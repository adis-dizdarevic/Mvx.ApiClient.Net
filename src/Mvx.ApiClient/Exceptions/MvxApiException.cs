namespace Mvx.ApiClient.Exceptions;

public class MvxApiException : Exception
{
    public MvxApiException(string message, string error, int statusCode) : base(message)
    {
        Error = error;
        StatusCode = statusCode;
    }
    
    public string Message { get; set; }
    public string Error { get; set; }
    public int StatusCode { get; set; }
}
