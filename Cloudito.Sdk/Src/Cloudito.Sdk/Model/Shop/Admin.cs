namespace Cloudito.Sdk;

public record ShopAdmin(Guid Id,Guid ShopId,Guid UserId,Guid RoleId);

public record UpsertShopAdmin(Guid? Id,Guid ShopId,Guid UserId,Guid RoleId);