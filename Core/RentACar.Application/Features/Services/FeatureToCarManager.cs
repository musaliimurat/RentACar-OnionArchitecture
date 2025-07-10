using AutoMapper;
using MediatR;
using RentACar.Application.DTOs.Concrete.FeatureToCarDTOs;
using RentACar.Application.Features.CQRS.Commands.CarFeatureCommands;
using RentACar.Application.Features.CQRS.Queries.CarFeatureQueries;
using RentACar.Application.Interfaces.Services;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Application.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Services
{
    public class FeatureToCarManager : IFeatureToCarService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public FeatureToCarManager(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IResult> CreateFeatureToCarAsync(CreateFeatureToCarDto createFeatureToCarDto)
        {
            var command = _mapper.Map<CreateFeatureToCarCommand>(createFeatureToCarDto);
            return await _mediator.Send(command);
        }

        public async Task<IResult> DeleteFeatureToCarAsync(Guid id)
        {
            var command = new RemoveFeatureToCarCommand(id);
            return await _mediator.Send(command);
        }

        public async Task<IDataResult<List<GetAllFeatureToCarDto>>> GetAllFeatureToCarsAsync()
        {
            var result = await _mediator.Send(new GetAllCarFeatureQuery());
            if (!result.Success)
              return new ErrorDataResult<List<GetAllFeatureToCarDto>>(result.Message);

            var mappedData = _mapper.Map<List<GetAllFeatureToCarDto>>(result.Data);
            return new SuccessDataResult<List<GetAllFeatureToCarDto>>(mappedData, result.Message);
        }

        public async Task<IDataResult<GetFeatureToCarByIdDto>> GetFeatureToCarByIdAsync(Guid id)
        {
            var result = await _mediator.Send(new GetCarFeatureByIdQuery(id));
            if (!result.Success)
                return new ErrorDataResult<GetFeatureToCarByIdDto>(result.Message);

            var mappedData = _mapper.Map<GetFeatureToCarByIdDto>(result.Data);
            return new SuccessDataResult<GetFeatureToCarByIdDto>(mappedData, result.Message);
        }

        public async Task<IResult> UpdateFeatureToCarAsync(UpdateFeatureToCarDto updateFeatureToCarDto)
        {
            var command = _mapper.Map<UpdateFeatureToCarCommand>(updateFeatureToCarDto);
            return await _mediator.Send(command);
        }
    }
}
