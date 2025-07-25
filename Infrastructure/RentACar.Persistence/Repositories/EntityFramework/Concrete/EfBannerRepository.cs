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
    public class EfBannerRepository : EfRepositoryBase<Banner, RentACarContext>, IBannerRepository
    {
        public EfBannerRepository(RentACarContext context) : base(context)
        {
        }
    }
}
