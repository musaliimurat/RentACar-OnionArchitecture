using MediatR;
using RentACar.Application.Features.CQRS.Commands.AuthorCommands;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Application.Utilities.Results.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Write.AuthorWriteHandlers
{
    public class RemoveAuthorCommandHandler : IRequestHandler<RemoveAuthorCommand, IResult>
    {
        private readonly IAuthorRepository _authorRepository;
        public RemoveAuthorCommandHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public async Task<IResult> Handle(RemoveAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _authorRepository.GetAsync(x => x.Id == request.Id);
            if (author == null) return new ErrorResult("Author not found!");
            await _authorRepository.RemoveAsync(author);
            return new SuccessResult("Author deleted successfully!");
        }
    }
    }
