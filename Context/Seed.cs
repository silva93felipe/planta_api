using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;
using Microsoft.Data.Sqlite;

namespace PlantaApi.Context
{
    public class Seed
    {
        private static IDbConnection _dbConnection;

        public static void CreateDb(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Prod");
            _dbConnection = new SqliteConnection(connectionString);
            _dbConnection.Open();

            _dbConnection.Execute(@"
                CREATE TABLE IF NOT EXISTS Planta (
                    id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                    nome varchar(50) not null,
                    statusPlanta INTEGER ,
                    minutosRegar INTEGER ,
                    urlImage varchar(255),
                    dataUltimaRegagem datetime
                )");

                // CREATE TABLE IF NOT EXISTS Planta (
                //     Id int  NOT NULL AUTO_INCREMENT,
                //     Nome varchar(50) not null,
                //     StatusPlanta int,
                //     MinutosRegar int,
                //     UrlImage varchar(255),
                //     DataUltimaRegagem datetime,
                //     primary key (Id)
                // )");

            _dbConnection.Close();
            
        }
    }
}