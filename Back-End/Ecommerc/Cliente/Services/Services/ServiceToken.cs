using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Cliente.DTO.Login;
using Cliente.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace Cliente.Services.Services
{
    public class ServiceToken : IServiceToken
    {
        private readonly JwtConfiguration jwtConfiguration;

        public ServiceToken(JwtConfiguration jwtConfiguration)
        {
            this.jwtConfiguration = jwtConfiguration;
        }

        public string ObterTokenLogin(string usuario)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfiguration.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, usuario)
            };

            var Sectoken = new JwtSecurityToken(issuer: jwtConfiguration.Issuer,
              audience: jwtConfiguration.Issuer,
              claims: claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(Sectoken);
        }
    }
}
