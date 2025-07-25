using MediatR;
using RentACar.Application.Features.CQRS.Results.CarPricingResults;
using RentACar.Common.Utilities.Results.Abstract;

namespace RentACar.Application.Features.CQRS.Queries.CarPricingQueries
{
    public class GetAllCarPricingForAdminQuery : IRequest<IDataResult<List<GetAllCarPricingForAdminQueryResult>>>
    {
    }
}
