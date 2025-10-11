namespace Cloudito.Sdk.Services;

internal class ShopService(IBaseService baseService) : IShop
{
    public Task<ServiceResult<Pagination<Shop>>> GetListAsync(int page, int count, string? q,
        CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync<Pagination<Shop>>(UrlsConst.Shop.GetShopsList(page, count, q), null,
            HttpMethod.Get, cancellationToken);

    public Task<ServiceResult<Pagination<Shop>>> GetUserShopsAsync(Guid userId, int page, int count,
        CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync<Pagination<Shop>>(UrlsConst.Shop.GetUserShops(userId, page, count), null,
            HttpMethod.Get, cancellationToken);

    public Task<ServiceResult<IEnumerable<ShopAdmin>>> GetShopAdminsAsync(Guid shopId,
        CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync<IEnumerable<ShopAdmin>>(UrlsConst.Shop.GetAdmins(shopId), null, HttpMethod.Get,
            cancellationToken);

    public Task<ServiceResult<object>> DeleteAsync(Guid shopId, CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync<object>(UrlsConst.Shop.Delete(shopId), null, HttpMethod.Delete,
            cancellationToken);

    public Task<ServiceResult<object>> RemoveAdminAsync(Guid shopId, Guid userId,
        CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync<object>(UrlsConst.Shop.RemoveAdmin(shopId, userId), null, HttpMethod.Delete,
            cancellationToken);

    public Task<ServiceResult<Shop>> UpsertAsync(UpsertShop shop, CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync<Shop>(UrlsConst.Shop.Upsert, shop, HttpMethod.Post, cancellationToken);

    public Task<ServiceResult<ShopAdmin>> UpsertShopAdminAsync(UpsertShopAdmin shopAdmin,
        CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync<ShopAdmin>(UrlsConst.Shop.UpsertAdmin, shopAdmin, HttpMethod.Post,
            cancellationToken);

    public Task<ServiceResult<bool>> IsAdminAsync(Guid shopId, Guid userId,
        CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync<bool>(UrlsConst.Shop.IsAdmin(shopId, userId), null, HttpMethod.Get,
            cancellationToken);
}