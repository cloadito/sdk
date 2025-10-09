namespace Cloudito.Sdk.Services;

public interface IShopType
{
    Task<ServiceResult<IEnumerable<ShopType>>> GetListAsync(CancellationToken cancellationToken = default);

    Task<ServiceResult<ShopType>> GetByNameAsync(string name, CancellationToken cancellationToken = default);

    Task<ServiceResult<ShopType>> GetByCodeAsync(string code, CancellationToken cancellationToken = default);
}