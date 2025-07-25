using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Features;
using MediatR;
using RentACar.Application.Features.CQRS.Commands.CarFeatureCommands;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Common.Utilities.Results.Abstract;
using RentACar.Common.Utilities.Results.Concrete;
using RentACar.Domain.Entities.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Write.CarFeatureWriteHandlers
{
    public class CreateFeatureToCarCommandHandler : IRequestHandler<CreateFeatureToCarCommand, IResult>
    {
        private readonly ICarFeatureRepository _carFeatureRepository;

        public CreateFeatureToCarCommandHandler(ICarFeatureRepository carFeatureRepository)
        {
            _carFeatureRepository = carFeatureRepository;
        }

        public async Task<IResult> Handle(CreateFeatureToCarCommand request, CancellationToken cancellationToken)
        {
            if (request.SelectedFeatureIds == null || !request.SelectedFeatureIds.Any())
            {
                return new ErrorResult("No features selected.");
            }

            foreach (var featureId in request.SelectedFeatureIds)
            {
                var carFeature = new FeatureToCar
                {
                    CarId = request.CarId,
                    FeatureId = featureId,
                    IsAvailable = request.IsAvailable,
                };

                await _carFeatureRepository.CreateAsync(carFeature);
            }

            return new SuccessResult("Features assigned to car successfully.");
        }
    }
}
