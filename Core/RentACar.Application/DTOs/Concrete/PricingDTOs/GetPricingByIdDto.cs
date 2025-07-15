using RentACar.Application.DTOs.Abstract;

namespace RentACar.Application.DTOs.Concrete.PricingDTOs
{
    public class GetPricingByIdDto : IDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
