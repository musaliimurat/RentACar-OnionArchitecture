using Microsoft.AspNetCore.Mvc;

namespace RentACar.MVC.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _ScriptsAdminLayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
