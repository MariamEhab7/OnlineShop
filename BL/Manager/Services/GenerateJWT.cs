using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BL;

public  class GenerateJWT : IGenerateJWT
{
    public string JwtGenerator(IList<Claim> claims)
    {
        var keyString = "kdfjigningoeigbisnlfin";
        var keyInBytes = Encoding.ASCII.GetBytes(keyString);
        var key = new SymmetricSecurityKey(keyInBytes);

        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

        var jwt = new JwtSecurityToken(
            claims: claims,
            signingCredentials: signingCredentials,
            expires: DateTime.Now.AddMinutes(15),
            notBefore: DateTime.Now
            );
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.WriteToken(jwt);
        return token;
    }
}
