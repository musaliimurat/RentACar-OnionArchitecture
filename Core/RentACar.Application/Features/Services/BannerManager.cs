using AutoMapper;
using MediatR;
using RentACar.Application.DTOs.Concrete.BannerDTOs;
using RentACar.Application.Features.CQRS.Commands.BannerCommands;
using RentACar.Application.Features.CQRS.Queries.BannerQueries;
using RentACar.Application.Features.CQRS.Results.BannerResults;
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
    public class BannerManager : IBannerService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public BannerManager(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IResult> CreateBannerAsync(CreateBannerDto createBannerDto)
        {
           var command = _mapper.Map<CreateBannerCommand>(createBannerDto);
            return await _mediator.Send(command);

        }

        public async Task<IResult> DeleteBannerAsync(Guid id)
        {
            return await _mediator.Send(new RemoveBannerCommand(id));
        }

        public async Task<IDataResult<List<GetAllBannerDto>>> GetAllBannerAsync()
        {
            var result = await _mediator.Send(new GetAllBannerQuery());

            if (!result.Success)
                return new ErrorDataResult<List<GetAllBannerDto>>(result.Message);

            var mappedData = _mapper.Map<List<GetAllBannerDto>>(result.Data);
            return new SuccessDataResult<List<GetAllBannerDto>>(mappedData, result.Message);
        }

        public async Task<IDataResult<GetBannerByIdDto>> GetBannerByIdAsync(Guid id)
        {
            var result = await _mediator.Send(new GetBannerByIdQuery(id));
            if (!result.Success)
                return new ErrorDataResult<GetBannerByIdDto>(result.Message);

            var mappedData = _mapper.Map<GetBannerByIdDto>(result.Data);
            return new SuccessDataResult<GetBannerByIdDto>(mappedData, result.Message);
        }

        public async Task<IResult> UpdateBannerAsync(UpdateBannerDto updateBannerDto)
        {
            var command = _mapper.Map<UpdateBannerCommand>(updateBannerDto);
            return await _mediator.Send(command);
        }
    }
}
