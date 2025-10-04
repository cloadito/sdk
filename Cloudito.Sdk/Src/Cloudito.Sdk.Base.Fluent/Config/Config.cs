using Cloudito.Sdk.Base.Fluent.Builder;
using Cloudito.Sdk.Base.Fluent.Provider;
using Cloudito.Sdk.Base.Fluent.Rest;
using Microsoft.Extensions.DependencyInjection;

namespace Cloudito.Sdk.Base.Fluent.Config;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddFluentRest(this IServiceCollection services,
        Action<IServiceCollectionFluentBuilder> configure)
    {
        var builder = new ServiceCollectionFluentBuilder(services);
        configure(builder);
        return services;
    }
}

public interface IServiceCollectionFluentBuilder
{
    IServiceCollection AddNamedClient(string name, Action<HttpClient> configureClient, FluentRestConfig? config = null);
}

public class ServiceCollectionFluentBuilder(IServiceCollection services) : IServiceCollectionFluentBuilder
{
    public IServiceCollection AddNamedClient(string name, Action<HttpClient> configureClient,
        FluentRestConfig? config = null)
    {
        // 1️⃣ Register the named HttpClient
        services.AddHttpClient(name, configureClient);

        // 2️⃣ Register the RestClient as a singleton
        services.AddSingleton<NamedRestClient>(sp =>
        {
            var factory = sp.GetRequiredService<IHttpClientFactory>();
            var client = new RestClient(factory, name, config);

            return new NamedRestClient(name, client);
        });
        
        services.AddSingleton<IBaseService>(sp =>
        {
            var factory = sp.GetRequiredService<IHttpClientFactory>();
            var client = new RestClient(factory, name, config);
            return new BaseService(client);
        });

        // 3️⃣ Register the provider once (only if not already registered)
        if (services.All(s => s.ServiceType != typeof(IRestClientProvider)))
        {
            services.AddSingleton<IRestClientProvider>(sp =>
            {
                var clients = sp.GetServices<NamedRestClient>();
                return new RestClientProvider(clients);
            });
        }

        return services;
    }
}