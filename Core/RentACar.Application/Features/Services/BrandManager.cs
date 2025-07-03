using MediatR;
using RentACar.Application.Features.CQRS.Commands.BrandCommands;
using RentACar.Application.Features.CQRS.Queries.BrandQueries;
using RentACar.Application.Features.CQRS.Results.BrandResults;
using RentACar.Application.Interfaces.Services;
using RentACar.Application.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Services
{
    public class BrandManager : IBrandService
    {
        private readonly IMediator _mediator;

        public BrandManager(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IResult> CreateBrandAsync(CreateBrandCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<IResult> DeleteBrandAsync(Guid id)
        {
            return await _mediator.Send(new RemoveBrandCommand(id));
        }

        public async Task<IDataResult<List<GetAllBrandQueryResult>>> GetAllBrandsAsync()
        {
            return await _mediator.Send(new GetAllBrandQuery());
        }

        public async Task<IDataResult<GetBrandByIdQueryResult>> GetBrandByIdAsync(Guid id)
        {
            return await _mediator.Send(new GetBrandByIdQuery(id));
        }

        public async Task<IResult> UpdateBrandAsync(UpdateBrandCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
