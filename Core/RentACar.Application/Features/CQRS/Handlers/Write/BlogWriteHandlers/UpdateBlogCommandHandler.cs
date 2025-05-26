using MediatR;
using RentACar.Application.Features.CQRS.Commands.BlogCommands;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Application.Utilities.Results.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Write.BlogWriteHandlers
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, IResult>
    {
        private readonly IBlogRepository _blogRepository;

        public UpdateBlogCommandHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<IResult> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = await _blogRepository.GetAsync(b=>b.Id == request.Id);
            if (blog == null) return new ErrorResult("Blog is not found!");
            blog.AuthorId = request.AuthorId;
            blog.CategoryId = request.CategoryId;
            blog.Title = request.Title;
            blog.Content = request.Content;
            blog.ImageUrl = request.ImageUrl;
            blog.IsNew = request.IsNew;
            blog.UpdateDate = DateTime.Today;
            await _blogRepository.UpdateAsync(blog);
            return new SuccessResult("Blog updated successfully!");
        }
    }
}
