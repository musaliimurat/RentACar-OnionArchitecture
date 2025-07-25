using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.DTOs.Abstract;

namespace RentACar.Application.DTOs.Concrete.PricingToCarDTOs
{
    public class GetAllPricingToCarDto : IDto
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public Guid BrandId { get; set; }
        public Guid PricingId { get; set; }
        public string Model { get; set; }
        public string BrandName { get; set; }
        public string CoverImageUrl { get; set; }
        public string PriceName { get; set; }
        public decimal Amount { get; set; }

        public string DisplayName => $"{BrandName} - {Model}";
    }
}
