using RentACar.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Domain.Entities.Concrete
{
    public class PricingToCar : BaseEntity
    {
        public Guid CarId { get; set; }
        public Car Car { get; set; }
        public Guid PricingId { get; set; }
        public Pricing Pricing { get; set; }
        public decimal Amount { get; set; }
    }
}
