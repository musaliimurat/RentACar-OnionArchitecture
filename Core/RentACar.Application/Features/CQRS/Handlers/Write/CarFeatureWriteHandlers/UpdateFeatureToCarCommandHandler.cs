using MediatR;
using RentACar.Application.Features.CQRS.Commands.CarFeatureCommands;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Application.Utilities.Results.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Write.CarFeatureWriteHandlers
{
    public class UpdateFeatureToCarCommandHandler : IRequestHandler<UpdateFeatureToCarCommand, IResult>
    {
        private readonly ICarFeatureRepository _carFeatureRepository;

        public UpdateFeatureToCarCommandHandler(ICarFeatureRepository carFeatureRepository)
        {
            _carFeatureRepository = carFeatureRepository;
        }

        public async Task<IResult> Handle(UpdateFeatureToCarCommand request, CancellationToken cancellationToken)
        {
            var existingFeatures = await _carFeatureRepository.GetWithDetailByIdAsync(request.Id);
            if (existingFeatures == null)
            {
                return new ErrorResult("No features selected.");
            }

                existingFeatures.CarId = request.CarId;
                existingFeatures.FeatureId = request.SelectedFeatureId;
                existingFeatures.IsAvailable = request.IsAvailable;
                existingFeatures.UpdateDate = DateTime.Today;

                await _carFeatureRepository.UpdateAsync(existingFeatures);

            return new SuccessResult("Features assigned to car  update successfully.");
        }
    }
}
