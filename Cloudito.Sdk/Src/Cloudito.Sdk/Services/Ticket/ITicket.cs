namespace Cloudito.Sdk.Services;

public interface ITicket
{
    /// <summary>
    /// Get list of departments for application
    /// </summary>
    /// <returns>List of <see cref="Department"/></returns>
    Task<ServiceResult<IEnumerable<Department>>> GetDepartmentsAsync();

    /// <summary>
    /// Get app tickets list
    /// </summary>
    /// <param name="departmentId">filter by department id</param>
    /// <param name="page">page index that zero index</param>
    /// <param name="count">page size</param>
    /// <returns>Pagination model of <see cref="Ticket"/></returns>
    Task<ServiceResult<Pagination<Ticket>>> GetAppTicketsAsync(Guid? departmentId, int page, int count);

    /// <summary>
    /// Get user tickets list
    /// </summary>
    /// <param name="userId">User id that wanna get tickets</param>
    /// <param name="departmentId">filter by department id</param>
    /// <param name="page">page index that zero index</param>
    /// <param name="count">page size</param>
    /// <returns>Pagination model of <see cref="Ticket"/></returns>
    Task<ServiceResult<Pagination<Ticket>>> GetUserTicketsAsync(Guid userId, Guid? departmentId, int page, int count);

    /// <summary>
    /// Create new ticket 
    /// </summary>
    /// <param name="ticket">instance of <see cref="NewTicket"/></param>
    /// <returns>Service result of <see cref="Ticket?"/></returns>
    Task<ServiceResult<Ticket?>> NewTicketAsync(NewTicket ticket);

    /// <summary>
    /// Get ticket message list
    /// </summary>
    /// <param name="ticketId">Ticket id</param>
    /// <param name="page">page index that zero index</param>
    /// <param name="count">page size</param>
    /// <returns>instance of <see cref="Pagination{TResult}"/></returns>
    Task<ServiceResult<Pagination<TicketMessage>>> GetMessagesAsync(Guid ticketId, int page, int count);

    Task<ServiceResult<TicketMessage?>> UpsertMessageAsync(TicketMessage message);

    Task<ServiceResult<object>> DeleteMessageAsync(Guid ticketId, Guid messageId);
}
