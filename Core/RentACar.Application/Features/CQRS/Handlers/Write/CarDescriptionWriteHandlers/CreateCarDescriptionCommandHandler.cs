using MediatR;
using RentACar.Application.Features.CQRS.Commands.CarDescriptionCommands;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Common.Utilities.Results.Abstract;
using RentACar.Common.Utilities.Results.Concrete;
using RentACar.Domain.Entities.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Write.CarDescriptionWriteHandlers
{
    public class CreateCarDescriptionCommandHandler : IRequestHandler<CreateCarDescriptionCommand, IResult>
    {
        private readonly ICarDescriptionRepository _carDescriptionRepository;

        public CreateCarDescriptionCommandHandler(ICarDescriptionRepository carDescriptionRepository)
        {
            _carDescriptionRepository = carDescriptionRepository;
        }

        public async Task<IResult> Handle(CreateCarDescriptionCommand request, CancellationToken cancellationToken)
        {
            CarDescription carDescription = new()
            {
                CarId = request.CarId,
                Details = request.Details,
            };
            await _carDescriptionRepository.CreateAsync(carDescription);
            return new SuccessResult("Car description created successfully.");
        }
    }
}
