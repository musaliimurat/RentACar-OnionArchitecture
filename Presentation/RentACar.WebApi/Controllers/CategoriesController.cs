using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.DTOs.Concrete.CaregoryDTOs;
using RentACar.Application.Features.CQRS.Commands.CategoryCommands;
using RentACar.Application.Features.CQRS.Queries.CategoryQueries;
using RentACar.Application.Interfaces.Services;

namespace RentACategory.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _categoryService.GetAllCategoryAsync();
            if (result.Success)
            {
                return Ok(result);

            }
            else return BadRequest(result.Message);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _categoryService.GetCategoryByIdAsync(id);
            if (result.Success)
            {
                return Ok(result);

            }
            else return BadRequest(result.Message);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateCategoryDto createCategoryDto)
        {
            var result = await _categoryService.CreateCategoryAsync(createCategoryDto);
            if (result.Success)
            {
                return Created();
            }
            else return BadRequest(result.Message);

        }

        [HttpDelete("Remove")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var result = await _categoryService.DeleteCategoryAsync(id);
            if (result.Success)
            {
                return Ok("Delete Successfully!");
            }
            else return BadRequest(result.Message);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateCategoryDto updateCategoryDto)
        {
            var result = await _categoryService.UpdateCategoryAsync(updateCategoryDto);
            if (result.Success)
            {
                return Ok("Update Successfully!");
            }
            else return BadRequest(result.Message);
        }

    }
}
