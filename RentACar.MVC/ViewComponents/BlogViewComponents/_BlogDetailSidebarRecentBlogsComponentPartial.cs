using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Interfaces.Services;

namespace RentACar.MVC.ViewComponents.BlogViewComponents
{
    public class _BlogDetailSidebarRecentBlogsComponentPartial : ViewComponent
    {
        private readonly IBlogService _blogService;

        public _BlogDetailSidebarRecentBlogsComponentPartial(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var recentBlogs = await _blogService.GetAllBlogIsNewAsync();
            if (recentBlogs.Success)
            {
                return View(recentBlogs.Data);
            }
            return View("NoRecentBlogs");

        }
    }
}
