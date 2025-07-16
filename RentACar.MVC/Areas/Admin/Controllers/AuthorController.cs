using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.DTOs.Concrete.AuthorDTOs;
using RentACar.Application.Interfaces.Services;
using RentACar.Application.Utilities.Results.Concrete;

namespace RentACar.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;
        private readonly IUploadImageService _uploadImageService;
        private readonly IWebHostEnvironment _env;

        public AuthorController(IMapper mapper, IAuthorService authorService, IUploadImageService uploadImageService, IWebHostEnvironment env)
        {
            _mapper = mapper;
            _authorService = authorService;
            _uploadImageService = uploadImageService;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            var authors = await _authorService.GetAllAuthorsAsync();
            if (authors.Success)
            {
                return View(authors.Data);
            }
            else return View("Error", new { message = authors.Message });
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAuthorDto createAuthorDto)
        {

            var imagePathList = await _uploadImageService.UploadImagesAsync(
                new FormFileCollection { createAuthorDto.ImageFile }, "assets/images/author", _env);
            var imageUrl = imagePathList.FirstOrDefault();
            createAuthorDto.ImageUrl = "/" + imageUrl;
            var result = await _authorService.CreateAuthorAsync(createAuthorDto);
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

                return View(createAuthorDto);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var author = await _authorService.GetAuthorByIdAsync(id);
            if (author.Success)
            {
                var updateAuthorDto = _mapper.Map<UpdateAuthorDto>(author.Data);
                return View(updateAuthorDto);
            }
            else
            {
                return View("Error", new { message = author.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateAuthorDto updateAuthorDto)
        {
            string? imageUrl = updateAuthorDto.ImageUrl;
            if (updateAuthorDto.ImageFile != null)
            {
                var imagePathList = await _uploadImageService.UploadImagesAsync(
                    new FormFileCollection { updateAuthorDto.ImageFile }, "assets/images/author", _env);
                imageUrl = "/" + imagePathList.FirstOrDefault();
            }
            updateAuthorDto.ImageUrl = updateAuthorDto.ImageFile != null ? imageUrl : updateAuthorDto.ImageUrl;

            var result = await _authorService.UpdateAuthorAsync(updateAuthorDto);
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
                return View(updateAuthorDto);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _authorService.DeleteAuthorAsync(id);
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
