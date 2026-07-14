#nullable enable
using System.Text.Json;
using Mvx.ApiClient.Net.Infrastructure;
using Mvx.ApiClient.Net.Models.Api;

namespace Mvx.ApiClient.Net.Clients;

internal sealed class KeyClient : IKeyClient
{
    private readonly ApiRequestExecutor _requestExecutor;

    public KeyClient(HttpClient httpClient)
    {
        _requestExecutor = new ApiRequestExecutor(httpClient);
    }

    [ApiOperation("/keys/{key}/unbond-period", "KeysController_getKeyUnbondPeriod")]
    public async Task<KeyUnbondPeriod> GetKeyUnbondPeriodAsync(string key, CancellationToken cancellationToken = default)
    {
        var path = $"keys/{ApiPath.EscapeRequired(key.ToString(), nameof(key))}/unbond-period";
        QueryParameters? query = null;
        return await _requestExecutor.GetJsonAsync<KeyUnbondPeriod>(path, query, cancellationToken);
    }

}
