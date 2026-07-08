using Microsoft.Extensions.DependencyInjection;
using TUnit.Assertions;

namespace Mvx.ApiClient.Net.IntegrationTests;

public class LiveApiSmokeTest
{
    [Test]
    public async Task MainnetNetworkStats_WhenLiveTestsEnabled_ReturnsStats()
    {
        if (!string.Equals(Environment.GetEnvironmentVariable("MVX_API_LIVE_TESTS"), "true", StringComparison.OrdinalIgnoreCase))
        {
            return;
        }

        var services = new ServiceCollection();
        await using var provider = services.AddMvxApiClient(NetworkType.Mainnet).BuildServiceProvider();
        var client = provider.GetRequiredService<IMvxApiClient>();

        var stats = await client.Network.GetStatsAsync();

        await Assert.That(stats.Shards).IsGreaterThan(0);
        await Assert.That(stats.Blocks).IsGreaterThan(0);
    }
}
