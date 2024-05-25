using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PFA.Context;
using PFA.Models;
using PFA.ModelView;

namespace PFA.Controllers
{
    public class UserController : Controller
    {
        

        MyContext db;
        public UserController(MyContext db)
        {
            this.db = db; 
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Inscription()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Inscription(ClientInscriptionModelView mv)
        {
            
                if (ModelState.IsValid)
                {
                    // verifier que le login(email) est unique
                    int count = db.Users.Where(us => us.Email == mv.Email).Count();
                    if (count == 0)
                    {
                        User u = new User(mv);
                         

                        db.Users.Add(u);
                        db.SaveChanges();

                        HttpContext.Session.SetString("Nom", u.Nom);
                        HttpContext.Session.SetString("Prenom", u.Prenom);
                        HttpContext.Session.SetString("Email", u.Email);
                    HttpContext.Session.SetString("Login", u.Login);
                     HttpContext.Session.SetString("Role", u.Role);
                        return RedirectToAction("Index", "Client");  
                }
                    ModelState.AddModelError("Email", "Email existe deja "); // anotation pour email deja existe il s'appelle annotation unique



                }
                return View();
            }


            //Login 
            public IActionResult Login() 
            {
            return View();
            }
        
        [HttpPost]
        public IActionResult Login(UserLoginModelView mv)
        {
            if (ModelState.IsValid)
            {
                User u = db.Users.Where(u => u.Login == mv.Login && u.Password == mv.Password).FirstOrDefault();
                
                if (u != null)
                {
                    HttpContext.Session.SetString("Id", u.Id.ToString());
                    HttpContext.Session.SetString("Nom", u.Nom);
                    HttpContext.Session.SetString("Prenom", u.Prenom);
                    HttpContext.Session.SetString("Email", u.Email);
                    HttpContext.Session.SetString("Login", u.Login);
                    HttpContext.Session.SetString("Telephone",u.Telephone);
                    HttpContext.Session.SetString("Role", u.Role);
                    if (u.Role == "Client")
                    {
                        return RedirectToAction("AfficherStatistique", "Client");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Admin");

                    }
                }
                ModelState.AddModelError("Login", "Le Login ou Le password errone");

            }
            return View();
        }


        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Login");
        }

    }
    }

