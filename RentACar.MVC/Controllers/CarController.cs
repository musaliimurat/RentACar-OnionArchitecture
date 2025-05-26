using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Interfaces.Services;

namespace RentACar.MVC.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 3)
        {
            ViewBag.MyTitle = "Cars";
            ViewBag.Description = "Choose Your Car";
            var result = await _carService.GetAllCarsWithBrandsAsync(page, pageSize);
            if (result.Success)
            {
                return View(result.Data);
            }
            else
            {
                return View();
            }
        }
    }
}
