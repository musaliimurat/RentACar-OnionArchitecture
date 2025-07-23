using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using RentACar.Application.DTOs.Concrete.BlogDto;
using RentACar.Application.DTOs.Concrete.BlogDTOs;
using RentACar.Application.Features.CQRS.Commands.BlogCommands;
using RentACar.Application.Features.CQRS.Queries.BlogQueries;
using RentACar.Application.Interfaces.Services;
using RentACar.Application.Pagination;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Domain.Entities.Concrete;
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
        private readonly IUploadImageService _uploadImageService;
        private readonly IWebHostEnvironment _env;

        public BlogManager(IMediator mediator, IMapper mapper, IWebHostEnvironment env, IUploadImageService uploadImageService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _env = env;
            _uploadImageService = uploadImageService;
        }

        public async Task<IResult> CreateBlogAsync(CreateBlogDto createBlogDto)
        {
            var blogImagePathList = await _uploadImageService.UploadImagesAsync(
               new Microsoft.AspNetCore.Http.FormFileCollection { createBlogDto.ImageFile }, "assets/images/blog", _env);
            var blogImageUrl = blogImagePathList.FirstOrDefault();
            createBlogDto.ImageUrl = "/" + blogImageUrl;
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
            string? blogImageUrl = updateBlogDto.ImageUrl;

            if (updateBlogDto.ImageFile != null)
            {
                var blogImagePathList = await _uploadImageService.UploadImagesAsync(
                new Microsoft.AspNetCore.Http.FormFileCollection { updateBlogDto.ImageFile }, "assets/images/blog", _env);
                blogImageUrl = "/" + blogImagePathList.FirstOrDefault();
            }

            updateBlogDto.ImageUrl = updateBlogDto.ImageFile != null ? blogImageUrl : updateBlogDto.ImageUrl;
            var command = _mapper.Map<UpdateBlogCommand>(updateBlogDto);
            return await _mediator.Send(command);
        }
    }
}
