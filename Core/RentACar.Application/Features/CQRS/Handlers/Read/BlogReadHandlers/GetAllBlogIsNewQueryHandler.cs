using MediatR;
using RentACar.Application.DTOs.Concrete.BlogDto;
using RentACar.Application.Features.CQRS.Queries.BlogQueries;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Application.Utilities.Results.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Read.BlogReadHandlers
{
    public class GetAllBlogIsNewQueryHandler : IRequestHandler<GetAllBlogIsNewQuery, IDataResult<List<GetAllBlogDto>>>
    {
        private readonly IBlogRepository _blogRepository;
        public GetAllBlogIsNewQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
        public async Task<IDataResult<List<GetAllBlogDto>>> Handle(GetAllBlogIsNewQuery request, CancellationToken cancellationToken)
        {
            var allBlogsIsNew = await _blogRepository.GetAllBlogIsNewDtosAsync();
            var allBlogs = await _blogRepository.GetAllBlogDtosAsync();
            if (allBlogsIsNew.Count > 0)
            {
                foreach (var item in allBlogsIsNew)
                {
                    item.AuthorBlogCount = allBlogs.Count(b => b.AuthorId == item.AuthorId);
                }
                return new SuccessDataResult<List<GetAllBlogDto>>(allBlogsIsNew, "Blog list is load successfull!");
            }
            else return new ErrorDataResult<List<GetAllBlogDto>>("Blog list is empty!");
        }
    }
    }
