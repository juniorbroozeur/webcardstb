using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webcardstb.Data;
using WebCardstb.Models;

namespace WebCardstb.Controllers
{
    [ApiController]
    [Route("api/gestionnaire")]
    public class GestionnaireController(AppDbContext context) : ControllerBase
    {
        private readonly AppDbContext _context = context;

        // Voir toutes les cartes en attente de validation
        [HttpGet("cartes-en-attente")]
        public async Task<IActionResult> GetCartesEnAttente()
        {
            var cartes = await _context.Cartes
                .Where(c => c.Statut == "En attente")
                .ToListAsync();

            return Ok(cartes);
        }

        // Valider une carte (changer son statut)
        [HttpPost("valider-carte/{carteId}")]
        public async Task<IActionResult> ValiderCarte(int carteId)
        {
            var carte = await _context.Cartes.FindAsync(carteId);
            if (carte == null)
                return NotFound("Carte non trouvée");

            carte.Statut = "Validée";
            await _context.SaveChangesAsync();

            return Ok(carte);
        }
    }
}