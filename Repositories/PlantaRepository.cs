using System.Data;
using Dapper;
using PlantaApi.Model;
using MySql.Data.MySqlClient;

namespace PlantaApi.Repositories
{
    public class PlantaRepository : AbstractRepository<PlantaModel>
    {
       public PlantaRepository(IConfiguration configuration): base(configuration) { }

        public override void Add(PlantaModel item)
        {
            using (IDbConnection dbConnection = new MySqlConnection(ConnectionString))
            {
                string sQuery = "INSERT INTO Planta (Nome, MinutosParaAguar, UrlImage)"
                                + " VALUES(@Nome, @MinutosParaAguar, @UrlImage)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, item);
            }
        }
        public override void Remove(int id)
        {
            using (IDbConnection dbConnection = new MySqlConnection(ConnectionString))
            {
                string sQuery = "DELETE FROM Planta" 
                            + " WHERE Id = @Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = id });
            }
        }
        public override void Update(PlantaModel item)
        {
            using (IDbConnection dbConnection = new MySqlConnection(ConnectionString))
            {
                string sQuery = "UPDATE planta SET Nome = @Nome,"
                            + " MinutosParaAguar = @MinutosParaAguar" 
                            + " WHERE Id = @Id";
                dbConnection.Open();
                dbConnection.Query(sQuery, item);
            }
        }
        public override PlantaModel FindByID(int id)
        { 
            using (IDbConnection dbConnection = new MySqlConnection(ConnectionString))
            {
                string sQuery = "SELECT * FROM planta" 
                            + " WHERE Id = @Id";
                dbConnection.Open();
                return dbConnection.Query<PlantaModel>(sQuery, new { Id = id }).FirstOrDefault();
            }
        }
        public override IEnumerable<PlantaModel> FindAll()
        { 
            using (IDbConnection dbConnection = new MySqlConnection(ConnectionString))
            {
                dbConnection.Open();
                return dbConnection.Query<PlantaModel>("SELECT * FROM planta");
            }
        }
    }
}