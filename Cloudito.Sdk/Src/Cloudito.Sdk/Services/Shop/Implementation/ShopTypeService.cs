namespace Cloudito.Sdk.Services;

internal class ShopTypeService(IBaseService baseService) : IShopType
{
    public Task<ServiceResult<IEnumerable<ShopType>>> GetListAsync(CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync<IEnumerable<ShopType>>(UrlsConst.Shop.Type.GetList, null, HttpMethod.Get,
            cancellationToken);

    public Task<ServiceResult<ShopType>> GetByNameAsync(string name, CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync<ShopType>(UrlsConst.Shop.Type.GetByName(name), null, HttpMethod.Get,
            cancellationToken);

    public Task<ServiceResult<ShopType>> GetByCodeAsync(string code, CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync<ShopType>(UrlsConst.Shop.Type.GetByCode(code), null, HttpMethod.Get,
            cancellationToken);
}