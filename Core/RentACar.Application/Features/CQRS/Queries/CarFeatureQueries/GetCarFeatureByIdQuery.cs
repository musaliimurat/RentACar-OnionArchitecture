using MediatR;
using RentACar.Application.Features.CQRS.Results.CarFeatureResults;
using RentACar.Common.Utilities.Results.Abstract;

namespace RentACar.Application.Features.CQRS.Queries.CarFeatureQueries
{
    public class GetCarFeatureByIdQuery(Guid id) : IRequest<IDataResult<GetCarFeatureByIdQueryResult>>
    {
        public Guid Id { get; set; } = id;
     
    }
}
