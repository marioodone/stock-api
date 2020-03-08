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
                string sQuery = "INSERT INTO History (IdStock, Opening, Closing, Min, Max, Timestamp) "
                              + "VALUES (@IdStock, @Opening, @Closing, @Min, @Max, @Timestamp)";

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
                string sQuery = "SELECT IdStock, cast(Opening as REAL) as Opening, cast(Closing as REAL) as Closing, cast(Min as REAL) as Min, cast(Max as REAL) as Max, Timestamp "
                              + "FROM History "
                              + "WHERE Id = @Id";

                dbConnection.Open();
                return dbConnection.Query<History>(sQuery, new { Id = id }).FirstOrDefault();
            }
        }

        public override IList<History> SelectAll()
        {
            using (IDbConnection dbConnection = new SqliteConnection(ConnectionString))
            {
                string sQuery = "SELECT IdStock, cast(Opening as REAL) as Opening, cast(Closing as REAL) as Closing, cast(Min as REAL) as Min, cast(Max as REAL) as Max, Timestamp "
                              + "FROM History ";

                dbConnection.Open();
                return dbConnection.Query<History>(sQuery).ToList();
            }
        }

        public IList<History> SelectAllFromStock(int idStock)
        {
            using (IDbConnection dbConnection = new SqliteConnection(ConnectionString))
            {
                string sQuery = "SELECT IdStock, cast(Opening as REAL) as Opening, cast(Closing as REAL) as Closing, cast(Min as REAL) as Min, cast(Max as REAL) as Max, Timestamp "
                              + "FROM History "
                              + "WHERE IdStock = @IdStock";

                dbConnection.Open();
                return dbConnection.Query<History>(sQuery, new { IdStock = idStock}).ToList();
            }
        }

        public IList<History> SelectAllFromStock(string code)
        {
            using (IDbConnection dbConnection = new SqliteConnection(ConnectionString))
            {
                string sQuery = "SELECT H.IdStock, cast(Opening as REAL) as Opening, cast(Closing as REAL) as Closing, cast(Min as REAL) as Min, cast(Max as REAL) as Max, Timestamp FROM History AS H "
                               + "JOIN Stock AS S   ON H.IdStock = S.Id "
                               + "WHERE S.Code = @Code";

                dbConnection.Open();
                return dbConnection.Query<History>(sQuery, new { Code = code }).ToList();
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
