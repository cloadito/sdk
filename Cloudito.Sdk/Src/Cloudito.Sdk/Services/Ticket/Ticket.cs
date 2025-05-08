

namespace Cloudito.Sdk.Services;

internal class TicketService(IBaseService baseService) : ITicket
{
    public async Task<ServiceResult<Pagination<Ticket>>> GetAppTicketsAsync(Guid? departmentId, int page, int count)
        => await baseService.CallServiceAsync<Pagination<Ticket>>(UrlsConst.Ticket.GetAppTickets(departmentId, page, count), null, HttpMethod.Get);

    public async Task<ServiceResult<IEnumerable<Department>>> GetDepartmentsAsync()
        => await baseService.CallServiceAsync<IEnumerable<Department>>(UrlsConst.Ticket.GetDepartmetns, null, HttpMethod.Get);

    public async Task<ServiceResult<Pagination<Ticket>>> GetUserTicketsAsync(Guid userId, Guid? departmentId, int page, int count)
        => await baseService.CallServiceAsync<Pagination<Ticket>>(UrlsConst.Ticket.GetUserTickets(userId, departmentId, page, count), null, HttpMethod.Get);
}
