using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.DTOs.Concrete.CarDescriptionDTOs;
using RentACar.Application.Interfaces.Services;

namespace RentACar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarDescriptionsController : ControllerBase
    {
        private readonly ICarDescriptionService _carDescriptionService;
        public CarDescriptionsController(ICarDescriptionService carDescriptionService)
        {
            _carDescriptionService = carDescriptionService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _carDescriptionService.GetAllCarDescriptionsAsync();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _carDescriptionService.GetCarDescriptionByIdAsync(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateCarDescriptionDto createCarDescriptionDto)
        {
            var result = await _carDescriptionService.CreateCarDescriptionAsync(createCarDescriptionDto);
            if (result.Success)
            {
                return Created();
            }
            return BadRequest(result.Message);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateCarDescriptionDto updateCarDescriptionDto)
        {
            var result = await _carDescriptionService.UpdateCarDescriptionAsync(updateCarDescriptionDto);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _carDescriptionService.DeleteCarDescriptionAsync(id);
            if (result.Success)
            {
                return NoContent();
            }
            return BadRequest(result.Message);
        }
    }
}
