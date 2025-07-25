using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.DTOs.Concrete.FeatureDto;
using RentACar.Application.DTOs.Concrete.FeatureToCarDTOs;
using RentACar.Application.Interfaces.Services;
using RentACar.Common.Utilities.Results.Concrete;
using RentACar.MVC.Areas.Admin.ViewModels;

namespace RentACar.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CarFeatureController : Controller
    {
        private readonly IFeatureToCarService _featureToCarService;
        private readonly ICarService _carService;
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public CarFeatureController(IMapper mapper, IFeatureToCarService featureToCarService, IFeatureService featureService, ICarService carService)
        {
            _mapper = mapper;
            _featureToCarService = featureToCarService;
            _featureService = featureService;
            _carService = carService;
        }

        public async Task<IActionResult> Index()
        {
            var features = await _featureToCarService.GetAllFeatureToCarsAsync();
            if (features.Success)
            {
                return View(features.Data);
            }
            else return View("Error", features.Message);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var cars  = await _carService.GetAllCarsWithBrandsForAdminAsync();
            var features = await _featureService.GetAllFeaturesAsync();
            if (cars.Success && features.Success)
            {
                FeatureToCarVM createFeatureToCarVM = new()
                {
                    GetAllCarsWithBrandNameForAdminDtos = cars.Data,
                    GetAllFeatureDtos = features.Data,
                };
                return View(createFeatureToCarVM);
            }
            else
            {
                return View("Error", "Error fetching data for creating feature to car.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(FeatureToCarVM featureToCarVM)
        {
            var result = await _featureToCarService.CreateFeatureToCarAsync(featureToCarVM.CreateFeatureToCarDto);
            if (!result.Success)
            {
                if (result is ValidationErrorResult validationError)
                {
                    foreach (var error in validationError.Errors)
                    {
                        var key = $"{error.PropertyName}";
                        ModelState.AddModelError(key, error.ErrorMessage);
                    }
                }
                var cars = await _carService.GetAllCarsWithBrandsForAdminAsync();
                var features = await _featureService.GetAllFeaturesAsync();
                if (cars.Success && features.Success)
                {
                    featureToCarVM.GetAllCarsWithBrandNameForAdminDtos = cars.Data;
                    featureToCarVM.GetAllFeatureDtos = features.Data;
                }
               
                return View(featureToCarVM);
            }
            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var featureToCar = await _featureToCarService.GetFeatureToCarByIdAsync(id);
            var cars = await _carService.GetAllCarsWithBrandsForAdminAsync();
            var features = await _featureService.GetAllFeaturesAsync();
            if (featureToCar.Success)
            {
                var mappedData = _mapper.Map<UpdateFeatureToCarDto>(featureToCar.Data);
                UpdateFeatureToCarVM updateFeatureToCarVM = new()
                {
                    UpdateFeatureToCarDto = mappedData,
                    GetAllCarsWithBrandNameForAdminDtos = cars.Data,
                    GetAllFeatureDtos = features.Data
                };
                return View(updateFeatureToCarVM);
            }
            else
            {
                return View("Error", featureToCar.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateFeatureToCarVM updateFeatureToCarVM)
        {
            var result = await _featureToCarService.UpdateFeatureToCarAsync(updateFeatureToCarVM.UpdateFeatureToCarDto);
            if (!result.Success)
            {
                if (result is ValidationErrorResult validationError)
                {
                    foreach (var error in validationError.Errors)
                    {
                        var key = $"{error.PropertyName}";
                        ModelState.AddModelError(key, error.ErrorMessage);
                    }
                }
                var cars = await _carService.GetAllCarsWithBrandsForAdminAsync();
                var features = await _featureService.GetAllFeaturesAsync();
                updateFeatureToCarVM.GetAllCarsWithBrandNameForAdminDtos = cars.Data;
                updateFeatureToCarVM.GetAllFeatureDtos = features.Data;
                return View(updateFeatureToCarVM);
            }
            return RedirectToAction("Index");

        }


        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _featureToCarService.DeleteFeatureToCarAsync(id);
            if (result.Success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Error", result.Message);
            }
        }
    }
}
