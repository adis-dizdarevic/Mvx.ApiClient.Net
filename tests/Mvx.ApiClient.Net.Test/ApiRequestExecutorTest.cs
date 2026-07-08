using Mvx.ApiClient.Net.Infrastructure;
using TUnit.Assertions;

namespace Mvx.ApiClient.Net.Test;

public class ApiRequestExecutorTest
{
    private const string BaseAddress = "https://api.multiversx.com";
    private const string RequestUri = "/accounts";

    [Test]
    public async Task BuildRequestUri_QueryOptionsIsNull_UseDefaultValues()
    {
        var result = ApiRequestExecutor.BuildRequestUri(new Uri(BaseAddress), RequestUri);

        await Assert.That(result).IsEqualTo(new Uri("https://api.multiversx.com/accounts"));
    }

    [Test]
    public async Task BuildRequestUri_QueryOptionsNewInstanceWithoutSettingsValues_UseDefaultValues()
    {
        var data = new DataSelection();

        var result = ApiRequestExecutor.BuildRequestUri(new Uri(BaseAddress), RequestUri, new QueryOptions { Data = data });

        await Assert.That(result).IsEqualTo(new Uri("https://api.multiversx.com/accounts"));
    }

    [Test]
    public async Task BuildRequestUri_QueryOptionsWithLimitAndOffset_ReturnsExpectedUri()
    {
        var pagination = new Pagination { Limit = 15, Offset = 0 };

        var result = ApiRequestExecutor.BuildRequestUri(new Uri(BaseAddress), RequestUri, new QueryOptions { Pagination = pagination });

        await Assert.That(result).IsEqualTo(new Uri("https://api.multiversx.com/accounts?size=15&from=0"));
    }

    [Test]
    public async Task BuildRequestUri_QueryOptionsWithOneField_ReturnsExpectedUri()
    {
        var data = new DataSelection { Fields = ["balance"] };

        var result = ApiRequestExecutor.BuildRequestUri(new Uri(BaseAddress), RequestUri, new QueryOptions { Data = data });

        await Assert.That(result).IsEqualTo(new Uri("https://api.multiversx.com/accounts?fields=balance"));
    }

    [Test]
    public async Task BuildRequestUri_QueryOptionsWithThreeFields_ReturnsExpectedUri()
    {
        var data = new DataSelection { Fields = ["balance", "address", "price"] };

        var result = ApiRequestExecutor.BuildRequestUri(new Uri(BaseAddress), RequestUri, new QueryOptions { Data = data });

        await Assert.That(result).IsEqualTo(new Uri("https://api.multiversx.com/accounts?fields=balance%2Caddress%2Cprice"));
    }

    [Test]
    public async Task BuildRequestUri_QueryOptionsWithScalarValue_ReturnsExpectedUri()
    {
        var data = new DataSelection { Extract = "price/usd" };

        var result = ApiRequestExecutor.BuildRequestUri(new Uri(BaseAddress), RequestUri, new QueryOptions { Data = data });

        await Assert.That(result).IsEqualTo(new Uri("https://api.multiversx.com/accounts?extract=price%2Fusd"));
    }

    [Test]
    public async Task BuildRequestUri_QueryOptionsWithAllPropertiesSet_ReturnsExpectedUri()
    {
        var options = new QueryOptions
        {
            Pagination = new Pagination { Limit = 100, Offset = 25 },
            Data = new DataSelection { Fields = ["balance", "address", "price"], Extract = "amount value" }
        };

        var result = ApiRequestExecutor.BuildRequestUri(new Uri(BaseAddress), RequestUri, options);

        await Assert.That(result).IsEqualTo(new Uri("https://api.multiversx.com/accounts?size=100&from=25&fields=balance%2Caddress%2Cprice&extract=amount%20value"));
    }

    [Test]
    public async Task BuildRequestUri_EmptyFieldsList_DoesNotAddFieldsToUri()
    {
        var data = new DataSelection { Fields = [] };

        var result = ApiRequestExecutor.BuildRequestUri(new Uri(BaseAddress), RequestUri, new QueryOptions { Data = data });

        await Assert.That(result).IsEqualTo(new Uri("https://api.multiversx.com/accounts"));
    }

    [Test]
    public async Task BuildRequestUri_EmptyExtractString_DoesNotAddExtractToUri()
    {
        var data = new DataSelection { Extract = "" };

        var result = ApiRequestExecutor.BuildRequestUri(new Uri(BaseAddress), RequestUri, new QueryOptions { Data = data });

        await Assert.That(result).IsEqualTo(new Uri("https://api.multiversx.com/accounts"));
    }

    [Test]
    public async Task BuildRequestUri_NegativePagination_ThrowsArgumentOutOfRangeException()
    {
        var options = new QueryOptions { Pagination = new Pagination { Limit = -1 } };

        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => ApiRequestExecutor.BuildRequestUri(new Uri(BaseAddress), RequestUri, options));

        await Assert.That(exception.Message).Contains("Pagination limit cannot be negative.");
    }

    [Test]
    public async Task BuildRequestUri_EmptyFieldName_ThrowsArgumentException()
    {
        var options = new QueryOptions { Data = new DataSelection { Fields = ["id", ""] } };

        var exception = Assert.Throws<ArgumentException>(() => ApiRequestExecutor.BuildRequestUri(new Uri(BaseAddress), RequestUri, options));

        await Assert.That(exception.Message).Contains("Field names cannot be empty.");
    }
}
