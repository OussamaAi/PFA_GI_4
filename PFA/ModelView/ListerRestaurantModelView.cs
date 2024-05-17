using AuthSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace PFA.ModelView
{
	public class ListerRestaurantModelView
	{
		[HiddenInput]
		public int Id { get; set; }
		public string NomEndroit { get; set; }
		public string Image { get; set; }
        public string TypeCuisine { get; set; }
        public float NbrEtoile { get; set; }
		public string Addresse { get; set; }
		public string Telephone { get; set; }
		public Ville ville { get; set; }


	}
}
