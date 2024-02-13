using Bussiness_Logic_Layer.Interfaces;
using Data_Access_Layer.DTOs.User;
using Data_Access_Layer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Bussiness_Logic_Layer.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private User? _user;
        public AuthService(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<bool> ValidateUser(LoginUserDto loginUserDto)
        {
            _user = await _userManager.FindByEmailAsync(loginUserDto.Email!);
            if (_user != null)
            {
                return await _userManager.CheckPasswordAsync(_user, loginUserDto.Password!);
            }

            return false;
        }

        public async Task<string> GenerateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var token = GetTokenOptions(signingCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(token!);
        }

        public SigningCredentials GetSigningCredentials()
        {
            var key = _configuration.GetSection("JWT").GetSection("Key").Value;
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key!));

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        public async Task<List<Claim>> GetClaims()
        {
            var roles = await _userManager.GetRolesAsync(_user!);
            var claims = new List<Claim>
            {
                new Claim("name", $"{_user!.FirstName!} {_user!.LastName!}"),
                new Claim("firstName", _user!.FirstName!),
                new Claim("LastName", _user!.LastName!),
                new Claim("role", roles.First()),
                new Claim("sid", _user!.Id!),
                new Claim("email", _user!.Email!)
            };

            return claims;
        }

        public JwtSecurityToken GetTokenOptions(SigningCredentials signingCredentials, List<Claim> claimsList)
        {
            var jwtSettings = _configuration.GetSection("JWT");
            DateTime expireAt = DateTime.Now.AddDays(Convert.ToInt16(jwtSettings.GetSection("LifeTime").Value));

            var token = new JwtSecurityToken(
                issuer: jwtSettings.GetSection("Issuer").Value,
                claims: claimsList,
                audience: jwtSettings.GetSection("Audience").Value,
                expires: expireAt,
                signingCredentials: signingCredentials
                );
            return token;
        }
    }
}
