using MediatR;
using RentACar.Application.Features.CQRS.Commands.CarPricingCommands;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Application.Utilities.Results.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Write.CarPricingWriteHandlers
{
    public class RemovePricingToCarCommandHandler : IRequestHandler<RemovePricingToCarCommand, IResult>
    {
        private readonly IPricingToCarRepository _pricingToCarRepository;
        public RemovePricingToCarCommandHandler(IPricingToCarRepository pricingToCarRepository)
        {
            _pricingToCarRepository = pricingToCarRepository;
        }
        public async Task<IResult> Handle(RemovePricingToCarCommand request, CancellationToken cancellationToken)
        {
            var pricingToCar = await _pricingToCarRepository.GetAsync(p => p.Id == request.Id);
            if (pricingToCar != null)
            {
                await _pricingToCarRepository.RemoveAsync(pricingToCar);
                return new SuccessResult("Pricing to car is deleted successfully!");
            }
            else return new ErrorResult("Pricing to car is not found!");
        }
    }


}
