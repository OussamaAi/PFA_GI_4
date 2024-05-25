using Microsoft.AspNetCore.Mvc;
using PFA.ModelView;

namespace PFA.Controllers
{
    public class PaimentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Payer(int id)
        {
            var model = new PaymentViewModel { ReservationId = id };
            return View(model);
        }

        [HttpPost]
        public IActionResult Payer(PaymentViewModel model)
        {
            if (ModelState.IsValid)
            {
              

            return RedirectToAction("Confirmation", new { reservationId = model.ReservationId });

            }
            return View(model);
        }

         


        [HttpGet]
        public IActionResult Confirmation(int reservationId)
        {
            ViewBag.ReservationId = reservationId;
            return View();
        }
    }
}
