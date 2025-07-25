using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.DTOs.Concrete.BannerDTOs;
using RentACar.Application.Interfaces.Services;
using RentACar.Common.Utilities.Results.Concrete;

namespace RentACar.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BannerController : Controller
    {
        private readonly IBannerService _bannerService;
        private readonly IMapper _mapper;

        public BannerController(IBannerService bannerService, IMapper mapper)
        {
            _bannerService = bannerService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _bannerService.GetAllBannerAsync();
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
        public async Task<IActionResult> Create(CreateBannerDto createBannerDto)
        {
            var result = await _bannerService.CreateBannerAsync(createBannerDto);
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
                return View(createBannerDto);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var banner = await _bannerService.GetBannerByIdAsync(id);
            if (banner.Success)
            {
                var mappedData = _mapper.Map<UpdateBannerDto>(banner.Data);
                return View(mappedData);
            }
            else
            {
                return View("Error", new { message = banner.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateBannerDto updateBannerDto)
        {
            var result = await _bannerService.UpdateBannerAsync(updateBannerDto);
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
                return View(updateBannerDto);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var banner = await _bannerService.GetBannerByIdAsync(id);
            if (banner.Success)
            {
                var result = await _bannerService.DeleteBannerAsync(id);
                if (result.Success)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Error", new { message = result.Message });
                }
            }
            else
            {
                return View("Error", new { message = banner.Message });
            }
        }
    }
}
