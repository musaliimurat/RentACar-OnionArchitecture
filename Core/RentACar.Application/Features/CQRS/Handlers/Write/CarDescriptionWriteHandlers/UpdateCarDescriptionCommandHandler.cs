using MediatR;
using RentACar.Application.Features.CQRS.Commands.CarDescriptionCommands;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Application.Utilities.Results.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Write.CarDescriptionWriteHandlers
{
    public class UpdateCarDescriptionCommandHandler : IRequestHandler<UpdateCarDescriptionCommand, IResult>
    {
        private readonly ICarDescriptionRepository _carDescriptionRepository;

        public UpdateCarDescriptionCommandHandler(ICarDescriptionRepository carDescriptionRepository)
        {
            _carDescriptionRepository = carDescriptionRepository;
        }

        public async Task<IResult> Handle(UpdateCarDescriptionCommand request, CancellationToken cancellationToken)
        {
            var carDescription = await _carDescriptionRepository.GetCarDescriptionByIdAsync(request.Id);
            if (carDescription == null)
            {
                return new ErrorResult("Car description not found.");
            }
            carDescription.CarId = request.CarId;
            carDescription.Details = request.Details;
            carDescription.UpdateDate = DateTime.Today;
            await _carDescriptionRepository.UpdateAsync(carDescription);
            return new SuccessResult("Car description updated successfully.");
        }
    }
}
