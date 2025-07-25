using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.DTOs.Concrete.CarDto;
using RentACar.Application.Features.CQRS.Results.CarPricingResults;
using RentACar.Common.Utilities.Results.Abstract;

namespace RentACar.Application.Features.CQRS.Queries.CarPricingQueries
{
    public class GetAllCarPricingQuery : IRequest<IDataResult<List<GetAllCarPricingQueryResult>>>
    {
    }
}
