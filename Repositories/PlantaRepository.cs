using System.Data;
using Dapper;
using PlantaApi.Model;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using Microsoft.Data.Sqlite;

namespace PlantaApi.Repositories
{
    public class PlantaRepository : AbstractRepository<PlantaModel>
    {
       public PlantaRepository(IConfiguration configuration): base(configuration) { }

        public override void Add(PlantaModel item)
        {
            using (IDbConnection dbConnection = new SqliteConnection(ConnectionString))
            {
                string sQuery = "INSERT INTO Planta (Nome, StatusPlanta, MinutosRegar, UrlImage)"
                                + " VALUES(@Nome, @StatusPlanta, @MinutosRegar, @UrlImage)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, item);
            }
        }
        public override void Remove(int id)
        {
            using (IDbConnection dbConnection = new SqliteConnection(ConnectionString))
            {
                string sQuery = "DELETE FROM Planta" 
                            + " WHERE Id = @Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = id });
            }
        }
        public override void Update(PlantaModel item)
        {
            using (IDbConnection dbConnection = new SqliteConnection(ConnectionString))
            {
                string sQuery = "UPDATE Planta SET Nome = @Nome,"
                            + " MinutosRegar = @MinutosRegar, " 
                            + " StatusPlanta = @StatusPlanta, "
                            + " DataUltimaRegagem = @DataUltimaRegagem"
                            + " WHERE Id = @Id";
                dbConnection.Open();
                dbConnection.Query(sQuery, item);
            }
        }
        public override PlantaModel FindByID(int id)
        { 
            using (IDbConnection dbConnection = new SqliteConnection(ConnectionString))
            {
                string sQuery = "SELECT * FROM Planta" 
                            + " WHERE Id = @Id";
                dbConnection.Open();
                return dbConnection.Query<PlantaModel>(sQuery, new { Id = id }).FirstOrDefault();
            }
        }

        public void Regar(int id, DateTime dataRegagem)
        { 
            var plantaDb = FindByID(id);

            if (plantaDb != null) {
                using (IDbConnection dbConnection = new SqliteConnection(ConnectionString))
                {
                    string sQuery = "UPDATE Planta SET StatusPlanta = @StatusPlanta, "
                                + " DataUltimaRegagem = @DataUltimaRegagem"
                                + " WHERE Id = @Id";
                    dbConnection.Open();
                    dbConnection.Query(sQuery, new { StatusPlanta = 1, DataUltimaRegagem = dataRegagem, Id = id});
                }
            }
        }
        public override IEnumerable<PlantaModel> FindAll()
        { 
            using (IDbConnection dbConnection = new SqliteConnection(ConnectionString))
            {
                dbConnection.Open();
                return dbConnection.Query<PlantaModel>("SELECT * FROM Planta");
            }
        }
    }
}