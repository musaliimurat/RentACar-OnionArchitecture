using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Interfaces.Services;

namespace RentACar.MVC.ViewComponents.ServiceViewComponents
{
    public class _ServiceListComponentPartial : ViewComponent
    {
        private readonly ICompanyServiceService _companyServiceService;

        public _ServiceListComponentPartial(ICompanyServiceService companyServiceService)
        {
            _companyServiceService = companyServiceService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _companyServiceService.GetAllAsync();
            if (result.Success)
            {
                return View(result.Data);
            }
            else
            {
                return View();
            }
        }

    }  
}
