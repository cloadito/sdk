namespace Cloudito.Sdk.Services;

public interface IShopType
{
    Task<ServiceResult<IEnumerable<ShopStatus>>> GetListAsync(CancellationToken cancellationToken = default);

    Task<ServiceResult<ShopStatus>> GetByNameAsync(string name, CancellationToken cancellationToken = default);

    Task<ServiceResult<ShopStatus>> GetByCodeAsync(string code, CancellationToken cancellationToken = default);
}