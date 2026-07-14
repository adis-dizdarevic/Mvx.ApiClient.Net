using Microsoft.Extensions.DependencyInjection;
using TUnit.Assertions;
using TUnit.Core;

namespace Mvx.ApiClient.Net.IntegrationTests;

[NotInParallel]
public class LiveApiSmokeTest
{
    private static readonly TimeSpan MinimumRequestInterval = TimeSpan.FromMilliseconds(600);
    private static DateTimeOffset _nextRequestAt;

    [Test]
    public async Task ClientComposition_WithoutNetworkCall_ResolvesCompleteRootClient()
    {
        var services = new ServiceCollection();
        await using var provider = services.AddMvxApiClient(NetworkType.Mainnet).BuildServiceProvider();

        var client = provider.GetRequiredService<IMvxApiClient>();

        await Assert.That(client.NetworkType).IsEqualTo(NetworkType.Mainnet);
        await Assert.That(client.Network).IsNotNull();
        await Assert.That(client.XExchange).IsNotNull();
    }

    [Test]
    public async Task MainnetTypedGetSurface_WhenLiveTestsEnabled_MatchesCurrentContracts()
    {
        if (!string.Equals(Environment.GetEnvironmentVariable("MVX_API_LIVE_TESTS"), "true", StringComparison.OrdinalIgnoreCase))
        {
            Skip.Test("Set MVX_API_LIVE_TESTS=true to run tests against the public API.");
            return;
        }

#if !NET10_0
        Skip.Test("Live API contracts run once under net10.0 to respect the public API rate limit.");
        return;
#else
        var services = new ServiceCollection();
        await using var provider = services.AddMvxApiClient(NetworkType.Mainnet).BuildServiceProvider();
        var client = provider.GetRequiredService<IMvxApiClient>();

        var stats = await ExecuteRateLimitedAsync(() => client.Network.GetStatsAsync());
        var economics = await ExecuteRateLimitedAsync(() => client.Network.GetEconomicsAsync());
        var constants = await ExecuteRateLimitedAsync(() => client.Network.GetConstantsAsync());
        var about = await ExecuteRateLimitedAsync(() => client.Network.GetAboutAsync());
        var exchangeEconomics = await ExecuteRateLimitedAsync(() => client.XExchange.GetEconomicsAsync());
        var pairs = await ExecuteRateLimitedAsync(() => client.XExchange.GetPairsAsync(
            new QueryOptions { Pagination = new Pagination { Limit = 1 } }));
        var pair = pairs.Single();
        var pairDetails = await ExecuteRateLimitedAsync(() => client.XExchange.GetPairAsync(pair.BaseId, pair.QuoteId));
        var pairsCount = await ExecuteRateLimitedAsync(() => client.XExchange.GetPairsCountAsync());
        var tokens = await ExecuteRateLimitedAsync(() => client.XExchange.GetTokensAsync(
            new QueryOptions { Pagination = new Pagination { Limit = 1 } }));
        var token = tokens.Single();
        var tokenDetails = await ExecuteRateLimitedAsync(() => client.XExchange.GetTokenAsync(token.Id));
        var tokensCount = await ExecuteRateLimitedAsync(() => client.XExchange.GetTokensCountAsync());
        var farms = await ExecuteRateLimitedAsync(() => client.XExchange.GetFarmsAsync(
            new QueryOptions { Pagination = new Pagination { Limit = 1 } }));
        var farmsCount = await ExecuteRateLimitedAsync(() => client.XExchange.GetFarmsCountAsync());

        await Assert.That(stats.Shards).IsGreaterThan(0);
        await Assert.That(stats.Blocks).IsGreaterThan(0);
        await Assert.That(economics.TotalSupply).IsGreaterThan(0);
        await Assert.That(constants.ChainId).IsNotEmpty();
        await Assert.That(about.Network).IsNotEmpty();
        await Assert.That(exchangeEconomics.TotalSupply).IsGreaterThan(0);
        await Assert.That(pairDetails.Address).IsNotEmpty();
        await Assert.That(pairsCount).IsGreaterThanOrEqualTo(1);
        await Assert.That(tokenDetails.Id).IsEqualTo(token.Id);
        await Assert.That(tokensCount).IsGreaterThanOrEqualTo(1);
        await Assert.That(farms).IsNotEmpty();
        await Assert.That(farmsCount).IsGreaterThanOrEqualTo(1);
#endif
    }

    private static async Task<T> ExecuteRateLimitedAsync<T>(Func<Task<T>> request)
    {
        var delay = _nextRequestAt - DateTimeOffset.UtcNow;
        if (delay > TimeSpan.Zero)
        {
            await Task.Delay(delay);
        }

        _nextRequestAt = DateTimeOffset.UtcNow + MinimumRequestInterval;

        return await request();
    }
}
