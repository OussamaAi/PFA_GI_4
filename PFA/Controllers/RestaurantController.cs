using AuthSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PFA.Context;
using PFA.Models;
using PFA.ModelView;
using PFA.Visite;

namespace PFA.Controllers
{
    public class RestaurantController : Controller
    {
        MyContext db;
        VisitService _VisitService;
        public RestaurantController(MyContext db, VisitService _VisitService)
        {
            this.db = db;
            this._VisitService = _VisitService;
        }

        public async Task<IActionResult> Details(int id)
        {
            var restaurant = await db.Restaurants
                .Where(r => r.Id == id)
                .Select(r => new ListerRestaurantModelView
                {
                    Id = r.Id,
                    NomEndroit = r.NomEndroit,
                    TypeCuisine = r.TypeCuisine,
                    NbrEtoile = r.NbrEtoile,
                    Addresse = r.Addresse,
                    Telephone = r.Telephone,
                    Image = r.Image
                })
                .FirstOrDefaultAsync();

            if (restaurant == null)
            {
                return NotFound();
            }


            if (HttpContext.Session.GetString("Id") != null)
            {
                var clientIdString = HttpContext.Session.GetString("Id");
                if (int.TryParse(clientIdString, out int clientId))
                {
                    await _VisitService.TrackVisit(clientId, id);
                }
            }
            //else
            //{
            //    throw new InvalidOperationException("Client ID is not found in the session.");
            //}


            return View(restaurant);
        }


        [HttpGet]
        public async Task<IActionResult> Reserver(int id)
        {
            if (HttpContext.Session.GetString("Id") != null)
            {

                var restaurant = await db.Restaurants
               .Include(r => r.Tables)
               .FirstOrDefaultAsync(r => r.Id == id);
                var model = new ReserverTableViewModel
                {
                    RestaurantId = id,
                    UserId = int.Parse(HttpContext.Session.GetString("Id")), // Obtenez l'ID de l'utilisateur connecté (par exemple, depuis le contexte de l'authentification)
                };

                ViewBag.Tables = restaurant.Tables; // Vous pouvez également utiliser un SelectList pour faciliter l'affichage dans la vue
                return View(model);
            }
            return RedirectToAction("Login", "User");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reserver(ReserverTableViewModel model,int id)
        {
            if (ModelState.IsValid)
            {
                var reservation = new Reservation
                {
                    Date = model.DateReservation,
                    Etat = "Confirmée",
                    UserId = model.UserId,
                    tables = new List<Table>
                {
                    await db.Tables.FindAsync(model.TableId)
                }
                };

                db.Reservations.Add(reservation);
                await db.SaveChangesAsync();

                return RedirectToAction("Details", new { id = model.RestaurantId });
            }

            var restaurant = await db.Restaurants
                .Include(r => r.Tables)
                .FirstOrDefaultAsync(r => r.Id == id);

            ViewBag.Tables = restaurant.Tables; // Rechargez les tables disponibles si le modèle est invalide
            return View(model);
        }



        public async Task<IActionResult> ListeReservations()
        {
            User user = db.Users.FirstOrDefault(u => u.Id == int.Parse(HttpContext.Session.GetString("Id")));

            if (user == null)
            {
                // Gérer le cas où l'utilisateur n'est pas trouvé
                return NotFound();
            }

            var reservations = await db.Reservations
                .Include(r => r.tables) // Inclure les tables réservées
                    .ThenInclude(t => t.Restaurant) // Inclure les restaurants associés aux tables
                .ToListAsync();

            var viewModel = new ListerTablesReserveViewModel
            {
                reservations = reservations,
                user = user,
                PhotoPath = user.Photo
            };

            return View(viewModel);

        }


        public IActionResult EditerReservation(int id)
        {
            User user = db.Users.Where(u => u.Login == HttpContext.Session.GetString("Login")).FirstOrDefault();
            if (user == null)
            {
                return NotFound();
            }

            Reservation reservation = db.Reservations.Include(r => r.tables).FirstOrDefault(r => r.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            var viewModel = new ModifierReservationTableViewModel
            {
                Date = reservation.Date,
                Etat = reservation.Etat,
                user = user,
                PhotoPath=user.Photo,
                // Assigner d'autres propriétés au besoin
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult EditerReservation(int id, ModifierReservationTableViewModel viewModel)
        {
            
                var reservation = db.Reservations.Include(r => r.tables).FirstOrDefault(r => r.Id == id);
                if (reservation!= null)
                {
                    //return NotFound();
                

                reservation.Date = viewModel.Date;
                reservation.Etat = viewModel.Etat;
                // Mettre à jour d'autres propriétés au besoin

                db.SaveChanges();

                return RedirectToAction("ListeReservations");
           }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<RedirectToActionResult> SupprimerReservation(int id)
{
    // Trouver et charger toutes les chambres liées à la réservation
    var table = await db.Tables.Where(c => c.ReservationId == id).ToListAsync();
    db.Tables.RemoveRange(table);
    await db.SaveChangesAsync();

    // Maintenant, supprimez la réservation
    var reservation = await db.Reservations.FindAsync(id);
    if (reservation != null)
    {
        db.Reservations.Remove(reservation);
        await db.SaveChangesAsync();
    }

    return RedirectToAction("ListeReservations");
}








    }
}

 
