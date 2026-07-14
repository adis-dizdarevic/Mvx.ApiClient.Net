using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Mvx.ApiClient.Net.Infrastructure;
using Mvx.ApiClient.Net.Exceptions;
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
        await using var provider = services.AddMvxApiClient(options =>
        {
            options.Network = NetworkType.Mainnet;
            options.Timeout = TimeSpan.FromSeconds(20);
        }).BuildServiceProvider();

        var client = provider.GetRequiredService<IMvxApiClient>();

        await Assert.That(client.NetworkType).IsEqualTo(NetworkType.Mainnet);
        foreach (var property in typeof(IMvxApiClient).GetProperties().Where(property => property.Name != nameof(IMvxApiClient.NetworkType)))
        {
            await Assert.That(property.GetValue(client)).IsNotNull()
                .Because($"the complete root client must resolve its {property.Name} endpoint group");
        }
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
        await using var provider = services.AddMvxApiClient(options =>
        {
            options.Network = NetworkType.Mainnet;
            options.Timeout = TimeSpan.FromSeconds(20);
        }).BuildServiceProvider();
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
        var globalResults = await ValidateHandwrittenGlobalContractsAsync(provider);
        await ValidateHandwrittenDetailContractsAsync(provider, globalResults, pair, token);

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

    private static async Task<Dictionary<string, object?>> ValidateHandwrittenGlobalContractsAsync(IServiceProvider provider)
    {
        var results = new Dictionary<string, object?>(StringComparer.Ordinal);
        var methods = typeof(IMvxApiClient).Assembly.GetTypes()
            .Where(type => type.Namespace == "Mvx.ApiClient.Net.Clients")
            .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
                .Select(method => new { Type = type, Method = method, Operation = method.GetCustomAttribute<ApiOperationAttribute>() }))
            .Where(item => item.Operation is not null
                && !item.Operation.Path.Contains('{', StringComparison.Ordinal)
                // The upstream marketplace list currently hangs for size=1 and returns HTTP 500 for size=0.
                && item.Operation.Path is not ("/auctions" or "/auctions/count")
                && item.Operation.Path is not ("/stats" or "/economics" or "/constants" or "/about" or "/mex/economics" or "/mex/pairs" or "/mex/pairs/count" or "/mex/tokens" or "/mex/tokens/count" or "/mex/farms" or "/mex/farms/count"))
            .OrderBy(item => item.Operation!.Path, StringComparer.Ordinal)
            .ToArray();

        foreach (var item in methods)
        {
            var serviceType = item.Type.GetInterfaces().Single(type => type.Name.EndsWith("Client", StringComparison.Ordinal));
            var service = provider.GetRequiredService(serviceType);
            var arguments = item.Method.GetParameters().Select(CreateGlobalArgument).ToArray();

            await ExecuteRateLimitedAsync(async () =>
            {
                var task = item.Method.Invoke(service, arguments) as Task
                    ?? throw new InvalidOperationException($"{item.Method} did not return a Task.");
                await task;
                results[item.Operation!.Path] = task.GetType().GetProperty("Result")?.GetValue(task);
                return true;
            });
        }

        return results;
    }

    private static async Task ValidateHandwrittenDetailContractsAsync(
        IServiceProvider provider,
        IReadOnlyDictionary<string, object?> globalResults,
        Models.XExchange.XExchangePairDto exchangePair,
        Models.XExchange.XExchangeTokenDto exchangeToken)
    {
        var skippedPrefixes = new[]
        {
            "/auctions/", "/accounts/{address}/auction", "/accounts/{address}/auctions",
            "/collections/{collection}/auction", "/collections/{collection}/auctions"
        };
        var nftIdentifier = StringProperty(FirstRequired(globalResults, "/nfts"), "Identifier");
        var nftOwners = await ExecuteRateLimitedAsync(() => provider.GetRequiredService<INftClient>().GetNftAccountsAsync(
            nftIdentifier,
            new Mvx.ApiClient.Net.Requests.Nfts.GetNftAccountsOptions { Pagination = new Pagination { Limit = 1 } }));
        var nftHolder = nftOwners.FirstOrDefault()?.Address
            ?? throw new InvalidOperationException($"Could not derive a holder for NFT {nftIdentifier}.");
        var methods = typeof(IMvxApiClient).Assembly.GetTypes()
            .Where(type => type.Namespace == "Mvx.ApiClient.Net.Clients")
            .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
                .Select(method => new { Type = type, Method = method, Operation = method.GetCustomAttribute<ApiOperationAttribute>() }))
            .Where(item => item.Operation is not null
                && item.Operation.Path.Contains('{', StringComparison.Ordinal)
                && item.Operation.Path != "/batch/{address}/{id}"
                && skippedPrefixes.All(prefix => !item.Operation.Path.StartsWith(prefix, StringComparison.Ordinal)))
            .OrderBy(item => item.Operation!.Path, StringComparer.Ordinal)
            .ToArray();

        var failures = new List<string>();
        foreach (var item in methods)
        {
            if (item.Operation!.Path == "/pool/{txhash}" && First(globalResults, "/pool") is null)
            {
                continue;
            }

            var serviceType = item.Type.GetInterfaces().Single(type => type.Name.EndsWith("Client", StringComparison.Ordinal));
            var service = provider.GetRequiredService(serviceType);
            object?[] arguments;
            try
            {
                arguments = item.Method.GetParameters()
                    .Select(parameter => CreateDetailArgument(parameter, item.Operation.Path, globalResults, exchangePair, exchangeToken, nftHolder))
                    .ToArray();
            }
            catch (InvalidOperationException exception)
            {
                failures.Add($"{item.Operation.Path}: seed error: {exception.Message}");
                continue;
            }

            try
            {
                await ExecuteRateLimitedAsync(async () =>
                {
                    var task = item.Method.Invoke(service, arguments) as Task
                        ?? throw new InvalidOperationException($"{item.Method} did not return a Task.");
                    await task;
                    return true;
                });
            }
            catch (MvxApiException exception) when (exception.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                if (item.Operation.Path is not ("/accounts/{address}/verification" or "/collections/{collection}/ranks" or "/pool/{txhash}"))
                {
                    failures.Add($"{item.Operation.Path}: live seed did not identify an existing resource");
                }
            }
            catch (Exception exception)
            {
                failures.Add($"{item.Operation.Path}: {exception.GetType().Name}: {exception.Message}");
            }
        }

        if (failures.Count != 0)
        {
            throw new InvalidOperationException("Parameterized live contract failures:" + Environment.NewLine + string.Join(Environment.NewLine, failures));
        }
    }

    private static object? CreateDetailArgument(
        ParameterInfo parameter,
        string path,
        IReadOnlyDictionary<string, object?> globalResults,
        Models.XExchange.XExchangePairDto exchangePair,
        Models.XExchange.XExchangeTokenDto exchangeToken,
        string nftHolder)
    {
        if (parameter.ParameterType == typeof(CancellationToken))
        {
            return CancellationToken.None;
        }

        if (parameter.HasDefaultValue)
        {
            return null;
        }

        if (parameter.ParameterType == typeof(bool))
        {
            return true;
        }

        if (parameter.ParameterType == typeof(long))
        {
            return parameter.Name switch
            {
                "shardId" => 0L,
                "shard" => Convert.ToInt64(Property(FirstRequired(globalResults, "/rounds"), "Shard") ?? 0),
                "round" => Convert.ToInt64(Property(FirstRequired(globalResults, "/rounds"), "RoundValue") ?? 0),
                _ => 1L
            };
        }

        if (parameter.ParameterType != typeof(string))
        {
            return Activator.CreateInstance(parameter.ParameterType);
        }

        return parameter.Name switch
        {
            "address" when path == "/providers/{address}/avatar" => StringProperty(FirstWithString(globalResults, "/providers", "Identity"), "ProviderValue"),
            "address" when path.StartsWith("/providers/", StringComparison.Ordinal) => StringProperty(FirstRequired(globalResults, "/providers"), "ProviderValue"),
            "address" when path.StartsWith("/applications/", StringComparison.Ordinal) => StringProperty(FirstRequired(globalResults, "/applications"), "Contract"),
            "address" when path.Contains("/collections", StringComparison.Ordinal) => StringProperty(FirstRequired(globalResults, "/collections"), "Owner"),
            "address" when path.Contains("/nfts", StringComparison.Ordinal) => nftHolder,
            "address" when path.Contains("/results", StringComparison.Ordinal) => StringProperty(FirstRequired(globalResults, "/results"), "Sender"),
            "address" when path.Contains("/tokens", StringComparison.Ordinal) => StringProperty(FirstRequired(globalResults, "/tokens"), "Owner"),
            "address" when path.EndsWith("/upgrades", StringComparison.Ordinal) || path.EndsWith("/verification", StringComparison.Ordinal) => StringProperty(FirstRequired(globalResults, "/applications"), "Contract"),
            "address" when path.Contains("/roles/tokens/", StringComparison.Ordinal) => StringProperty(FirstRequired(globalResults, "/tokens"), "Owner"),
            "address" when path.Contains("/roles/collections/", StringComparison.Ordinal) => StringProperty(FirstRequired(globalResults, "/collections"), "Owner"),
            "address" => StringProperty(FirstRequired(globalResults, "/accounts"), "Address"),
            "identifier" when path.StartsWith("/identities/", StringComparison.Ordinal) => StringProperty(FirstRequired(globalResults, "/identities"), "IdentityValue"),
            "identifier" when path.StartsWith("/nfts/", StringComparison.Ordinal) => StringProperty(FirstRequired(globalResults, "/nfts"), "Identifier"),
            "identifier" when path.StartsWith("/mex/", StringComparison.Ordinal) => exchangeToken.Id,
            "identifier" => StringProperty(FirstRequired(globalResults, "/tokens"), "Identifier"),
            "collection" => StringProperty(FirstRequired(globalResults, "/collections"), "Collection"),
            "nft" => StringProperty(FirstRequired(globalResults, "/nfts"), "Identifier"),
            "token" or "tokenIdentifier" => StringProperty(FirstRequired(globalResults, "/tokens"), "Identifier"),
            "baseId" => exchangePair.BaseId,
            "quoteId" => exchangePair.QuoteId,
            "hash" => StringProperty(FirstRequired(globalResults, "/blocks"), "Hash"),
            "miniBlockHash" => StringProperty(FirstRequired(globalResults, "/miniblocks"), "MiniBlockHash"),
            "txHash" => StringProperty(FirstRequired(globalResults, path.StartsWith("/events/", StringComparison.Ordinal) ? "/events" : "/transactions"), "TxHash"),
            "txhash" => StringProperty(FirstRequired(globalResults, "/pool"), "TxHash"),
            "scHash" => StringProperty(FirstRequired(globalResults, "/results"), "Hash"),
            "bls" or "key" => StringProperty(FirstRequired(globalResults, "/nodes"), "Bls"),
            "tag" => StringProperty(FirstRequired(globalResults, "/tags"), "TagValue"),
            "username" => "alice",
            _ => throw new InvalidOperationException($"No live seed is defined for {path} parameter {parameter.Name}.")
        };
    }

    private static object FirstRequired(IReadOnlyDictionary<string, object?> results, string path)
    {
        return First(results, path) ?? throw new InvalidOperationException($"{path} returned no seed item.");
    }

    private static object? First(IReadOnlyDictionary<string, object?> results, string path)
    {
        if (!results.TryGetValue(path, out var value) || value is not System.Collections.IEnumerable enumerable)
        {
            return null;
        }

        return enumerable.Cast<object>().FirstOrDefault();
    }

    private static object FirstWithString(IReadOnlyDictionary<string, object?> results, string path, string propertyName)
    {
        if (!results.TryGetValue(path, out var value) || value is not System.Collections.IEnumerable enumerable)
        {
            throw new InvalidOperationException($"{path} returned no seed collection.");
        }

        return enumerable.Cast<object>().FirstOrDefault(item => Property(item, propertyName) is string text && !string.IsNullOrWhiteSpace(text))
            ?? throw new InvalidOperationException($"{path} returned no item with {propertyName}.");
    }

    private static object? Property(object value, string name) => value.GetType().GetProperty(name)?.GetValue(value);

    private static string StringProperty(object value, string name)
    {
        return Property(value, name) as string
            ?? throw new InvalidOperationException($"{value.GetType().Name}.{name} did not contain a string seed.");
    }

    private static object? CreateGlobalArgument(ParameterInfo parameter)
    {
        if (parameter.ParameterType == typeof(CancellationToken))
        {
            return CancellationToken.None;
        }

        var options = Activator.CreateInstance(parameter.ParameterType)
            ?? throw new InvalidOperationException($"Could not create {parameter.ParameterType}.");
        var pagination = parameter.ParameterType.GetProperty("Pagination");
        pagination?.SetValue(options, new Pagination { Limit = 1 });
        var size = parameter.ParameterType.GetProperty("Size");
        size?.SetValue(options, 1L);

        return options;
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
