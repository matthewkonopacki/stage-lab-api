using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using StageLabApi.Interfaces;

namespace StageLabApi.Services;

public class AuthService(IConfiguration configuration) : IAuthService
{
    public string GenerateJwtToken(
        string email,
        string userId,
        string role,
        int roleId,
        string firstName,
        string lastName
    )
    {
        var jwtKey =
            configuration["Jwt:Key"]
            ?? throw new InvalidOperationException("JWT Key is not configured");
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim("sub", userId),
            new Claim("email", email),
            new Claim("jti", Guid.NewGuid().ToString()),
            new Claim("role", role),
            new Claim("roleId", roleId.ToString()),
            new Claim("firstName", firstName),
            new Claim("lastName", lastName),
        };

        var token = new JwtSecurityToken(
            configuration["Jwt:Issuer"],
            configuration["Jwt:Audience"],
            claims,
            expires: DateTime.UtcNow.AddMinutes(
                Convert.ToDouble(configuration["Jwt:ExpiryMinutes"])
            ),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
