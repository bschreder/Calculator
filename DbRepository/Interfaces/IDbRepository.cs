using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DbRepository.Interfaces
{
    public interface IDbRepository<T> 
    {
        Task<int> CreateAsync(T entity);

        Task<List<T>> ReadAllAsync();
        Task<T> ReadAsync(int id);
        Task<IEnumerable<T>> ReadAsync(Expression<Func<T, bool>> f);

        Task<int> UpdateAsync(T existingEntity, T newEntity);
        Task<int> UpdateAsync(T entity);

        Task<int> DeleteAsync(T entity);
        Task<int> DeleteAsync(int id);


    }
}
