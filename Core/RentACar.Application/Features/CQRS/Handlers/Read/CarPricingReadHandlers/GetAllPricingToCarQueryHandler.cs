using MediatR;
using RentACar.Application.DTOs.Concrete.CarDto;
using RentACar.Application.Features.CQRS.Queries.CarPricingQueries;
using RentACar.Application.Features.CQRS.Results.CarPricingResults;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Application.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Handlers.Read.CarPricingReadHandlers
{
    public class GetAllPricingToCarQueryHandler : IRequestHandler<GetAllCarPricingQuery, IDataResult<List<GetAllCarPricingQueryResult>>>
    {
        private readonly IPricingToCarRepository _pricingToCarRepository;

        public GetAllPricingToCarQueryHandler(IPricingToCarRepository pricingToCarRepository)
        {
            _pricingToCarRepository = pricingToCarRepository;
        }

        public async Task<IDataResult<List<GetAllCarPricingQueryResult>>> Handle(GetAllCarPricingQuery request, CancellationToken cancellationToken)
        {
            var allPricingToCar = await _pricingToCarRepository.GetAllAsync();
            var allPricingToCarResult = allPricingToCar.Select(p => new GetAllCarPricingQueryResult
            {
                Id = p.Id,
                CarId = p.CarId,
                PricingId = p.PricingId,
                Amount = p.Amount,

            }).ToList();
            if (allPricingToCarResult.Count > 0)
            {
                return new SuccessDataResult<List<GetAllCarPricingQueryResult>>(allPricingToCarResult, "Pricing list is load successfull!");
            }
            else return new ErrorDataResult<List<GetAllCarPricingQueryResult>>("Pricing list is empty!");
        }
    }
}
