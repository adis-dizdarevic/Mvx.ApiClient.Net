#nullable enable
using System.Text.Json;
using Mvx.ApiClient.Net.Infrastructure;
using Mvx.ApiClient.Net.Models.Api;
using Mvx.ApiClient.Net.Requests.Providers;

namespace Mvx.ApiClient.Net.Clients;

internal sealed class ProviderClient : IProviderClient
{
    private readonly ApiRequestExecutor _requestExecutor;

    public ProviderClient(HttpClient httpClient)
    {
        _requestExecutor = new ApiRequestExecutor(httpClient);
    }

    [ApiOperation("/providers", "ProviderController_getProviders")]
    public async Task<IReadOnlyList<Provider>> GetProvidersAsync(GetProvidersOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = "providers";
        var query = new QueryParameters();
        query.AddString("identity", options?.Identity);
        query.AddString("owner", options?.Owner);
        query.AddCollection("providers", options?.Providers);
        query.AddBoolean("withIdentityInfo", options?.WithIdentityInfo);
        query.AddBoolean("withLatestInfo", options?.WithLatestInfo);
        return await _requestExecutor.GetJsonAsync<IReadOnlyList<Provider>>(path, query, cancellationToken);
    }

    [ApiOperation("/providers/{address}/accounts", "ProviderController_getProviderAccounts")]
    public async Task<IReadOnlyList<ProviderAccount>> GetProviderAccountsAsync(string address, GetProviderAccountsOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = $"providers/{ApiPath.EscapeRequired(address.ToString(), nameof(address))}/accounts";
        var query = new QueryParameters();
        query.AddPagination(options?.Pagination);
        return await _requestExecutor.GetJsonAsync<IReadOnlyList<ProviderAccount>>(path, query, cancellationToken);
    }

    [ApiOperation("/providers/{address}/accounts/count", "ProviderController_getProviderAccountsCount")]
    public async Task<long> GetProviderAccountsCountAsync(string address, CancellationToken cancellationToken = default)
    {
        var path = $"providers/{ApiPath.EscapeRequired(address.ToString(), nameof(address))}/accounts/count";
        QueryParameters? query = null;
        return await _requestExecutor.GetInt64Async(path, query, cancellationToken);
    }

    [ApiOperation("/providers/{address}", "ProviderController_getProvider")]
    public async Task<Provider> GetProviderAsync(string address, CancellationToken cancellationToken = default)
    {
        var path = $"providers/{ApiPath.EscapeRequired(address.ToString(), nameof(address))}";
        QueryParameters? query = null;
        return await _requestExecutor.GetJsonAsync<Provider>(path, query, cancellationToken);
    }

    [ApiOperation("/providers/{address}/avatar", "ProviderController_getIdentityAvatar")]
    public async Task<MvxApiContent> GetProviderAvatarAsync(string address, CancellationToken cancellationToken = default)
    {
        var path = $"providers/{ApiPath.EscapeRequired(address.ToString(), nameof(address))}/avatar";
        QueryParameters? query = null;
        return await _requestExecutor.GetContentAsync(path, query, cancellationToken);
    }

}
