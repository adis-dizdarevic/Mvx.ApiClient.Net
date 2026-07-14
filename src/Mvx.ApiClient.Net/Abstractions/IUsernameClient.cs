#nullable enable
using System.Text.Json;
using Mvx.ApiClient.Net.Models.Api;

namespace Mvx.ApiClient.Net;

/// <summary>Client for MultiversX Usernames GET endpoints.</summary>
public interface IUsernameClient
{
    /// <summary>Account details by username.</summary>
    /// <param name="username">The username value.</param>
    /// <param name="withGuardianInfo">The withGuardianInfo value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<AccountUsername> GetUsernameDetailsAsync(string username, bool withGuardianInfo, CancellationToken cancellationToken = default);

}
