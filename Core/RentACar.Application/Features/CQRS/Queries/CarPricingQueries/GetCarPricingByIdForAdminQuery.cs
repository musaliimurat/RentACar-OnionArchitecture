using MediatR;
using RentACar.Application.Features.CQRS.Results.CarPricingResults;
using RentACar.Application.Utilities.Results.Abstract;

namespace RentACar.Application.Features.CQRS.Queries.CarPricingQueries
{
    public class GetCarPricingByIdForAdminQuery(Guid id) : IRequest<IDataResult<GetCarPricingByIdForAdminQueryResult>>
    {
        public Guid Id { get; set; } = id;
    }
}
