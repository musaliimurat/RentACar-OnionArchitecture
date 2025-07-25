using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.DTOs.Concrete.ContactDto;
using RentACar.Application.Features.CQRS.Commands.ContactCommands;
using RentACar.Application.Features.CQRS.Results.ContactResults;
using RentACar.Common.Utilities.Results.Abstract;

namespace RentACar.Application.Interfaces.Services
{
    public interface IContactService
    {
        Task<IResult> CreateContactAsync(ContactCreateDto contactCreateDto);
        Task<IResult> UpdateContactAsync(UpdateContactCommand command);
        Task<IResult> DeleteContactAsync(Guid id);
        Task<IDataResult<List<GetAllContactQueryResult>>> GetAllContactAsync();
        Task<IDataResult<GetContactByIdQueryResult>> GetByIdContactAsync(Guid id);
    }
}
