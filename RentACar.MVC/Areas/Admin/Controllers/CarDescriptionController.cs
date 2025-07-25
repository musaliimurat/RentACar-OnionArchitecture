using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.DTOs.Concrete.CarDescriptionDTOs;
using RentACar.Application.Interfaces.Services;
using RentACar.Common.Utilities.Results.Concrete;
using RentACar.Domain.Entities.Concrete;
using RentACar.MVC.Areas.Admin.ViewModels;

namespace RentACar.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CarDescriptionController : Controller
    {
        private readonly ICarDescriptionService _carDescriptionService;
        private readonly ICarService _carService;
        private readonly IMapper _mapper;

        public CarDescriptionController(IMapper mapper, ICarDescriptionService carDescriptionService, ICarService carService)
        {
            _mapper = mapper;
            _carDescriptionService = carDescriptionService;
            _carService = carService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _carDescriptionService.GetAllCarDescriptionsAsync();
            if (result.Success)
            {
                var cars = result.Data;
                return View(cars);
            }

            else return View("Error", new { message = result.Message });
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var cars = await _carService.GetAllCarsWithBrandsForAdminAsync();
            if (cars.Success)
            {
                var carDescriptionVM = new CarDescriptionVM
                {
                    GetAllCarsWithBrandNameForAdminDtos = cars.Data,
                };
                return View(carDescriptionVM);
            }
            else
            {
                return View("Error", new { message = cars.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarDescriptionVM carDescriptionVM)
        {
            var result = await _carDescriptionService.CreateCarDescriptionAsync(carDescriptionVM.CreateCarDescriptionDto);
            if (!result.Success)
            {
                if (result is ValidationErrorResult validationError)
                {
                    foreach (var error in validationError.Errors)
                    {
                        var key = $"CreateCarDescriptionDto.{error.PropertyName}";
                        ModelState.AddModelError(key, error.ErrorMessage);
                    }
                }
                var cars = await _carService.GetAllCarsWithBrandsForAdminAsync();
                if (cars.Success)
                {
                    carDescriptionVM.GetAllCarsWithBrandNameForAdminDtos = cars.Data;
                }
                return View(carDescriptionVM);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var carDescription = await _carDescriptionService.GetCarDescriptionByIdAsync(id);
            if (carDescription.Success)
            {
                var mappedData = _mapper.Map<UpdateCarDescriptionDto>(carDescription.Data);
                var cars = await _carService.GetAllCarsWithBrandsForAdminAsync();
                UpdateCarDescriptionVM updateCarDescriptionVM = new()
                {
                    UpdateCarDescriptionDto = mappedData,
                    GetAllCarsWithBrandNameForAdminDtos = cars.Data
                };
                return View(updateCarDescriptionVM);
            }
            else
            {
                return View("Error", carDescription.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCarDescriptionVM updateCarDescriptionVM)
        {
            var result = await _carDescriptionService.UpdateCarDescriptionAsync(updateCarDescriptionVM.UpdateCarDescriptionDto);
            if (!result.Success)
            {
                if (result is ValidationErrorResult validationError)
                {
                    foreach (var error in validationError.Errors)
                    {
                        var key = $"UpdateCarDescriptionDto.{error.PropertyName}";
                        ModelState.AddModelError(key, error.ErrorMessage);
                    }
                }
                var cars = await _carService.GetAllCarsWithBrandsForAdminAsync();
                if (cars.Success)
                {
                    updateCarDescriptionVM.GetAllCarsWithBrandNameForAdminDtos = cars.Data;
                }
                return View(updateCarDescriptionVM);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _carDescriptionService.DeleteCarDescriptionAsync(id);
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
