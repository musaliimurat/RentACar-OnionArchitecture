using RentACar.Application.DTOs.Abstract;

namespace RentACar.Application.DTOs.Concrete.FeatureToCarDTOs
{
    public class UpdateFeatureToCarDto : IDto
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public Guid FeatureId { get; set; }
        public bool IsAvailable { get; set; }
    }
}
