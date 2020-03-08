using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.IO;

namespace stock_api.Infra
{
    public class Seed
    {
        public static IDbConnection _dbConnection;

        public static void CreateDb(IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("DBInfo:ConnectionString").Value;
            var dbFilePath = configuration.GetSection("DBInfo:FilePath").Value;

           

            if (!File.Exists(dbFilePath))
            {
                _dbConnection = new SqliteConnection(connectionString);
                _dbConnection.Open();

                _dbConnection.Execute(@"
                    CREATE TABLE IF NOT EXISTS [Stock] (
                        [Id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                        [Code] NVARCHAR(6) NOT NULL,
                        [Name] NVARCHAR(100) NOT NULL
                    )
                ");

                _dbConnection.Execute(@"
                    CREATE TABLE IF NOT EXISTS [History] (
                        [Id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                        [IdStock] INTEGER NOT NULL,    
                        [Openning] DECIMAL(5,2) NOT NULL,
                        [Closing] DECIMAL(5,2) NOT NULL,
                        [Max] DECIMAL(5,2) NOT NULL,
                        [Min] DECIMAL(5,2) NOT NULL,
                        [Timestamp] NVARCHAR(10) NOT NULL,
                        FOREIGN KEY(IdStock) REFERENCES Stock(Id)
                    )
                ");

                _dbConnection.Close();
            }

        }
    }
}
