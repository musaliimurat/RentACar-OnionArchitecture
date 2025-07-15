using AutoMapper;
using MediatR;
using RentACar.Application.DTOs.Concrete.CarDto;
using RentACar.Application.DTOs.Concrete.PricingToCarDTOs;
using RentACar.Application.Features.CQRS.Commands.CarCommands;
using RentACar.Application.Features.CQRS.Commands.CarPricingCommands;
using RentACar.Application.Features.CQRS.Queries.CarPricingQueries;
using RentACar.Application.Features.CQRS.Results.CarPricingResults;
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
    public class PricingToCarManager : IPricingToCarService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PricingToCarManager(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IResult> AddAsync(CreatePricingToCarDto createPricingToCarDto)
        {
            var command = _mapper.Map<CreatePricingToCarCommand>(createPricingToCarDto);
            return await _mediator.Send(command);
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            return await _mediator.Send(new RemovePricingToCarCommand(id));
        }

        public async Task<IDataResult<List<GetAllCarPricingQueryResult>>> GetAllAsync()
        {
            return await _mediator.Send(new GetAllCarPricingQuery());
        }

        public async Task<IDataResult<List<GetAllPricingToCarDto>>> GetAllForAdminAsync()
        {
            var  result = await _mediator.Send(new GetAllCarPricingForAdminQuery());
            if (result.Success)
            {
                var mappedData = _mapper.Map<List<GetAllPricingToCarDto>>(result.Data);
                return new SuccessDataResult<List<GetAllPricingToCarDto>>(mappedData, result.Message);
            }
            else
            {
                return new ErrorDataResult<List<GetAllPricingToCarDto>>(result.Message);
            }
        }

        public async Task<IDataResult<GetCarPricingByIdQueryResult>> GetByIdAsync(Guid id)
        {
            return await _mediator.Send(new GetCarPricingByIdQuery(id));
        }

        public async Task<IDataResult<GetPricingToCarByIdDto>> GetByIdForAdminAsync(Guid id)
        {
            var result = await _mediator.Send(new GetCarPricingByIdForAdminQuery(id));
            if (result.Success) {
                var mappedData = _mapper.Map<GetPricingToCarByIdDto>(result.Data);
                return new SuccessDataResult<GetPricingToCarByIdDto>(mappedData, result.Message);
            }
            else
            {
                return new ErrorDataResult<GetPricingToCarByIdDto>(result.Message);
            }
        }

        public async Task<IResult> UpdateAsync(UpdatePricingToCarDto updatePricingToCarDto)
        {
            var command = _mapper.Map<UpdatePricingToCarCommand>(updatePricingToCarDto);
            return await _mediator.Send(command);
        }
    }
}
