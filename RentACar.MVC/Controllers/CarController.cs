using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Interfaces.Services;
using RentACar.MVC.ViewModels;

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

        public async Task<IActionResult> Detail(Guid id)
        {
            ViewBag.MyTitleOne = "Car";
            ViewBag.MyTitle = "Car Detail";
            ViewBag.Description = "Car Detail";
            var result = await _carService.GetCarDetailByIdAsync(id);
            var allCarsSliderResult = await _carService.GetAllIsSliderCarsAsync();
            if (result.Success && allCarsSliderResult.Success)
            {
                CarVM carVM = new()
                {
                    GetCarByIdDto = result.Data,
                    GetAllCarsSliderDtos = allCarsSliderResult.Data
                };
                return View(carVM);
            }
            else
            {
                return View();
            }
        }
    }
}
