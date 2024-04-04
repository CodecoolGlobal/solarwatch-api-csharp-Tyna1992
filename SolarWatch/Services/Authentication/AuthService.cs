using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace SolarWatch.Services.Authentication;

public class AuthService : IAuthService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ITokenService _tokenService;
    private readonly IConfiguration _configuration;

    public AuthService(UserManager<IdentityUser> userManager, ITokenService tokenService, IConfiguration configuration)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _configuration = configuration;
    }
    

    public async Task<AuthResult> RegisterAsync(string email, string username, string password, string role)
    {
        var user = new IdentityUser { UserName = username, Email = email };
        var result = await _userManager.CreateAsync(user, password);

        if (!result.Succeeded)
        {
            return FailedRegistration(result, email, username);
        }

        await _userManager.AddToRoleAsync(user, role); 
        return new AuthResult(true, email, username, "");
    }

    private static AuthResult FailedRegistration(IdentityResult result, string email, string username)
    {
        var authResult = new AuthResult(false, email, username, "");

        foreach (var error in result.Errors)
        {
            authResult.ErrorMessages.Add(error.Code, error.Description);
        }

        return authResult;
    }
    public async Task<AuthResult> LoginAsync(string email, string password)
    {
        var managedUser = await _userManager.FindByEmailAsync(email);

        if (managedUser == null)
        {
            return InvalidEmail(email);
        }

        var isPasswordValid = await _userManager.CheckPasswordAsync(managedUser, password);
        if (!isPasswordValid)
        {
            return InvalidPassword(email, managedUser.UserName);
        }

        var roles = await _userManager.GetRolesAsync(managedUser);
        var accessToken = _tokenService.CreateToken(managedUser, roles[0]);

        return new AuthResult(true, managedUser.Email, managedUser.UserName, accessToken);
    }

    public JwtSecurityToken Verify(string token){
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_configuration.GetSection("IssuerSigningKey").Value);
        tokenHandler.ValidateToken(token, new TokenValidationParameters{
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuerSigningKey = true,
            ValidateIssuer = false,
            ValidateAudience = false,
        }, out SecurityToken validatedToken);
        return (JwtSecurityToken)validatedToken;
    }
    private static AuthResult InvalidEmail(string email)
    {
        var result = new AuthResult(false, email, "", "");
        result.ErrorMessages.Add("Bad credentials", "Invalid email");
        return result;
    }

    private static AuthResult InvalidPassword(string email, string userName)
    {
        var result = new AuthResult(false, email, userName, "");
        result.ErrorMessages.Add("Bad credentials", "Invalid password");
        return result;
    }
}