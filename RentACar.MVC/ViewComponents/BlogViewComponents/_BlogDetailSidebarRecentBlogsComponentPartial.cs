using Microsoft.AspNetCore.Mvc;

namespace RentACar.MVC.ViewComponents.BlogViewComponents
{
    public class _BlogDetailSidebarRecentBlogsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
