using MediatR;
using RentACar.Application.Features.CQRS.Results.FooterAddressResults;
using RentACar.Application.Utilities.Results.Abstract;

namespace RentACar.Application.Features.CQRS.Queries.FooterAddressQueries
{
    public class GetFooterAddressByIdQuery(Guid id) : IRequest<IDataResult<GetFooterAddressByIdQueryResult>>
    {
        public Guid Id { get; set; } = id;
    }
}
