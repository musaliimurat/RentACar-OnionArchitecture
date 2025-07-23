using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.DTOs.Concrete.BlogDTOs;
using RentACar.Application.Interfaces.Services;
using RentACar.Application.Utilities.Results.Concrete;
using RentACar.MVC.Areas.Admin.ViewModels;

namespace RentACar.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IAuthorService _authorService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public BlogController(IBlogService blogService, ICategoryService categoryService, IAuthorService authorService, IMapper mapper)
        {
            _blogService = blogService;
            _categoryService = categoryService;
            _authorService = authorService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _blogService.GetAllBlogForAdminAsync();
            if (result.Success)
            {
                return View(result.Data);
            }
            else return View("Error", new { message = result.Message });
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var authors = await _authorService.GetAllAuthorsAsync();
            var categories = await _categoryService.GetAllCategoryAsync();
            if (authors.Success && categories.Success)
            {
                BlogVM blogVM = new()
                {
                    GetAllAuthorDtos = authors.Data,
                    GetAllCategoryDtos = categories.Data
                };
                return View(blogVM);
            }
            else
            {
                return View("Error", new { message = "Error fetching authors or categories." });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(BlogVM blogVM)
        {
            var result = await _blogService.CreateBlogAsync(blogVM.CreateBlogDto);
            if (!result.Success)
            {
                if (result is ValidationErrorResult validationError)
                {
                    foreach (var error in validationError.Errors)
                    {
                        var key = $"CreateBlogDto.{error.PropertyName}";
                        ModelState.AddModelError(key, error.ErrorMessage);
                    }
                }
                var authors = await _authorService.GetAllAuthorsAsync();
                var categories = await _categoryService.GetAllCategoryAsync();
                blogVM.GetAllAuthorDtos = authors.Data;
                blogVM.GetAllCategoryDtos = categories.Data;
                return View(blogVM);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _blogService.GetBlogByIdAsync(id);

            if (result.Success)
            {
                var authors = await _authorService.GetAllAuthorsAsync();
                var categories = await _categoryService.GetAllCategoryAsync();

                var mappedBlog = _mapper.Map<UpdateBlogDto>(result.Data);
                UpdateBlogVM updateBlogVM = new()
                {
                    UpdateBlogDto = mappedBlog,
                    GetAllAuthorDtos = authors.Data,
                    GetAllCategoryDtos = categories.Data
                };
                return View(updateBlogVM);
            }
            else
            {
                return View("Error", new { message = result.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateBlogVM updateBlogVM)
        {

            var result = await _blogService.UpdateBlogAsync(updateBlogVM.UpdateBlogDto);
            if (!result.Success)
            {
                if (result is ValidationErrorResult validationError)
                {
                    foreach (var error in validationError.Errors)
                    {
                        var key = $"UpdateBlogDto.{error.PropertyName}";
                        ModelState.AddModelError(key, error.ErrorMessage);
                    }
                }
                var authors = await _authorService.GetAllAuthorsAsync();
                var categories = await _categoryService.GetAllCategoryAsync();
                updateBlogVM.GetAllAuthorDtos = authors.Data;
                updateBlogVM.GetAllCategoryDtos = categories.Data;
                return View(updateBlogVM);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _blogService.DeleteBlogAsync(id);
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
