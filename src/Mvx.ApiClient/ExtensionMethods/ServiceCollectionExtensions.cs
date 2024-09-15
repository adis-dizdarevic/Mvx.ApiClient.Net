using Microsoft.Extensions.DependencyInjection;
using Mvx.ApiClient.Interfaces;
using Mvx.ApiClient.Services;

namespace Mvx.ApiClient.ExtensionMethods;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMvxApiClient(this IServiceCollection services)
    {
        services.AddTransient<INetworkService, NetworkService>();

        return services;
    }
}
