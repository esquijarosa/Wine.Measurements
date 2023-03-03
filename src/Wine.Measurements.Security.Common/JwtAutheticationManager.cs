using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Wine.Measurements.Security.Common;

public class JwtAuthenticationManager : IJwtAuthenticator
{
    private readonly string _key;
    private readonly IConfiguration _configuration;

    public JwtAuthenticationManager(IConfiguration configuration)
    {
        _configuration = configuration;
        _key = _configuration["API-KEY"];
    }

    public string? Authorize(string userFullName, string userName)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.ASCII.GetBytes(_key);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, userFullName),
                new Claim(ClaimTypes.Email, userName),
            }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}