using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PontoMaisDomain.Employees.Entities;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PontoMaisDomain.Token
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(Employee employee)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var secret = _configuration.GetSection("Secret").Value;
            var key = Encoding.ASCII.GetBytes(secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature
                    ),
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, employee.Name),
                    new Claim(ClaimTypes.Role, employee.Role)
                })
            };

            var token = tokenHandler.CreateEncodedJwt(tokenDescriptor);

            return token;
        }
    }
}
