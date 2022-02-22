using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using PanteraTech.EaiApp.Infrastructure.Auth.Model;

namespace PanteraTech.EaiApp.Infrastructure.Auth.Service
{
  public class TokenService : ITokenService
  {
    public string GenerateToken(string username, string email, string roles)
    {
      var tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.ASCII.GetBytes(Settings.key);

      var tokenDecriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new[]
        {
          new Claim(ClaimTypes.Name, username),
          new Claim(ClaimTypes.Email, email),
          new Claim("ExpireDate", DateTime.UtcNow.AddHours(2).ToString()),
        }),
        Expires = DateTime.UtcNow.AddHours(2),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
      };

      var token = tokenHandler.CreateToken(tokenDecriptor);

      return tokenHandler.WriteToken(token);
    }
  }
}