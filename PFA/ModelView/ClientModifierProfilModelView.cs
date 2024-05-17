using Microsoft.AspNetCore.Mvc;
using PFA.Models;
using System.ComponentModel.DataAnnotations;

namespace PFA.ModelView
{
    public class ClientModifierProfilModelView
    {

       
        [Required]
        public string Nom { get; set; }
        [Required]
        public string Prenom { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Telephone { get; set; }
        public string PhotoPath { get; set; }
        public IFormFile Photo { get; set; }
         public string Login { get; set; }
      

        public ClientModifierProfilModelView() { }

        public ClientModifierProfilModelView(User user) 
        {
            Nom = user.Nom;
            Prenom = user.Prenom;
            Email = user.Email;
            Login = user.Login;
            Telephone = user.Telephone;
            PhotoPath = user.Photo;

        }
    }
}
