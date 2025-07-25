using MediatR;
using RentACar.Application.DTOs.Concrete.CarDto;
using RentACar.Common.Utilities.Results.Abstract;

namespace RentACar.Application.Features.CQRS.Queries.CarQueries
{
    public class GetCarDetailByIdQuery(Guid id) : IRequest<IDataResult<GetCarByIdDto>>
    {
        public Guid Id { get; set; } = id;
    }

}
