using PFA.Models;

namespace AuthSystem.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Question { get; set; }

        public int UserId { get; set; }
        public User? user { get; set; }
 
    }
}
