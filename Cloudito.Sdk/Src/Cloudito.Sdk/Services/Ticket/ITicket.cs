namespace Cloudito.Sdk.Services;

public interface ITicket
{
    /// <summary>
    /// Get list of departments for application
    /// </summary>
    /// <returns>List of <see cref="Department"/></returns>
    Task<ServiceResult<IEnumerable<Department>>> GetDepartmentsAsync();

    Task<ServiceResult<Pagination<>>>
}
