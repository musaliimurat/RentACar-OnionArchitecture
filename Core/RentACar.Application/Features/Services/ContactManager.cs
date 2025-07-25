using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.DTOs.Concrete.ContactDto;
using RentACar.Application.Features.CQRS.Commands.ContactCommands;
using RentACar.Application.Features.CQRS.Queries.ContactQueries;
using RentACar.Application.Features.CQRS.Results.ContactResults;
using RentACar.Application.Interfaces.Services;
using RentACar.Common.Utilities.Results.Abstract;

namespace RentACar.Application.Features.Services
{
    public class ContactManager : IContactService
    {
        private readonly IMediator _mediator;

        public ContactManager(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IResult> CreateContactAsync(ContactCreateDto contactCreateDto)
        {
            var command = new CreateContactCommand
            {
                Name = contactCreateDto.Name,
                Email = contactCreateDto.Email,
                Subject = contactCreateDto.Subject,
                Message = contactCreateDto.Message,
                SendDate = DateTime.Today,
                
            };
            return await _mediator.Send(command);
        }

        public async Task<IResult> DeleteContactAsync(Guid id)
        {
            return await _mediator.Send(new RemoveContactCommand(id));
        }

        public async Task<IDataResult<List<GetAllContactQueryResult>>> GetAllContactAsync()
        {
            return await _mediator.Send(new GetAllContactQuery());
        }

        public async Task<IDataResult<GetContactByIdQueryResult>> GetByIdContactAsync(Guid id)
        {
            return await _mediator.Send(new GetContactByIdQuery(id));
        }

        public async Task<IResult> UpdateContactAsync(UpdateContactCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
