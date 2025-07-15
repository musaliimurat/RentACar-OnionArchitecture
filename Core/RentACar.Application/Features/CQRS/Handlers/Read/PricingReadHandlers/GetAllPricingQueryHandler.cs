using AutoMapper;
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
        private readonly IMapper _mapper;

        public GetAllPricingQueryHandler(IPricingRepository pricingRepository, IMapper mapper)
        {
            _pricingRepository = pricingRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<List<GetAllPricingQueryResult>>> Handle(GetAllPricingQuery request, CancellationToken cancellationToken)
        {
            var values = await _pricingRepository.GetAllAsync();
            var result = _mapper.Map<List<GetAllPricingQueryResult>>(values);
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<GetAllPricingQueryResult>>(result, "Pricing list is load successfull!");
            }
            else return new ErrorDataResult<List<GetAllPricingQueryResult>>("Pricing list is not found!");
        }
    }
}
