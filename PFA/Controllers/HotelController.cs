using AuthSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PFA.Context;
using PFA.Models;
using PFA.ModelView;
using PFA.Visite;

namespace PFA.Controllers
{
    public class HotelController : Controller
    {
        MyContext db;
        VisitService _VisitService;
        
        public HotelController(MyContext db, VisitService _VisitService)
        {
            this.db = db;
            this._VisitService = _VisitService;
            
        }


        public async Task<IActionResult> Details(int id)
        {
            var hotel = await db.Hotels
                .Where(h => h.Id == id)
                .Select(h => new ListerHotelModelView
                {                    
                    NomEndroit = h.NomEndroit,                    
                    NbrEtoile = h.NbrEtoile,
                    Addresse = h.Addresse,
                    NbrCHambre = h.NbrCHambre,
                    Image = h.Image
                })
                .FirstOrDefaultAsync();

            if (hotel == null)
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

            return View(hotel);
        }



        [HttpGet]
        public async Task<IActionResult> Reserver(int id)
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
               
                var hotel= await db.Hotels
                    .Include(h=>h.Chambres)
                    .FirstOrDefaultAsync(h=> h.Id == id);

                var rooms = await db.Chambress.Where(r => r.Disponibilité && r.ReservationId == null).ToListAsync();
                var model = new ReserverChambreViewModel
                {
                    HotelId = id,
                    UserId = int.Parse(HttpContext.Session.GetString("Id")),
                };

                ViewBag.Rooms =rooms ?? new List<Chambre>(); ;
                return View(model);
            }
            return RedirectToAction("Login", "User");
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reserver(ReserverChambreViewModel model,int id)
        {
            if (ModelState.IsValid)
            {
                 
                
                    var reservation = new Reservation
                    {
                        Date = model.DateReservation,
                        Etat = "En attente",
                        UserId = model.UserId,
                        chambres = new List<Chambre>
                         {
                        await db.Chambress.FindAsync(model.RoomId)
                        }
                    };

                    db.Reservations.Add(reservation);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Payer","Paiment",new { id = model.HotelId });
                }
            // Marquer la chambre comme réservée
            var hotel = await db.Hotels
                .Include(h => h.Chambres)
                .FirstOrDefaultAsync(h => h.Id == id);

            ViewBag.Tables = hotel.Chambres; // Rechargez les tables disponibles si le modèle est invalide
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
                .Include(r => r.chambres) // Inclure les tables réservées
                    .ThenInclude(t => t.hotel) // Inclure les restaurants associés aux tables
                .ToListAsync();

            var viewModel = new ListerChambresReserverViewModel
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

            Reservation reservation = db.Reservations.Include(r => r.chambres).FirstOrDefault(r => r.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            var viewModel = new ModifierReservationChambreViewModel
            {
                Date = reservation.Date,
                Etat = reservation.Etat,
                user = user,
                PhotoPath = user.Photo,
                // Assigner d'autres propriétés au besoin
            };

            return View(viewModel);
        }


        [HttpPost]
        public IActionResult EditerReservation(int id, ModifierReservationChambreViewModel viewModel)
        {

            var reservation = db.Reservations.Include(r => r.chambres).FirstOrDefault(r => r.Id == id);
            if (reservation != null)
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






        //[HttpPost]
        //public async Task<RedirectToActionResult> SupprimerReservation(int id)
        //{
        //    // Trouver et charger toutes les chambres liées à la réservation
        //    var chambres = await db.Chambress.Where(c => c.ReservationId == id).ToListAsync();
        //    db.Chambress.RemoveRange(chambres);
        //    await db.SaveChangesAsync();

        //    // Maintenant, supprimez la réservation
        //    var reservation = await db.Reservations.FindAsync(id);
        //    if (reservation != null)
        //    {
        //        db.Reservations.Remove(reservation);
        //        await db.SaveChangesAsync();
        //    }

        //    return RedirectToAction("ListeReservations");
        //}








        public IActionResult Visit()
        {
            return View();
        }
    }
}
