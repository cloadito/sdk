namespace Cloudito.Sdk.Services;

internal class ShopStatusService(IBaseService baseService) : IShopStatus
{
    public Task<ServiceResult<IEnumerable<ShopStatus>>> GetListAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResult<ShopStatus>> GetByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResult<ShopStatus>> GetByCodeAsync(string code, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}