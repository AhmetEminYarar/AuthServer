using AuthServer.Data.Entity;
using AuthServer.DTO.Request.Authentication;
using AuthServer.Server.Config;
using AutServer.Server.Abstract;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AutServer.Server.Services
{
    public class AuthorizeService : IAuthorizeService
    {
        private readonly IConfiguration _configuration;
        private readonly IRoleService _roleService;
        private readonly IUserService _userService;

        public AuthorizeService(IConfiguration configuration, IUserService userService, IRoleService roleService)
        {
            _configuration = configuration;
            _roleService = roleService;
            _userService = userService;
        }

        public string CreateToken(User entity)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, entity.Id.ToString()),
                new Claim(ClaimTypes.Name, entity.UserName!),
                new Claim(ClaimTypes.Role, entity.Role.RoleName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            return new JwtSecurityTokenHandler().WriteToken(
                new JwtSecurityToken(
                        issuer: _configuration.GetSection("JwtSettings:Issuer").Value!,
                        audience: _configuration.GetSection("JwtSettings:Audience").Value!,
                        claims: claims,
                        expires: DateTime.UtcNow.AddHours(1),
                        signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JwtSettings:Key").Value!)), SecurityAlgorithms.HmacSha256Signature)
                        ));
        }

        public async Task<string> UserValidator(AuthenticationRequest entity)
        {
            var user = await _userService.GetByUserName(entity.userName);
            if (user == null || !BCrypt.Net.BCrypt.Verify(entity.password, user!.PasswordHash))
                throw new Exception("E-posta veya şifre yanlış");

            var role = await _roleService.GetByIdAsync(user.RoleId);
            user.Role.RoleName = role.RoleName;

            return CreateToken(user);
        }

    }
}
