using MediatR;
using RentACar.Application.DTOs.Concrete.BlogDto;
using RentACar.Application.Features.CQRS.Queries.BlogQueries;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Application.Pagination;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Application.Utilities.Results.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Read.BlogReadHandlers
{
    public class GetAllBlogQueryHandler : IRequestHandler<GetAllBlogQuery, IDataResult<PaginatedList<GetAllBlogDto>>>
    {
        private readonly IBlogRepository _blogRepository;

        public GetAllBlogQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<IDataResult<PaginatedList<GetAllBlogDto>>> Handle(GetAllBlogQuery request, CancellationToken cancellationToken)
        {
            var allBlogs = await _blogRepository.GetAllBlogDtosAsync();
            var count = allBlogs.Count;
            var items = allBlogs
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();
            var result = new PaginatedList<GetAllBlogDto>
            {
                Items = items,
                TotalCount = count,
                PageSize = request.PageSize,
                CurrentPage = request.Page
            };
            if (result.TotalCount > 0)
            {
                return new SuccessDataResult<PaginatedList<GetAllBlogDto>>(result, "Blog list is load successfull!");
            }
            else return new ErrorDataResult<PaginatedList<GetAllBlogDto>>("Blog list is empty!");
        }
    }
    }
