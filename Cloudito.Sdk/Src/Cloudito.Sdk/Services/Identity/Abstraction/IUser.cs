namespace Cloudito.Sdk.Services;

public interface IUser
{
    Task<ServiceResult<User?>> FindByIdAsync(Guid id);

    Task<ServiceResult<User?>> ForceRegisterAsync(ForceRegisterRequest request);

    Task<ServiceResult<Pagination<User>>> GetUsersAsync(int page, int count);

    Task<ServiceResult<IEnumerable<Role>>> GetUserRolesAsync(Guid userId);

    Task<ServiceResult<bool>> IsInRoleAsync(Guid userId, string role);

    Task<ServiceResult<bool>> HasAccessAsync(Guid userId, string page, string action);
}
