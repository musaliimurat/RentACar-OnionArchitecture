using MediatR;
using RentACar.Application.Features.CQRS.Queries.PricingQueries;
using RentACar.Application.Features.CQRS.Results.PricingResults;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Application.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Handlers.Read.PricingReadHandlers
{
    public class GetAllPricingQueryHandler : IRequestHandler<GetAllPricingQuery, IDataResult<List<GetAllPricingQueryResult>>>
    {
        private readonly IPricingRepository _pricingRepository;

        public GetAllPricingQueryHandler(IPricingRepository pricingRepository)
        {
            _pricingRepository = pricingRepository;
        }

        public async Task<IDataResult<List<GetAllPricingQueryResult>>> Handle(GetAllPricingQuery request, CancellationToken cancellationToken)
        {
            var values = await _pricingRepository.GetAllAsync();
            var result = values.Select(f => new GetAllPricingQueryResult
            {
                Id = f.Id,
                Name = f.Name,
            }).ToList();
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<GetAllPricingQueryResult>>(result, "Pricing list is load successfull!");
            }
            else return new ErrorDataResult<List<GetAllPricingQueryResult>>("Pricing list is not found!");
        }
    }
}
