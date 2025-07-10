using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RentACar.Application.DTOs.Concrete.CarDto;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Domain.Entities.Concrete;
using RentACar.Persistence.Context;

namespace RentACar.Persistence.Repositories.EntityFramework.Concrete
{
    public class EfCarRepository(RentACarContext context, IMapper mapper) : EfRepositoryBase<Car, RentACarContext>(context), ICarRepository
    {
        private readonly IMapper _mapper = mapper;
        public async Task<List<GetAllCarsWithBrandNameDto>> GetAllCarsReadAsync()
        {
            var result = await context.Cars
                .Include(c => c.Brand)
                .Include(c => c.PricingToCars)
                .ThenInclude(ptc => ptc.Pricing)
                .Include(c => c.FeatureToCars)
                .ThenInclude(ftc => ftc.Feature)
                .ToListAsync();
            return _mapper.Map<List<GetAllCarsWithBrandNameDto>>(result);
        }

        public async Task<List<GetAllCarsWithBrandNameForAdminDto>> GetAllCarsReadForAdminAsync()
        {
            var result = await context.Cars
                .Include(c => c.Brand)
                .Include(c => c.PricingToCars)
                .ThenInclude(ptc => ptc.Pricing)
                .ToListAsync();
            return _mapper.Map<List<GetAllCarsWithBrandNameForAdminDto>>(result);
        }

        public async Task<List<GetAllCarsToPriceListDto>> GetAllCarsToPriceListsReadAsync()
        {
            var result = await context.Cars
                .Include(c => c.Brand)
                .Include(c => c.PricingToCars)
                .ThenInclude(ptc => ptc.Pricing)
                .ToListAsync();
            return _mapper.Map<List<GetAllCarsToPriceListDto>>(result);
        }

        public async Task<List<GetAllCarsSliderDto>> GetAllFeaturedCarsReadAsync()
        {
            var result = await context.Cars
                .Include(c => c.Brand)
                .Include(c => c.PricingToCars)
                .ThenInclude(ptc => ptc.Pricing)
                .OrderByDescending(c => c.CreatedDate)
                .Take(6)
                .ToListAsync();
            return _mapper.Map<List<GetAllCarsSliderDto>>(result);

        }
    }
}
