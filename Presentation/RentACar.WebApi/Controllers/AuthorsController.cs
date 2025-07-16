using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.DTOs.Concrete.AuthorDTOs;
using RentACar.Application.Features.CQRS.Commands.AuthorCommands;
using RentACar.Application.Interfaces.Services;

namespace RentACar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _service;

        public AuthorsController(IAuthorService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAuthorsAsync();
            if (result.Success)
            {
                return Ok(result);

            }
            else return BadRequest(result.Message);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _service.GetAuthorByIdAsync(id);
            if (result.Success)
            {
                return Ok(result);

            }
            else return BadRequest(result.Message);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm] CreateAuthorDto createAuthorDto)
        {
            var result = await _service.CreateAuthorAsync(createAuthorDto);
            if (result.Success)
            {
                return Created();
            }
            else return BadRequest(result.Message);

        }

        [HttpDelete("Remove")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var result = await _service.DeleteAuthorAsync(id);
            if (result.Success)
            {
                return Ok("Delete Successfully!");
            }
            else return BadRequest(result.Message);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromForm] UpdateAuthorDto updateAuthorDto)
        {
            var result = await _service.UpdateAuthorAsync(updateAuthorDto);
            if (result.Success)
            {
                return Ok("Update Successfully!");
            }
            else return BadRequest(result.Message);
        }
    }
}
