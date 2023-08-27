using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Application.Dto;
using Domain.Abstraction.Repository;
using Domain.Entity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.Text;
using Application.Service.Abstraction;

namespace Application.Service.Implementation.Shared
{
  public class AuthService : IAuthService
  {
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;

    public AuthService(IUserRepository userRepository, IConfiguration configuration)
    {
      _userRepository = userRepository;
      _configuration = configuration;
    }

    public async Task<string> VerifyCredentialsAsync(UserCredentials userCredentials)
    {
      var user = await _userRepository.GetByUsernameAsync(userCredentials.Username);
      var isAuthenticated = PasswordService.VerifyPassword(userCredentials.Password, user.Password, user.Salt);

      if (!isAuthenticated)
      {
        throw new Exception("Invalid credentials");
      }
      return GenerateToken(user);
    }

    private string GenerateToken(User user)
    {
      var claims = new List<Claim>
      {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Role, user.Role.ToString())
      };

      var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtConfig:SecretKey"]));

      var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

      var securityTokenDescriptor = new SecurityTokenDescriptor
      {
        Issuer = _configuration["JwtConfig:Issuer"],
        Expires = DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["JwtConfig:Expires"])),
        Subject = new ClaimsIdentity(claims),
        SigningCredentials = signingCredentials
      };
      var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
      var token = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);

      return jwtSecurityTokenHandler.WriteToken(token);
    }
  }
}