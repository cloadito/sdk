namespace Cloudito.Sdk.Services;

internal class ShopStatusService(IBaseService baseService) : IShopStatus
{
    public Task<ServiceResult<IEnumerable<ShopStatus>>> GetListAsync(CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync<IEnumerable<ShopStatus>>(UrlsConst.Shop.Status.GetList, null, HttpMethod.Get,
            cancellationToken);

    public Task<ServiceResult<ShopStatus>> GetByNameAsync(string name, CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync<ShopStatus>(UrlsConst.Shop.Status.GetByName(name), null, HttpMethod.Get,
            cancellationToken);

    public Task<ServiceResult<ShopStatus>> GetByCodeAsync(string code, CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync<ShopStatus>(UrlsConst.Shop.Status.GetByCode(code), null, HttpMethod.Get,
            cancellationToken);
}