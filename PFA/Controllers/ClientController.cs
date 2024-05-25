using AuthSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PFA.Context;
using PFA.Filters;
using PFA.Models;
using PFA.ModelView;
using PFA.Visite;
using System.Diagnostics.Metrics;

namespace PFA.Controllers
{

    [AuthFilter]
    public class ClientController : Controller
    { 
        private readonly IWebHostEnvironment _webHostEnvironment;
        MyContext db;
        private readonly IVisitService _visitService;

        

        
        public ClientController(MyContext db, IWebHostEnvironment webHostEnvironment, IVisitService visitService)
        {
            this.db = db;
            _webHostEnvironment = webHostEnvironment;
            _visitService = visitService;
        }

        public async Task<IActionResult> AfficherStatistique()
        {
            var statistics = await _visitService.GetVisitStatistics();
            var userInfo = await _visitService.GetUserInfo();

            ViewData["UserPhotoPath"] = userInfo.PhotoPath;
            ViewData["UserName"] = userInfo.user;

            var model =new StatistiqueViewModel
            {
                VisitStatistics = statistics,
                PhotoPath = userInfo.PhotoPath,
                user=userInfo.user,
            };
            
            return View(model);
        }

        public IActionResult Index()
        {
            User user = db.Users.Where(l => l.Login == HttpContext.Session.GetString("Login")).FirstOrDefault();
            if (user != null)
            {
                var client = new ClientModifierProfilModelView()
                {
                    Nom = user.Nom,
                    Prenom = user.Prenom,
                    Email = user.Email,
                    Login = user.Login,
                    Telephone = user.Telephone,
                    PhotoPath = user.Photo,
                };
                return View(client);

            }
            return View();
        }
        public IActionResult ModifierProfil()
        {

            User user = db.Users.Where(l => l.Login == HttpContext.Session.GetString("Login")).FirstOrDefault();
            if (user != null)
            {
                var client = new ClientModifierProfilModelView()
                { Nom = user.Nom,
                    Prenom = user.Prenom,
                    Email = user.Email,
                    Login = user.Login,
                    Telephone = user.Telephone,
                    PhotoPath = user.Photo,
                };



                return View("ModifierProfil", client);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        public IActionResult ModifierProfil(ClientModifierProfilModelView mv)
        {
              
                 User user = db.Users.FirstOrDefault(u => u.Email == HttpContext.Session.GetString("Email"));
                if (user != null)
                {
                    if (mv.Photo != null && (mv.Photo.FileName.EndsWith(".jpeg") || mv.Photo.FileName.EndsWith(".jpg") || mv.Photo.FileName.EndsWith(".png")) && mv.Photo.Length < 100000)
                    {
                        string nomFichier = Guid.NewGuid().ToString() + Path.GetExtension(mv.Photo.FileName);
                        string cheminFichier = Path.Combine(_webHostEnvironment.WebRootPath, "ProfilImage", nomFichier);

                         //string p = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot","ProfilImage", mv.Photo.FileName);
                        using (var file = new FileStream(cheminFichier, FileMode.Create))
                        {
                            mv.Photo.CopyTo(file);

                        }
                        user.Photo = nomFichier;

                    }
                    
                        user.Nom = mv.Nom;
                        user.Email = mv.Email;
                        user.Prenom = mv.Prenom;
                        user.Login = mv.Login;
                        user.Telephone = mv.Telephone;
                        
                        db.SaveChanges();
                    HttpContext.Session.SetString("Nom", user.Nom);
                    HttpContext.Session.SetString("Prenom", user.Prenom);
                    HttpContext.Session.SetString("Login", user.Login);
                    HttpContext.Session.SetString("Email", user.Email);
                    HttpContext.Session.SetString("Telephone",user.Telephone);
                HttpContext.Session.SetString("Photo",user.Photo);

                var ModifieClient = new ClientModifierProfilModelView(user);
                


                return View(ModifieClient);
                }      
                  
                     return RedirectToAction("Index");
                                
                }

        [HttpGet]
        public IActionResult DemanderPlan()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DemanderPlan(string ville)
        {
            var listLieu=db.Endroits.OrderBy(item => item.Id).Take(5).ToList();
            ViewBag.listLieu = listLieu;

            var listHotel = db.Endroits.OrderBy(item => item.Id).Skip(5).Take(4).ToList();
            ViewBag.listHotel = listHotel;

            var listRestarants = db.Endroits.OrderBy(item => item.Id).Skip(9).Take(5).ToList();
            ViewBag.listRestarants = listRestarants;
         
            return View();
        }



    } 
}
        
    

