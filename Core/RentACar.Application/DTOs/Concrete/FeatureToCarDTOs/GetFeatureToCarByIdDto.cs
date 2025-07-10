using RentACar.Application.DTOs.Abstract;

namespace RentACar.Application.DTOs.Concrete.FeatureToCarDTOs
{
    public class GetFeatureToCarByIdDto : IDto
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public Guid FeatureId { get; set; }
        public Guid BrandId { get; set; }
        public string BrandName { get; set; }
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public string FeatureName { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
