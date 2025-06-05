namespace Cloudito.Sdk.Services;

public interface IAuth
{
    Task<ServiceResult<object>> SendOtpAsync(string userName);

    Task<ServiceResult<LoginResult>> LoginOtpAsync(string userName, string code);

    Task<ServiceResult<LoginResult>> LoginAsync(string userName, string password);

    Task<ServiceResult<User?>> GetProfileAsync(Guid userId);

    Task<ServiceResult<User?>> SetProfileAsync(SetProfile profile);

    Task<ServiceResult<object>> SetPasswordAsync(SetPassword setPassword);

    Task<ServiceResult<string>> RefreshTokenAsync(string token);
}
