namespace Cloudito.Sdk.Services;

internal class ShopService(IBaseService baseService) : IShop
{
    public Task<ServiceResult<Pagination<Shop>>> GetListAsync(GetShopsRequest request,
        CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync<Pagination<Shop>>(UrlsConst.Shop.GetShopsList, request,
            HttpMethod.Post, cancellationToken);

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

    public Task<ServiceResult<ShopSettings>> GetSettingsAsync(Guid shopId,
        CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync<ShopSettings>(UrlsConst.Shop.GetSettings(shopId), null, HttpMethod.Get,
            cancellationToken);

    public Task<ServiceResult<ShopSettings>> UpdateSettingsAsync(ShopSettings settings,
        CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync<ShopSettings>(UrlsConst.Shop.UpdateSettings, settings, HttpMethod.Post,
            cancellationToken);

    public Task<ServiceResult<ShopDetails>> FindAsync(FindShopRequest request,
        CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync<ShopDetails>(UrlsConst.Shop.Find, request, HttpMethod.Post, cancellationToken);

    public Task<ServiceResult<ShopDetails>> SetInfoAsync(SetShopInfoRequest request,
        CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync<ShopDetails>(UrlsConst.Shop.SetInfo, request, HttpMethod.Post,
            cancellationToken);

    public Task<ServiceResult<IEnumerable<WeeklyWorkTime>>> GetWeeklyWorkTimeAsync(Guid shopId,
        CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync<IEnumerable<WeeklyWorkTime>>(UrlsConst.Shop.GetWeeklyWorkTime(shopId), null,
            HttpMethod.Get, cancellationToken);

    public Task<ServiceResult<IEnumerable<WorkTimeException>>> GetWorkTimeExceptionsAsync(Guid shopId,
        CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync<IEnumerable<WorkTimeException>>(UrlsConst.Shop.GetWorkTimeException(shopId),
            null,
            HttpMethod.Get, cancellationToken);

    public Task<ServiceResult<WeeklyWorkTime>> UpsertWeeklyWorkTimeAsync(UpsertWeeklyWorkTime request,
        CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync<WeeklyWorkTime>(UrlsConst.Shop.UpsertWeeklyWorkTime, request, HttpMethod.Post,
            cancellationToken);

    public Task<ServiceResult<WorkTimeException>> UpsertWorkTimeExceptionAsync(UpsertWorkTimeException request,
        CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync<WorkTimeException>(UrlsConst.Shop.UpsertWorkTimeException, request,
            HttpMethod.Post,
            cancellationToken);

    public Task<ServiceResult<object>> DeleteWeeklyWorkTimeAsync(Guid shopId, Guid id,
        CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync(UrlsConst.Shop.DeleteWeeklyWorkTime(shopId, id), null, HttpMethod.Delete,
            cancellationToken);

    public Task<ServiceResult<object>> DeleteWorkTimeExceptionAsync(Guid shopId, Guid id,
        CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync(UrlsConst.Shop.DeleteWorkTimeException(shopId, id), null, HttpMethod.Delete,
            cancellationToken);
}