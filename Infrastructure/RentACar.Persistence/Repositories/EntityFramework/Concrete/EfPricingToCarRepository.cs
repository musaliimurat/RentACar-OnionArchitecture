using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Domain.Entities.Concrete;
using RentACar.Persistence.Context;

namespace RentACar.Persistence.Repositories.EntityFramework.Concrete
{
    public class EfPricingToCarRepository (RentACarContext context) : EfRepositoryBase<PricingToCar, RentACarContext>(context), IPricingToCarRepository
    {
        public async Task<List<PricingToCar>> GetAllWithDetailsAsync()
        {
            return await context.PricingToCars
                                .Include(x => x.Car)
                                 .ThenInclude(c => c.Brand)
                                .Include(x => x.Pricing)
                                 .ToListAsync();
        }

        public async Task<PricingToCar> GetWithDetailByIdAsync(Guid id)
        {
            var data = await context.PricingToCars
                                .Include(x => x.Car)
                                 .ThenInclude(c => c.Brand)
                                .Include(x => x.Pricing)
                                 .FirstOrDefaultAsync(x => x.Id == id);

            // // If data is null, return null
            return data != null ? data : null;
        }
    }
}
