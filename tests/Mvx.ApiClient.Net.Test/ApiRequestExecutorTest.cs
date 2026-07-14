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

    [Test]
    public async Task BuildRequestUri_WithLimitAboveApiMaximum_ThrowsArgumentOutOfRangeException()
    {
        var options = new QueryOptions { Pagination = new Pagination { Limit = Pagination.MaximumLimit + 1 } };

        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => ApiRequestExecutor.BuildRequestUri(BaseAddress, "accounts", options));

        await Assert.That(exception.Message).Contains($"Pagination limit cannot exceed {Pagination.MaximumLimit}.");
    }

    [Test]
    public async Task BuildRequestUri_WithEverySupportedValueKind_FormatsAndEscapesValues()
    {
        var parameters = new QueryParameters()
            .AddString("search", "Alice & Bob")
            .AddBoolean("withAssets", true)
            .AddBoolean("includeFlagged", false)
            .AddNumber("price", 12.50m)
            .AddCollection("identifiers", ["TOKEN-1", "TOKEN/2"]);

        var result = ApiRequestExecutor.BuildRequestUri(BaseAddress, "accounts", parameters);

        await Assert.That(result.PathAndQuery).IsEqualTo(
            "/accounts?search=Alice%20%26%20Bob&withAssets=true&includeFlagged=false&price=12.50&identifiers=TOKEN-1%2CTOKEN%2F2");
    }

    [Test]
    public async Task BuildRequestUri_WithRepeatedCollection_PreservesDuplicateQueryKeys()
    {
        var parameters = new QueryParameters()
            .AddCollection("status", ["success", "pending"], QueryCollectionFormat.Repeated);

        var result = ApiRequestExecutor.BuildRequestUri(BaseAddress, "transactions", parameters);

        await Assert.That(result.PathAndQuery).IsEqualTo("/transactions?status=success&status=pending");
    }

    [Test]
    public async Task BuildRequestUri_WithExistingQuery_AppendsParameters()
    {
        var parameters = new QueryParameters().AddString("search", "alice");

        var result = ApiRequestExecutor.BuildRequestUri(BaseAddress, "accounts?withAssets=true", parameters);

        await Assert.That(result.PathAndQuery).IsEqualTo("/accounts?withAssets=true&search=alice");
    }
}
