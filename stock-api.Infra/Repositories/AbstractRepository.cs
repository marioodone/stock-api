
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using stock_api.Domain.Entities;
using stock_api.Domain.Interfaces;
using stock_api.Infra;

namespace History_api.Infra.Repositories
{
    public abstract class AbstractRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly string _connectionString;
        protected string ConnectionString => _connectionString;
        

        public AbstractRepository(IConfiguration configuration)
        {
            this._connectionString = configuration.GetSection("DBInfo:ConnectionString").Value;
            Seed.CreateDb(configuration);            
        }

        public abstract void Insert(T obj);
        public abstract void Update(T obj);
        public abstract void Remove(int id);
        public abstract T Select(int id);
        public abstract IList<T> SelectAll();
    }
}
