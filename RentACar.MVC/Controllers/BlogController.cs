using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Interfaces.Services;

namespace RentACar.MVC.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 3)
        {
            ViewBag.MyTitle = "Blog";
            ViewBag.Description = "Our Blog";
            var result = await _blogService.GetAllBlogAsync(page, pageSize);
            if (result.Success)
            {
                return View(result.Data);
            }
            else
            {
                return View();
            }
        }

        public async Task<IActionResult> Detail(Guid id)
        {
            ViewBag.MyTitleOne = "Blog";
            ViewBag.MyTitle = "Blog Detail";
            ViewBag.Description = "Read our blog";
            var result = await _blogService.GetBlogByIdAsync(id);
            if (result.Success)
            {
                return View(result.Data);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
