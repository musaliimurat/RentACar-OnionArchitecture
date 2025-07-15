using RentACar.Application.DTOs.Abstract;

namespace RentACar.Application.DTOs.Concrete.PricingDTOs
{
    public class  CreatePricingDto : IDto
    {
        public string Name { get; set; }
    }

}
