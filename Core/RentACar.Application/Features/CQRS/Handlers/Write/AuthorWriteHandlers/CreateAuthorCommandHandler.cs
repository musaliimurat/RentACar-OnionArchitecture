using MediatR;
using RentACar.Application.Features.CQRS.Commands.AuthorCommands;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Application.Utilities.Results.Concrete;
using RentACar.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Handlers.Write.AuthorWriteHandlers
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, IResult>
    {
        private readonly IAuthorRepository _authorRepository;

        public CreateAuthorCommandHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<IResult> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            if (request == null) return new ErrorResult("Author is null!");
            var author = new Author
            {
                FullName = request.FullName,
                ImageUrl = request.ImageUrl,
                Description = request.Description,
            };
            await _authorRepository.CreateAsync(author);
            return new SuccessResult("Author created successfully!");
        }
    }
    }
