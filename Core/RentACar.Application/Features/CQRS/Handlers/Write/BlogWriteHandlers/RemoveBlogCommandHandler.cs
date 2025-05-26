using MediatR;
using RentACar.Application.Features.CQRS.Commands.BlogCommands;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Application.Utilities.Results.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Write.BlogWriteHandlers
{
    public class RemoveBlogCommandHandler : IRequestHandler<RemoveBlogCommand, IResult>
    {
        private readonly IBlogRepository _blogRepository;
        public RemoveBlogCommandHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
        public async Task<IResult> Handle(RemoveBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = await _blogRepository.GetAsync(b => b.Id == request.Id);
            if (blog == null) return new ErrorResult("Blog is not found!");
            await _blogRepository.RemoveAsync(blog);
            return new SuccessResult("Blog removed successfully!");
        }
    }
}
