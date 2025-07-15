using AutoMapper;
using MediatR;
using RentACar.Application.Features.CQRS.Queries.CarPricingQueries;
using RentACar.Application.Features.CQRS.Results.CarPricingResults;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Application.Utilities.Results.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Read.CarPricingReadHandlers
{
    public class GetAllPricingToCarForAdminQueryHandler : IRequestHandler<GetAllCarPricingForAdminQuery, IDataResult<List<GetAllCarPricingForAdminQueryResult>>>
    {
        private readonly IPricingToCarRepository _pricingToCarRepository;
        private readonly IMapper _mapper;

        public GetAllPricingToCarForAdminQueryHandler(IPricingToCarRepository pricingToCarRepository, IMapper mapper)
        {
            _pricingToCarRepository = pricingToCarRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<List<GetAllCarPricingForAdminQueryResult>>> Handle(GetAllCarPricingForAdminQuery request, CancellationToken cancellationToken)
        {
            var allPricingToCar = await _pricingToCarRepository.GetAllWithDetailsAsync();
            var allPricingToCarResult = _mapper.Map<List<GetAllCarPricingForAdminQueryResult>>(allPricingToCar);

            if (allPricingToCarResult.Count > 0)
            {
                return new SuccessDataResult<List<GetAllCarPricingForAdminQueryResult>>(allPricingToCarResult, "Pricing list is load successfull!");
            }
            else return new ErrorDataResult<List<GetAllCarPricingForAdminQueryResult>>("Pricing list is empty!");
        }
    }
}
