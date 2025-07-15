using RentACar.Application.DTOs.Abstract;

namespace RentACar.Application.DTOs.Concrete.CarDescriptionDTOs
{
    public class GetCarDescriptionByIdDto : IDto
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public string Model { get; set; }
        public string BrandName { get; set; }
        public string CoverPhotoUrl { get; set; }
        public string Details { get; set; }
    }

}
