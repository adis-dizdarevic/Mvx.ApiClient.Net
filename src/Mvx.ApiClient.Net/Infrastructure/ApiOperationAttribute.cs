namespace Mvx.ApiClient.Net.Infrastructure;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
internal sealed class ApiOperationAttribute : Attribute
{
    public ApiOperationAttribute(string path, string operationId)
    {
        Path = path;
        OperationId = operationId;
    }

    public string Path { get; }

    public string OperationId { get; }
}
