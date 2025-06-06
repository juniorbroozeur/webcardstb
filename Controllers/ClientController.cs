using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webcardstb.Data;
using WebCardstb.Models;

namespace WebCardstb.Controllers
{
    [ApiController]
    [Route("api/client")]
    public class ClientController(AppDbContext context) : ControllerBase
    {
        private readonly AppDbContext _context = context;

        // Récupérer les comptes d’un utilisateur
        [HttpGet("comptes/{userId}")]
        public async Task<IActionResult> GetComptes(int userId)
        {
            var comptes = await _context.Comptes
                .Where(c => c.UserId == userId)
                .ToListAsync();

            if (comptes == null || comptes.Count == 0)
                return NotFound("Aucun compte trouvé pour cet utilisateur.");

            return Ok(comptes);
        }

        // Récupérer les cartes d’un compte
        [HttpGet("cartes/{compteId}")]
        public async Task<IActionResult> GetCartes(int compteId)
        {
            var cartes = await _context.Cartes
                .Where(c => c.CompteId == compteId)
                .ToListAsync();

            if (cartes == null || cartes.Count == 0)
                return NotFound("Aucune carte trouvée pour ce compte.");

            return Ok(cartes);
        }
    }
}