using MediatR;
using RentACar.Application.Features.CQRS.Results.PricingResults;
using RentACar.Application.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Queries.PricingQueries
{
    public class GetPricingByIdQuery(Guid id) : IRequest<IDataResult<GetPricingByIdQueryResult>>
    {
        public Guid Id { get; set; } = id;
    }
}
