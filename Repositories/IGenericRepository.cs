using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monolithic_mvc_temp.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<T> CreateAsync(T entity);
        Task<List<T>> CreateAsync(List<T> entities);
        Task DeleteAsync(T entity);
        Task DeleteAsync(List<T> entities);
        Task UpdateAsync(T entity);
        Task UpdateAsync(List<T> entities);
        IQueryable<T> AsQueryable();
        IQueryable<T> AsNoTracking();
        IEnumerable<T> AsEnumerable();
         
    }
}