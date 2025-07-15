using RentACar.Application.DTOs.Abstract;

namespace RentACar.Application.DTOs.Concrete.CarDescriptionDTOs
{
    public class UpdateCarDescriptionDto : IDto
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public string Details { get; set; }
    }

}
