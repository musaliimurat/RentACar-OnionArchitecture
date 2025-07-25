using MediatR;
using RentACar.Application.Features.CQRS.Commands.AuthorCommands;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Common.Utilities.Results.Abstract;
using RentACar.Common.Utilities.Results.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Write.AuthorWriteHandlers
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, IResult>
    {
        private readonly IAuthorRepository _authorRepository;
        public UpdateAuthorCommandHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public async Task<IResult> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _authorRepository.GetAsync(x => x.Id == request.Id);
            if (author == null) return new ErrorResult("Author not found!");
            author.FullName = request.FullName;
            author.ImageUrl = request.ImageUrl;
            author.Description = request.Description;
            author.UpdateDate = DateTime.Today;
            await _authorRepository.UpdateAsync(author);
            return new SuccessResult("Author updated successfully!");
        }
    }
    }
