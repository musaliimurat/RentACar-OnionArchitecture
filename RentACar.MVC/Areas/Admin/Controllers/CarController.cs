using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.DTOs.Concrete.CarDto;
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
        private readonly IMapper _mapper;

        public CarController(ICarService carService, IBrandService brandService, IMapper mapper)
        {
            _carService = carService;
            _brandService = brandService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var cars = await _carService.GetAllCarsWithBrandsForAdminAsync();
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
                GetAllBrandDto = brands.Data,
            };

            if (carVM.GetAllBrandDto.Count != 0)
            {
                return View(carVM);
            }
            else return View("Error", new { message = "Error" });

        }

        [HttpPost]
        public async Task<IActionResult> Create(CarVM carVM)
        {
          

            var result = await _carService.CreateCarAsync(carVM.CreateCarDto);
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
                carVM.GetAllBrandDto = brands.Data;

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
                var brands = await _brandService.GetAllBrandsAsync();

                var mappedCar = _mapper.Map<UpdateCarDto>(car.Data);
                UpdateCarVM updateCarVM = new()
                {
                    UpdateCarDto = mappedCar,
                    GetAllBrandDto = brands.Data,
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
            var brands = await _brandService.GetAllBrandsAsync();
            
            var result = await _carService.UpdateCarAsync(updateCarVM.UpdateCarDto);
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
                updateCarVM.GetAllBrandDto = brands.Data;
                return View(updateCarVM);
            }
            return RedirectToAction("Index");
        }
    }
}
