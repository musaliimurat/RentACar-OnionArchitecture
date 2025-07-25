using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Domain.Entities.Concrete;

namespace RentACar.Application.Features.CQRS.Results.CarPricingResults
{
    public class GetAllCarPricingQueryResult
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public Guid PricingId { get; set; }
        public decimal Amount { get; set; }
    }
}
