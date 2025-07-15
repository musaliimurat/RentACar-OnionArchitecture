using Microsoft.AspNetCore.Mvc;
using RentACar.Application.DTOs.Concrete.PricingDTOs;
using RentACar.Application.Interfaces.Services;

namespace RentACar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingsController : ControllerBase
    {
        private readonly IPricingService _pricingService;
        public PricingsController(IPricingService pricingService)
        {
            _pricingService = pricingService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _pricingService.GetAllPricingAsync();
            if (result.Success)
            {
                return Ok(result);

            }
            else return BadRequest(result.Message);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _pricingService.GetPricingByIdAsync(id);
            if (result.Success)
            {
                return Ok(result);

            }
            else return BadRequest(result.Message);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreatePricingDto createPricingDto)
        {
            var result = await _pricingService.CreatePricingAsync(createPricingDto);
            if (result.Success)
            {
                return Created();
            }
            else return BadRequest(result.Message);

        }

        [HttpDelete("Remove")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var result = await _pricingService.DeletePricingAsync(id);
            if (result.Success)
            {
                return Ok("Delete Successfully!");
            }
            else return BadRequest(result.Message);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdatePricingDto updatePricingDto)
        {
            var result = await _pricingService.UpdatePricingAsync(updatePricingDto);
            if (result.Success)
            {
                return Ok("Update Successfully!");
            }
            else return BadRequest(result.Message);
        }
    }
}
