using Microsoft.AspNetCore.Mvc;

namespace RentACar.MVC.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _HeadAdminLayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
