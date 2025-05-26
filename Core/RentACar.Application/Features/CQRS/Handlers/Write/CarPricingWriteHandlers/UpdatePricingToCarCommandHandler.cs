using MediatR;
using RentACar.Application.Features.CQRS.Commands.CarPricingCommands;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Application.Utilities.Results.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Write.CarPricingWriteHandlers
{
    public class UpdatePricingToCarCommandHandler : IRequestHandler<UpdatePricingToCarCommand, IResult>
    {
        private readonly IPricingToCarRepository _pricingToCarRepository;
        public UpdatePricingToCarCommandHandler(IPricingToCarRepository pricingToCarRepository)
        {
            _pricingToCarRepository = pricingToCarRepository;
        }
        public async Task<IResult> Handle(UpdatePricingToCarCommand request, CancellationToken cancellationToken)
        {
            var pricingToCar = await _pricingToCarRepository.GetAsync(p=>p.Id == request.Id);
            if (pricingToCar != null)
            {
                pricingToCar.CarId = request.CarId;
                pricingToCar.PricingId = request.PricingId;
                pricingToCar.Amount = request.Amount;
                pricingToCar.UpdateDate = DateTime.Today;
                await _pricingToCarRepository.UpdateAsync(pricingToCar);
                return new SuccessResult("Pricing to car is updated successfully!");
            }
            else return new ErrorResult("Pricing to car is not found!");
        }
    }


}
