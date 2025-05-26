using MediatR;
using RentACar.Application.Features.CQRS.Results.ServiceResults;
using RentACar.Application.Utilities.Results.Abstract;

namespace RentACar.Application.Features.CQRS.Queries.ServiceQueries
{
    public class GetServiceByIdQuery(Guid id) : IRequest<IDataResult<GetServiceByIdQueryResult>>
    {
        public Guid Id { get; set; } = id;
    }
}
