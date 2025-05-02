using Microsoft.Extensions.DependencyInjection;

namespace Cloudito.Sdk;

public static class ClouditoSdkConfig
{
    public static IServiceCollection AddCloudito(this IServiceCollection services, string apiKey)
    {
        Settings.ApiKey = apiKey;



        return services;
    }
}