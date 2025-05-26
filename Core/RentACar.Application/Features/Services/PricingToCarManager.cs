using MediatR;
using RentACar.Application.DTOs.Concrete.CarDto;
using RentACar.Application.Features.CQRS.Commands.CarCommands;
using RentACar.Application.Features.CQRS.Commands.CarPricingCommands;
using RentACar.Application.Features.CQRS.Queries.CarPricingQueries;
using RentACar.Application.Features.CQRS.Results.CarPricingResults;
using RentACar.Application.Interfaces.Services;
using RentACar.Application.Utilities.Results.Abstract;
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

        public PricingToCarManager(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IResult> AddAsync(CreatePricingToCarCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            return await _mediator.Send(new RemoveCarCommand(id));
        }

        public async Task<IDataResult<List<GetAllCarPricingQueryResult>>> GetAllAsync()
        {
            return await _mediator.Send(new GetAllCarPricingQuery());
        }

        public async Task<IDataResult<GetCarPricingByIdQueryResult>> GetByIdAsync(Guid id)
        {
            return await _mediator.Send(new GetCarPricingByIdQuery(id));
        }

        public async Task<IResult> UpdateAsync(UpdatePricingToCarCommand command)
        {
           return await _mediator.Send(command);
        }
    }
}
