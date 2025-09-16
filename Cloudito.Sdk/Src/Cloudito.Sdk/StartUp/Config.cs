using Cloudito.Sdk.Finders;
using Cloudito.Sdk.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Cloudito.Sdk;

public static class ClouditoSdkConfig
{
    public static IServiceCollection AddCloudito(this IServiceCollection services, string apiKey,
        string? serviceKey = null)
    {
        Settings.ApiKey = apiKey;
        Settings.ServiceKey = serviceKey;

        // Common
        services.AddHttpClient(Constants.HttpClientName, client =>
        {
            client.BaseAddress = new Uri(Constants.ServerAddress);
            client.DefaultRequestHeaders.Add(Constants.HeaderKey, apiKey);
            if (!string.IsNullOrEmpty(serviceKey))
                client.DefaultRequestHeaders.Add(Constants.ServiceHeaderKey, serviceKey);
        });

        services.AddServices();
        return services;
    }

    static void AddServices(this IServiceCollection services)
    {
        services.AddClouditoBase(Constants.HttpClientName);

        // Identity
        services.AddScoped<IUserFinder, UserFinder>();
        services.AddScoped<IAuth, Auth>();
        services.AddScoped<IUser, UserService>();

        //Wallet
        services.AddScoped<IWallet, WalletService>();

        // App
        services.AddScoped<IAppFinder, AppFinder>();
        services.AddScoped<IApplication, ApplicationService>();

        // Ticket
        services.AddScoped<ITicket, TicketService>();

        // Shop
        services.AddScoped<IShop, ShopService>();
        services.AddScoped<IProduct, ProductService>();

        // Notif
        services.AddScoped<INotifGroup, NotifGroupService>();
        services.AddScoped<INotification, NotificationService>();
        services.AddScoped<INotifProvider, NotifProviderService>();
    }
}