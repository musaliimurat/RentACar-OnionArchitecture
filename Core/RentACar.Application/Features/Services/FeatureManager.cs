using AutoMapper;
using MediatR;
using RentACar.Application.DTOs.Concrete.FeatureDto;
using RentACar.Application.Features.CQRS.Commands.FeatureCommands;
using RentACar.Application.Features.CQRS.Queries.FeatureQueries;
using RentACar.Application.Features.Validators.CategoryValidators;
using RentACar.Application.Features.Validators.FeatureValidators;
using RentACar.Application.Interfaces.Services;
using RentACar.Common.Aspects.ValidationAspect;
using RentACar.Common.Utilities.Results.Abstract;
using RentACar.Common.Utilities.Results.Concrete;

namespace RentACar.Application.Features.Services
{
    public class FeatureManager : IFeatureService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public FeatureManager(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [ValidationAspect(typeof(CreateFeatureDtoValidator))]
        public async Task<IResult> CreateFeatureAsync(CreateFeatureDto createFeatureDto)
        {
            var command =_mapper.Map<CreateFeatureCommand>(createFeatureDto);
            return await _mediator.Send(command);
        }

        public async Task<IResult> DeleteFeatureAsync(Guid id)
        {
            return await _mediator.Send(new RemoveFeatureCommand(id));
        }

        public async Task<IDataResult<List<GetAllFeatureDto>>> GetAllFeaturesAsync()
        {
            var result = await _mediator.Send(new GetAllFeatureQuery());
            if (!result.Success)
                return new ErrorDataResult<List<GetAllFeatureDto>>(result.Message);

            var mappedData = _mapper.Map<List<GetAllFeatureDto>>(result.Data);
            return new SuccessDataResult<List<GetAllFeatureDto>>(mappedData, result.Message);

        }

        public async Task<IDataResult<GetFeatureByIdDto>> GetFeatureByIdAsync(Guid id)
        {
            var result = await _mediator.Send(new GetFeatureByIdQuery(id));
            if (!result.Success)
                return new ErrorDataResult<GetFeatureByIdDto>(result.Message);

            var mappedData = _mapper.Map<GetFeatureByIdDto>(result.Data);
            return new SuccessDataResult<GetFeatureByIdDto>(mappedData, result.Message);

        }

        [ValidationAspect(typeof(UpdateFeatureDtoValidator))]
        public async Task<IResult> UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto)
        {
            var command = _mapper.Map<UpdateFeatureCommand>(updateFeatureDto);
            return await _mediator.Send(command);
        }
    }
}
