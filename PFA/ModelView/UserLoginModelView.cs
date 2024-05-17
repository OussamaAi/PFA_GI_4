using System.ComponentModel.DataAnnotations;

namespace PFA.ModelView
{
    public class UserLoginModelView
    {
        [Required(ErrorMessage = "Le Login Est Obligatoire")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Le Password Est Obligatoire")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
