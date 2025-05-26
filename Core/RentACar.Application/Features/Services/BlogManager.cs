using MediatR;
using RentACar.Application.DTOs.Concrete.BlogDto;
using RentACar.Application.Features.CQRS.Commands.BlogCommands;
using RentACar.Application.Features.CQRS.Queries.BlogQueries;
using RentACar.Application.Interfaces.Services;
using RentACar.Application.Pagination;
using RentACar.Application.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Services
{
    public class BlogManager : IBlogService
    {
        private readonly IMediator _mediator;

        public BlogManager(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IResult> CreateBlogAsync(CreateBlogCommand command)
        {
           return await _mediator.Send(command);
        }

        public async Task<IResult> DeleteBlogAsync(Guid id)
        {
            return await _mediator.Send(new RemoveBlogCommand(id));
        }

        public async Task<IDataResult<PaginatedList<GetAllBlogDto>>> GetAllBlogAsync(int page, int pageSize)
        {
            var query = new GetAllBlogQuery
            {
                Page = page,
                PageSize = pageSize
            };
            return await _mediator.Send(query);
        }

        public async Task<IDataResult<List<GetAllBlogDto>>> GetAllBlogIsNewAsync()
        {
            return await _mediator.Send(new GetAllBlogIsNewQuery());
        }

        public async Task<IDataResult<GetBlogByIdDto>> GetBlogByIdAsync(Guid id)
        {
            return await _mediator.Send(new GetBlogByIdQuery(id));
        }

        public async Task<IResult> UpdateBlogAsync(UpdateBlogCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
