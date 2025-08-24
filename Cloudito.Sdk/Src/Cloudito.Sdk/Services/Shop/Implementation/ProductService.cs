namespace Cloudito.Sdk.Services;

internal class ProductService(IBaseService baseService) : IProduct
{
    public Task<ServiceResult<Product>> GetListAsync(GetProductsList request,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResult<ProductDetails>> GetDetailsAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResult<IEnumerable<ProductProperty>>> GetPropertiesAsync(Guid categoryId,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResult<IEnumerable<Shop>>> GetSellersAsync(Guid id,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResult<ProductDetails>> UpsertAsync(UpsertProduct request,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResult<ProductProperty>> UpsertPropertyAsync(UpsertProperty request,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResult<object>> DeleteShopProductAsync(Guid shopId, Guid productId,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResult<object>> DeletePropertyAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResult<object>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResult<Product>> AddToShopAsync(AddProductToShop request,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}