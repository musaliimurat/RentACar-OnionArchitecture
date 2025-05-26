using MediatR;
using RentACar.Application.Features.CQRS.Commands.BannerCommands;
using RentACar.Application.Features.CQRS.Queries.BannerQueries;
using RentACar.Application.Features.CQRS.Results.BannerResults;
using RentACar.Application.Interfaces.Services;
using RentACar.Application.Utilities.Results.Abstract;
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

        public BannerManager(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IResult> CreateBannerAsync(CreateBannerCommand command)
        {
           return await _mediator.Send(command);
        }

        public async Task<IResult> DeleteBannerAsync(Guid id)
        {
            return await _mediator.Send(new RemoveBannerCommand(id));
        }

        public async Task<IDataResult<List<GetAllBannerQueryResult>>> GetAllBannerAsync()
        {
            return await _mediator.Send(new GetAllBannerQuery());
        }

        public async Task<IDataResult<GetBannerByIdQueryResult>> GetBannerByIdAsync(Guid id)
        {
           return await _mediator.Send(new GetBannerByIdQuery(id));
        }

        public async Task<IResult> UpdateBannerAsync(UpdateBannerCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
