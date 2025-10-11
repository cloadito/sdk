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
}