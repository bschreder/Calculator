using DbRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DbRepository.Business
{
    public class DataRepository<T> where T : class, IEntity
    {
        private IDbRepository<T> _dbRepository = default(IDbRepository<T>);
        public DataRepository(IDbRepository<T> dbRepository)
        {
            _dbRepository = dbRepository;
        }

        /// <summary>
        /// Add or Update entity to database <typeparamref name="T"/>
        /// </summary>
        /// <param name="entity">Entity to add or update</param>
        /// <returns>Number of records added or updated</returns>
        public async Task<int> AddOrUpdateAsync(T entity)
        {
            int numEntityChanged = 0;

            T entityResult = await _dbRepository.ReadAsync(entity.ID);
            if (entityResult == null)
                numEntityChanged = await _dbRepository.CreateAsync(entity);
            else
                numEntityChanged = await _dbRepository.UpdateAsync(entityResult, entity);

            return numEntityChanged;
        }



        /// <summary>
        /// Add or Update entity to database <typeparamref name="T"/> with match found by lambda expression
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="f">lambda expression used to determine if record already exists (update) or is new (add)</param>
        /// <returns>Number of records added or updated</returns>
        public async Task<int> AddOrUpdateAsync(T entity, Expression<Func<T, bool>> f)
        {
            int numEntityChanged = 0;

            IEnumerable<T> entitiesResult = await _dbRepository.ReadAsync(f);
            if (entitiesResult.Count() == 0)
                numEntityChanged = await _dbRepository.CreateAsync(entity);
            else
            {
                T existingEntity = entitiesResult.FirstOrDefault(e => e.ID == entity.ID);
                numEntityChanged = await _dbRepository.UpdateAsync(existingEntity, entity);
            }

            return numEntityChanged;
        }


        /// <summary>
        /// Get a list of all database <typeparamref name="T"/> records
        /// </summary>
        /// <returns>List of records</returns>
        public async Task<List<T>> GetAllAsync()
        {
            return await _dbRepository.ReadAllAsync();
        }

        /// <summary>
        /// Get a database <typeparamref name="T"/> record based on primary key
        /// </summary>
        /// <param name="id">Primary Key</param>
        /// <returns>Record that matches the primary key</returns>
        public async Task<T> GetAsync(int id)
        {
            return await _dbRepository.ReadAsync(id);
        }

        /// <summary>
        /// Get a database <typeparamref name="T"/> record based on lambda expression
        /// </summary>
        /// <param name="f">Lambda expression used to determine match</param>
        /// <returns>Records that matches lambda expression</returns>
        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> f)
        {
            return await _dbRepository.ReadAsync(f);
        }
    }
}
