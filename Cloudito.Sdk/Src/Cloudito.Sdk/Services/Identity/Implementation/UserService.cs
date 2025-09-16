namespace Cloudito.Sdk.Services;

internal class UserService(IBaseService baseService) : IUser
{
    public Task<ServiceResult<User?>> FindByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync<User?>(UrlsConst.Identity.FindUserById(id), null, HttpMethod.Get,
            cancellationToken);

    public Task<ServiceResult<User?>> ForceRegisterAsync(ForceRegisterRequest request,
        CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync<User?>(UrlsConst.Identity.ForceRegister, request, HttpMethod.Post,
            cancellationToken);

    public Task<ServiceResult<IEnumerable<Role>>> GetUserRolesAsync(Guid userId,
        CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync<IEnumerable<Role>>(UrlsConst.Identity.GetUserRoles(userId), null,
            HttpMethod.Get, cancellationToken);

    public Task<ServiceResult<Pagination<User>>> GetUsersAsync(int page, int count,
        CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync<Pagination<User>>(UrlsConst.Identity.GetAppUsers(page, count), null,
            HttpMethod.Get, cancellationToken);

    public Task<ServiceResult<bool>> HasAccessAsync(Guid userId, string page, string action,
        CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync<bool>(UrlsConst.Identity.HasAccess, new
        {
            UserId = userId,
            Page = page,
            Action = action
        }, HttpMethod.Post, cancellationToken);

    public Task<ServiceResult<User>> FindByUserNameAsync(string userName, CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync<User>(UrlsConst.Identity.FindUserByUserName(userName), null, HttpMethod.Get,
            cancellationToken);

    public Task<ServiceResult<bool>> IsInRoleAsync(Guid userId, string role,
        CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync<bool>(UrlsConst.Identity.IsInRole(userId, role), null, HttpMethod.Get,
            cancellationToken);
}