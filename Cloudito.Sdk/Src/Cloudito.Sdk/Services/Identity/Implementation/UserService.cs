namespace Cloudito.Sdk.Services;

internal class UserService(IBaseService baseService) : IUser
{
    public async Task<ServiceResult<User?>> FindByIdAsync(Guid id)
        => await baseService.CallServiceAsync<User?>(UrlsConst.Identity.FindUserById(id), null, HttpMethod.Get);

    public async Task<ServiceResult<User?>> ForceRegisterAsync(ForceRegisterRequest request)
        => await baseService.CallServiceAsync<User?>(UrlsConst.Identity.ForceRegister, request, HttpMethod.Post);

    public async Task<ServiceResult<IEnumerable<Role>>> GetUserRolesAsync(Guid userId)
        => await baseService.CallServiceAsync<IEnumerable<Role>>(UrlsConst.Identity.GetUserRoles(userId), null, HttpMethod.Get);

    public async Task<ServiceResult<Pagination<User>>> GetUsersAsync(int page, int count)
        => await baseService.CallServiceAsync<Pagination<User>>(UrlsConst.Identity.GetAppUsers(page, count), null, HttpMethod.Get);

    public async Task<ServiceResult<bool>> HasAccessAsync(Guid userId, string page, string action)
        => await baseService.CallServiceAsync<bool>(UrlsConst.Identity.HasAccess, new
        {
            UserId = userId,
            Page = page,
            Action = action
        }, HttpMethod.Post);

    public async Task<ServiceResult<bool>> IsInRoleAsync(Guid userId, string role)
        => await baseService.CallServiceAsync<bool>(UrlsConst.Identity.IsInRole(userId, role), null, HttpMethod.Get);
}
