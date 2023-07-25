using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
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
                    MinutosParaAguar int,
                    UrlImage varchar(255),
                    primary key (Id)
                )");

            _dbConnection.Close();
            
        }
    }
}