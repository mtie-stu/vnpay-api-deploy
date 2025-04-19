using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using PDP104.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PDP104.Service
{
    public interface ITokenService
    {
        Task<string> GenerateJwtToken(NguoiDung user);
    }
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly UserManager<NguoiDung> _userManager;

        public TokenService(IConfiguration config, UserManager<NguoiDung> userManager)
        {
            _config = config;
            _userManager = userManager;
        }

        public async Task<string> GenerateJwtToken(NguoiDung user)
        {
            var claims = new List<Claim>
{
    new Claim(JwtRegisteredClaimNames.Sub, user.Id ?? ""),
    new Claim(JwtRegisteredClaimNames.Email, user.Email ?? ""),
    new Claim("Hinh", user.Hinh ?? string.Empty),
    new Claim(JwtRegisteredClaimNames.Name, user.NameND ?? "")
};


            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_config["AuthSettings:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _config["AuthSettings:Issuer"],
                _config["AuthSettings:Audience"],
                claims,
                expires: DateTime.UtcNow.AddDays(30),
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
