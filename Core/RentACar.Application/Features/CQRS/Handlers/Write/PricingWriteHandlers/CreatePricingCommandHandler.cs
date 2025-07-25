using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.CQRS.Commands.PricingCommands;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Common.Utilities.Results.Abstract;
using RentACar.Common.Utilities.Results.Concrete;
using RentACar.Domain.Entities.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Write.PricingWriteHandlers
{
    public class CreatePricingCommandHandler : IRequestHandler<CreatePricingCommand, IResult>
    {
        private readonly IPricingRepository _pricingRepository;

        public CreatePricingCommandHandler(IPricingRepository pricingRepository)
        {
            _pricingRepository = pricingRepository;
        }

        public async Task<IResult> Handle(CreatePricingCommand request, CancellationToken cancellationToken)
        {
            if (request == null) return new ErrorResult("Pricing add error!");

            Pricing pricing = new()
            {
                Name = request.Name,
            };
            await _pricingRepository.CreateAsync(pricing);
            return new SuccessResult("Pricing added successfully!");
        }
    }
}
