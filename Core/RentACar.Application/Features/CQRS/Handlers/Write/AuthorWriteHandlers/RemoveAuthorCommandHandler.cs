using MediatR;
using RentACar.Application.Features.CQRS.Commands.AuthorCommands;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Common.Utilities.Results.Abstract;
using RentACar.Common.Utilities.Results.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Write.AuthorWriteHandlers
{
    public class RemoveAuthorCommandHandler(IAuthorRepository authorRepository)
        : IRequestHandler<RemoveAuthorCommand, IResult>
    {
        public async Task<IResult> Handle(RemoveAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await authorRepository.GetAsync(x => x.Id == request.Id);
            if (author == null) return new ErrorResult("Author not found!");
            await authorRepository.RemoveAsync(author);
            return new SuccessResult("Author deleted successfully!");
        }
    }
    }
