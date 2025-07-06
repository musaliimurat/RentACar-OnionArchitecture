using RentACar.Application.DTOs.Concrete.BrandDto;
using RentACar.Application.DTOs.Concrete.CarDto;
using RentACar.Application.Features.CQRS.Results.BrandResults;

namespace RentACar.MVC.Areas.Admin.ViewModels
{
    public class CarVM
    {
        public CreateCarDto CreateCarDto { get; set; }
        public List<GetAllBrandDto> GetAllBrandDto { get; set; }
    }
}
