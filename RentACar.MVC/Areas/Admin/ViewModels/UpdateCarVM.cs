using RentACar.Application.DTOs.Concrete.CarDto;
using RentACar.Application.Features.CQRS.Results.BrandResults;
using RentACar.Application.Features.CQRS.Results.CarResults;

namespace RentACar.MVC.Areas.Admin.ViewModels
{
    public class UpdateCarVM
    {
        public UpdateCarDto UpdateCarDto { get; set; } = new();
        public List<GetAllBrandQueryResult> GetAllBrandQueryResults { get; set; }
    }
}
