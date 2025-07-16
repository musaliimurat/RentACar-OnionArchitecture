using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.DTOs.Concrete.CarDto;
using RentACar.Application.Features.CQRS.Commands.CarCommands;
using RentACar.Application.Features.CQRS.Commands.CarCommands;
using RentACar.Application.Features.CQRS.Queries.CarQueries;
using RentACar.Application.Interfaces.Services;

namespace RentACar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _service;

        public CarsController(ICarService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllCarsAsync();
            if (result.Success)
            {
                return Ok(result);

            }
            else return BadRequest(result.Message);
        }

        [HttpGet("GetAllWithBrands")]
        public async Task<IActionResult> GetAllWithBrands(int page = 1, int pageSize = 3)
        {
            var result = await _service.GetAllCarsWithBrandsAsync(page, pageSize);
            if (result.Success)
            {
                return Ok(result);

            }
            else return BadRequest(result.Message);
        }


        [HttpGet("GetAllIsSlider")]
        public async Task<IActionResult> GetAllCarIsSlider()
        {
            var result = await _service.GetAllIsSliderCarsAsync();
            if (result.Success)
            {
                return Ok(result);

            }
            else return BadRequest(result.Message);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _service.GetCarByIdAsync(id);
            if (result.Success)
            {
                return Ok(result);

            }
            else return BadRequest(result.Message);
        }
        [HttpGet("GetCarWithDetailById/{id}")]
        public async Task<IActionResult> GetCarWithDetailById(Guid id)
        {
            var result = await _service.GetCarDetailByIdAsync(id);
            if (result.Success)
            {
                return Ok(result);

            }
            else return BadRequest(result.Message);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm] CreateCarDto createCarDto)
        {
            var result = await _service.CreateCarAsync(createCarDto);
            if (result.Success)
            {
                return Created();
            }
            else return BadRequest(result.Message);

        }

        [HttpDelete("Remove")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var result = await _service.DeleteCarAsync(id);
            if (result.Success)
            {
                return Ok("Delete Successfully!");
            }
            else return BadRequest(result.Message);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromForm] UpdateCarDto updateCarDto)
        {
            var result = await _service.UpdateCarAsync(updateCarDto);
            if (result.Success)
            {
                return Ok("Update Successfully!");
            }
            else return BadRequest(result.Message);
        }

    }
}
