using Authentication.Models;

namespace Security.Authentication.Services;

public interface IJwtTokenGenerator
{
    string GenerateToken(TokenRequest tokenRequest);
}