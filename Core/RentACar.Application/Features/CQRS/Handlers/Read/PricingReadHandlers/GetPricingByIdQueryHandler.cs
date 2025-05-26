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
    public class GetPricingByIdQueryHandler : IRequestHandler<GetPricingByIdQuery, IDataResult<GetPricingByIdQueryResult>>
    {
        private readonly IPricingRepository _pricingRepository;

        public GetPricingByIdQueryHandler(IPricingRepository pricingRepository)
        {
            _pricingRepository = pricingRepository;
        }

        public async Task<IDataResult<GetPricingByIdQueryResult>> Handle(GetPricingByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _pricingRepository.GetAsync(p=>p.Id == request.Id);
            if (value == null) return new ErrorDataResult<GetPricingByIdQueryResult>("Pricing is not found!");
            var result = new GetPricingByIdQueryResult
            {
                Id = value.Id,
                Name = value.Name,
            };
            return new SuccessDataResult<GetPricingByIdQueryResult>(result, "Pricing is load successfull!");
        }
    }
}
