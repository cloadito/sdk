namespace Cloudito.Sdk.Services;

public interface IApplication
{
    Task<ServiceResult<bool>> IsAdminAsync(Guid userId, Guid appId);

    Task<ServiceResult<object>> MakeTransactionAsync(Guid appId, decimal amount);
}
