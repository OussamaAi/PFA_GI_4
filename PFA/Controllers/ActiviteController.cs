using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PFA.Context;
using PFA.Models;
using PFA.ModelView;
using PFA.Visite;

namespace PFA.Controllers
{
    public class ActiviteController : Controller
    {
        private readonly VisitService _visitService;
        private readonly MyContext db;

        public ActiviteController(MyContext db, VisitService visitService)
        {
            this.db = db;
            _visitService = visitService;
        }


        public async Task<IActionResult> Details(int id)
        {
            var activites = await db.LieuTouristiques
                .Where(a => a.Id == id)
                .Select(r => new ListerActivieViewModelcs
                {
                    Id = r.Id,
                    NomEndroit = r.NomEndroit,                  
                    NbrEtoile = r.NbrEtoile,
                    Addresse = r.Addresse,
                    Image = r.Image
                })
                .FirstOrDefaultAsync();

            if (activites == null)
            {
                return NotFound();
            }

            if(HttpContext.Session.GetString("Id")!=null) 
            {
                var clientIdString = HttpContext.Session.GetString("Id");
                if (int.TryParse(clientIdString, out int clientId))
                {
                    await _visitService.TrackVisit(clientId, id);
                } 
            }
            
            //else
            //{
            //   throw new InvalidOperationException("Client ID is not found in the session.");
            //}


            return View(activites);
        }










    }
}
 
