using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using RentACar.Application.Features.CQRS.Queries.PricingQueries;
using RentACar.Application.Features.CQRS.Results.PricingResults;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Common.Utilities.Results.Abstract;
using RentACar.Common.Utilities.Results.Concrete;
// Ignore Spelling: CQRS

namespace RentACar.Application.Features.CQRS.Handlers.Read.PricingReadHandlers
{
    public class GetPricingByIdQueryHandler : IRequestHandler<GetPricingByIdQuery, IDataResult<GetPricingByIdQueryResult>>
    {
        private readonly IPricingRepository _pricingRepository;
        private readonly IMapper _mapper;

        public GetPricingByIdQueryHandler(IPricingRepository pricingRepository, IMapper mapper)
        {
            _pricingRepository = pricingRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<GetPricingByIdQueryResult>> Handle(GetPricingByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _pricingRepository.GetAsync(p=>p.Id == request.Id);
            if (value == null) return new ErrorDataResult<GetPricingByIdQueryResult>("Pricing is not found!");
            var result = _mapper.Map<GetPricingByIdQueryResult>(value);

            return new SuccessDataResult<GetPricingByIdQueryResult>(result, "Pricing is load successfully!");
        }
    }
}
