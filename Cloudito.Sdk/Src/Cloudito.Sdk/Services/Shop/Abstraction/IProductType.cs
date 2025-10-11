namespace Cloudito.Sdk.Services;

public interface IProductType
{
    Task<ServiceResult<IEnumerable<ProductType>>> GetListAsync(CancellationToken cancellationToken = default);

    Task<ServiceResult<ProductType>> GetByNameAsync(string name, CancellationToken cancellationToken = default);

    Task<ServiceResult<ProductType>> GetByCodeAsync(string code, CancellationToken cancellationToken = default);
}