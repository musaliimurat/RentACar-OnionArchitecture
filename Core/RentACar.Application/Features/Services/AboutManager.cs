using MediatR;
using RentACar.Application.Features.CQRS.Commands.AboutCommands;
using RentACar.Application.Features.CQRS.Queries.AboutQueries;
using RentACar.Application.Features.CQRS.Results.AboutResults;
using RentACar.Application.Interfaces.Services;
using RentACar.Application.Utilities.BusinessRules;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Application.Utilities.Results.Concrete;

namespace RentACar.Application.Features.Services
{
    public class AboutManager : IAboutService
    {
        private readonly IMediator _mediator;

        public AboutManager(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IResult> CreateAboutAsync(CreateAboutCommand command)
        {
            var result = await BusinessRules.Run(CheckIfAboutCountLimitExceded());

            if (result != null)
            {
                return result;
            }
            else
            {
                return await _mediator.Send(command);
            }
        }

        public async Task<IResult> DeleteAboutAsync(Guid id)
        {
            return await _mediator.Send(new RemoveAboutCommand(id));
        }

        public async Task<IDataResult<GetAboutByIdQueryResult>> GetAboutByIdAsync(Guid id)
        {
            return await _mediator.Send(new GetAboutByIdQuery(id));
        }

        public async Task<IDataResult<List<GetAllAboutQueryResult>>> GetAllAboutAsync()
        {
            return await _mediator.Send(new GetAllAboutQuery());
        }

        public async Task<IResult> UpdateAboutAsync(UpdateAboutCommand command)
        {
            return await _mediator.Send(command);
        }

        private async Task<IResult> CheckIfAboutCountLimitExceded()
        {
            var abouts = await _mediator.Send(new GetAllAboutQuery());

            if (abouts == null || abouts.Data == null || abouts.Data.Count == 0)
            {
                return new SuccessResult();
            }
            if (abouts.Data.Count >= 4)
            {
                return new ErrorResult("About count limit exceeded!");
            }
            else
            {
                return new SuccessResult();
            }
        }
    }
}
