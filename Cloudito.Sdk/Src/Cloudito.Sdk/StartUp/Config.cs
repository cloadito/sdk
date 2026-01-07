using Cloudito.Sdk.Finders;
using Microsoft.Extensions.DependencyInjection;

namespace Cloudito.Sdk;

public static class ClouditoSdkConfig
{
    public static IServiceCollection AddCloudito(this IServiceCollection services, string apiKey,
        string? serviceKey = null,TimeSpan? timeOut = null)
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

            if(timeOut is not null)
                client.Timeout = (TimeSpan)timeOut;
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
        services.AddScoped<ICategory, CategoryService>();
        services.AddScoped<IShopStatus, ShopStatusService>();
        services.AddScoped<IShopType, ShopTypeService>();
        services.AddScoped<ITag, TagService>();
        services.AddScoped<IProductType, ProductTypeService>();

        // Notif
        services.AddScoped<INotifGroup, NotifGroupService>();
        services.AddScoped<INotification, NotificationService>();
        services.AddScoped<INotifProvider, NotifProviderService>();
    }
}