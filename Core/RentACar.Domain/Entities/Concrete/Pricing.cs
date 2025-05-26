using RentACar.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Domain.Entities.Concrete
{
    public class Pricing : BaseEntity
    {
        public string Name { get; set; }
        public List<PricingToCar> PricingToCars { get; set; }
    }
}
