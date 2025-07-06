using AutoMapper;
using MediatR;
using RentACar.Application.Features.CQRS.Commands.FeatureCommands;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Application.Utilities.Results.Concrete;
using RentACar.Domain.Entities.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Write.FeatureWriteHandlers
{
    public class CreateFeatureCommandHandler : IRequestHandler<CreateFeatureCommand, IResult>
    {
        private readonly IFeatureRepository _featureRepository;
        private readonly IMapper _mapper;

        public CreateFeatureCommandHandler(IFeatureRepository featureRepository, IMapper mapper)
        {
            _featureRepository = featureRepository;
            _mapper = mapper;
        }

        public async Task<IResult> Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
        {
           
            if (request != null)
            {
                Feature feature = new()
                {
                    Name = request.Name,

                };
                await _featureRepository.CreateAsync(feature);

                return new SuccessResult("Feature is created successfull!");
            }
            else
            {
                return new ErrorResult("Feature is not created!");
            }
        }
    }
}
