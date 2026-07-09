using Mvx.ApiClient.Net.Infrastructure;
using TUnit.Assertions;

namespace Mvx.ApiClient.Net.Test;

public class ApiRequestExecutorTest
{
    private static readonly Uri BaseAddress = new("https://api.multiversx.com/");

    [Test]
    public async Task BuildRequestUri_WithoutOptions_ReturnsEndpointUri()
    {
        var result = ApiRequestExecutor.BuildRequestUri(BaseAddress, "accounts");

        await Assert.That(result).IsEqualTo(new Uri("https://api.multiversx.com/accounts"));
    }

    [Test]
    public async Task BuildRequestUri_WithPagination_ReturnsExpectedUri()
    {
        var result = ApiRequestExecutor.BuildRequestUri(
            BaseAddress,
            "accounts",
            new QueryOptions { Pagination = new Pagination { Limit = 15, Offset = 0 } });

        await Assert.That(result).IsEqualTo(new Uri("https://api.multiversx.com/accounts?size=15&from=0"));
    }

    [Test]
    public async Task BuildRequestUri_WithNegativePagination_ThrowsArgumentOutOfRangeException()
    {
        var options = new QueryOptions { Pagination = new Pagination { Limit = -1 } };

        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => ApiRequestExecutor.BuildRequestUri(BaseAddress, "accounts", options));

        await Assert.That(exception.Message).Contains("Pagination limit cannot be negative.");
    }
}
