using Microsoft.Extensions.DependencyInjection;

namespace Cloudito.Sdk.Test;

public class TestFixture : IDisposable
{
    public ServiceProvider ServiceProvider { get; private set; }

    public TestFixture()
    {
        IServiceCollection services = new ServiceCollection();

        // Register your services and mocks here
        services.AddCloudito("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIyYzNjODBmNy01OThhLTQ3NzUtYTJlZi1lZGJlNGZmMzllZWEiLCJuYW1lIjoi2qnZhNin2K_bjNiq2YgiLCJqdGkiOiJiY2ViNDFlZC1iNmRhLTRkMDYtYmJkOS1hYmIyNTBhZTAwNDYiLCJleHAiOjE3Nzc4MTMzNDMsImlzcyI6Imh0dHBzOi8vYXBpLmFwcC5jbG91ZGl0by5pciIsImF1ZCI6Imh0dHBzOi8vYXBpLmFwcC5jbG91ZGl0by5pciJ9.2lTLIXgCUqKoJBSdo73D0nIxuG4IffVJpZf88MWhTxM");

        ServiceProvider = services.BuildServiceProvider();
    }

    public void Dispose()
    {
        // Clean up resources
        ServiceProvider.Dispose();
        GC.SuppressFinalize(this);
    }
}