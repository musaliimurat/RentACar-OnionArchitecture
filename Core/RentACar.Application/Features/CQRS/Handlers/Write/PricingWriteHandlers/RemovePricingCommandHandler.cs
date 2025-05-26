using MediatR;
using RentACar.Application.Features.CQRS.Commands.PricingCommands;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Application.Utilities.Results.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Write.PricingWriteHandlers
{
    public class RemovePricingCommandHandler : IRequestHandler<RemovePricingCommand, IResult>
    {
        private readonly IPricingRepository _pricingRepository;

        public RemovePricingCommandHandler(IPricingRepository pricingRepository)
        {
            _pricingRepository = pricingRepository;
        }

        public async Task<IResult> Handle(RemovePricingCommand request, CancellationToken cancellationToken)
        {
            var value = await _pricingRepository.GetAsync(f => f.Id == request.Id);
            if (value != null)
            {
                await _pricingRepository.RemoveAsync(value);
                return new SuccessResult("Pricing is removed successfull!");
            }
            else return new ErrorResult("Pricing is not removed!");
        }
    }
}
