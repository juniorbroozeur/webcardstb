using Microsoft.EntityFrameworkCore;
using Webcardstb.Models;
using WebCardstb.Models;

namespace Webcardstb.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Compte> Comptes { get; set; }
        public DbSet<Carte> Cartes { get; set; }
    }
}
