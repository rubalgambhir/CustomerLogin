using Microsoft.AspNetCore.Mvc;

namespace CustomerLogin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }
    }
}
