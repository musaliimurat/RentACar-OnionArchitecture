using Microsoft.EntityFrameworkCore;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Domain.Entities.Concrete;
using RentACar.Persistence.Context;

namespace RentACar.Persistence.Repositories.EntityFramework.Concrete
{
    public class EfFeatureToCarRepository(RentACarContext context) : EfRepositoryBase<FeatureToCar, RentACarContext>(context), ICarFeatureRepository
    {
        public async Task<List<FeatureToCar>> GetAllWithDetailsAsync()
        {
            return await context.FeatureToCars
                                .Include(x => x.Car)
                                 .ThenInclude(c => c.Brand)
                                .Include(x => x.Feature)
                                 .ToListAsync();
        }

        public async Task<FeatureToCar> GetWithDetailByIdAsync(Guid id)
        {
            var data = await context.FeatureToCars
                                .Include(x => x.Car)
                                 .ThenInclude(c => c.Brand)
                                .Include(x => x.Feature)
                                 .FirstOrDefaultAsync(x => x.Id == id);

            // // If data is null, return null
            return data != null ? data : null;
        }
    }
}
