using System.IdentityModel.Tokens.Jwt;

namespace Cloudito.Sdk;

internal class JwtTokenGenerator
{
    public static User? GetUserData(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        try
        {
            // Parse the token
            var jwtToken = tokenHandler.ReadJwtToken(token);

            // Extract the user ID (assumes it's stored in the "sub" claim)
            var id = jwtToken.Claims.FirstOrDefault(c => c.Type == Constants.JwtConstnats.Id)?.Value;
            var name = jwtToken.Claims.FirstOrDefault(c => c.Type == Constants.JwtConstnats.FirstName)?.Value;
            var lastName = jwtToken.Claims.FirstOrDefault(c => c.Type == Constants.JwtConstnats.LastName)?.Value;
            var mobileNo = jwtToken.Claims.FirstOrDefault(c => c.Type == Constants.JwtConstnats.MobileNo)?.Value;
            var email = jwtToken.Claims.FirstOrDefault(c => c.Type == Constants.JwtConstnats.Email)?.Value;

            if (id is null)
                return null;

            _ = Guid.TryParse(id, out Guid userId);
            return new(userId, name ?? "", lastName ?? "", mobileNo ?? "", email ?? "");
        }
        catch
        {
            return null;
        }
    }

    public static bool IsTokenExpired(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        try
        {
            var jwtToken = tokenHandler.ReadJwtToken(token);
            var expirationDate = jwtToken.ValidTo; // Extract expiration time (UTC)

            return expirationDate < DateTime.Now; // Return true if expired
        }
        catch
        {
            return false;
        }
    }
}