using Cloudito.Sdk.Services;
using Microsoft.Extensions.DependencyInjection;


namespace Cloudito.Sdk.Base;

public static class Config
{
    public static IServiceCollection AddClouditoBase(this IServiceCollection service, string httpClientName)
    {
        Settings.HttpClientName = httpClientName;
        service.AddScoped<IRest, Rest>();
        service.AddScoped<IBaseService, BaseService>();

        return service;
    }
}

internal class Settings
{
    public static string HttpClientName { get; set; } = "";
}