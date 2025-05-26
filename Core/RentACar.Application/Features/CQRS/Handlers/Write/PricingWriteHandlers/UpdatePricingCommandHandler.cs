using MediatR;
using RentACar.Application.Features.CQRS.Commands.PricingCommands;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Application.Utilities.Results.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Write.PricingWriteHandlers
{
    public class UpdatePricingCommandHandler : IRequestHandler<UpdatePricingCommand, IResult>
    {
        private readonly IPricingRepository _pricingRepository;

        public UpdatePricingCommandHandler(IPricingRepository pricingRepository)
        {
            _pricingRepository = pricingRepository;
        }

        public async Task<IResult> Handle(UpdatePricingCommand request, CancellationToken cancellationToken)
        {
            var value = await _pricingRepository.GetAsync(f => f.Id == request.Id);
            if (value != null)
            {
                value.Name = request.Name;
                await _pricingRepository.UpdateAsync(value);
                return new SuccessResult("Pricing is updated successfull!");
            }
            else return new ErrorResult("Pricing is not updated!");
        }
    }
}
