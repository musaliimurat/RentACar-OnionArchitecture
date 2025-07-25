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

namespace RentACar.Application.Features.CQRS.Handlers.Write.ContactWriteHandlers
{
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, IResult>
    {
        private readonly IContactRepository _contactRepository;

        public UpdateContactCommandHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<IResult> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var value = await _contactRepository.GetAsync(c=>c.Id == request.Id);
            if (value != null) 
            {
                value.Name = request.Name;
                value.Email = request.Email;
                value.Subject = request.Subject;
                value.Message = request.Message;
                value.SendDate = request.SendDate;

                await _contactRepository.UpdateAsync(value);
                return new SuccessResult("Contact is updated successfully!");
            }
            else return new ErrorResult("Contact is not updated!");
        }
    }
}
