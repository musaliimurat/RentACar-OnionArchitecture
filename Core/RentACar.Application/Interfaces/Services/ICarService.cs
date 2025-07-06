using RentACar.Application.DTOs.Concrete.CarDto;
using RentACar.Application.Features.CQRS.Commands.CarCommands;
using RentACar.Application.Features.CQRS.Results.CarResults;
using RentACar.Application.Pagination;
using RentACar.Application.Utilities.Results.Abstract;

namespace RentACar.Application.Interfaces.Services
{
    public interface ICarService
    {
        Task<IDataResult<List<GetAllCarsDto>>> GetAllCarsAsync();
        Task<IDataResult<List<GetAllCarsWithBrandNameForAdminDto>>> GetAllCarsWithBrandsForAdminAsync();
        Task<IDataResult<PaginatedList<GetAllCarsWithBrandNameDto>>> GetAllCarsWithBrandsAsync(int page, int pageSize);
        Task<IDataResult<List<GetAllFeaturedCarsDto>>> GetAllFeaturedCarsAsync();
        Task<IDataResult<List<GetAllCarsToPriceListDto>>> GetAllCarsToPriceListsAsync();
        Task<IDataResult<GetCarByIdDto>> GetCarByIdAsync(Guid id);
        Task<IResult> CreateCarAsync(CreateCarDto createCarDto);
        Task<IResult> UpdateCarAsync(UpdateCarDto updateCarDto);
        Task<IResult> DeleteCarAsync(Guid id);
    }
}
