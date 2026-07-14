#nullable enable
using System.Text.Json;
using Mvx.ApiClient.Net.Models.Api;
using Mvx.ApiClient.Net.Requests.Tokens;

namespace Mvx.ApiClient.Net;

/// <summary>Client for MultiversX Tokens GET endpoints.</summary>
public interface ITokenClient
{
    /// <summary>Tokens.</summary>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<IReadOnlyList<TokenDetailed>> GetTokensAsync(GetTokensOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Tokens count.</summary>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<long> GetTokenCountAsync(GetTokenCountOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Token.</summary>
    /// <param name="identifier">The identifier value.</param>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<TokenDetailed> GetTokenAsync(string identifier, GetTokenOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Token supply.</summary>
    /// <param name="identifier">The identifier value.</param>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<EsdtSupply> GetTokenSupplyAsync(string identifier, GetTokenSupplyOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Token accounts.</summary>
    /// <param name="identifier">The identifier value.</param>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<IReadOnlyList<TokenAccount>> GetTokenAccountsAsync(string identifier, GetTokenAccountsOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Token accounts count.</summary>
    /// <param name="identifier">The identifier value.</param>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<long> GetTokenAccountsCountAsync(string identifier, GetTokenAccountsCountOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Token transactions.</summary>
    /// <param name="identifier">The identifier value.</param>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<IReadOnlyList<Transaction>> GetTokenTransactionsAsync(string identifier, GetTokenTransactionsOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Token transactions count.</summary>
    /// <param name="identifier">The identifier value.</param>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<long> GetTokenTransactionsCountAsync(string identifier, GetTokenTransactionsCountOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Token value transfers.</summary>
    /// <param name="identifier">The identifier value.</param>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<IReadOnlyList<Transaction>> GetTokenTransfersAsync(string identifier, GetTokenTransfersOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Account transfer count.</summary>
    /// <param name="identifier">The identifier value.</param>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<long> GetTokenTransfersCountAsync(string identifier, GetTokenTransfersCountOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Gets data from the MultiversX API..</summary>
    /// <param name="identifier">The identifier value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<MvxApiContent> GetTokenLogoPngAsync(string identifier, CancellationToken cancellationToken = default);

    /// <summary>Gets data from the MultiversX API..</summary>
    /// <param name="identifier">The identifier value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<MvxApiContent> GetTokenLogoSvgAsync(string identifier, CancellationToken cancellationToken = default);

}
