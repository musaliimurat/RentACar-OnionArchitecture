using RentACar.Application.DTOs.Abstract;

namespace RentACar.Application.DTOs.Concrete.CaregoryDTOs
{
    public class UpdateCategoryDto : IDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }


}
