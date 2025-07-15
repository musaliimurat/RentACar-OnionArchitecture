using RentACar.Application.DTOs.Abstract;

namespace RentACar.Application.DTOs.Concrete.CarDescriptionDTOs
{
    public class GetAllCarDescriptionForCarListDto : IDto
    {
        public Guid Id { get; set; }
        public string Details { get; set; }
    }

}
