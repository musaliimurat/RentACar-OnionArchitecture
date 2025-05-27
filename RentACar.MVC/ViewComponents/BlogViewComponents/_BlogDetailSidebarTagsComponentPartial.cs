using Microsoft.AspNetCore.Mvc;

namespace RentACar.MVC.ViewComponents.BlogViewComponents
{
    public class _BlogDetailSidebarTagsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
