namespace Cloudito.Sdk.Services;

internal class ProductService(IBaseService baseService) : IProduct
{
    public Task<ServiceResult<Pagination<Product>>> GetListAsync(GetProductsList request,
        CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync<Pagination<Product>>(UrlsConst.Shop.Product.GetList, request, HttpMethod.Post,
            cancellationToken);

    public Task<ServiceResult<ProductDetails>> GetDetailsAsync(Guid id, CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync<ProductDetails>(UrlsConst.Shop.Product.GetDetails(id), null, HttpMethod.Get,
            cancellationToken);

    public Task<ServiceResult<IEnumerable<ProductProperty>>> GetPropertiesAsync(Guid categoryId,
        CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync<IEnumerable<ProductProperty>>(UrlsConst.Shop.Product.GetProperties(categoryId),
            null, HttpMethod.Get, cancellationToken);

    public Task<ServiceResult<IEnumerable<Shop>>> GetSellersAsync(Guid id,
        CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync<IEnumerable<Shop>>(UrlsConst.Shop.Product.GetSellers(id), null, HttpMethod.Get,
            cancellationToken);

    public Task<ServiceResult<ProductDetails>> UpsertAsync(UpsertProduct request,
        CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync<ProductDetails>(UrlsConst.Shop.Product.Upsert, request, HttpMethod.Post,
            cancellationToken);

    public Task<ServiceResult<ProductProperty>> UpsertPropertyAsync(UpsertProperty request,
        CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync<ProductProperty>(UrlsConst.Shop.Product.UpsertProperty, request,
            HttpMethod.Post, cancellationToken);

    public Task<ServiceResult<object>> DeleteShopProductAsync(Guid shopId, Guid productId,
        CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync(UrlsConst.Shop.Product.DeleteShopProduct(productId, shopId), null,
            HttpMethod.Delete, cancellationToken);

    public Task<ServiceResult<object>> DeletePropertyAsync(Guid id, CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync(UrlsConst.Shop.Product.DeleteProperty(id), null, HttpMethod.Delete,
            cancellationToken);

    public Task<ServiceResult<object>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync(UrlsConst.Shop.Product.Delete(id), null, HttpMethod.Delete, cancellationToken);

    public Task<ServiceResult<Product>> AddToShopAsync(AddProductToShop request,
        CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync<Product>(UrlsConst.Shop.Product.AddProductToShop, request, HttpMethod.Post,
            cancellationToken);

    public Task<ServiceResult<int>> AddAllToShopWithTagAsync(AddAllWithTagRequest request,
        CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync<int>(UrlsConst.Shop.Product.AddAllWithTag, request, HttpMethod.Post,
            cancellationToken);
}