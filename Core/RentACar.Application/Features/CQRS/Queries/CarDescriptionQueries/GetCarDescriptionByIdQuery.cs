using MediatR;
using RentACar.Application.Features.CQRS.Results.CarDescriptionResults;
using RentACar.Common.Utilities.Results.Abstract;

namespace RentACar.Application.Features.CQRS.Queries.CarDescriptionQueries
{
    public class GetCarDescriptionByIdQuery(Guid id) : IRequest<IDataResult<GetCarDescriptionByIdQueryResult>>
    {
        public Guid Id { get; set; } = id;
    }
}
