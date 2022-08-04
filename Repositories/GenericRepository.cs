using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Monolithic_mvc_temp.Context;

namespace Monolithic_mvc_temp.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<T> _entity;

        public GenericRepository(ApplicationContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }

        public IEnumerable<T> AsEnumerable()
        {
            return _context.Set<T>().AsEnumerable();
        }

        public IQueryable<T> AsNoTracking()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public IQueryable<T> AsQueryable()
        {
            return _context.Set<T>().AsQueryable();
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task<List<T>> CreateAsync(List<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);;
            return entities;
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(List<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
            await Task.CompletedTask;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(List<T> entities)
        {
            _context.Set<T>().UpdateRange(entities);
            await Task.CompletedTask;
        }
    }
}