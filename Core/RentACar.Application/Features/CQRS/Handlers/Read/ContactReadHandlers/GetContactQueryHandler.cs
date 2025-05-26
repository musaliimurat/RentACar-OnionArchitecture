using MediatR;
using RentACar.Application.Features.CQRS.Queries.ContactQueries;
using RentACar.Application.Features.CQRS.Results.ContactResults;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Application.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Handlers.Read.ContactReadHandlers
{
    public class GetContactQueryHandler : IRequestHandler<GetContactByIdQuery, IDataResult<GetContactByIdQueryResult>>
    {
        private readonly IContactRepository _contactRepository;

        public GetContactQueryHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async  Task<IDataResult<GetContactByIdQueryResult>> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _contactRepository.GetAsync(c => c.Id == request.Id);
          
            if (value != null)
            {
                GetContactByIdQueryResult getContactByIdQueryResult = new()
                {
                    Id = value.Id,
                    Name = value.Name,
                    Email = value.Email,
                    Subject = value.Subject,
                    SendDate = value.SendDate,
                    Message = value.Message,
                };
                return new SuccessDataResult<GetContactByIdQueryResult>(getContactByIdQueryResult, "Contact is load successfull!");
            }
            else return new ErrorDataResult<GetContactByIdQueryResult>("Contact is not found!");
        }
    }
}
