using MediatR;
using RentACar.Application.Features.CQRS.Commands.FeatureCommands;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Application.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Handlers.Write.FeatureWriteHandlers
{
    public class RemoveFeatureCommandHandler : IRequestHandler<RemoveFeatureCommand, IResult>
    {
        private readonly IFeatureRepository _featureRepository;

        public RemoveFeatureCommandHandler(IFeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;
        }

        public async Task<IResult> Handle(RemoveFeatureCommand request, CancellationToken cancellationToken)
        {
            var value = await _featureRepository.GetAsync(f => f.Id == request.Id);
            if (value !=null)
            {

                await _featureRepository.RemoveAsync(value);
                return new SuccessResult("Feature is removed successfull!");
            }
            else return new ErrorResult("Feature is not removed!");
        }
    }
}
