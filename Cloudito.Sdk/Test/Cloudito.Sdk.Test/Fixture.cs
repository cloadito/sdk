using Cloudito.Sdk.Base;
using Cloudito.Sdk.Base.Fluent.Config;
using Microsoft.Extensions.DependencyInjection;

namespace Cloudito.Sdk.Test;

public class TestFixture : IDisposable
{
    public ServiceProvider ServiceProvider { get; private set; }

    public TestFixture()
    {
        IServiceCollection services = new ServiceCollection();

        // Register your services and mocks here
        services.AddCloudito(
            "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIyYzNjODBmNy01OThhLTQ3NzUtYTJlZi1lZGJlNGZmMzllZWEiLCJuYW1lIjoi2qnZhNin2K_bjNiq2YgiLCJqdGkiOiJiY2ViNDFlZC1iNmRhLTRkMDYtYmJkOS1hYmIyNTBhZTAwNDYiLCJleHAiOjE3Nzc4MTMzNDMsImlzcyI6Imh0dHBzOi8vYXBpLmFwcC5jbG91ZGl0by5pciIsImF1ZCI6Imh0dHBzOi8vYXBpLmFwcC5jbG91ZGl0by5pciJ9.2lTLIXgCUqKoJBSdo73D0nIxuG4IffVJpZf88MWhTxM",
            "B2A8E6DBA8480A05C8FE033B9A4FF393A0E271A39AEFCECEBA78DB4FC7E512D6");
        services.AddClouditoBase("BaseName");

        services.AddFluentRest(builder =>
        {
            builder.AddNamedClient("auth",
                client =>
                {
                    client.BaseAddress = new Uri("http://10.0.2.38:800/");
                    client.Timeout = TimeSpan.FromSeconds(10);
                }
            );
            
            builder.AddNamedClient("auth2",
                client =>
                {
                    client.BaseAddress = new Uri("http://10.0.2.38:800/");
                    client.Timeout = TimeSpan.FromSeconds(10);
                }
            );
        });

        ServiceProvider = services.BuildServiceProvider();
    }

    public void Dispose()
    {
        // Clean up resources
        ServiceProvider.Dispose();
        GC.SuppressFinalize(this);
    }
}