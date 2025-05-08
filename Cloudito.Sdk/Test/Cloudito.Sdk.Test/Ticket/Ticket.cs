using Cloudito.Sdk.Services;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Abstractions;

namespace Cloudito.Sdk.Test;

internal class TicketTest(TestFixture fixture, ITestOutputHelper outputHelper) : IClassFixture<TestFixture>
{
    private readonly ITicket _ticket = fixture.ServiceProvider.GetRequiredService<ITicket>();
}
