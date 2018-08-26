using DbRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DbRepository.Business
{
    //   NOTE:   This class is a place holder for the low level db repository
    public class DbRepository<T> : IDbRepository<T> where T: class, new()
    {
        public async Task<int> CreateAsync(T entity)
        {
            return await Task.FromResult(default(int));
        }

        public async Task<List<T>> ReadAllAsync()
        {
            return await Task.FromResult(new List<T>());
        }

        public async Task<T> ReadAsync(int id)
        {
            return await Task.FromResult(new T());
        }

        public async Task<IEnumerable<T>> ReadAsync(Expression<Func<T, bool>> f)
        {
            return await Task.FromResult(new List<T>().AsEnumerable());
        }

        public async Task<int> UpdateAsync(T existingEntity, T newEntity)
        {
            return await Task.FromResult(default(int));
        }

        public async Task<int> UpdateAsync(T entity)
        {
            return await Task.FromResult(default(int));
        }

        public async Task<int> DeleteAsync(T entity)
        {
            return await Task.FromResult(default(int));
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await Task.FromResult(default(int));
        }

    }
}
