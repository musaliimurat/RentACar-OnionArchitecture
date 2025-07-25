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
    public class EfLocationRepository : EfRepositoryBase<Location, RentACarContext>, ILocationRepository
    {
        public EfLocationRepository(RentACarContext context) : base(context)
        {
        }
    }
}
