using Microsoft.AspNetCore.Mvc;

namespace PFA.ModelView
{
    public class ListerLieuTouristiqueModelView
    {
        [HiddenInput]
        public int Id { get; set; }
        public string NomEndroit { get; set; }
        public string Image { get; set; }
        public float NbrEtoile { get; set; }
        public string Addresse { get; set; }
      
    }
}
