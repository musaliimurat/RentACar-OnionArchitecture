using RentACar.Application.DTOs.Concrete.CarDto;
using RentACar.Application.Features.CQRS.Commands.CarCommands;
using RentACar.Application.Features.CQRS.Results.CarResults;
using RentACar.Application.Pagination;
using RentACar.Application.Utilities.Results.Abstract;

namespace RentACar.Application.Interfaces.Services
{
    public interface ICarService
    {
        Task<IDataResult<List<GetAllCarQueryResult>>> GetAllCarsAsync();
        Task<IDataResult<PaginatedList<GetAllCarsDto>>> GetAllCarsWithBrandsAsync(int page, int pageSize);
        Task<IDataResult<List<GetAllFeaturedCarsDto>>> GetAllFeaturedCarsAsync();
        Task<IDataResult<List<GetAllCarsToPriceListDto>>> GetAllCarsToPriceListsAsync();
        Task<IDataResult<GetCarByIdQueryResult>> GetCarByIdAsync(Guid id);
        Task<IResult> CreateCarAsync(CreateCarCommand command);
        Task<IResult> UpdateCarAsync(UpdateCarCommand command);
        Task<IResult> DeleteCarAsync(Guid id);
    }
}
