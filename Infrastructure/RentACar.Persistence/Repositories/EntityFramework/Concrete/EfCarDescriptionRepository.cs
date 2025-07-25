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
    public class EfCarDescriptionRepository(RentACarContext context) : EfRepositoryBase<CarDescription, RentACarContext>(context), ICarDescriptionRepository
    {
        public async Task<List<CarDescription>> GetAllCarDescriptionsAsync()
        {
            var result = await context.CarDescriptions
                .Include(cd => cd.Car)
                .ThenInclude(c => c.Brand)
                .ToListAsync();

            return result;
        }

        public async Task<CarDescription> GetCarDescriptionByIdAsync(Guid id)
        {
            var result = await context.CarDescriptions
                .Include(cd => cd.Car)
                .ThenInclude(c => c.Brand)
                .FirstOrDefaultAsync(cd => cd.Id == id);
            if (result == null)
                return null;
            return result;
        }
    }
}
