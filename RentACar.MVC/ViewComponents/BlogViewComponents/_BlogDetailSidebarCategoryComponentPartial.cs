using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Interfaces.Services;

namespace RentACar.MVC.ViewComponents.BlogViewComponents
{
    public class _BlogDetailSidebarCategoryComponentPartial : ViewComponent
    {
        private readonly IBlogService _blogService;

        public _BlogDetailSidebarCategoryComponentPartial(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _blogService.GetAllBlogWithCategoryNameAsync();
            if (result.Success)
            {
                return View(result.Data);

            }
            else
            {
                return View("Error", result.Message);
            }
        }
    }
   
}
