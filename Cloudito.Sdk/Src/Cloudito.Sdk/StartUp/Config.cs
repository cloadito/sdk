using Cloudito.Sdk.Finders;
using Cloudito.Sdk.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Cloudito.Sdk;

public static class ClouditoSdkConfig
{
    public static IServiceCollection AddCloudito(this IServiceCollection services, string apiKey)
    {
        Settings.ApiKey = apiKey;

        // Common
        services.AddHttpClient(Constants.HttpClientName, client =>
        {
            client.BaseAddress = new Uri(Constants.ServerAddress);
            client.DefaultRequestHeaders.Add(Constants.HeaderKey, apiKey);
        });
        services.AddScoped<IRest, Rest>();

        // Identity
        services.AddScoped<IUserFinder, UserFinder>();
        services.AddScoped<IAuth, Auth>();

        return services;
    }
}