using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.DTOs.Concrete.CaregoryDTOs;
using RentACar.Application.Interfaces.Services;
using RentACar.Application.Utilities.Results.Concrete;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RentACar.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllCategoryAsync();
            if (categories.Success)
            {
                return View(categories.Data);
            }
            else return View("Error", new { message = categories.Message });
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto createCategoryDto)
        {
            var result = await _categoryService.CreateCategoryAsync(createCategoryDto);
            if (!result.Success)
            {
                if (result is ValidationErrorResult validationErrorResult)
                {
                    foreach (var error in validationErrorResult.Errors)
                    {
                        var key = $"{error.PropertyName}";
                        ModelState.AddModelError(key, error.ErrorMessage);
                    }
                    return View(createCategoryDto);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category.Success)
            {
                var updateCategoryDto = _mapper.Map<UpdateCategoryDto>(category.Data);
                return View(updateCategoryDto);
            }
            else return View("Error", new { message = category.Message });
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCategoryDto updateCategoryDto)
        {
            var result = await _categoryService.UpdateCategoryAsync(updateCategoryDto);
            if (!result.Success)
            {
                if (result is ValidationErrorResult validationErrorResult)
                {
                    foreach (var error in validationErrorResult.Errors)
                    {
                        var key = $"{error.PropertyName}";
                        ModelState.AddModelError(key, error.ErrorMessage);
                    }
                    return View(updateCategoryDto);
                }
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _categoryService.DeleteCategoryAsync(id);
            if (!result.Success)
            {
                return View("Error", new { message = result.Message });
            }
            return RedirectToAction("Index");
        }
    }
}
