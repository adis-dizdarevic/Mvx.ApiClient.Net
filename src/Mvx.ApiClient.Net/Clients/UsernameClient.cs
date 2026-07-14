#nullable enable
using System.Text.Json;
using Mvx.ApiClient.Net.Infrastructure;
using Mvx.ApiClient.Net.Models.Api;

namespace Mvx.ApiClient.Net.Clients;

internal sealed class UsernameClient : IUsernameClient
{
    private readonly ApiRequestExecutor _requestExecutor;

    public UsernameClient(HttpClient httpClient)
    {
        _requestExecutor = new ApiRequestExecutor(httpClient);
    }

    [ApiOperation("/usernames/{username}", "UsernameController_getUsernameDetails")]
    public async Task<AccountUsername> GetUsernameDetailsAsync(string username, bool withGuardianInfo, CancellationToken cancellationToken = default)
    {
        var path = $"usernames/{ApiPath.EscapeRequired(username.ToString(), nameof(username))}";
        var query = new QueryParameters();
        query.AddBoolean("withGuardianInfo", withGuardianInfo);
        return await _requestExecutor.GetJsonAsync<AccountUsername>(path, query, cancellationToken);
    }

}
