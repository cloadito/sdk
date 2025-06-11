namespace Cloudito.Sdk.Services;

public interface IApplication
{
    Task<ServiceResult<bool>> IsAdminAsync(Guid userId, Guid appId);

    Task<ServiceResult<object>> MakeTransactionAsync(Guid appId, decimal amount);

    Task<ServiceResult<object>> MakeTransactionAsync(MakeTransaction transaction);

    Task<ServiceResult<object>> MakeBulkTransactionAsync(IEnumerable<MakeTransaction> transactions);

    Task<ServiceResult<object>> LogUsageAsync(IEnumerable<LogUsage> logs);
}
