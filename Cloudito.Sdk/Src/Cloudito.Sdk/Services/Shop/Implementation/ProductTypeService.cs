namespace Cloudito.Sdk.Services;

internal class ProductTypeService(IBaseService baseService) : IProductType
{
    public Task<ServiceResult<IEnumerable<ProductType>>> GetListAsync(CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync<IEnumerable<ProductType>>(UrlsConst.Shop.ProductType.GetList, null,
            HttpMethod.Get, cancellationToken);

    public Task<ServiceResult<ProductType>> GetByNameAsync(string name, CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync<ProductType>(UrlsConst.Shop.ProductType.GetByName(name), null, HttpMethod.Get,
            cancellationToken);

    public Task<ServiceResult<ProductType>> GetByCodeAsync(string code, CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync<ProductType>(UrlsConst.Shop.ProductType.GetByCode(code), null, HttpMethod.Get,
            cancellationToken);
}