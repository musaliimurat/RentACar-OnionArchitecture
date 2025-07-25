using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Domain.Entities.Concrete;
using RentACar.Persistence.Context;

namespace RentACar.Persistence.Repositories.EntityFramework.Concrete
{
    public class EfBrandRepository : EfRepositoryBase<Brand, RentACarContext>, IBrandRepository
    {
        public EfBrandRepository(RentACarContext context) : base(context)
        {
        }
    }
}
