namespace WebCardstb.Models
{
    public class Carte
    {
        public int Id { get; set; }
        public int CompteId { get; set; }
        public string Numero { get; set; }
        public DateTime DateExpiration { get; set; }
        public string Statut { get; set; } // en attente, validée, refusée
    }
}

