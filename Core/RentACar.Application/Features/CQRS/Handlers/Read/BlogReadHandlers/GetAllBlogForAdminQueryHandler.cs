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
    public class GetAllBlogForAdminQueryHandler : IRequestHandler<GetAllBlogForAdminQuery, IDataResult<List<GetAllBlogDto>>>
    {
        private readonly IBlogRepository _blogRepository;

        public GetAllBlogForAdminQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<IDataResult<List<GetAllBlogDto>>> Handle(GetAllBlogForAdminQuery request, CancellationToken cancellationToken)
        {
            var result = await _blogRepository.GetAllBlogDtosAsync();
            if (result.Count >0)
            {
                foreach (var item in result)
                {
                    item.AuthorBlogCount = result.Count(b => b.AuthorId == item.AuthorId);
                }
                return new SuccessDataResult<List<GetAllBlogDto>>(result, "Blogs retrieved successfully.");
            }
            return new ErrorDataResult<List<GetAllBlogDto>>("No blogs found.");
        }
    }
}
