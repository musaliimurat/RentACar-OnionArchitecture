using Microsoft.AspNetCore.Mvc;
using RentACar.Application.DTOs.Concrete.CarDto;
using RentACar.Application.Features.CQRS.Commands.CarCommands;
using RentACar.Application.Interfaces.Services;
using RentACar.Application.Utilities.Results.Concrete;
using RentACar.MVC.Areas.Admin.ViewModels;

namespace RentACar.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CarController : Controller
    {
        private readonly ICarService _carService;
        private readonly IBrandService _brandService;
        private readonly IUploadImageService _uploadImageService;
        private readonly IWebHostEnvironment _env;

        public CarController(ICarService carService, IBrandService brandService, IWebHostEnvironment env, IUploadImageService uploadImageService)
        {
            _carService = carService;
            _brandService = brandService;
            _env = env;
            _uploadImageService = uploadImageService;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 30000000)
        {
            var cars = await _carService.GetAllCarsWithBrandsAsync(page, pageSize);
            if (cars.Success)
                return View(cars.Data);
            else return View("Error", new { message = cars.Message });
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {

            var brands = await _brandService.GetAllBrandsAsync();
            CarVM carVM = new()
            {
                GetAllBrandQueryResults = brands.Data,
                CreateCarDto = new CreateCarDto()
            };

            if (carVM.GetAllBrandQueryResults.Count != 0)
            {
                return View(carVM);
            }
            else return View("Error", new { message = "Error" });

        }

        [HttpPost]
        public async Task<IActionResult> Create(CarVM carVM)
        {

            var coverImagePathList = await _uploadImageService.UploadImagesAsync(
                          new FormFileCollection { carVM.CreateCarDto.CoverImageUrl }, "assets/images/car", _env);
            var coverImageUrl = coverImagePathList.FirstOrDefault();

            var detailImagePathList = await _uploadImageService.UploadImagesAsync(
                                       new FormFileCollection { carVM.CreateCarDto.DetailImageUrl }, "assets/images/car", _env);

            var detailImageUrl = detailImagePathList.FirstOrDefault();

            CreateCarDto car = carVM.CreateCarDto;
            var command = new CreateCarCommand
            {
                BrandId = car.BrandId,
                Model = car.Model,
                Fuel = car.Fuel,
                Km = car.Km,
                Luggage = car.Luggage,
                Seat = car.Seat,
                Transmission = car.Transmission,
                CoverImageUrl = "/" + coverImageUrl,
                DetailImageUrl = "/" + detailImageUrl,
            };

            var result = await _carService.CreateCarAsync(command);
            if (!result.Success)
            {
                if (result is ValidationErrorResult validationError)
                {
                    foreach (var error in validationError.Errors)
                    {
                        var key = $"CreateCarDto.{error.PropertyName}";
                        ModelState.AddModelError(key, error.ErrorMessage);
                    }
                }
                var brands = await _brandService.GetAllBrandsAsync();
                carVM.GetAllBrandQueryResults = brands.Data;

                return View(carVM);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _carService.DeleteCarAsync(id);
            if (result.Success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Error", new { message = result.Message });
            }
        }
    }
}
