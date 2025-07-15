using MediatR;
using RentACar.Application.Features.CQRS.Results.CarDescriptionResults;
using RentACar.Application.Utilities.Results.Abstract;

namespace RentACar.Application.Features.CQRS.Queries.CarDescriptionQueries
{
    public class GetAllCarDescriptionQuery : IRequest<IDataResult<List<GetAllCarDescriptionQueryResult>>>
    {
    }
}
