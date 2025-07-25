using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.CQRS.Commands.FeatureCommands;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Common.Utilities.Results.Abstract;
using RentACar.Common.Utilities.Results.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Write.FeatureWriteHandlers
{
    public class RemoveFeatureCommandHandler(IFeatureRepository featureRepository)
        : IRequestHandler<RemoveFeatureCommand, IResult>
    {
        public async Task<IResult> Handle(RemoveFeatureCommand request, CancellationToken cancellationToken)
        {
            var value = await featureRepository.GetAsync(f => f.Id == request.Id);
            if (value !=null)
            {

                await featureRepository.RemoveAsync(value);
                return new SuccessResult("Feature is removed successfully!");
            }
            else return new ErrorResult("Feature is not removed!");
        }
    }
}
