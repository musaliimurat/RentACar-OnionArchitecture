using MediatR;
using RentACar.Application.Features.CQRS.Queries.FooterAddressQueries;
using RentACar.Application.Features.CQRS.Results.FooterAddressResults;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Application.Utilities.Results.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Read.FooterAddressReadHandlers
{
    public class GetFooterAddressByIdQueryHandler : IRequestHandler<GetFooterAddressByIdQuery, IDataResult<GetFooterAddressByIdQueryResult>>
    {
        private readonly IFooterAddressRepository _footerAddressRepository;

        public GetFooterAddressByIdQueryHandler(IFooterAddressRepository footerAddressRepository)
        {
            _footerAddressRepository = footerAddressRepository;
        }

        public async Task<IDataResult<GetFooterAddressByIdQueryResult>> Handle(GetFooterAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _footerAddressRepository.GetAsync(f=>f.Id == request.Id);
            
            if (value !=null)
            {
                var result = new GetFooterAddressByIdQueryResult
                {
                    Id = value.Id,
                    Email = value.Email,
                    PhoneNumber = value.PhoneNumber,
                    Address = value.Address,
                    Description = value.Description,
                };
                return new SuccessDataResult<GetFooterAddressByIdQueryResult>(result, "Footer address is load successfull!");
            }
            else return new ErrorDataResult<GetFooterAddressByIdQueryResult>("Footer address is not found!");
        }
    }
}
