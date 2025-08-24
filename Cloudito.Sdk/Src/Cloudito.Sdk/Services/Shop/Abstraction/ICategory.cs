namespace Cloudito.Sdk.Services;

public interface ICategory
{
    Task<ServiceResult<object>> AddCategoryToShopAsync(AddCategoryToShop request,
        CancellationToken cancellationToken = default);

    Task<ServiceResult<object>> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    Task<ServiceResult<Pagination<ProductCategory>>> GetListAsync(GetCategories request,
        CancellationToken cancellationToken = default);

    Task<ServiceResult<IEnumerable<ProductCategory>>> GetShopCategoriesAsync(Guid shopId,
        CancellationToken cancellationToken = default);

    Task<ServiceResult<object>> DeleteShopCategoryAsync(Guid shopId, Guid categoryId,
        CancellationToken cancellationToken = default);

    Task<ServiceResult<ProductCategory>> UpsertAsync(UpsertProductCategory request,
        CancellationToken cancellationToken = default);
}