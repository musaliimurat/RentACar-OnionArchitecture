using MediatR;
using RentACar.Application.Features.CQRS.Commands.CarFeatureCommands;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Common.Utilities.Results.Abstract;
using RentACar.Common.Utilities.Results.Concrete;

public class RemoveFeatureToCarCommandHandler : IRequestHandler<RemoveFeatureToCarCommand, IResult>
{
    private readonly ICarFeatureRepository _carFeatureRepository;
    public RemoveFeatureToCarCommandHandler(ICarFeatureRepository carFeatureRepository)
    {
        _carFeatureRepository = carFeatureRepository;
    }
    public async Task<IResult> Handle(RemoveFeatureToCarCommand request, CancellationToken cancellationToken)
    {
        var carFeature = await _carFeatureRepository.GetAsync(ft=> ft.Id == request.Id);
        if (carFeature != null)
        {
            await _carFeatureRepository.RemoveAsync(carFeature);
            return new SuccessResult("Feature removed from car successfully.");
        }
        else
        {
            return new ErrorResult("Feature not found for the specified car.");
        }
    }
}
