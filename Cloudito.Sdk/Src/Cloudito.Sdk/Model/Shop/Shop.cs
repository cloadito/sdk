namespace Cloudito.Sdk;

public record Shop(Guid Id, Guid AppId, string Name, ShopStatus Status);

public record ShopStatus(Guid Id, Guid AppId, string Name, string Title, string Code);

public record UpsertShop(Guid? Id, string Name, Guid StatusId, Guid TypeId);

public record ShopType(Guid Id, Guid AppId, string Name, string Title, string Code);