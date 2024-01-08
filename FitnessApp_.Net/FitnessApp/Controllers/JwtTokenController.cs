using FitnessApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtGenerateToken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenGenerationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TokenGenerationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private static readonly TimeSpan TokenLifetime = TimeSpan.FromDays(1);

        [HttpPost("token")]
        public IActionResult GenerateToken([FromBody] User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]);

            // Ensure the key has the required size for HmacSha256
            var validKeySize = 256 / 8; // For HmacSha256
            if (key.Length < validKeySize)
            {
                throw new ArgumentException($"The key size should be at least {validKeySize} bits for HmacSha256.");
            }

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new(JwtRegisteredClaimNames.Email, user.UserEmail),
                new("userId", user.Id.ToString())
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.Add(TokenLifetime),
                Issuer = "https://localhost:7271/swagger/index.html",
                Audience = "https://localhost:7271/swagger/index.html",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwt = tokenHandler.WriteToken(token);

            return Ok(jwt);
        }
    }
}
