using MediatR;
using RentACar.Application.DTOs.Concrete.CarDto;
using RentACar.Application.Features.CQRS.Queries.CarPricingQueries;
using RentACar.Application.Features.CQRS.Results.CarPricingResults;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Application.Utilities.Results.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Read.CarPricingReadHandlers
{
    public class GetPricingToCarByIdQueryHandler : IRequestHandler<GetCarPricingByIdQuery, IDataResult<GetCarPricingByIdQueryResult>>
    {
        private readonly IPricingToCarRepository _pricingToCarRepository;

        public GetPricingToCarByIdQueryHandler(IPricingToCarRepository pricingToCarRepository)
        {
            _pricingToCarRepository = pricingToCarRepository;
        }

        public async Task<IDataResult<GetCarPricingByIdQueryResult>> Handle(GetCarPricingByIdQuery request, CancellationToken cancellationToken)
        {
            var pricingToCar = await _pricingToCarRepository.GetAsync(p=>p.Id == request.Id);
            if (pricingToCar == null)
            {
                return new ErrorDataResult<GetCarPricingByIdQueryResult>("Pricing not found!");
            }
            var pricingToCarResult = new GetCarPricingByIdQueryResult
            {
                Id = pricingToCar.Id,
                CarId = pricingToCar.CarId,
                PricingId = pricingToCar.PricingId,
                Amount = pricingToCar.Amount
            };
            return new SuccessDataResult<GetCarPricingByIdQueryResult>(pricingToCarResult, "Pricing is load successfull!");
        }
    }
}
