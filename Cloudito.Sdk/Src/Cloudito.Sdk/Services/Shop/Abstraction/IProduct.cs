namespace Cloudito.Sdk.Services;

public interface IProduct
{
    Task<ServiceResult<Pagination<Product>>> GetListAsync(GetProductsList request, CancellationToken cancellationToken = default);

    Task<ServiceResult<ProductDetails>> GetDetailsAsync(Guid id, CancellationToken cancellationToken = default);

    Task<ServiceResult<IEnumerable<ProductProperty>>> GetPropertiesAsync(Guid categoryId,
        CancellationToken cancellationToken = default);

    Task<ServiceResult<IEnumerable<Shop>>> GetSellersAsync(Guid id, CancellationToken cancellationToken = default);

    Task<ServiceResult<ProductDetails>> UpsertAsync(UpsertProduct request,
        CancellationToken cancellationToken = default);

    Task<ServiceResult<ProductProperty>> UpsertPropertyAsync(UpsertProperty request,
        CancellationToken cancellationToken = default);

    Task<ServiceResult<object>> DeleteShopProductAsync(Guid shopId, Guid productId,
        CancellationToken cancellationToken = default);

    Task<ServiceResult<object>> DeletePropertyAsync(Guid id, CancellationToken cancellationToken = default);

    Task<ServiceResult<object>> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    Task<ServiceResult<Product>>
        AddToShopAsync(AddProductToShop request, CancellationToken cancellationToken = default);
}