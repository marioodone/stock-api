using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using History_api.Infra.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using stock_api.Domain.Entities;

namespace stock_api.Infra.Repositories
{
    public class StockReposotory : AbstractRepository<Stock>
    {
        public StockReposotory(IConfiguration configuration) : base(configuration) { }

        public override void Insert(Stock obj)
        {
            using (IDbConnection dbConnection = new SqliteConnection(ConnectionString))
            {
                string sQuery = "INSERT INTO Stock (Code, Name) "
                              + "VALUES (@Code, @Name)";

                dbConnection.Open();
                dbConnection.Execute(sQuery, obj);
            }
        }

        public override void Remove(int id)
        {
            using (IDbConnection dbConnection = new SqliteConnection(ConnectionString))
            {
                string sQuery = "DELETE FROM Stock "
                              + "WHERE Id = @Id";

                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = id });
            }
        }

        public override Stock Select(int id)
        {
            using (IDbConnection dbConnection = new SqliteConnection(ConnectionString))
            {
                string sQuery = "SELECT * FROM Stock "
                              + "WHERE Id = @Id";

                dbConnection.Open();
                return dbConnection.Query<Stock>(sQuery, new { Id = id }).FirstOrDefault();
            }
        }

        public override IList<Stock> SelectAll()
        {
            using (IDbConnection dbConnection = new SqliteConnection(ConnectionString))
            {
                string sQuery = "SELECT * FROM Stock";

                dbConnection.Open();
                return dbConnection.Query<Stock>(sQuery).ToList();
            }
        }

        public override void Update(Stock obj)
        {
            using (IDbConnection dbConnection = new SqliteConnection(ConnectionString))
            {
                string sQuery = "UPDATE Stock "
                              + "SET Code = @Code, Name = @Name "
                              + "WHERE Id = @Id";

                dbConnection.Open();
                dbConnection.Execute(sQuery, obj);
            }
        }
    }
}
