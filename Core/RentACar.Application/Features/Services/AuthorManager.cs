using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using RentACar.Application.DTOs.Concrete.AuthorDTOs;
using RentACar.Application.Features.CQRS.Commands.AuthorCommands;
using RentACar.Application.Features.CQRS.Queries.AuthorQueries;
using RentACar.Application.Features.Validators.AuthorValidators;
using RentACar.Application.Features.Validators.BrandValidators;
using RentACar.Application.Interfaces.Services;
using RentACar.Common.Aspects.ValidationAspect;
using RentACar.Common.Utilities.Results.Abstract;
using RentACar.Common.Utilities.Results.Concrete;



namespace RentACar.Application.Features.Services
{
    public class AuthorManager : IAuthorService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IUploadImageService _uploadImageService;
        private readonly Microsoft.AspNetCore.Hosting.IWebHostEnvironment _env;

        public AuthorManager(IMediator mediator, IMapper mapper, IUploadImageService uploadImageService, Microsoft.AspNetCore.Hosting.IWebHostEnvironment env)
        {
            _mediator = mediator;
            _mapper = mapper;
            _uploadImageService = uploadImageService;
            _env = env;
        }

        [ValidationAspect(typeof(CreateAuthorDtoValidator))]
        public async Task<IResult> CreateAuthorAsync(CreateAuthorDto createAuthorDto)
        {
            var imagePathList = await _uploadImageService.UploadImagesAsync(
             new Microsoft.AspNetCore.Http.FormFileCollection { createAuthorDto.ImageFile }, "assets/images/author", _env);
            var imageUrl = imagePathList.FirstOrDefault();
            createAuthorDto.ImageUrl = "/" + imageUrl;
            var request = _mapper.Map<CreateAuthorCommand>(createAuthorDto);
            return await _mediator.Send(request);
        }

        public async Task<IResult> DeleteAuthorAsync(Guid id)
        {
            return await _mediator.Send(new RemoveAuthorCommand(id));
        }

        public async Task<IDataResult<List<GetAllAuthorDto>>> GetAllAuthorsAsync()
        {
            var result = await _mediator.Send(new GetAllAuthorQuery());
            if (result.Success)
            {
                var authors = _mapper.Map<List<GetAllAuthorDto>>(result.Data);
                return new SuccessDataResult<List<GetAllAuthorDto>>(authors, result.Message);
            }
            else return new ErrorDataResult<List<GetAllAuthorDto>>(result.Message);
        }

        public async Task<IDataResult<GetAuthorByIdDto>> GetAuthorByIdAsync(Guid id)
        {
            var result = await _mediator.Send(new GetAuthorByIdQuery(id));
            if (result.Success)
            {
                var author = _mapper.Map<GetAuthorByIdDto>(result.Data);
                return new SuccessDataResult<GetAuthorByIdDto>(author, result.Message);
            }
            else return new ErrorDataResult<GetAuthorByIdDto>(result.Message);
        }

        [ValidationAspect(typeof(UpdateAuthorDtoValidator))]
        public async Task<IResult> UpdateAuthorAsync(UpdateAuthorDto updateAuthorDto)
        {
            string? imageUrl = updateAuthorDto.ImageUrl;
            if (updateAuthorDto.ImageFile != null)
            {
                var imagePathList = await _uploadImageService.UploadImagesAsync(
                    new Microsoft.AspNetCore.Http.FormFileCollection { updateAuthorDto.ImageFile }, "assets/images/author", _env);
                imageUrl = "/" + imagePathList.FirstOrDefault();
            }
            updateAuthorDto.ImageUrl = updateAuthorDto.ImageFile != null ? imageUrl : updateAuthorDto.ImageUrl;
            var request = _mapper.Map<UpdateAuthorCommand>(updateAuthorDto);
            return await _mediator.Send(request);
        }
    }
}
