using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Interfaces.Services;

namespace RentACar.MVC.Controllers
{
    public class PricingController : Controller
    {
        private readonly ICarService _carService;

        public PricingController(ICarService carService)
        {
            _carService = carService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.MyTitle = "Pricing";
            ViewBag.Description = "Car Pricing";

            var result = await _carService.GetAllCarsToPriceListsAsync();
            if (result.Success)
            {
                return View(result.Data);

            }
            else return View();
        }
    }
}
