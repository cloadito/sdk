namespace Cloudito.Sdk;

public record Shop(Guid Id, Guid AppId, string Name, ShopStatus Status);

public record ShopStatus(Guid Id, Guid AppId, string Name);

public record UpsertShop(Guid? Id,string Name,Guid StatusId,Guid TypeId);