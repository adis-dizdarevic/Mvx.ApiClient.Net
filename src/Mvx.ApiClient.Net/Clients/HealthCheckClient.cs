#nullable enable
using System.Text.Json;
using Mvx.ApiClient.Net.Infrastructure;
using Mvx.ApiClient.Net.Models.Api;

namespace Mvx.ApiClient.Net.Clients;

internal sealed class HealthCheckClient : IHealthCheckClient
{
    private readonly ApiRequestExecutor _requestExecutor;

    public HealthCheckClient(HttpClient httpClient)
    {
        _requestExecutor = new ApiRequestExecutor(httpClient);
    }

    [ApiOperation("/hello", "HealthCheckController_getHello")]
    public async Task<string> GetHelloAsync(CancellationToken cancellationToken = default)
    {
        var path = "hello";
        QueryParameters? query = null;
        return await _requestExecutor.GetStringAsync(path, query, cancellationToken);
    }

}
