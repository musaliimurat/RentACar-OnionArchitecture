using RentACar.Application.DTOs.Concrete.BlogDto;
using RentACar.Application.DTOs.Concrete.CarDto;
using RentACar.Application.Features.CQRS.Results.BannerResults;

namespace RentACar.MVC.ViewModels
{
    public class HomeVM
    {
        public GetAllBannerQueryResult GetBanner { get; set; }
        public List<GetAllFeaturedCarsDto> GetAllFeaturedCars { get; set; }
        public List<GetAllBlogDto> GetAllBlogIsNew { get; set; }
    }
}
