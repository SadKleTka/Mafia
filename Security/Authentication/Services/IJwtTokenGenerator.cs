using DomainModel.Models.Model;

namespace Security.Authentication.Services;

public interface IJwtTokenGenerator
{
    string GenerateToken(TokenRequest tokenRequest);
}