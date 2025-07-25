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
    public class CreateAboutCommandHandler : IRequestHandler<CreateAboutCommand, IResult>
    {
        private readonly IAboutRepository _aboutRepository;
       

        public CreateAboutCommandHandler(IAboutRepository aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }
        public async Task<IResult> Handle(CreateAboutCommand request, CancellationToken cancellationToken)
        {
            About about = new()
            {
                Title = request.Title,
                Description = request.Description,
                ImageUrl = request.ImageUrl,
            };
          

            await _aboutRepository.CreateAsync(about);
            return  new SuccessResult("About created successfully!");
        }

       
    }
}
