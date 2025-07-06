using RentACar.Application.DTOs.Abstract;

namespace RentACar.Application.DTOs.Concrete.BrandDto
{
    public class UpdateBrandDto : IDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
