namespace Cloudito.Sdk.Services;

internal class CategoryService(IBaseService service) : ICategory
{
    public Task<ServiceResult<object>> AddCategoryToShopAsync(AddCategoryToShop request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResult<object>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResult<Pagination<ProductCategory>>> GetListAsync(GetCategories request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResult<IEnumerable<ProductCategory>>> GetShopCategoriesAsync(Guid shopId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResult<object>> DeleteShopCategoryAsync(Guid shopId, Guid categoryId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResult<ProductCategory>> UpsertAsync(UpsertProductCategory request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}