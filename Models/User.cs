namespace Webcardstb.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Nom { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string MotDePasse { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;

        public string Region { get; set; } = string.Empty;      // 🔹 Ajouté
        public string NomAgence { get; set; } = string.Empty;   // 🔹 Ajouté
    }
}
