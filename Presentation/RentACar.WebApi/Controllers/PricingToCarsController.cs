using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.DTOs.Concrete.PricingToCarDTOs;
using RentACar.Application.Features.CQRS.Commands.CarPricingCommands;
using RentACar.Application.Interfaces.Services;

namespace RentACar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingToCarsController : ControllerBase
    {
        private readonly IPricingToCarService _pricingToCarService;

        public PricingToCarsController(IPricingToCarService pricingToCarService)
        {
            _pricingToCarService = pricingToCarService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _pricingToCarService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _pricingToCarService.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreatePricingToCarDto createPricingToCarDto)
        {
            var result = await _pricingToCarService.AddAsync(createPricingToCarDto);
            if (result.Success)
            {
                return Created();
            }
            return BadRequest(result.Message);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdatePricingToCarDto updatePricingToCarDto)
        {
            var result = await _pricingToCarService.UpdateAsync(updatePricingToCarDto);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpDelete("Remove")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var result = await _pricingToCarService.DeleteAsync(id);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
