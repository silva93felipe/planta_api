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
            var connectionString = String.Empty;
            //if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development"){
            connectionString = configuration.GetConnectionString("Prod");
           /*  }else if(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production"){
                connectionString = configuration.GetConnectionString("Prod");
            } */

            _dbConnection = new MySqlConnection(connectionString);
            _dbConnection.Open();

            _dbConnection.Execute(@"
                CREATE TABLE IF NOT EXISTS Planta (
                    Id INT  NOT NULL AUTO_INCREMENT,
                    Ativo BOOLEAN,
                    CreateAt DATETIME,
                    UpdateAt DATETIME,
                    Nome VARCHAR(50) NOT NULL,
                    MinutosRegar INT,
                    UrlImage VARCHAR(255),
                    UltimaRegagem DATETIME,
                    PRIMARY KEY (Id)
                );
                
                CREATE TABLE IF NOT EXISTS Regagem (
                    Id INT  NOT NULL AUTO_INCREMENT,
                    Ativo BOOLEAN,
                    CreateAt DATETIME,
                    UpdateAt DATETIME,
                    PlantaId INT NOT NULL,
                    Data DATETIME,
                    Observacao VARCHAR(50),
                    PRIMARY KEY (Id),
                    FOREIGN KEY (PlantaId) REFERENCES Planta(Id)
                );
                
                ");

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