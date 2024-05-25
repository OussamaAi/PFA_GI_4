using PFA.Models;

namespace AuthSystem.Models
{
    public class Endroit
    {
        public int Id { get; set; }
        public string? NomEndroit { get; set; } 
        public int? Longitude { get; set; }
        public int? Latitude { get; set; }
        public string? Image {  get; set; }
		public float NbrEtoile { get; set; }
		public string? Addresse {  get; set; }
        public string? Telephone {  get; set; }

        public Ville? ville { get; set; }
        public int VilleId { get; set; }

        public ICollection<Visit>? Visits { get; set; }
    }
}
