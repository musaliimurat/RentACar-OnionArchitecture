using Microsoft.AspNetCore.Mvc;

namespace RentACar.MVC.ViewComponents.BlogViewComponents
{
    public class _BlogDetailSidebarAuthorComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
