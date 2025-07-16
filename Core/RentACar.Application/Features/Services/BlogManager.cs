using AutoMapper;
using MediatR;
using RentACar.Application.DTOs.Concrete.BlogDto;
using RentACar.Application.DTOs.Concrete.BlogDTOs;
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
        private readonly IMapper _mapper;

        public BlogManager(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IResult> CreateBlogAsync(CreateBlogDto createBlogDto)
        {
            var command = _mapper.Map<CreateBlogCommand>(createBlogDto);
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

        public async Task<IDataResult<PaginatedList<GetAllBlogDto>>> GetAllBlogByCategoryAsync(Guid categoryId, int page, int pageSize)
        {
            var query = new GetAllBlogByCategoryQuery(categoryId)
            {
                Page = page,
                PageSize = pageSize
            };
            return await _mediator.Send(query);
        }

        public async Task<IDataResult<List<GetAllBlogDto>>> GetAllBlogForAdminAsync()
        {
            return await _mediator.Send(new GetAllBlogForAdminQuery());
        }

        public async Task<IDataResult<List<GetAllBlogDto>>> GetAllBlogIsNewAsync()
        {
            return await _mediator.Send(new GetAllBlogIsNewQuery());
        }

        public async Task<IDataResult<List<GetAllBlogWithCategoryNameDto>>> GetAllBlogWithCategoryNameAsync()
        {
            return await _mediator.Send(new GetAllBlogWithCategoryNameQuery());
        }

        public async Task<IDataResult<GetBlogByIdDto>> GetBlogByIdAsync(Guid id)
        {
            return await _mediator.Send(new GetBlogByIdQuery(id));
        }

        public async Task<IResult> UpdateBlogAsync(UpdateBlogDto updateBlogDto)
        {
            var command = _mapper.Map<UpdateBlogCommand>(updateBlogDto);
            return await _mediator.Send(command);
        }
    }
}
