using AutoMapper;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Domain.Entities.Concrete;
using RentACar.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Persistence.Repositories.EntityFramework.Concrete
{
    public class EfTestimonialRepository : EfRepositoryBase<Testimonial, RentACarContext>, ITestimonialRepository
    {
        public EfTestimonialRepository(RentACarContext context) : base(context)
        {
        }
    }
}
