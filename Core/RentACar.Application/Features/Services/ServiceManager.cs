using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.CQRS.Commands.ServiceCommands;
using RentACar.Application.Features.CQRS.Queries.ServiceQueries;
using RentACar.Application.Features.CQRS.Results.ServiceResults;
using RentACar.Application.Interfaces.Services;
using RentACar.Common.Utilities.Results.Abstract;
using RentACar.Common.Utilities.Results.Concrete;

namespace RentACar.Application.Features.Services
{
    public class ServiceManager : ICompanyServiceService
    {
        private readonly IMediator _mediator;

        public ServiceManager(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IResult> CreateAsync(CreateServiceCommand command)
        {
            await _mediator.Send(command);
            return new SuccessResult("Service added successfully!");
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            return await _mediator.Send(new RemoveServiceCommand(id));
        }

        public async Task<IDataResult<List<GetAllServiceQueryResult>>> GetAllAsync()
        {
            return await _mediator.Send(new GetAllServiceQuery());
        }

        public async Task<IDataResult<GetServiceByIdQueryResult>> GetByIdAsync(Guid id)
        {
            return await _mediator.Send(new GetServiceByIdQuery(id));
        }

        public async Task<IResult> UpdateAsync(UpdateServiceCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
