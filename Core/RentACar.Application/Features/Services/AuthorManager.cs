using AutoMapper;
using MediatR;
using RentACar.Application.DTOs.Concrete.AuthorDTOs;
using RentACar.Application.Features.CQRS.Commands.AuthorCommands;
using RentACar.Application.Features.CQRS.Queries.AuthorQueries;
using RentACar.Application.Features.CQRS.Results.AuthorResults;
using RentACar.Application.Interfaces.Services;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Application.Utilities.Results.Concrete;
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
        private readonly IMapper _mapper;

        public AuthorManager(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IResult> CreateAuthorAsync(CreateAuthorDto createAuthorDto)
        {
            var request = _mapper.Map<CreateAuthorCommand>(createAuthorDto);
            return await _mediator.Send(request);
        }

        public async Task<IResult> DeleteAuthorAsync(Guid id)
        {
            return await _mediator.Send(new RemoveAuthorCommand(id));
        }

        public async Task<IDataResult<List<GetAllAuthorDto>>> GetAllAuthorsAsync()
        {
            var result = await _mediator.Send(new GetAllAuthorQuery());
            if (result.Success)
            {
                var authors = _mapper.Map<List<GetAllAuthorDto>>(result.Data);
                return new SuccessDataResult<List<GetAllAuthorDto>>(authors, result.Message);
            }
            else return new ErrorDataResult<List<GetAllAuthorDto>>(result.Message);
        }

        public async Task<IDataResult<GetAuthorByIdDto>> GetAuthorByIdAsync(Guid id)
        {
            var result = await _mediator.Send(new GetAuthorByIdQuery(id));
            if (result.Success)
            {
                var author = _mapper.Map<GetAuthorByIdDto>(result.Data);
                return new SuccessDataResult<GetAuthorByIdDto>(author, result.Message);
            }
            else return new ErrorDataResult<GetAuthorByIdDto>(result.Message);
        }

        public async Task<IResult> UpdateAuthorAsync(UpdateAuthorDto updateAuthorDto)
        {
            var request = _mapper.Map<UpdateAuthorCommand>(updateAuthorDto);
            return await _mediator.Send(request);
        }
    }
}
