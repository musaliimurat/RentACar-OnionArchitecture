using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Results.CarPricingResults
{
    public class GetCarPricingByIdQueryResult
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public Guid PricingId { get; set; }
        public decimal Amount { get; set; }
    }
}
