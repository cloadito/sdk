
namespace Cloudito.Sdk.Services;

internal class TicketService(IBaseService baseService) : ITicket
{
    public async Task<ServiceResult<IEnumerable<Department>>> GetDepartmentsAsync()
        => await baseService.CallServiceAsync<IEnumerable<Department>>(UrlsConst.Ticket.GetDepartmetns, null, HttpMethod.Get);
}
