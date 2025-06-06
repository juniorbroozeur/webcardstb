using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Webcardstb.Models; // Assure-toi que ce namespace contient ta classe User

namespace Webcardstb.service
{
    public class JwtService
    {
        private readonly string _secretKey;

        public JwtService(IConfiguration config)
        {
            _secretKey = config["Jwt:Key"] ?? throw new ArgumentNullException("Jwt:Key", "3x4mpl3-C1é-S3cr3t3-JWT-Tr3s-S3cur1s3e-123!");
        }

        public string GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Nom),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "Webcardstb",
                audience: "Webcardstb",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

