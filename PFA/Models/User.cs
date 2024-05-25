using AuthSystem.Models;
using PFA.ModelView;
using System.Text.Json.Serialization;

namespace PFA.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }

        public string? Photo {  get; set; }

        public string Login { get; set; }
        public string Password { get; set; }
        public string? Role { get; set; }

        public IList<Avis>? Avis { get; set; }
        public IList<Reservation>? Reservations { get; set; }
        public IList<Contact>? Contacts { get; set; }
        [JsonIgnore]
        public ICollection<Visit>? Visits { get; set; }


        public User() { }
        public User(ClientInscriptionModelView uvm)
        {

            Nom = uvm.Nom;
            Prenom = uvm.Prenom;
            Email = uvm.Email;
            Login = uvm.Nom+" "+uvm.Prenom;
            Password = uvm.Password;
            Role = "Client";
            Photo = "profile-img.jpg";
            Telephone =uvm.Telephone;
        }

       


    }
}
