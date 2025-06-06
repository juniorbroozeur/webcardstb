using Microsoft.AspNetCore.Mvc;
using Webcardstb.Data;
using Webcardstb.service;  // Ajoute si JwtService est dans ce namespace
using WebCardstb.Models;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace Webcardstb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly JwtService _jwtService;

        public AuthController(AppDbContext context, IConfiguration configuration, JwtService jwtService)
        {
            _context = context;
            _configuration = configuration;
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == model.Email && u.MotDePasse == model.MotDePasse);
            if (user == null)
                return Unauthorized(new { message = "Identifiants invalides." });

            var token = _jwtService.GenerateToken(user);

            // Retourner le token et les informations utilisateur
            return Ok(new
            {
                token,
                user = new
                {
                    user.Id,
                    user.Nom,
                    user.Email,
                    user.Role,
                    user.Region,
                    user.NomAgence
                }
            });
        }
    }
}
