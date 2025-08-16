using AutoMapper;
using MediatR;
using RentACar.Application.DTOs.Concrete.CarDto;
using RentACar.Application.Features.CQRS.Commands.CarCommands;
using RentACar.Application.Features.CQRS.Queries.CarQueries;
using RentACar.Application.Features.Validators.CarDescriptionValidators;
using RentACar.Application.Features.Validators.CarValidators;
using RentACar.Application.Interfaces.Services;
using RentACar.Application.Pagination;
using RentACar.Common.Aspects.AuthAspect;
using RentACar.Common.Aspects.ValidationAspect;
using RentACar.Common.Utilities.Results.Abstract;
using RentACar.Common.Utilities.Results.Concrete;

namespace RentACar.Application.Features.Services
{
    public class CarManager : ICarService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IUploadImageService _uploadImageService;
        private readonly Microsoft.AspNetCore.Hosting.IWebHostEnvironment _env;

        public CarManager(IMediator mediator, IMapper mapper, Microsoft.AspNetCore.Hosting.IWebHostEnvironment env, IUploadImageService uploadImageService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _env = env;
            _uploadImageService = uploadImageService;
        }

        [ValidationAspect(typeof(CreateCarDtoValidator))]
        public async Task<IResult> CreateCarAsync(CreateCarDto createCarDto)
        {

            var coverImagePathList = await _uploadImageService.UploadImagesAsync(
                        new Microsoft.AspNetCore.Http.FormFileCollection { createCarDto.CoverImageUpload }, "assets/images/car", _env);
            var coverImageUrl = coverImagePathList.FirstOrDefault();
            var detailImagePathList = await _uploadImageService.UploadImagesAsync(
                                       new Microsoft.AspNetCore.Http.FormFileCollection { createCarDto.DetailImageUpload }, "assets/images/car", _env);
            var detailImageUrl = detailImagePathList.FirstOrDefault();

            createCarDto.CoverImageUrl = "/" + coverImageUrl;
            createCarDto.DetailImageUrl = "/" + detailImageUrl;
            var command = _mapper.Map<CreateCarCommand>(createCarDto);
            return await _mediator.Send(command);
        }

        public async Task<IResult> DeleteCarAsync(Guid id)
        {
            return await _mediator.Send(new RemoveCarCommand(id));
        }

        public async Task<IDataResult<List<GetAllCarsDto>>> GetAllCarsAsync()
        {
            var result = await _mediator.Send(new GetAllCarQuery());
            if (!result.Success)
                return new ErrorDataResult<List<GetAllCarsDto>>(result.Message);

            var mappedData = _mapper.Map<List<GetAllCarsDto>>(result.Data);
            return new SuccessDataResult<List<GetAllCarsDto>>(mappedData, result.Message);
        }

        public async Task<IDataResult<List<GetAllCarsToPriceListDto>>> GetAllCarsToPriceListsAsync()
        {
            var result = await _mediator.Send(new GetAllCarsToPriceListQuery());
            return result.Success
                ? new SuccessDataResult<List<GetAllCarsToPriceListDto>>(result.Data, result.Message)
                : new ErrorDataResult<List<GetAllCarsToPriceListDto>>(result.Message);
        }

        public async Task<IDataResult<PaginatedList<GetAllCarsWithBrandNameDto>>> GetAllCarsWithBrandsAsync(int page, int pageSize)
        {
            var query = new GetAllCarWithBrandNameQuery
            {
                Page = page,
                PageSize = pageSize
            };
            var result = await _mediator.Send(query);
            return result.Success
                ? new SuccessDataResult<PaginatedList<GetAllCarsWithBrandNameDto>>(result.Data, result.Message)
                : new ErrorDataResult<PaginatedList<GetAllCarsWithBrandNameDto>>(result.Message);
        }

        public async Task<IDataResult<List<GetAllCarsWithBrandNameForAdminDto>>> GetAllCarsWithBrandsForAdminAsync()
        {
            var result = await _mediator.Send(new GetAllCarWithBrandNameForAdminQuery());
            return result.Success
                ? new SuccessDataResult<List<GetAllCarsWithBrandNameForAdminDto>>(result.Data, result.Message)
                : new ErrorDataResult<List<GetAllCarsWithBrandNameForAdminDto>>(result.Message);
        }

        //[SecuredAspect(roles:"Admin", permissions:"Car.GetAllIsSlider", Priority =1)]
        public async Task<IDataResult<List<GetAllCarsSliderDto>>> GetAllIsSliderCarsAsync()
        {
            var result = await _mediator.Send(new GetAllCarIsSliderQuery());
            return result.Success
                ? new SuccessDataResult<List<GetAllCarsSliderDto>>(result.Data, result.Message)
                : new ErrorDataResult<List<GetAllCarsSliderDto>>(result.Message);
        }

        public async Task<IDataResult<GetCarByIdDto>> GetCarByIdAsync(Guid id)
        {
            var result = await _mediator.Send(new GetCarByIdQuery(id));
            if (!result.Success)
                return new ErrorDataResult<GetCarByIdDto>(result.Message);

            var mappedData = _mapper.Map<GetCarByIdDto>(result.Data);
            return new SuccessDataResult<GetCarByIdDto>(mappedData, result.Message);

        }

        public async Task<IDataResult<GetCarByIdDto>> GetCarDetailByIdAsync(Guid id)
        {
            var result = await _mediator.Send(new GetCarDetailByIdQuery(id));
            if (!result.Success)
                return new ErrorDataResult<GetCarByIdDto>(result.Message);

            var mappedData = _mapper.Map<GetCarByIdDto>(result.Data);
            return new SuccessDataResult<GetCarByIdDto>(mappedData, result.Message);
        }

        [ValidationAspect(typeof(UpdateCarDtoValidator))]
        public async Task<IResult> UpdateCarAsync(UpdateCarDto updateCarDto)
        {
            string? coverImageUrl = updateCarDto.CoverImageUrl;
            if (updateCarDto.CoverImageUpload != null)
            {
                var coverImagePathList = await _uploadImageService.UploadImagesAsync(
                    new Microsoft.AspNetCore.Http.FormFileCollection { updateCarDto.CoverImageUpload }, "assets/images/car", _env);
                coverImageUrl = "/" + coverImagePathList.FirstOrDefault();
            }

            string? detailImageUrl = updateCarDto.DetailImageUrl;
            if (updateCarDto.DetailImageUpload != null)
            {
                var detailImagePathList = await _uploadImageService.UploadImagesAsync(
                    new Microsoft.AspNetCore.Http.FormFileCollection { updateCarDto.DetailImageUpload }, "assets/images/car", _env);
                detailImageUrl = "/" + detailImagePathList.FirstOrDefault();
            }
            updateCarDto.CoverImageUrl = updateCarDto.CoverImageUpload != null ? coverImageUrl : updateCarDto.CoverImageUrl;
            updateCarDto.DetailImageUrl = updateCarDto.DetailImageUpload != null ? detailImageUrl : updateCarDto.DetailImageUrl;

            var command = _mapper.Map<UpdateCarCommand>(updateCarDto);
            return await _mediator.Send(command);
        }
    }
}
