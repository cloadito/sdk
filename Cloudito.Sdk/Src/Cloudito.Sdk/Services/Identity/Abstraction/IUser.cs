namespace Cloudito.Sdk.Services;

public interface IUser
{
    Task<ServiceResult<User?>> FindByIdAsync(Guid id,CancellationToken cancellationToken = default);

    Task<ServiceResult<User?>> ForceRegisterAsync(ForceRegisterRequest request,CancellationToken cancellationToken = default);

    Task<ServiceResult<Pagination<User>>> GetUsersAsync(int page, int count,CancellationToken cancellationToken = default);

    Task<ServiceResult<IEnumerable<Role>>> GetUserRolesAsync(Guid userId,CancellationToken cancellationToken = default);

    Task<ServiceResult<bool>> IsInRoleAsync(Guid userId, string role,CancellationToken cancellationToken = default);

    Task<ServiceResult<bool>> HasAccessAsync(Guid userId, string page, string action,CancellationToken cancellationToken = default);
    
    Task<ServiceResult<User>> FindByUserNameAsync(string userName,CancellationToken cancellationToken = default);
}
