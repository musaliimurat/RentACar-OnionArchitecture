using MediatR;
using RentACar.Application.DTOs.Concrete.CarDto;
using RentACar.Application.Features.CQRS.Results.CarPricingResults;
using RentACar.Common.Utilities.Results.Abstract;

namespace RentACar.Application.Features.CQRS.Queries.CarPricingQueries
{
    public class GetCarPricingByIdQuery(Guid id): IRequest<IDataResult<GetCarPricingByIdQueryResult>>
    {
        public Guid Id { get; set; } = id;
    }
}
