using Microsoft.AspNetCore.Mvc;

namespace RentACar.MVC.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
