namespace WebCardstb.Models
{
    public class Compte
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Solde { get; set; }
        public DateTime DateCreation { get; set; }
    }
}
