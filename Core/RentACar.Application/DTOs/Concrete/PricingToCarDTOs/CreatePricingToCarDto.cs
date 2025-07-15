using RentACar.Application.DTOs.Abstract;

namespace RentACar.Application.DTOs.Concrete.PricingToCarDTOs
{
    public class CreatePricingToCarDto : IDto
    {
        public Guid CarId { get; set; }
        public Guid PricingId { get; set; }
        public decimal Amount { get; set; }
    }
}
