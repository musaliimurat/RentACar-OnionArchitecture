using RentACar.Application.DTOs.Abstract;

namespace RentACar.Application.DTOs.Concrete.FeatureToCarDTOs
{
    public class CreateFeatureToCarDto : IDto
    {
        public Guid CarId { get; set; }
        public List<Guid> SelectedFeatureIds { get; set; }
        public bool IsAvailable { get; set; }
    }
}
