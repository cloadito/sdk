namespace Cloudito.Sdk.Services;

internal class TicketService(IBaseService baseService) : ITicket
{
    public async Task<ServiceResult<object>> DeleteMessageAsync(Guid ticketId, Guid messageId)
        => await baseService.CallServiceAsync<object>(UrlsConst.Ticket.DeleteMessage(ticketId, messageId), null, HttpMethod.Delete);

    public async Task<ServiceResult<Pagination<Ticket>>> GetAppTicketsAsync(Guid? departmentId, int page, int count)
        => await baseService.CallServiceAsync<Pagination<Ticket>>(UrlsConst.Ticket.GetAppTickets(departmentId, page, count), null, HttpMethod.Get);

    public async Task<ServiceResult<IEnumerable<Department>>> GetDepartmentsAsync()
        => await baseService.CallServiceAsync<IEnumerable<Department>>(UrlsConst.Ticket.GetDepartmetns, null, HttpMethod.Get);

    public async Task<ServiceResult<Pagination<TicketMessage>>> GetMessagesAsync(Guid ticketId, int page, int count)
        => await baseService.CallServiceAsync<Pagination<TicketMessage>>(UrlsConst.Ticket.GetMessages(ticketId, page, count), null, HttpMethod.Get);

    public async Task<ServiceResult<Pagination<Ticket>>> GetUserTicketsAsync(Guid userId, Guid? departmentId, int page, int count)
        => await baseService.CallServiceAsync<Pagination<Ticket>>(UrlsConst.Ticket.GetUserTickets(userId, departmentId, page, count), null, HttpMethod.Get);

    public async Task<ServiceResult<Ticket?>> NewTicketAsync(NewTicket ticket)
        => await baseService.CallServiceAsync<Ticket?>(UrlsConst.Ticket.New, ticket, HttpMethod.Post);

    public async Task<ServiceResult<TicketMessage?>> UpsertMessageAsync(TicketMessage message)
        => await baseService.CallServiceAsync<TicketMessage?>(UrlsConst.Ticket.UpsertMessage, message, HttpMethod.Post);
}
