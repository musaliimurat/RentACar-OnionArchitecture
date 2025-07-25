using MediatR;
using RentACar.Application.Features.CQRS.Queries.FooterAddressQueries;
using RentACar.Application.Features.CQRS.Results.FooterAddressResults;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Common.Utilities.Results.Abstract;
using RentACar.Common.Utilities.Results.Concrete;
// Ignore Spelling: CQRS

namespace RentACar.Application.Features.CQRS.Handlers.Read.FooterAddressReadHandlers
{
    public class GetAllFooterAddressQueryHandler : IRequestHandler<GetAllFooterAddressQuery, IDataResult<List<GetAllFooterAddressQueryResult>>>
    {
        private readonly IFooterAddressRepository _footerAddressRepository;

        public GetAllFooterAddressQueryHandler(IFooterAddressRepository footerAddressRepository)
        {
            _footerAddressRepository = footerAddressRepository;
        }

        public async Task<IDataResult<List<GetAllFooterAddressQueryResult>>> Handle(GetAllFooterAddressQuery request, CancellationToken cancellationToken)
        {
            var values = await _footerAddressRepository.GetAllAsync();
            var result = values.Select(f => new GetAllFooterAddressQueryResult
            {
                Id = f.Id,
                Email = f.Email,
                PhoneNumber = f.PhoneNumber,
                Address = f.Address,
                Description = f.Description,
            }).ToList();
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<GetAllFooterAddressQueryResult>>(result, "Footer address list is load successfully!");
            }
            else return new ErrorDataResult<List<GetAllFooterAddressQueryResult>>("Footer address list is not found!");
        }
    }
}