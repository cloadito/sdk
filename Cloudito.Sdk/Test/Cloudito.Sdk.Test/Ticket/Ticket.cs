using Cloudito.Sdk.Services;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Abstractions;

namespace Cloudito.Sdk.Test;

public class TicketTest(TestFixture fixture, ITestOutputHelper outputHelper) : IClassFixture<TestFixture>
{
    private readonly ITicket _ticket = fixture.ServiceProvider.GetRequiredService<ITicket>();

    [Fact]
    public async Task GetDepartments()
    {
        var departments = await _ticket.GetDepartmentsAsync();

        if (!departments.Success)
        {
            Assert.Fail(departments.Message);
            return;
        }

        Assert.True(departments.Success);
        outputHelper.WriteLine(departments.Message);
        outputHelper.WriteLine(departments.Result?.ToString());
    }

    [Fact]
    public async Task GetAppTickets()
    {
        var appTickets = await _ticket.GetAppTicketsAsync(null, 0, 10);

        if (!appTickets.Success)
        {
            Assert.Fail(appTickets.Message);
            return;
        }

        Assert.True(appTickets.Success);
        outputHelper.WriteLine(appTickets.Message);
        outputHelper.WriteLine(appTickets.Result?.ToString());
    }

    [Fact]
    public async Task GetUserTickets()
    {
        var userTickets = await _ticket.GetUserTicketsAsync(Constants.userId, null, 0, 10);

        if (!userTickets.Success)
        {
            Assert.Fail(userTickets.Message);
            return;
        }

        Assert.True(userTickets.Success);
        outputHelper.WriteLine(userTickets.Message);
        outputHelper.WriteLine(userTickets.Result?.ToString());
    }

    [Fact]
    public async Task NewTicket()
    {
        var ticket = await _ticket.NewTicketAsync(new("Test", "test for new ticket", TicketStatus.Active, TicketPriority.Medium, Constants.userId, null));

        if (!ticket.Success)
        {
            Assert.Fail(ticket.Message);
            return;
        }

        Assert.True(ticket.Success);
        outputHelper.WriteLine(ticket.Message);
        outputHelper.WriteLine(ticket.Result?.ToString());
    }

    [Fact]
    public async Task GetMessages()
    {
        var messages = await _ticket.GetMessagesAsync(Constants.ticketId, 0, 10);

        if (!messages.Success)
        {
            Assert.Fail(messages.Message);
            return;
        }

        Assert.True(messages.Success);
        outputHelper.WriteLine(messages.Message);
        outputHelper.WriteLine(messages.Result?.ToString());
    }

    [Fact]
    public async Task UpsertMessage()
    {
        var message = await _ticket.UpsertMessageAsync(new(Constants.ticketId, null, null, Constants.userId, "Hello this is message"));

        if (!message.Success)
        {
            Assert.Fail(message.Message);
            return;
        }

        Assert.True(message.Success);
        outputHelper.WriteLine(message.Message);
        outputHelper.WriteLine(message.Result?.ToString());
    }

    [Fact]
    public async Task DeleteMessage()
    {
        var message = await _ticket.DeleteMessageAsync(Constants.ticketId, Guid.Parse("a8898f73-0149-4abc-9a9a-15ea98e151a4"));

        if (!message.Success)
        {
            Assert.Fail(message.Message);
            return;
        }

        Assert.True(message.Success);
        outputHelper.WriteLine(message.Message);
        outputHelper.WriteLine(message.Result?.ToString());
    }
}
