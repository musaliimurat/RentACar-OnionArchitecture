using Microsoft.AspNetCore.Mvc;

namespace RentACar.MVC.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _NotificationAdminLayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
