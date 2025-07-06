using RentACar.Application.DTOs.Concrete.CarDto;
using RentACar.Domain.Entities.Concrete;

namespace RentACar.Application.Interfaces.Repository.Abstract
{
    public interface ICarRepository : IRepositoryBase<Car>
    {
        Task<List<GetAllCarsWithBrandNameDto>> GetAllCarsReadAsync();
        Task<List<GetAllCarsWithBrandNameForAdminDto>> GetAllCarsReadForAdminAsync();

        Task<List<GetAllFeaturedCarsDto>> GetAllFeaturedCarsReadAsync();
        Task<List<GetAllCarsToPriceListDto>> GetAllCarsToPriceListsReadAsync();
    }
}
