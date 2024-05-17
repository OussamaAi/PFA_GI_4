using AuthSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace PFA.ModelView
{
    public class ListerHotelModelView
    {
        [HiddenInput]
        public int Id {  get; set; }
        public string NomEndroit {  get; set; }
        public string Image { get; set; }
        public float NbrEtoile { get; set; }
        public int NbrCHambre { get; set; }
        public string Addresse { get; set; }
         
        public Ville? ville { get; set; }
        
    }
}
