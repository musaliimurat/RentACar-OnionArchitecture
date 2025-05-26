using Microsoft.AspNetCore.Mvc;

namespace RentACar.MVC.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.MyTitle = "About";
            ViewBag.Description = "About Us";
            return View();
        }
    }
}
