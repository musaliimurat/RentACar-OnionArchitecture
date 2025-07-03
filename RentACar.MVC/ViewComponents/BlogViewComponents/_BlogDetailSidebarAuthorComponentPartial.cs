using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Interfaces.Services;

namespace RentACar.MVC.ViewComponents.BlogViewComponents
{
    public class _BlogDetailSidebarAuthorComponentPartial : ViewComponent
    {
        private readonly IBlogService _blogService;

        public _BlogDetailSidebarAuthorComponentPartial(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid id)
        {
            var blogAuthor = await _blogService.GetBlogByIdAsync(id);
            if (blogAuthor.Success)
                return View(blogAuthor.Data);
            else
            {
                return View(blogAuthor.Message);
            }
        }
    }
}
