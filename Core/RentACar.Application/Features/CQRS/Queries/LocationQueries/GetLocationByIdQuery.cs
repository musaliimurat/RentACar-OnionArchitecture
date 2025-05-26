using MediatR;
using RentACar.Application.Features.CQRS.Results.LocationResults;
using RentACar.Application.Utilities.Results.Abstract;

namespace RentACar.Application.Features.CQRS.Queries.LocationQueries
{
    public class GetLocationByIdQuery(Guid id) : IRequest<IDataResult<GetLocationByIdQueryResult>>
    {
        public Guid Id { get; set; } = id;
    }
   
}
