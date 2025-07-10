using AutoMapper;
using MediatR;
using RentACar.Application.DTOs.Concrete.CarDto;
using RentACar.Application.Features.CQRS.Commands.CarCommands;
using RentACar.Application.Features.CQRS.Queries.CarQueries;
using RentACar.Application.Features.CQRS.Results.CarResults;
using RentACar.Application.Interfaces.Services;
using RentACar.Application.Pagination;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Application.Utilities.Results.Concrete;
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
        private readonly IMapper _mapper;

        public CarManager(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IResult> CreateCarAsync(CreateCarDto createCarDto)
        {
            var command = _mapper.Map<CreateCarCommand>(createCarDto);
            return await _mediator.Send(command);
        }

        public async Task<IResult> DeleteCarAsync(Guid id)
        {
            return await _mediator.Send(new RemoveCarCommand(id));
        }

        public async Task<IDataResult<List<GetAllCarsDto>>> GetAllCarsAsync()
        {
            var result = await _mediator.Send(new GetAllCarQuery());
            if (!result.Success)
                return new ErrorDataResult<List<GetAllCarsDto>>(result.Message);

            var mappedData = _mapper.Map<List<GetAllCarsDto>>(result.Data);
            return new SuccessDataResult<List<GetAllCarsDto>>(mappedData, result.Message);
        }

        public async Task<IDataResult<List<GetAllCarsToPriceListDto>>> GetAllCarsToPriceListsAsync()
        {
            var result = await _mediator.Send(new GetAllCarsToPriceListQuery());
            return result.Success
                ? new SuccessDataResult<List<GetAllCarsToPriceListDto>>(result.Data, result.Message)
                : new ErrorDataResult<List<GetAllCarsToPriceListDto>>(result.Message);
        }

        public async Task<IDataResult<PaginatedList<GetAllCarsWithBrandNameDto>>> GetAllCarsWithBrandsAsync(int page, int pageSize)
        {
            var query = new GetAllCarWithBrandNameQuery
            {
                Page = page,
                PageSize = pageSize
            };
            var result = await _mediator.Send(query);
            return result.Success
                ? new SuccessDataResult<PaginatedList<GetAllCarsWithBrandNameDto>>(result.Data, result.Message)
                : new ErrorDataResult<PaginatedList<GetAllCarsWithBrandNameDto>>(result.Message);
        }

        public async Task<IDataResult<List<GetAllCarsWithBrandNameForAdminDto>>> GetAllCarsWithBrandsForAdminAsync()
        {
            var result = await _mediator.Send(new GetAllCarWithBrandNameForAdminQuery());
            return result.Success
                ? new SuccessDataResult<List<GetAllCarsWithBrandNameForAdminDto>>(result.Data, result.Message)
                : new ErrorDataResult<List<GetAllCarsWithBrandNameForAdminDto>>(result.Message);
        }

        public async Task<IDataResult<List<GetAllCarsSliderDto>>> GetAllIsSliderCarsAsync()
        {
            var result = await _mediator.Send(new GetAllCarIsSliderQuery());
            return result.Success
                ? new SuccessDataResult<List<GetAllCarsSliderDto>>(result.Data, result.Message)
                : new ErrorDataResult<List<GetAllCarsSliderDto>>(result.Message);
        }

        public async Task<IDataResult<GetCarByIdDto>> GetCarByIdAsync(Guid id)
        {
            var result = await _mediator.Send(new GetCarByIdQuery(id));
            if (!result.Success)
                return new ErrorDataResult<GetCarByIdDto>(result.Message);

            var mappedData = _mapper.Map<GetCarByIdDto>(result.Data);
            return new SuccessDataResult<GetCarByIdDto>(mappedData, result.Message);

        }

        public async Task<IResult> UpdateCarAsync(UpdateCarDto updateCarDto)
        {
            var command = _mapper.Map<UpdateCarCommand>(updateCarDto);
            return await _mediator.Send(command);
        }
    }
}
