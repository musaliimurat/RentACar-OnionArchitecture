using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.CQRS.Commands.ContactCommands;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Common.Utilities.Results.Abstract;
using RentACar.Common.Utilities.Results.Concrete;
using RentACar.Domain.Entities.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Write.ContactWriteHandlers
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, IResult>
    {
        private readonly IContactRepository _contactRepository;

        public CreateContactCommandHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<IResult> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            ContactForm contactForm = new()
            {
                Name = request.Name,
                Email = request.Email,
                Subject = request.Subject,
                Message = request.Message,
                SendDate = request.SendDate,
            };
            if (request !=null)
            {
                await _contactRepository.CreateAsync(contactForm);
                return new SuccessResult("Contact is created successfully!");
            }
            else return new ErrorResult("Contact is not created!");
        }
    }
}
