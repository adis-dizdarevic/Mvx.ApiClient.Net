using Mvx.ApiClient.Net.Dtos;
using Mvx.ApiClient.Net.ExtensionMethods;
using TUnit.Assertions;

namespace Mvx.ApiClient.Net.Test;

public class HttpClientExtensionsTest
{
    private const string BaseAddress = "https://api.multivers.com";
    private const string RequestPath = "/MyRequestPath";
    private const string RequestUri = BaseAddress + RequestPath;

    [Test]
    public async Task BuildRequestUri_QueryParametersDtoIsNull_UseDefaultValues()
    {
        // arrange
        var expectedRequestUri = new Uri(RequestUri);

        // act
        var result = HttpClientExtensions.BuildRequestUri(new Uri(BaseAddress), RequestUri);

        // assert
        await Assert.That(result).IsEqualTo(expectedRequestUri);
    }

    [Test]
    public async Task BuildRequestUri_QueryParametersDtoNewInstanceWithoutSettingsValues_UseDefaultValues()
    {
        // arrange
        var expectedRequestUri = new Uri(RequestUri);
        var data = new DataSelectionDto();

        // act
        var result = HttpClientExtensions.BuildRequestUri(new Uri(BaseAddress), RequestUri, new QueryParametersDto { Data = data });

        // assert
        await Assert.That(result).IsEqualTo(expectedRequestUri);
    }

    [Test]
    public async Task BuildRequestUri_QueryParametersDtoWithLimitAndOffset_ReturnsExpectedUri()
    {
        // arrange
        var expectedRequestUri = new Uri($"{RequestUri}?size=15&from=0");
        var pagination = new PaginationParametersDto { Limit = 15, Offset = 0 };

        // act
        var result = HttpClientExtensions.BuildRequestUri(new Uri(BaseAddress), RequestUri, new QueryParametersDto { Pagination = pagination });

        // assert
        await Assert.That(result).IsEqualTo(expectedRequestUri);
    }

    [Test]
    public async Task BuildRequestUri_QueryParametersDtoWithOneField_ReturnsExpectedUri()
    {
        // arrange
        var expectedRequestUri = new Uri($"{RequestUri}?fields=balance");
        var data = new DataSelectionDto { Fields = ["balance"] };

        // act
        var result = HttpClientExtensions.BuildRequestUri(new Uri(BaseAddress), RequestUri, new QueryParametersDto { Data = data });

        // assert
        await Assert.That(result).IsEqualTo(expectedRequestUri);
    }

    [Test]
    public async Task BuildRequestUri_QueryParametersDtoWithThreeFields_ReturnsExpectedUri()
    {
        // arrange
        var expectedRequestUri = new Uri($"{RequestUri}?fields=balance,address,price");
        var data = new DataSelectionDto { Fields = ["balance", "address", "price"] };

        // act
        var result = HttpClientExtensions.BuildRequestUri(new Uri(BaseAddress), RequestUri, new QueryParametersDto { Data = data });

        // assert
        await Assert.That(result).IsEqualTo(expectedRequestUri);
    }

    [Test]
    public async Task BuildRequestUri_QueryParametersDtoWithScalarValue_ReturnsExpectedUri()
    {
        // arrange
        var expectedRequestUri = new Uri($"{RequestUri}?extract=price");
        var data = new DataSelectionDto { Extract = "price" };

        // act
        var result = HttpClientExtensions.BuildRequestUri(new Uri(BaseAddress), RequestUri, new QueryParametersDto { Data = data });

        // assert
        await Assert.That(result).IsEqualTo(expectedRequestUri);
    }

    [Test]
    public async Task BuildRequestUri_QueryParametersDtoWithAllPropertiesSet_ReturnsExpectedUri()
    {
        // arrange
        var expectedRequestUri = new Uri($"{RequestUri}?size=100&from=25&fields=balance,address,price&extract=amount");
        var dto = new QueryParametersDto
        {
            Pagination = new PaginationParametersDto { Limit = 100, Offset = 25 },
            Data = new DataSelectionDto { Fields = ["balance", "address", "price"], Extract = "amount" }
        };

        // act
        var result = HttpClientExtensions.BuildRequestUri(new Uri(BaseAddress), RequestUri, dto);

        // assert
        await Assert.That(result).IsEqualTo(expectedRequestUri);
    }

    [Test]
    public async Task BuildRequestUri_EmptyFieldsList_DoesNotAddFieldsToUri()
    {
        // arrange
        var expectedRequestUri = new Uri(RequestUri);
        var data = new DataSelectionDto { Fields = [] };

        // act
        var result = HttpClientExtensions.BuildRequestUri(new Uri(BaseAddress), RequestUri, new QueryParametersDto { Data = data });

        // assert
        await Assert.That(result).IsEqualTo(expectedRequestUri);
    }

    [Test]
    public async Task BuildRequestUri_EmptyExtractString_DoesNotAddExtractToUri()
    {
        // arrange
        var expectedRequestUri = new Uri(RequestUri);
        var data = new DataSelectionDto { Extract = "" };

        // act
        var result = HttpClientExtensions.BuildRequestUri(new Uri(BaseAddress), RequestUri, new QueryParametersDto { Data = data });

        // assert
        await Assert.That(result).IsEqualTo(expectedRequestUri);
    }
}
