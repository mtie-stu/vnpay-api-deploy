using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Client.Services
{
    public static class JwtHelper
    {
        public static ClaimsPrincipal DecodeJwt(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            var identity = new ClaimsIdentity(jwtToken.Claims, "jwt");
            return new ClaimsPrincipal(identity);
        }

        public static string GetClaim(string token, string claimType)
        {
            var principal = DecodeJwt(token);
            return principal.FindFirst(claimType)?.Value;
        }
    }
}
