using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RentACar.Application.DTOs.Concrete.BlogDto;
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
    public class EfBlogRepository(RentACarContext context, IMapper mapper) : EfRepositoryBase<Blog, RentACarContext>(context, mapper), IBlogRepository
    {

        public async Task<List<GetAllBlogDto>> GetAllBlogDtosAsync()
        {
            var result = await context.Blogs.Include(b => b.Category).Include(b => b.Author).ToListAsync();
            return mapper.Map<List<GetAllBlogDto>>(result);
        }

        public async Task<List<GetAllBlogDto>> GetAllBlogIsNewDtosAsync()
        {
            var result = await context.Blogs.Include(b => b.Category).Include(b => b.Author).OrderByDescending(b=>b.IsNew).Take(3).ToListAsync();
            return mapper.Map<List<GetAllBlogDto>>(result);
        }

        public async Task<GetBlogByIdDto> GetBlogByIdDtoAsync(Guid id)
        {
            var result = await context.Blogs.Include(b => b.Category).Include(b => b.Author).Where(b => b.Id == id).SingleOrDefaultAsync();
            return mapper.Map<GetBlogByIdDto>(result);
        }
    }
}
