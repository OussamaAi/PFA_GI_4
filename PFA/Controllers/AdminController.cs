using Microsoft.AspNetCore.Mvc;
using PFA.Filters;

namespace PFA.Controllers
{    
	[AuthFilter]
	public class AdminController : Controller
	{
		
		public IActionResult Index()
		{
			return View();
		}
 
    }
}
