using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Persistence.Repositories.EntityFramework.Concrete
{
    public class EfRepositoryBase<TEntity, TContext>(TContext context, IMapper mapper) : IRepositoryBase<TEntity> 
        where TEntity : class, IEntity, new()
        where TContext : DbContext
    {
        private readonly TContext _context = context;
        private readonly IMapper _mapper = mapper;
        public async Task CreateAsync(TEntity entity)
        {
            var entityModel = _mapper.Map<TEntity>(entity);
            await _context.Set<TEntity>().AddAsync(entityModel);
            await _context.SaveChangesAsync();
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            var query =  _context.Set<TEntity>().AsQueryable();
            if (filter != null)
            {
                query = query.Where(filter);
            }

            var entityList = await query.ToListAsync();
            return _mapper.Map<List<TEntity>>(entityList);
                 
        }

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(filter);
            if (entity == null) return null;
            return _mapper.Map<TEntity>(entity);
        }

        public async Task RemoveAsync(TEntity domain)
        {
            var entityModel = _mapper.Map<TEntity>(domain);
            var deleteEntity = _context.Entry(entityModel);
            deleteEntity.State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity domain)
        {
            var entityModel = _mapper.Map<TEntity>(domain);
            var updateEntity = _context.Entry(entityModel);
            updateEntity.State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
