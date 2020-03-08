
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using stock_api.Infra;

namespace History_api.Infra.Repositories
{
    public abstract class AbstractRepository<T>
    {
        private string _connectionString;
        protected string ConnectionString => _connectionString;

        public AbstractRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DBInfo:ConnectionString");
            Seed.CreateDb(configuration);
        }

        public abstract void Insert(T obj);
        public abstract void Update(T obj);
        public abstract void Remove(int id);
        public abstract T Select(int id);
        public abstract IList<T> SelectAll();
    }
}
