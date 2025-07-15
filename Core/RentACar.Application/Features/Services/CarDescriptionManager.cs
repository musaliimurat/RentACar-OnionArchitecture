using AutoMapper;
using MediatR;
using RentACar.Application.DTOs.Concrete.CarDescriptionDTOs;
using RentACar.Application.Features.CQRS.Commands.CarDescriptionCommands;
using RentACar.Application.Features.CQRS.Queries.CarDescriptionQueries;
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
    public class CarDescriptionManager : ICarDescriptionService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CarDescriptionManager(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IResult> CreateCarDescriptionAsync(CreateCarDescriptionDto createCarDescriptionDto)
        {
            var command = _mapper.Map<CreateCarDescriptionCommand>(createCarDescriptionDto);
            return await _mediator.Send(command);
        }

        public async Task<IResult> DeleteCarDescriptionAsync(Guid id)
        {
            return await _mediator.Send(new RemoveCarDescriptionCommand(id));
        }

        public async Task<IDataResult<List<GetAllCarDescriptionDto>>> GetAllCarDescriptionsAsync()
        {
            var result = await _mediator.Send(new GetAllCarDescriptionQuery());
            if (result.Data == null || result.Data.Count == 0)
            {
                return new ErrorDataResult<List<GetAllCarDescriptionDto>>("No car descriptions found.");
            }
            var mappedData = _mapper.Map<List<GetAllCarDescriptionDto>>(result.Data);
            return new SuccessDataResult<List<GetAllCarDescriptionDto>>(mappedData, "Car descriptions retrieved successfully.");
        }

        public async Task<IDataResult<GetCarDescriptionByIdDto>> GetCarDescriptionByIdAsync(Guid id)
        {
            var query = new GetCarDescriptionByIdQuery(id);
            var result = await _mediator.Send(query);
            if (result.Data == null)
            {
                return new ErrorDataResult<GetCarDescriptionByIdDto>("Car description not found.");
            }
            var mappedData = _mapper.Map<GetCarDescriptionByIdDto>(result.Data);
            return new SuccessDataResult<GetCarDescriptionByIdDto>(mappedData, "Car description retrieved successfully.");
        }

        public async Task<IResult> UpdateCarDescriptionAsync(UpdateCarDescriptionDto updateCarDescriptionDto)
        {
            var command =  _mapper.Map<UpdateCarDescriptionCommand>(updateCarDescriptionDto);
            return await _mediator.Send(command);
        }
    }
}
