using Microsoft.AspNetCore.Mvc;
using RentACar.Application.DTOs.Concrete.FeatureToCarDTOs;
using RentACar.Application.Interfaces.Services;

namespace RentACar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureToCarsController : ControllerBase
    {
        private readonly IFeatureToCarService _featureToCarService;
        public FeatureToCarsController(IFeatureToCarService featureToCarService)
        {
            _featureToCarService = featureToCarService;
        }

        [HttpGet("GetAllFeatureToCars")]
        public async Task<IActionResult> GetAllFeatureToCars()
        {
            var result = await _featureToCarService.GetAllFeatureToCarsAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetFeatureToCarById/{id}")]
        public async Task<IActionResult> GetFeatureToCarById(Guid id)
        {
            var result = await _featureToCarService.GetFeatureToCarByIdAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result.Message);
        }


        [HttpPost("CreateFeatureToCar")]
        public async Task<IActionResult> Create([FromBody] CreateFeatureToCarDto createFeatureToCarDto)
        {
          
            var result = await _featureToCarService.CreateFeatureToCarAsync(createFeatureToCarDto);
            if (result.Success)
            {
                return Created();
            }
            return BadRequest(result.Message);
        }

        [HttpDelete("DeleteFeatureToCar/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _featureToCarService.DeleteFeatureToCarAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPut("UpdateFeatureToCar")]
        public async Task<IActionResult> Update([FromBody] UpdateFeatureToCarDto updateFeatureToCarDto)
        {
            var result = await _featureToCarService.UpdateFeatureToCarAsync(updateFeatureToCarDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
       
      
    }
}
