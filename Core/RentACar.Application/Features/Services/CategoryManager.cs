using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using RentACar.Application.DTOs.Concrete.CaregoryDTOs;
using RentACar.Application.Features.CQRS.Commands.CategoryCommands;
using RentACar.Application.Features.CQRS.Queries.CategoryQueries;
using RentACar.Application.Features.Validators.CarDescriptionValidators;
using RentACar.Application.Features.Validators.CategoryValidators;
using RentACar.Application.Interfaces.Services;
using RentACar.Common.Aspects.ValidationAspect;
using RentACar.Common.Utilities.Results.Abstract;
using RentACar.Common.Utilities.Results.Concrete;

namespace RentACar.Application.Features.Services
{
    public class CategoryManager : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CategoryManager(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [ValidationAspect(typeof(CreateCategoryDtoValidator))]
        public async Task<IResult> CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var command = _mapper.Map<CreateCategoryCommand>(createCategoryDto);
            return await _mediator.Send(command);
        }

        public async Task<IResult> DeleteCategoryAsync(Guid id)
        {
            var command = new RemoveCategoryCommand(id);
            return await _mediator.Send(command);
        }

        public async Task<IDataResult<List<GetAllCategoryDto>>> GetAllCategoryAsync()
        {
           var result = await _mediator.Send(new GetAllCategoryQuery());
            if (!result.Success)
                return new ErrorDataResult<List<GetAllCategoryDto>>(result.Message);

            var mappedData = _mapper.Map<List<GetAllCategoryDto>>(result.Data);
            return new SuccessDataResult<List<GetAllCategoryDto>>(mappedData, result.Message);
        }

        public async Task<IDataResult<GetCategoryByIdDto>> GetCategoryByIdAsync(Guid id)
        {
            var result = await _mediator.Send(new GetCategoryByIdQuery(id));
            if (!result.Success)
                return new ErrorDataResult<GetCategoryByIdDto>(result.Message);

            var mappedData = _mapper.Map<GetCategoryByIdDto>(result.Data);
            return new SuccessDataResult<GetCategoryByIdDto>(mappedData, result.Message);
        }

        [ValidationAspect(typeof(UpdateCategoryDtoValidator))]
        public async Task<IResult> UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var command = _mapper.Map<UpdateCategoryCommand>(updateCategoryDto);
            return await _mediator.Send(command);
        }
    }
}
