using MediatR;
using RentACar.Application.DTOs.Concrete.BlogDto;
using RentACar.Application.Features.CQRS.Queries.BlogQueries;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Application.Pagination;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Application.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Handlers.Read.BlogReadHandlers
{
    public class GetAllBlogByCategoryQueryHandler : IRequestHandler<GetAllBlogByCategoryQuery, IDataResult<PaginatedList<GetAllBlogDto>>>
    {
        private readonly IBlogRepository _blogRepository;

        public GetAllBlogByCategoryQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<IDataResult<PaginatedList<GetAllBlogDto>>> Handle(GetAllBlogByCategoryQuery request, CancellationToken cancellationToken)
        {
            var allBlogsWithAuthor = await _blogRepository.GetAllBlogDtosAsync();
            var allBlogs = await _blogRepository.GetAllBlogsByCategoryAsync(request.CategoryId);
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
                foreach (var item in result.Items)
                {
                    item.AuthorBlogCount = allBlogsWithAuthor.Count(b => b.AuthorId == item.AuthorId);
                }
                return new SuccessDataResult<PaginatedList<GetAllBlogDto>>(result, "Blog list by category is loaded successfully!");
            }
            else return new ErrorDataResult<PaginatedList<GetAllBlogDto>>("No blogs found for the specified category.");
        }
    }
}
