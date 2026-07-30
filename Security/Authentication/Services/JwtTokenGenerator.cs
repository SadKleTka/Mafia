using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Authentication.Options;
using DomainModel.Models.Model;
using Microsoft.IdentityModel.Tokens;

namespace Security.Authentication.Services;

/// <summary>
/// Создание JWT токена
/// </summary>
public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtOptions _jwtOptions;
    
    public JwtTokenGenerator(JwtOptions jwtOptions)
    {
        _jwtOptions = jwtOptions;
    }

    public string GenerateToken(TokenRequest tokenRequest)
    {

        var claims = new[]
        {
            new Claim(ClaimTypes.Email, tokenRequest.Email),
            new Claim(ClaimTypes.NameIdentifier, tokenRequest.Id),
            new Claim(ClaimTypes.Role, tokenRequest.Role),
        };
        
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken
        (
            issuer: _jwtOptions.Issuer,
            audience: _jwtOptions.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(
                _jwtOptions.ExpirationMinutes
            ),
            signingCredentials: credentials
        );
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}