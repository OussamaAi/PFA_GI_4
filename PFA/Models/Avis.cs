using PFA.Models;

namespace AuthSystem.Models
{
    public class Avis
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Commentaire { get; set; }
        public DateTime Date { get; set; }

        public User? user { get; set; }
        public int? UserId;
    }
}
