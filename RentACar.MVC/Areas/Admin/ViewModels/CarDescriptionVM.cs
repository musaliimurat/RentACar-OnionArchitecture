using RentACar.Application.DTOs.Concrete.CarDescriptionDTOs;
using RentACar.Application.DTOs.Concrete.CarDto;

namespace RentACar.MVC.Areas.Admin.ViewModels
{
    public class CarDescriptionVM
    {
        public List<GetAllCarsWithBrandNameForAdminDto> GetAllCarsWithBrandNameForAdminDtos { get; set; }
        public CreateCarDescriptionDto CreateCarDescriptionDto { get; set; }
    }
}
