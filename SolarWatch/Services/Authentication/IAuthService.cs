using System.IdentityModel.Tokens.Jwt;

namespace SolarWatch.Services.Authentication;

public interface IAuthService
{
    Task<AuthResult> RegisterAsync(string email, string username, string password, string role);
    Task<AuthResult> LoginAsync(string email, string password);
    JwtSecurityToken Verify(string token);
}