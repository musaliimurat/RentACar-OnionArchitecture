using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Results.PricingResults
{
    public class GetPricingByIdQueryResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
