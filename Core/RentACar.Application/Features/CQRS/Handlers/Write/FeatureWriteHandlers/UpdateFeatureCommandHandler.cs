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
    public class UpdateFeatureCommandHandler : IRequestHandler<UpdateFeatureCommand, IResult>
    {
        private readonly IFeatureRepository _featureRepository;

        public UpdateFeatureCommandHandler(IFeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;
        }

        public async Task<IResult> Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
        {
            var value = await _featureRepository.GetAsync(f => f.Id == request.Id);
            if (value !=null)
            {
                value.Name = request.Name;
                value.UpdateDate = DateTime.Today;
                await _featureRepository.UpdateAsync(value);
                return new SuccessResult("Feature is updated successfully!");
            }
            else return new ErrorResult("Feature is not updated!");
        }
    }
}
