using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.DTOs.Concrete.PricingDTOs;
using RentACar.Application.Interfaces.Services;
using RentACar.Application.Utilities.Results.Concrete;

namespace RentACar.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PricingController : Controller
    {
        private readonly IPricingService _pricingService;
        private readonly IMapper _mapper;

        public PricingController(IMapper mapper, IPricingService pricingService)
        {
            _mapper = mapper;
            _pricingService = pricingService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _pricingService.GetAllPricingAsync();
            if (result.Success)
            {
                return View(result.Data);
            }
            else return View("Error", new { message = result.Message });
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePricingDto createPricingDto)
        {
            var result = await _pricingService.CreatePricingAsync(createPricingDto);
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
                return View(createPricingDto);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _pricingService.GetPricingByIdAsync(id);
            if (result.Success)
            {
                var mappedData = _mapper.Map<UpdatePricingDto>(result.Data);
                return View(mappedData);
            }
            else
            {
                return View("Error", new { message = result.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdatePricingDto updatePricingDto)
        {
            var result = await _pricingService.UpdatePricingAsync(updatePricingDto);
            if (result.Success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                if (result is ValidationErrorResult validationError)
                {
                    foreach (var error in validationError.Errors)
                    {
                        var key = $"{error.PropertyName}";
                        ModelState.AddModelError(key, error.ErrorMessage);
                    }
                }
                return View(updatePricingDto);
            }
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _pricingService.DeletePricingAsync(id);
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
