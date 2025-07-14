using RentACar.Application.DTOs.Concrete.CarDto;
using RentACar.Application.DTOs.Concrete.FeatureDto;
using RentACar.Application.DTOs.Concrete.FeatureToCarDTOs;

namespace RentACar.MVC.Areas.Admin.ViewModels
{
    public class UpdateFeatureToCarVM
    {
        public List<GetAllCarsWithBrandNameForAdminDto> GetAllCarsWithBrandNameForAdminDtos { get; set; }
        public List<GetAllFeatureDto> GetAllFeatureDtos { get; set; }
        public UpdateFeatureToCarDto UpdateFeatureToCarDto { get; set; }
    }
}
