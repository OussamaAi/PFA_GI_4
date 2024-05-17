using System.ComponentModel.DataAnnotations;

namespace PFA.ModelView
{
    public class ClientInscriptionModelView
    {
        [Required(ErrorMessage ="Le Nom est Obligatoire ")]
        public string Nom { get; set; }
        [Required(ErrorMessage = "Le Prenom est Obligatoire ")]
        public string Prenom { get; set; }
        [Required(ErrorMessage ="Email est Obligatoire")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Le mot de passe doit avoir au moins 8 caractères et inclure au moins une lettre minuscule, une lettre majuscule, un chiffre et un caractère spécial.")]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Les deux mots de passe doivent etre egaux")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Telephone { get; set; }
    }
}
