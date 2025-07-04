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

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var car = await _carService.GetCarByIdAsync(id);
            if (car.Success)
            {
                UpdateCarVM updateCarVM = new()
                {
                    UpdateCarDto = new UpdateCarDto()
                    {
                        Id = car.Data.Id,
                        BrandId = car.Data.BrandId,
                        Model = car.Data.Model,
                        CoverImageUrl = car.Data.CoverImageUrl,
                        DetailImageUrl = car.Data.DetailImageUrl,
                        Km = car.Data.Km,
                        Transmission = car.Data.Transmission,
                        Seat = car.Data.Seat,
                        Luggage = car.Data.Luggage,
                        Fuel = car.Data.Fuel
                    },
                    GetAllBrandQueryResults = (await _brandService.GetAllBrandsAsync()).Data
                };
                return View(updateCarVM);
            }
            else
            {
                return View("Error", new { message = car.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCarVM updateCarVM)
        {

            string? coverImageUrl = updateCarVM.UpdateCarDto.CoverImageUrl;
            if (updateCarVM.UpdateCarDto.CoverImageUpload != null)
            {
                var coverImagePathList = await _uploadImageService.UploadImagesAsync(
                    new FormFileCollection { updateCarVM.UpdateCarDto.CoverImageUpload }, "assets/images/car", _env);
                coverImageUrl = "/" + coverImagePathList.FirstOrDefault();
            }

            string? detailImageUrl = updateCarVM.UpdateCarDto.DetailImageUrl;
            if (updateCarVM.UpdateCarDto.DetailImageUpload != null)
            {
                var detailImagePathList = await _uploadImageService.UploadImagesAsync(
                    new FormFileCollection { updateCarVM.UpdateCarDto.DetailImageUpload }, "assets/images/car", _env);
                detailImageUrl = "/" + detailImagePathList.FirstOrDefault();
            }
            var command = new UpdateCarCommand
            {
                Id = updateCarVM.UpdateCarDto.Id,
                BrandId = updateCarVM.UpdateCarDto.BrandId,
                Model = updateCarVM.UpdateCarDto.Model,
                CoverImageUrl = updateCarVM.UpdateCarDto.CoverImageUpload != null ? coverImageUrl : updateCarVM.UpdateCarDto.CoverImageUrl,
                DetailImageUrl = updateCarVM.UpdateCarDto.DetailImageUpload != null ? detailImageUrl : updateCarVM.UpdateCarDto.DetailImageUrl,
                Km = updateCarVM.UpdateCarDto.Km,
                Fuel = updateCarVM.UpdateCarDto.Fuel,
                Luggage = updateCarVM.UpdateCarDto.Luggage,
                Seat = updateCarVM.UpdateCarDto.Seat,
                Transmission = updateCarVM.UpdateCarDto.Transmission,
            };
            var result = await _carService.UpdateCarAsync(command);
            if (!result.Success)
            {
                if (result is ValidationErrorResult validationError)
                {
                    foreach (var error in validationError.Errors)
                    {
                        var key = $"UpdateCarDto.{error.PropertyName}";
                        ModelState.AddModelError(key, error.ErrorMessage);
                    }
                }
                updateCarVM.GetAllBrandQueryResults = (await _brandService.GetAllBrandsAsync()).Data;
                return View(updateCarVM);
            }
            return RedirectToAction("Index");
        }
    }
}
