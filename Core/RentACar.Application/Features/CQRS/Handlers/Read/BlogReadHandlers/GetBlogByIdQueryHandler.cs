using MediatR;
using RentACar.Application.DTOs.Concrete.BlogDto;
using RentACar.Application.Features.CQRS.Queries.BlogQueries;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Common.Utilities.Results.Abstract;
using RentACar.Common.Utilities.Results.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Read.BlogReadHandlers
{
    public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, IDataResult<GetBlogByIdDto>>
    {
        private readonly IBlogRepository _blogRepository;

        public GetBlogByIdQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<IDataResult<GetBlogByIdDto>> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var blog = await _blogRepository.GetBlogByIdDtoAsync(request.Id);
            if (blog == null)
                return new ErrorDataResult<GetBlogByIdDto>("Blog is not found!");
            else return new SuccessDataResult<GetBlogByIdDto>(blog);
        }
    }
}
