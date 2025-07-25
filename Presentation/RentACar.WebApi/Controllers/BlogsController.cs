using Microsoft.AspNetCore.Mvc;
using RentACar.Application.DTOs.Concrete.BlogDTOs;
using RentACar.Application.Interfaces.Services;

namespace RentABlog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogService _service;

        public BlogsController(IBlogService blogService)
        {
            _service = blogService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(int page = 1, int pageSize = 3)
        {
            var result = await _service.GetAllBlogAsync(page, pageSize);
            if (result.Success)
            {
                return Ok(result);

            }
            else return BadRequest(result.Message);
        }

        [HttpGet("GetAllForAdmin")]
        public async Task<IActionResult> GetAllForAdmin()
        {
            var result = await _service.GetAllBlogForAdminAsync();
            if (result.Success)
            {
                return Ok(result);

            }
            else return BadRequest(result.Message);
        }


        [HttpGet("GetAllIsNew")]
        public async Task<IActionResult> GetAllBlogIsNew()
        {
            var result = await _service.GetAllBlogIsNewAsync();
            if (result.Success)
            {
                return Ok(result);

            }
            else return BadRequest(result.Message);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _service.GetBlogByIdAsync(id);
            if (result.Success)
            {
                return Ok(result);

            }
            else return BadRequest(result.Message);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateBlogDto createBlogDto)
        {
            var result = await _service.CreateBlogAsync(createBlogDto);
            if (result.Success)
            {
                return Created();
            }
            else return BadRequest(result.Message);

        }

        [HttpDelete("Remove")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var result = await _service.DeleteBlogAsync(id);
            if (result.Success)
            {
                return Ok("Delete Successfully!");
            }
            else return BadRequest(result.Message);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateBlogDto updateBlogDto)
        {
            var result = await _service.UpdateBlogAsync(updateBlogDto);
            if (result.Success)
            {
                return Ok("Update Successfully!");
            }
            else return BadRequest(result.Message);
        }
    }
}
