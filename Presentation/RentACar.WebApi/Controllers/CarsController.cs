using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.DTOs.Concrete.CarDto;
using RentACar.Application.Interfaces.Services;

namespace RentACar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _service;
        private readonly IUploadImageService _uploadImageService;
        private readonly IWebHostEnvironment _env;

        public CarsController(ICarService service, IUploadImageService uploadImageService, IWebHostEnvironment env)
        {
            _service = service;
            _uploadImageService = uploadImageService;
            _env = env;
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
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] CreateCarDto createCarDto)
        {
            var coverImagePathList = await _uploadImageService.UploadImagesAsync(
                         new FormFileCollection { createCarDto.CoverImageUpload }, "assets/images/car", _env);
            var coverImageUrl = coverImagePathList.FirstOrDefault();

            var detailImagePathList = await _uploadImageService.UploadImagesAsync(
                                       new FormFileCollection { createCarDto.DetailImageUpload }, "assets/images/car", _env);
            var detailImageUrl = detailImagePathList.FirstOrDefault();

            createCarDto.CoverImageUrl = "/" + coverImageUrl;
            createCarDto.DetailImageUrl = "/" + detailImageUrl;
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
