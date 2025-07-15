using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.DTOs.Concrete.PricingToCarDTOs;
using RentACar.Application.Interfaces.Services;
using RentACar.Application.Utilities.Results.Concrete;
using RentACar.MVC.Areas.Admin.ViewModels;

namespace RentACar.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PricingToCarController : Controller
    {
        private readonly ICarService _carService;
        private readonly IPricingToCarService _pricingToCarService;
        private readonly IPricingService _pricingService;
        private readonly IMapper _mapper;

        public PricingToCarController(ICarService carService, IMapper mapper, IPricingToCarService pricingToCarService, IPricingService pricingService)
        {
            _carService = carService;
            _mapper = mapper;
            _pricingToCarService = pricingToCarService;
            _pricingService = pricingService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _pricingToCarService.GetAllForAdminAsync();
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
            var pricingList = await _pricingService.GetAllPricingAsync();
            if (cars.Success && pricingList.Success)
            {
                var pricingToCarVM = new PricingToCarVM
                {
                    GetAllCarsWithBrandNameForAdminDtos = cars.Data,
                    GetAllPricingDtos = pricingList.Data,
                };
                return View(pricingToCarVM);

            }
            else return View("Error", "Error fetching data for creating pricing to car.");
        }

        [HttpPost]
        public async Task<IActionResult> Create(PricingToCarVM pricingToCarVM)
        {
            var result = await _pricingToCarService.AddAsync(pricingToCarVM.CreatePricingToCarDto);
            if (!result.Success)
            {
                if (result is ValidationErrorResult validationError)
                {
                    foreach (var error in validationError.Errors)
                    {
                        var key = $"CreatePricingToCarDto.{error.PropertyName}";
                        ModelState.AddModelError(key, error.ErrorMessage);
                    }
                }
                var cars = await _carService.GetAllCarsWithBrandsForAdminAsync();
                var pricingList = await _pricingService.GetAllPricingAsync();
                if (pricingList.Success && cars.Success)
                {
                    pricingToCarVM.GetAllPricingDtos = pricingList.Data;
                    pricingToCarVM.GetAllCarsWithBrandNameForAdminDtos = cars.Data;
                }
                return View(pricingToCarVM);
            }
            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _pricingToCarService.GetByIdForAdminAsync(id);
            if (result.Success)
            {
                var mappedData = _mapper.Map<UpdatePricingToCarDto>(result.Data);
                var pricingToCarVM = new UpdatePricingToCarVM
                {
                    UpdatePricingToCarDto = mappedData,
                    GetAllCarsWithBrandNameForAdminDtos = (await _carService.GetAllCarsWithBrandsForAdminAsync()).Data,
                    GetAllPricingDtos = (await _pricingService.GetAllPricingAsync()).Data
                };

                return View(pricingToCarVM);
            }
            else return View("Error", new { message = result.Message });
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdatePricingToCarVM pricingToCarVM)
        {
            var result = await _pricingToCarService.UpdateAsync(pricingToCarVM.UpdatePricingToCarDto);
            if (!result.Success)
            {
                if (result is ValidationErrorResult validationError)
                {
                    foreach (var error in validationError.Errors)
                    {
                        var key = $"UpdatePricingToCarDto.{error.PropertyName}";
                        ModelState.AddModelError(key, error.ErrorMessage);
                    }
                }
                var cars = await _carService.GetAllCarsWithBrandsForAdminAsync();
                var pricingList = await _pricingService.GetAllPricingAsync();
                pricingToCarVM.GetAllCarsWithBrandNameForAdminDtos = cars.Data;
                pricingToCarVM.GetAllPricingDtos = pricingList.Data;
                return View(pricingToCarVM);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _pricingToCarService.DeleteAsync(id);
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
