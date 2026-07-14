#nullable enable
using System.Text.Json;
using Mvx.ApiClient.Net.Infrastructure;
using Mvx.ApiClient.Net.Models.Api;
using Mvx.ApiClient.Net.Requests.Identities;

namespace Mvx.ApiClient.Net.Clients;

internal sealed class IdentityClient : IIdentityClient
{
    private readonly ApiRequestExecutor _requestExecutor;

    public IdentityClient(HttpClient httpClient)
    {
        _requestExecutor = new ApiRequestExecutor(httpClient);
    }

    [ApiOperation("/identities", "IdentitiesController_getIdentities")]
    public async Task<IReadOnlyList<Identity>> GetIdentitiesAsync(GetIdentitiesOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = "identities";
        var query = new QueryParameters();
        query.AddPagination(options?.Pagination);
        query.AddCollection("identities", options?.Identities);
        query.AddCollection("sort", options?.Sort);
        return await _requestExecutor.GetJsonAsync<IReadOnlyList<Identity>>(path, query, cancellationToken);
    }

    [ApiOperation("/identities/{identifier}", "IdentitiesController_getIdentity")]
    public async Task<Identity> GetIdentityAsync(string identifier, CancellationToken cancellationToken = default)
    {
        var path = $"identities/{ApiPath.EscapeRequired(identifier.ToString(), nameof(identifier))}";
        QueryParameters? query = null;
        return await _requestExecutor.GetJsonAsync<Identity>(path, query, cancellationToken);
    }

    [ApiOperation("/identities/{identifier}/avatar", "IdentitiesController_getIdentityAvatar")]
    public async Task<MvxApiContent> GetIdentityAvatarAsync(string identifier, CancellationToken cancellationToken = default)
    {
        var path = $"identities/{ApiPath.EscapeRequired(identifier.ToString(), nameof(identifier))}/avatar";
        QueryParameters? query = null;
        return await _requestExecutor.GetContentAsync(path, query, cancellationToken);
    }

}
