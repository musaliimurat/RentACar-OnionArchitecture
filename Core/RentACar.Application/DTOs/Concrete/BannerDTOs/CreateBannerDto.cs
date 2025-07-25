using RentACar.Application.DTOs.Abstract;

namespace RentACar.Application.DTOs.Concrete.BannerDTOs
{
    public class CreateBannerDto : IDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoDescription { get; set; }
        public string VideoUrl { get; set; }
    }
}