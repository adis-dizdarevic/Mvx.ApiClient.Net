#nullable enable
using System.Text.Json;
using Mvx.ApiClient.Net.Infrastructure;
using Mvx.ApiClient.Net.Models.Api;
using Mvx.ApiClient.Net.Requests.Applications;

namespace Mvx.ApiClient.Net.Clients;

internal sealed class ApplicationClient : IApplicationClient
{
    private readonly ApiRequestExecutor _requestExecutor;

    public ApplicationClient(HttpClient httpClient)
    {
        _requestExecutor = new ApiRequestExecutor(httpClient);
    }

    [ApiOperation("/applications", "ApplicationController_getApplications")]
    public async Task<IReadOnlyList<Application>> GetApplicationsAsync(GetApplicationsOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = "applications";
        var query = new QueryParameters();
        query.AddPagination(options?.Pagination);
        query.AddOptionalNumber("before", options?.Before);
        query.AddOptionalNumber("after", options?.After);
        query.AddBoolean("withTxCount", options?.WithTxCount);
        return await _requestExecutor.GetJsonAsync<IReadOnlyList<Application>>(path, query, cancellationToken);
    }

    [ApiOperation("/applications/count", "ApplicationController_getApplicationsCount")]
    public async Task<long> GetApplicationsCountAsync(GetApplicationsCountOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = "applications/count";
        var query = new QueryParameters();
        query.AddOptionalNumber("before", options?.Before);
        query.AddOptionalNumber("after", options?.After);
        return await _requestExecutor.GetInt64Async(path, query, cancellationToken);
    }

    [ApiOperation("/applications/{address}", "ApplicationController_getApplication")]
    public async Task<Application> GetApplicationAsync(string address, CancellationToken cancellationToken = default)
    {
        var path = $"applications/{ApiPath.EscapeRequired(address.ToString(), nameof(address))}";
        QueryParameters? query = null;
        return await _requestExecutor.GetJsonAsync<Application>(path, query, cancellationToken);
    }

}
