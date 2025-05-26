using RentACar.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Domain.Entities.Concrete
{
    public class Car : BaseEntity
    {
        public Guid BrandId { get; set; }
        public Brand Brand { get; set; }
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public string DetailImageUrl { get; set; }
        public decimal Km { get; set; }
        public string Transmission { get; set; }
        public byte Seat { get; set; }
        public byte Luggage { get; set; }
        public string Fuel { get; set; }
        public List<FeatureToCar> FeatureToCars { get; set; }
        public List<CarDescription> CarDescriptions { get; set; }
        public List<PricingToCar> PricingToCars { get; set; }
    }
}
