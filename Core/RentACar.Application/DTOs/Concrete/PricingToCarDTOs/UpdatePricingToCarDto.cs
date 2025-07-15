using RentACar.Application.DTOs.Abstract;

namespace RentACar.Application.DTOs.Concrete.PricingToCarDTOs
{
    public class UpdatePricingToCarDto : IDto
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public Guid PricingId { get; set; }
        public decimal Amount { get; set; }
    }
}
