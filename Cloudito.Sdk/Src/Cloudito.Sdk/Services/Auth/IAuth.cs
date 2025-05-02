namespace Cloudito.Sdk.Services;

public interface IAuth
{
    Task<ServiceResult<object>> SendOtpAsync(string userName);

    Task<ServiceResult<LoginResult>> LoginOtpAsync(string userName, string code);
}
