using Microsoft.AspNetCore.Mvc;

namespace RentACar.MVC.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _FooterAdminLayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
