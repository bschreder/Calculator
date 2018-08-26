using DbRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DbRepository.Business
{
    public class DbFactory<T> where T: class, IEntity, new()
    {
        public DataRepository<T> CreateDbFactory()
        {
            IDbRepository<T> dbRepository = new DbRepository<T>();
            return new DataRepository<T>(dbRepository);
        }
    }
}
