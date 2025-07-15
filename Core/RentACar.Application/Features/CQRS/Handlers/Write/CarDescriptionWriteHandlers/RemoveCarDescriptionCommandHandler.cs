using MediatR;
using RentACar.Application.Features.CQRS.Commands.CarDescriptionCommands;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Application.Utilities.Results.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Write.CarDescriptionWriteHandlers
{
    public class RemoveCarDescriptionCommandHandler : IRequestHandler<RemoveCarDescriptionCommand, IResult>
    {
        private readonly ICarDescriptionRepository _carDescriptionRepository;

        public RemoveCarDescriptionCommandHandler(ICarDescriptionRepository carDescriptionRepository)
        {
            _carDescriptionRepository = carDescriptionRepository;
        }

        public async Task<IResult> Handle(RemoveCarDescriptionCommand request, CancellationToken cancellationToken)
        {
            var carDescription = await _carDescriptionRepository.GetCarDescriptionByIdAsync(request.Id);
            if (carDescription == null)
            {
                return new ErrorResult("Car description not found.");
            }
            await _carDescriptionRepository.RemoveAsync(carDescription);
            return new SuccessResult("Car description updated successfully.");
        }
    }
}
