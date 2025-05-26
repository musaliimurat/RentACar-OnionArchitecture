using Microsoft.AspNetCore.Mvc;

namespace RentACar.MVC.ViewComponents.CounterViewComponents
{
    public class _CounterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
