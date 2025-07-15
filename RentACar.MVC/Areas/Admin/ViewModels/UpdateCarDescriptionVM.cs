using RentACar.Application.DTOs.Concrete.CarDescriptionDTOs;
using RentACar.Application.DTOs.Concrete.CarDto;

namespace RentACar.MVC.Areas.Admin.ViewModels
{
    public class UpdateCarDescriptionVM
    {
        public List<GetAllCarsWithBrandNameForAdminDto> GetAllCarsWithBrandNameForAdminDtos { get; set; }
        public UpdateCarDescriptionDto UpdateCarDescriptionDto { get; set; }
    }
}
