using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.DTOs.Concrete.FeatureDto;
using RentACar.Application.Interfaces.Services;
using RentACar.Application.Utilities.Results.Concrete;

namespace RentACar.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeatureController : Controller
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public FeatureController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _featureService.GetAllFeaturesAsync();
            if (result.Success)
            {
                return View(result.Data);
            }
            else
            {
                return View("Error", new { message = result.Message });
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFeatureDto createFeatureDto)
        {

            var result = await _featureService.CreateFeatureAsync(createFeatureDto);
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
                return View(createFeatureDto);
            }
            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _featureService.GetFeatureByIdAsync(id);
            if (result.Success)
            {
                var mappedData = _mapper.Map<UpdateFeatureDto>(result.Data);
                return View(mappedData);
            }
            else
            {
                return View("Error", new { message = result.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateFeatureDto updateFeatureDto)
        {
            var result = await _featureService.UpdateFeatureAsync(updateFeatureDto);
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
                return View(updateFeatureDto);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _featureService.DeleteFeatureAsync(id);
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
