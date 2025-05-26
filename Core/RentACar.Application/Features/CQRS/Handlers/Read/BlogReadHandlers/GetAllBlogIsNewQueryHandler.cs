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
            var allBlogs = await _blogRepository.GetAllBlogIsNewDtosAsync();
            if (allBlogs.Count > 0)
            {
                return new SuccessDataResult<List<GetAllBlogDto>>(allBlogs, "Blog list is load successfull!");
            }
            else return new ErrorDataResult<List<GetAllBlogDto>>("Blog list is empty!");
        }
    }
    }
