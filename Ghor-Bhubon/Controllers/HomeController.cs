using Microsoft.AspNetCore.Mvc;

namespace Ghor_Bhubon.Controllers
{
    public class HomeController : Controller
    {
        // This action returns the homepage with Login and Register options
        public IActionResult Index()
        {
            return View();
        }
    }
}
