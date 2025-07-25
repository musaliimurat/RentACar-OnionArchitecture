using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using RentACar.Application.DTOs.Concrete.PricingDTOs;
using RentACar.Application.Features.CQRS.Commands.PricingCommands;
using RentACar.Application.Features.CQRS.Queries.PricingQueries;
using RentACar.Application.Features.Validators.FeatureValidators;
using RentACar.Application.Features.Validators.PricingValidators;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Application.Interfaces.Services;
using RentACar.Common.Aspects.ValidationAspect;
using RentACar.Common.Utilities.Results.Abstract;
using RentACar.Common.Utilities.Results.Concrete;

namespace RentACar.Application.Features.Services
{
    public class PricingManager : IPricingService
    {
        private readonly IPricingRepository _pricingRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public PricingManager(IMediator mediator, IMapper mapper, IPricingRepository pricingRepository)
        {
            _mediator = mediator;
            _mapper = mapper;
            _pricingRepository = pricingRepository;
        }

        [ValidationAspect(typeof(CreatePricingDtoValidator))]
        public async Task<IResult> CreatePricingAsync(CreatePricingDto createPricingDto)
        {
            var command = _mapper.Map<CreatePricingCommand>(createPricingDto);
            var result = await _mediator.Send(command);
            return result;
        }

        public Task<IResult> DeletePricingAsync(Guid id)
        {
            var command = new RemovePricingCommand(id);
            return _mediator.Send(command);
        }

        public async Task<IDataResult<List<GetAllPricingDto>>> GetAllPricingAsync()
        {
            var result = await _mediator.Send(new GetAllPricingQuery());
            if (!result.Success)
                return new ErrorDataResult<List<GetAllPricingDto>>(result.Message);

            var mappedData = _mapper.Map<List<GetAllPricingDto>>(result.Data);
            return new SuccessDataResult<List<GetAllPricingDto>>(mappedData, result.Message);
        }

        public async Task<IDataResult<GetPricingByIdDto>> GetPricingByIdAsync(Guid id)
        {
            var result = await _mediator.Send(new GetPricingByIdQuery(id));
            if (!result.Success)
                return new ErrorDataResult<GetPricingByIdDto>(result.Message);

            var mappedData = _mapper.Map<GetPricingByIdDto>(result.Data);
            return new SuccessDataResult<GetPricingByIdDto>(mappedData, result.Message);
        }

        [ValidationAspect(typeof(UpdatePricingDtoValidator))]
        public Task<IResult> UpdatePricingAsync(UpdatePricingDto updatePricingDto)
        {
            var command = _mapper.Map<UpdatePricingCommand>(updatePricingDto);
            return _mediator.Send(command);
        }
    }
}
