using System.Security.Claims;

namespace BL;

public interface IGenerateJWT
{
    string JwtGenerator(IList<Claim> claims);
}
