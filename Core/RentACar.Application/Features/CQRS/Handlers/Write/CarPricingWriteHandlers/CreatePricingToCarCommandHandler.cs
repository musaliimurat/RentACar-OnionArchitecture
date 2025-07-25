using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.CQRS.Commands.CarPricingCommands;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Common.Utilities.Results.Abstract;
using RentACar.Common.Utilities.Results.Concrete;
using RentACar.Domain.Entities.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Write.CarPricingWriteHandlers
{
    public class CreatePricingToCarCommandHandler : IRequestHandler<CreatePricingToCarCommand, IResult>
    {
        private readonly IPricingToCarRepository _pricingToCarRepository;

        public CreatePricingToCarCommandHandler(IPricingToCarRepository pricingToCarRepository)
        {
            _pricingToCarRepository = pricingToCarRepository;
        }

        public async Task<IResult> Handle(CreatePricingToCarCommand request, CancellationToken cancellationToken)
        {
           
            var pricingToCar = new PricingToCar
            {
                CarId = request.CarId,
                PricingId = request.PricingId,
                Amount = request.Amount
            };
            if (pricingToCar !=null)
            {
                await _pricingToCarRepository.CreateAsync(pricingToCar);
                return new SuccessResult("Pricing to car is created successfully!");
            }
            else return new ErrorResult("Pricing to car is not created!");
        }
    }


}
