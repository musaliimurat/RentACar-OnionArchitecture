using RentACar.Application.DTOs.Abstract;

namespace RentACar.Application.DTOs.Concrete.BannerDTOs
{
    public class GetAllBannerDto : IDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoDescription { get; set; }
        public string VideoUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}