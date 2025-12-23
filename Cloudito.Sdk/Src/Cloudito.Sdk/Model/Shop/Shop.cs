namespace Cloudito.Sdk;

public record Shop(Guid Id, Guid AppId, string Name, ShopStatus Status);

public record ShopStatus(Guid Id, Guid AppId, string Name, string Title, string Code);

public record UpsertShop(Guid? Id, string Name, Guid OwnerId, Guid StatusId, Guid TypeId);

public record ShopType(Guid Id, Guid AppId, string Name, string Title, string Code);

public record ShopSettings(Guid ShopId, string DefaultCurrency);

public record FindShopRequest(Guid? Id, ClouditoMetadata? Metadata);

public record ShopDetails(
    Guid Id,
    Guid AppId,
    string Name,
    ShopStatus Status,
    ShopType Type,
    ShopInfo? Info,
    ShopAddress.Address? Address,
    IEnumerable<ClouditoMetadata> Metadata);

public record ShopInfo(
    Guid ShopId,
    string? Address,
    string? MobileNo,
    string? PhoneNo,
    string? Description);

public record SetShopInfoRequest(
    Guid Id,
    IEnumerable<ClouditoMetadata> Metadata,
    ShopInfo? Info,
    ShopAddress.Address? Address);