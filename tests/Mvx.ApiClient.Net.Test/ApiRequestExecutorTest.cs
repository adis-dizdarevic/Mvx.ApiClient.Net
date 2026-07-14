using Mvx.ApiClient.Net.Infrastructure;
using System.Net;
using System.Net.Http.Headers;
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

    [Test]
    [Arguments("/accounts")]
    [Arguments("https://malicious.example/accounts")]
    [Arguments("../accounts")]
    [Arguments("accounts#fragment")]
    public async Task BuildRequestUri_WithUnsafeRequestPath_ThrowsArgumentException(string requestPath)
    {
        var exception = Assert.Throws<ArgumentException>(() => ApiRequestExecutor.BuildRequestUri(BaseAddress, requestPath));

        await Assert.That(exception.ParamName).IsEqualTo("requestPath");
    }

    [Test]
    public async Task BuildRequestUri_WithCustomBasePath_PreservesProxyPrefix()
    {
        var result = ApiRequestExecutor.BuildRequestUri(new Uri("https://example.com/proxy/api/"), "accounts");

        await Assert.That(result).IsEqualTo(new Uri("https://example.com/proxy/api/accounts"));
    }

    [Test]
    public async Task GetStringAsync_TextResponse_ReturnsCompleteBody()
    {
        var handler = new TestHttpMessageHandler(_ => TestHttpMessageHandler.TextResponse("hello MultiversX", HttpStatusCode.OK));
        var executor = CreateExecutor(handler);

        var result = await executor.GetStringAsync("hello");

        await Assert.That(result).IsEqualTo("hello MultiversX");
        await Assert.That(handler.Requests.Single().Uri.PathAndQuery).IsEqualTo("/hello");
    }

    [Test]
    public async Task GetContentAsync_BinaryResponse_PreservesBodyAndMetadata()
    {
        var expected = new byte[] { 0x89, 0x50, 0x4E, 0x47 };
        var handler = new TestHttpMessageHandler(_ =>
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(expected)
            };
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("inline")
            {
                FileName = "token.png"
            };

            return response;
        });
        var executor = CreateExecutor(handler);

        var result = await executor.GetContentAsync("tokens/TOKEN-123/logo/png");

        await Assert.That(result.Content.ToArray()).IsEquivalentTo(expected);
        await Assert.That(result.MediaType).IsEqualTo("image/png");
        await Assert.That(result.FileName).IsEqualTo("token.png");
    }

    [Test]
    public async Task GetJsonAsync_JsonResponse_DeserializesUsingSharedPipeline()
    {
        var handler = new TestHttpMessageHandler(_ => TestHttpMessageHandler.JsonResponse("""
            { "value": "ready" }
            """));
        var executor = CreateExecutor(handler);

        var result = await executor.GetJsonAsync<TestResponse>("test");

        await Assert.That(result.Value).IsEqualTo("ready");
    }

    [Test]
    public async Task GetJsonAsync_NonSuccessWithoutRegisteredErrorHandler_ThrowsHttpRequestException()
    {
        var handler = new TestHttpMessageHandler(_ => TestHttpMessageHandler.JsonResponse("{}", HttpStatusCode.BadGateway));
        var executor = CreateExecutor(handler);

        var exception = await CaptureHttpRequestException(() => executor.GetJsonAsync<TestResponse>("test"));

        await Assert.That(exception.StatusCode).IsEqualTo(HttpStatusCode.BadGateway);
    }

    [Test]
    public async Task GetJsonAsync_NullJsonResponse_ThrowsClearHttpRequestException()
    {
        var handler = new TestHttpMessageHandler(_ => TestHttpMessageHandler.JsonResponse("null"));
        var executor = CreateExecutor(handler);

        var exception = await CaptureHttpRequestException(() => executor.GetJsonAsync<TestResponse>("test"));

        await Assert.That(exception.Message).Contains(typeof(TestResponse).ToString());
    }

    private static ApiRequestExecutor CreateExecutor(HttpMessageHandler handler)
    {
        return new ApiRequestExecutor(new HttpClient(handler)
        {
            BaseAddress = BaseAddress
        });
    }

    private static async Task<HttpRequestException> CaptureHttpRequestException(Func<Task> action)
    {
        try
        {
            await action();
        }
        catch (HttpRequestException exception)
        {
            return exception;
        }

        throw new InvalidOperationException("Expected HttpRequestException was not thrown.");
    }

    private sealed record TestResponse(string Value);
}
