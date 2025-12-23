namespace Cloudito.Sdk.Services;

public interface IShop
{
    Task<ServiceResult<Pagination<Shop>>> GetListAsync(int page, int count, string? q,
        CancellationToken cancellationToken = default);

    Task<ServiceResult<Pagination<Shop>>> GetUserShopsAsync(Guid userId, int page, int count,
        CancellationToken cancellationToken = default);

    Task<ServiceResult<IEnumerable<ShopAdmin>>> GetShopAdminsAsync(Guid shopId,
        CancellationToken cancellationToken = default);

    Task<ServiceResult<object>> DeleteAsync(Guid shopId, CancellationToken cancellationToken = default);

    Task<ServiceResult<object>> RemoveAdminAsync(Guid shopId, Guid userId,
        CancellationToken cancellationToken = default);

    Task<ServiceResult<Shop>> UpsertAsync(UpsertShop shop, CancellationToken cancellationToken = default);

    Task<ServiceResult<ShopAdmin>> UpsertShopAdminAsync(UpsertShopAdmin shopAdmin,
        CancellationToken cancellationToken = default);

    Task<ServiceResult<bool>> IsAdminAsync(Guid shopId, Guid userId, CancellationToken cancellationToken = default);

    Task<ServiceResult<ShopSettings>> GetSettingsAsync(Guid shopId, CancellationToken cancellationToken = default);

    Task<ServiceResult<ShopSettings>> UpdateSettingsAsync(ShopSettings settings,
        CancellationToken cancellationToken = default);

    Task<ServiceResult<ShopDetails>> FindAsync(FindShopRequest request, CancellationToken cancellationToken = default);

    Task<ServiceResult<ShopDetails>> SetInfoAsync(SetShopInfoRequest request,
        CancellationToken cancellationToken = default);
}