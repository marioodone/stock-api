using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using stock_api.Domain.Entities;
using stock_api.Infra;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace History_api.Infra.Repositories
{
    public class HistoryRepository : AbstractRepository<History>
    {
        public HistoryRepository(IConfiguration configuration) : base(configuration) { }

        public override void Insert(History obj)
        {
            using (IDbConnection dbConnection = new SqliteConnection(ConnectionString))
            {
                string sQuery = "INSERT INTO History (IdHistory, Oppening, Closing, Min, Max, Timestamp) "
                              + "VALUES (@IdHistory, @Oppening, @Closing, @Min, @Max, @Timestamp)";

                dbConnection.Open();
                dbConnection.Execute(sQuery, obj);
            }
        }

        public override void Remove(int id)
        {
            using (IDbConnection dbConnection = new SqliteConnection(ConnectionString))
            {
                string sQuery = "DELETE FROM History "
                              + "WHERE Id = @Id";

                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = id });
            }
        }

        public override History Select(int id)
        {
            using (IDbConnection dbConnection = new SqliteConnection(ConnectionString))
            {
                string sQuery = "SELECT * FROM History "
                              + "WHERE Id = @Id";

                dbConnection.Open();
                return dbConnection.Query<History>(sQuery, new { Id = id }).FirstOrDefault();
            }
        }

        public override IList<History> SelectAll()
        {
            using (IDbConnection dbConnection = new SqliteConnection(ConnectionString))
            {
                string sQuery = "SELECT * FROM History";

                dbConnection.Open();
                return dbConnection.Query<History>(sQuery).ToList();
            }
        }

        public IList<History> SelectAllFromStock(int idStock)
        {
            using (IDbConnection dbConnection = new SqliteConnection(ConnectionString))
            {
                string sQuery = "SELECT * FROM History "
                               + "WHERE IdStock = @IdStock";

                dbConnection.Open();
                return dbConnection.Query<History>(sQuery, new { IdStock = idStock}).ToList();
            }
        }

        public override void Update(History obj)
        {
            using (IDbConnection dbConnection = new SqliteConnection(ConnectionString))
            {
                string sQuery = "UPDATE History "
                              + "SET IdHistory = @IdHistory, Oppening = @Oppening, Closing = @Closing, Min = @Min, Max = @Max, Timestamp = @Timestamp"
                              + "WHERE Id = @Id";

                dbConnection.Open();
                dbConnection.Execute(sQuery, obj);
            }
        }
    }
}
