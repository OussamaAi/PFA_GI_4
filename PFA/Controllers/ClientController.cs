using Microsoft.AspNetCore.Mvc;
using PFA.Context;
using PFA.Filters;
using PFA.Models;
using PFA.ModelView;
using System.Diagnostics.Metrics;

namespace PFA.Controllers
{

    [AuthFilter]
    public class ClientController : Controller
    { 
        private readonly IWebHostEnvironment _webHostEnvironment;
        MyContext db;
        public ClientController(MyContext db, IWebHostEnvironment webHostEnvironment)
        {
            this.db = db;
            _webHostEnvironment = webHostEnvironment;
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
            
          
            
                } 
             }
        
    

