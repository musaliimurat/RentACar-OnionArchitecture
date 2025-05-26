using MediatR;
using RentACar.Application.DTOs.Concrete.CarDto;
using RentACar.Application.Features.CQRS.Commands.CarCommands;
using RentACar.Application.Features.CQRS.Queries.CarQueries;
using RentACar.Application.Features.CQRS.Results.CarResults;
using RentACar.Application.Interfaces.Services;
using RentACar.Application.Pagination;
using RentACar.Application.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Services
{
    public class CarManager : ICarService
    {
        private readonly IMediator _mediator;

        public CarManager(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IResult> CreateCarAsync(CreateCarCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<IResult> DeleteCarAsync(Guid id)
        {
            return await _mediator.Send(new RemoveCarCommand(id));
        }

        public async Task<IDataResult<List<GetAllCarQueryResult>>> GetAllCarsAsync()
        {
            return await _mediator.Send(new GetAllCarQuery());
        }

        public async Task<IDataResult<List<GetAllCarsToPriceListDto>>> GetAllCarsToPriceListsAsync()
        {
            return await _mediator.Send(new GetAllCarsToPriceListQuery());
        }

        public async Task<IDataResult<PaginatedList<GetAllCarsDto>>> GetAllCarsWithBrandsAsync(int page, int pageSize)
        {
            var query = new GetAllCarWithBrandNameQuery
            {
                Page = page,
                PageSize = pageSize
            };
            return await _mediator.Send(query);
        }

        public async Task<IDataResult<List<GetAllFeaturedCarsDto>>> GetAllFeaturedCarsAsync()
        {
            return await _mediator.Send(new GetAllCarIsFeaturedQuery());
        }

        public async Task<IDataResult<GetCarByIdQueryResult>> GetCarByIdAsync(Guid id)
        {
            return await _mediator.Send(new GetCarByIdQuery(id));
        }

        public async Task<IResult> UpdateCarAsync(UpdateCarCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
