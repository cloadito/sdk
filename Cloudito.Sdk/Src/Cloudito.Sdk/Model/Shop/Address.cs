namespace Cloudito.Sdk;

public class ShopAddress
{
    public record Address(
        Guid Id,
        Guid ForId,
        AddressType Type,
        string Name,
        string Details,
        string Plate,
        Guid? ProvinceId,
        Guid? CityId,
        int Unit,
        Location? Location,
        AddressReceiver? Receiver
    );

    public record Location(double Lat, double Lng);

    public record AddressReceiver(string FirstName, string LastName, string MobileNo);

    public enum AddressType
    {
        User,
        Shop
    }
}