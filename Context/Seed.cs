using System.Data;
using Dapper;
using MySql.Data.MySqlClient;

namespace PlantaApi.Context
{
    public class Seed
    {
        private static IDbConnection _dbConnection;

        public static void CreateDb(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Dev");
            _dbConnection = new MySqlConnection(connectionString);
            _dbConnection.Open();

            _dbConnection.Execute(@"
                CREATE TABLE IF NOT EXISTS Planta (
                    Id int  NOT NULL AUTO_INCREMENT,
                    Nome varchar(50) not null,
                    StatusPlanta int,
                    MinutosRegar int,
                    UrlImage varchar(255),
                    DataUltimaRegagem datetime,
                    primary key (Id)
                )");

                 /*  CREATE TABLE IF NOT EXISTS Planta (
                    id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                    nome varchar(50) not null,
                    statusPlanta INTEGER ,
                    minutosRegar INTEGER ,
                    urlImage varchar(255),
                    dataUltimaRegagem datetime
                )"); */

            _dbConnection.Close();
            
        }
    }
}