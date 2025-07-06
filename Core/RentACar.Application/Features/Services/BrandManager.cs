using AutoMapper;
using MediatR;
using RentACar.Application.DTOs.Concrete.BrandDto;
using RentACar.Application.Features.CQRS.Commands.BrandCommands;
using RentACar.Application.Features.CQRS.Queries.BrandQueries;
using RentACar.Application.Features.CQRS.Results.BrandResults;
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
    public class BrandManager : IBrandService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public BrandManager(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IResult> CreateBrandAsync(CreateBrandDto createBrandDto)
        {
            var command = _mapper.Map<CreateBrandCommand>(createBrandDto);
            return await _mediator.Send(command);
        }

        public async Task<IResult> DeleteBrandAsync(Guid id)
        {
            return await _mediator.Send(new RemoveBrandCommand(id));
        }

        public async Task<IDataResult<List<GetAllBrandDto>>> GetAllBrandsAsync()
        {
            var result = await _mediator.Send(new GetAllBrandQuery());
            if (!result.Success)
                return new ErrorDataResult<List<GetAllBrandDto>>(result.Message);

            var mappedData = _mapper.Map<List<GetAllBrandDto>>(result.Data);
            return new SuccessDataResult<List<GetAllBrandDto>>(mappedData, result.Message);
        }

        public async Task<IDataResult<GetBrandByIdDto>> GetBrandByIdAsync(Guid id)
        {
            var result = await _mediator.Send(new GetBrandByIdQuery(id));
            var mappedData = _mapper.Map<GetBrandByIdDto>(result.Data);
            return result.Success
                ? new SuccessDataResult<GetBrandByIdDto>(mappedData, result.Message)
                : new ErrorDataResult<GetBrandByIdDto>(result.Message);
        }

        public async Task<IResult> UpdateBrandAsync(UpdateBrandDto updateBrandDto)
        {
            var command = _mapper.Map<UpdateBrandCommand>(updateBrandDto);
            return await _mediator.Send(command);
        }
    }
}
