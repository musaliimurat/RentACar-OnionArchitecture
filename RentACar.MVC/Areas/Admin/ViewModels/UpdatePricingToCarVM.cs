using RentACar.Application.DTOs.Concrete.CarDto;
using RentACar.Application.DTOs.Concrete.PricingDTOs;
using RentACar.Application.DTOs.Concrete.PricingToCarDTOs;

namespace RentACar.MVC.Areas.Admin.ViewModels
{
    public class UpdatePricingToCarVM
    {
        public List<GetAllCarsWithBrandNameForAdminDto> GetAllCarsWithBrandNameForAdminDtos { get; set; }
        public List<GetAllPricingDto> GetAllPricingDtos { get; set; }
        public UpdatePricingToCarDto UpdatePricingToCarDto { get; set; }
    }
}
