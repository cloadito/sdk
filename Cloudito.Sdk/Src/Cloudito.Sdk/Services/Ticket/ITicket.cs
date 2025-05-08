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
}
