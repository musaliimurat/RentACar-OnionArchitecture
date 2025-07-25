using MediatR;
using RentACar.Application.Features.CQRS.Queries.ContactQueries;
using RentACar.Application.Features.CQRS.Results.ContactResults;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Common.Utilities.Results.Abstract;
using RentACar.Common.Utilities.Results.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Read.ContactReadHandlers
{
    public class GetAllContactQueryHandler : IRequestHandler<GetAllContactQuery, IDataResult<List<GetAllContactQueryResult>>>
    {
        private readonly IContactRepository _contactRepository;

        public GetAllContactQueryHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<IDataResult<List<GetAllContactQueryResult>>> Handle(GetAllContactQuery request, CancellationToken cancellationToken)
        {
            var values = await _contactRepository.GetAllAsync();
            var result = values.Select(c => new GetAllContactQueryResult
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                Subject = c.Subject,
                Message = c.Message,
                SendDate = c.SendDate,
            }).ToList();
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<GetAllContactQueryResult>>(result, "Contact list is load successfull!");
            }
            else return new ErrorDataResult<List<GetAllContactQueryResult>>("Contact list is not found!");
        }
    }
}