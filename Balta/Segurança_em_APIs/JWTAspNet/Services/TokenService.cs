using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JWTAspNet.Models;
using Microsoft.IdentityModel.Tokens;

namespace JWTAspNet.Services;

public class TokenService
{
    public string Create(User user)
    {
        var handler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(Configuration.PrivateKey);
        var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            SigningCredentials = credentials,
            Expires = DateTime.UtcNow.AddHours(2),
            Subject = GenereateClaims(user)
        };
        var token = handler.CreateToken(tokenDescriptor);
        return handler.WriteToken(token);
    }

    private ClaimsIdentity GenereateClaims(User user)
    {
        var claimsIdentity = new ClaimsIdentity();
        claimsIdentity.AddClaim(new Claim("Id", user.Id.ToString()));
        claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, user.Email));
        claimsIdentity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
        claimsIdentity.AddClaim(new Claim(ClaimTypes.GivenName, user.Name));
        claimsIdentity.AddClaim(new Claim("Image", user.Image));

        foreach (var role in user.Roles)
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, role));
        
        return claimsIdentity;
    }
}