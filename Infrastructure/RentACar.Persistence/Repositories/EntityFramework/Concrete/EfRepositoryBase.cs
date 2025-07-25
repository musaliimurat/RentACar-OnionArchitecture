using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Domain.Common;

namespace RentACar.Persistence.Repositories.EntityFramework.Concrete
{
    public class EfRepositoryBase<TEntity, TContext>(TContext context) : IRepositoryBase<TEntity> 
        where TEntity : class, IEntity, new()
        where TContext : DbContext
    {
        private readonly TContext _context = context;
        public async Task CreateAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
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
            return entityList;
                 
        }

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(filter);
            if (entity == null) return null;
            return entity;
        }

        public async Task RemoveAsync(TEntity entity)
        {
            var deleteEntity = _context.Entry(entity);
            deleteEntity.State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            var updateEntity = _context.Entry(entity);
            updateEntity.State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
