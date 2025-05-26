using MediatR;
using RentACar.Application.Features.CQRS.Commands.AuthorCommands;
using RentACar.Application.Features.CQRS.Queries.AuthorQueries;
using RentACar.Application.Features.CQRS.Results.AuthorResults;
using RentACar.Application.Interfaces.Services;
using RentACar.Application.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Services
{
    public class AuthorManager : IAuthorService
    {
        private readonly IMediator _mediator;

        public AuthorManager(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IResult> CreateAuthorAsync(CreateAuthorCommand request)
        {
          return await _mediator.Send(request);
        }

        public async Task<IResult> DeleteAuthorAsync(Guid id)
        {
            return await _mediator.Send(new RemoveAuthorCommand(id));
        }

        public async Task<IDataResult<List<GetAllAuthorQueryResult>>> GetAllAuthorsAsync()
        {
            return await _mediator.Send(new GetAllAuthorQuery());
        }

        public async Task<IDataResult<GetAuthorByIdQueryResult>> GetAuthorByIdAsync(Guid id)
        {
            return await _mediator.Send(new GetAuthorByIdQuery(id));
        }

        public async Task<IResult> UpdateAuthorAsync(UpdateAuthorCommand request)
        {
            return await _mediator.Send(request);
        }
    }
}
