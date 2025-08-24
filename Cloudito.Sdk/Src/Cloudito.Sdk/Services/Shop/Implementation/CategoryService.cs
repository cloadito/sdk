namespace Cloudito.Sdk.Services;

internal class CategoryService(IBaseService baseService) : ICategory
{
    public Task<ServiceResult<object>> AddCategoryToShopAsync(AddCategoryToShop request,
        CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync(UrlsConst.Shop.Category.AddCategoryToShop, request, HttpMethod.Post,
            cancellationToken);

    public Task<ServiceResult<object>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync(UrlsConst.Shop.Category.Delete(id), null, HttpMethod.Delete, cancellationToken);

    public Task<ServiceResult<Pagination<ProductCategory>>> GetListAsync(GetCategories request,
        CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync<Pagination<ProductCategory>>(UrlsConst.Shop.Category.GetList, request,
            HttpMethod.Post, cancellationToken);

    public Task<ServiceResult<IEnumerable<ProductCategory>>> GetShopCategoriesAsync(Guid shopId,
        CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync<IEnumerable<ProductCategory>>(UrlsConst.Shop.Category.GetShopCategories(shopId),
            null, HttpMethod.Get, cancellationToken);

    public Task<ServiceResult<object>> DeleteShopCategoryAsync(Guid shopId, Guid categoryId,
        CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync(UrlsConst.Shop.Category.DeleteShopCategory(categoryId, categoryId), null,
            HttpMethod.Delete, cancellationToken);

    public Task<ServiceResult<ProductCategory>> UpsertAsync(UpsertProductCategory request,
        CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync<ProductCategory>(UrlsConst.Shop.Category.Upsert, request, HttpMethod.Post,
            cancellationToken);
}