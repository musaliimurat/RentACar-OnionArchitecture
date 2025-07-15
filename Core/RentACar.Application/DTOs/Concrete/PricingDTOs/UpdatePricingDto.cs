using RentACar.Application.DTOs.Abstract;

namespace RentACar.Application.DTOs.Concrete.PricingDTOs
{
    public class UpdatePricingDto : IDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

}
