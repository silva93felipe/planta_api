using System.Data;
using Dapper;
using planta_api.Model;
using MySql.Data.MySqlClient;
using planta_api.Repositories.Interfaces;

namespace planta_api.Repositories
{
    public class PlantaRepository : IPlantaRepository
    {
        private readonly string _connectionString;
       private readonly string DATA_ATUAL_FORMATADA = new DateTime().ToString("yyyy-MM-dd hh:mm:ss");
       public PlantaRepository(IConfiguration configuration)
       {
            _connectionString = configuration.GetConnectionString("Container");
       }

        public void Add(Planta item)
        {
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                string sQuery = "INSERT INTO Planta (Nome, MinutosRegar, UrlImage)"
                                + " VALUES(@Nome, @MinutosRegar, @UrlImage)";
                dbConnection.Open();
                
                dbConnection.Execute(sQuery, item);
            }
        }
        public void Remove(int id)
        {
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                string sQuery = "UPDATE Planta SET Ativo = false, UpdateAt = @UpdateAt" 
                            + " WHERE Id = @Id";
                dbConnection.Open();

                dbConnection.Execute(sQuery, new { Id = id, UpdateAt = DATA_ATUAL_FORMATADA });
            }
        }
        public void Update(Planta item)
        {
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                item.UpdateAt = DateTime.Now;
                string sQuery = "UPDATE Planta SET Nome = @Nome,"
                            + " MinutosRegar = @MinutosRegar, " 
                            + " UltimaRegagem = @UltimaRegagem, "
                            + " UpdateAt = @UpdateAt, "
                            + " Ativo = @Ativo"
                            + " WHERE Id = @Id";
                dbConnection.Open();

                dbConnection.Query(sQuery, item);
            }
        }

        public void UpdateUltimgaRegagem(DateTime ultimaRegagem, int plantaId)
        {
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                string sQuery = "UPDATE Planta SET UltimaRegagem = @UltimaRegagem"
                            + " WHERE Id = @Id";
                dbConnection.Open();

                dbConnection.Query(sQuery, new { Id = plantaId, UltimaRegagem = ultimaRegagem});
            }
        }
        public Planta FindByID(int id)
        { 
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                string sQuery = "SELECT * FROM Planta" 
                            + " WHERE Id = @Id";

                dbConnection.Open();

                return dbConnection.Query<Planta>(sQuery, new { Id = id }).FirstOrDefault();
            }
        }
        public IEnumerable<Planta> FindAll()
        { 
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                dbConnection.Open();

                return dbConnection.Query<Planta>("SELECT * FROM Planta");
            }
        }
    }
}