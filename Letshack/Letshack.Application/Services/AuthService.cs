using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Letshack.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Letshack.Application.Services;

public class AuthService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IConfiguration _configuration;

    public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
    }
    
    public async Task<string?> Login(User userRequest)
    {
        if (userRequest.UserName is null) return null;
        var user = await _userManager.FindByNameAsync(userRequest.UserName);
        if (user == null) return null;

        if (userRequest.PasswordHash is null) return null;
        var result = await _signInManager.CheckPasswordSignInAsync(user, userRequest.PasswordHash, false);

        return result.Succeeded ? GenerateToken(user) : null;
    }

    public async Task<bool> RegisterUser(User request, string password)
    {
        var result = await _userManager.CreateAsync(request, password);
        return result.Succeeded;
    }
    
    private string GenerateToken(User user)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Name, user.UserName ?? throw new InvalidOperationException()),
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("userId", user.Id.ToString()),
            
        };

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]
                                                                          ?? throw new Exception("signing key not found")));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(60),
            Issuer = _configuration["Jwt:Issuer"],
            Audience = _configuration["Jwt:Audience"],
            SigningCredentials = credentials
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var token = tokenHandler.CreateToken(tokenDescriptor);
       
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}