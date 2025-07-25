using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.CQRS.Commands.AboutCommands;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Common.Utilities.Results.Abstract;
using RentACar.Common.Utilities.Results.Concrete;
using RentACar.Domain.Entities.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Write.AboutWriteHandlers
{
    public class RemoveAboutCommandHandler : IRequestHandler<RemoveAboutCommand, IResult>
    {
        private readonly IAboutRepository _aboutRepository;

        public RemoveAboutCommandHandler(IAboutRepository aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }

        public async Task<IResult> Handle(RemoveAboutCommand request, CancellationToken cancellationToken)
        {
            var value = await _aboutRepository.GetAsync(a => a.Id == request.Id);
            if (value != null)
            {

                await _aboutRepository.RemoveAsync(value);
                return new SuccessResult("About removed successfully!");
            }
            else
            {
                return new ErrorResult("About not found!");
            }
        }
    }
}
