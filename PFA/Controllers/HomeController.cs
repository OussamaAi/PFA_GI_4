using AuthSystem.Models;
using Microsoft.AspNetCore.Mvc;
using PFA.Context;
using PFA.Models;
using PFA.ModelView;
 
using System.Diagnostics;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly MyContext db;
    public HomeController(ILogger<HomeController> logger, MyContext db)
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

    public IActionResult Blog()
    {
        return View();
    }

    public IActionResult AboutUs()
    {
        return View();
    }

    public async Task<IActionResult> Destination()
    {
        if (HttpContext.Session.GetString("Id") != null)
        {
            int clientId = int.Parse(HttpContext.Session.GetString("Id"));
            //await _visitService.TrackVisit(clientId, 0); // Pass 0 if destination is not specific to an endroit
        }
        return View();
    }

    public async Task<IActionResult> Hotel(int id)
    {

        List<Hotel> hotels = db.Hotels.ToList();
        var hotel = hotels.Select(h => new ListerHotelModelView
        {
            Id = h.Id,
            Image = h.Image,
            NbrEtoile = h.NbrEtoile,
            NbrCHambre = h.NbrCHambre,
            Addresse = h.Addresse,
        });
        return View(hotel);
    }

    public async Task<IActionResult> Restaurant(int id)
    {

        List<Restaurant> restaurants = db.Restaurants.ToList();
        var restaurant = restaurants.Select(r => new ListerRestaurantModelView
        {
            Id = r.Id,
            NomEndroit = r.NomEndroit,
            Image = r.Image,
            TypeCuisine = r.TypeCuisine,
            NbrEtoile = r.NbrEtoile,
            Addresse = r.Addresse,
            Telephone = r.Telephone,
            ville = r.ville,
        });

        return View(restaurant);
    }

   
    
    public async Task<IActionResult> RestaurantTest(string filter)
    {
        List<Restaurant> restaurants = db.Restaurants.ToList();

        if (!string.IsNullOrEmpty(filter) && filter == "mieuxNotes")
        {
            restaurants = restaurants.Where(r => r.NbrEtoile >= 4 && r.NbrEtoile <= 5).ToList();
        }

        var restaurant = restaurants.Select(r => new ListerRestaurantModelView
        {
            Id = r.Id,
            NomEndroit = r.NomEndroit,
            Image = r.Image,
            TypeCuisine = r.TypeCuisine,
            NbrEtoile = r.NbrEtoile,
            Addresse = r.Addresse,
            Telephone = r.Telephone,
            ville = r.ville,
        }).ToList();

        return View("Restaurant", restaurant);
    }
   
    public async Task<IActionResult> Activite()
    {
         
        List<LieuTouristique> lieuTouristique = db.LieuTouristiques.ToList();
        var lieu = lieuTouristique.Select(r => new ListerLieuTouristiqueModelView
        {
            Id = r.Id,
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
