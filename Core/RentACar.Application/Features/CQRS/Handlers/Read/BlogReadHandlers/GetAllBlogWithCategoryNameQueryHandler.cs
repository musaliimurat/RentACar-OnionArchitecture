using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.DTOs.Concrete.BlogDto;
using RentACar.Application.Features.CQRS.Queries.BlogQueries;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Common.Utilities.Results.Abstract;
using RentACar.Common.Utilities.Results.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Read.BlogReadHandlers
{
    public class GetAllBlogWithCategoryNameQueryHandler : IRequestHandler<GetAllBlogWithCategoryNameQuery, IDataResult<List<GetAllBlogWithCategoryNameDto>>>
    {
        private readonly IBlogRepository _blogRepository;

        public GetAllBlogWithCategoryNameQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<IDataResult<List<GetAllBlogWithCategoryNameDto>>> Handle(GetAllBlogWithCategoryNameQuery request, CancellationToken cancellationToken)
        {
            var categoryBlogs = await _blogRepository.GetAllBlogWithCategoryNameDtosAsync();
            if (categoryBlogs.Count > 0)
            {
                foreach (var item in categoryBlogs)
                {
                    item.BlogWithCatgoryCount = categoryBlogs.Count(b => b.CategoryId == item.CategoryId);
                }
                return new SuccessDataResult<List<GetAllBlogWithCategoryNameDto>>(categoryBlogs, "Blog list with category names loaded successfully!");
            }
            else
            {
                return new ErrorDataResult<List<GetAllBlogWithCategoryNameDto>>("CategoryName list is empty!");
            }
        }
    }
}
