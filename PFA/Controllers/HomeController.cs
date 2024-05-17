using AuthSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PFA.Context;
using PFA.Models;
using PFA.ModelView;
using System.Diagnostics;  
namespace PFA.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		MyContext db;
		 
		public HomeController(ILogger<HomeController> logger,MyContext db)
		{
			_logger = logger;
			this.db = db;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		public IActionResult SeConnecter() 
		{
			return View();
		}
		
		public IActionResult Inscription()
		{
			return View();
		}

		public IActionResult ContactUs() 
		{
			return View();
		}
		public	IActionResult Blog() 
		{
			return View();
		}
		public IActionResult AboutUs()
		{
			return View();
		}
		public IActionResult Destination() 
		{
			return View();
		}
		public IActionResult Hotel() 
		{
			List<Hotel>  hotels=db.Hotels.ToList();

			var hotel =hotels.Select(h=>new ListerHotelModelView { 

					Image=h.Image,
					NbrEtoile=h.NbrEtoile,
					NbrCHambre=h.NbrCHambre,
					Addresse=h.Addresse,
					 
				 
		 });
         

            return View(hotel);
		}
		public IActionResult Restaurant()
		{
			List<Restaurant> restaurants = db.Restaurants.ToList();
			var restaurant = restaurants.Select(r => new ListerRestaurantModelView
			{
				NomEndroit=r.NomEndroit,
				Image = r.Image,
                TypeCuisine=r.TypeCuisine,
				NbrEtoile=r.NbrEtoile,
				Addresse=r.Addresse,
				Telephone=r.Telephone,
				ville=r.ville,
			}); 

			return View(restaurant);
		}

        public IActionResult Activite()
        {
            List<LieuTouristique> lieuTouristique =  db.LieuTouristiques.ToList();
            var lieu = lieuTouristique.Select(r => new ListerLieuTouristiqueModelView
            {
                NomEndroit = r.NomEndroit,
                Image = r.Image,
                 
                NbrEtoile = r.NbrEtoile,
                Addresse = r.Addresse,
                
            });
            return View(lieu);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}