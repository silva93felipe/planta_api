using System.Data;
using Dapper;
using PlantaApi.Model;
using MySql.Data.MySqlClient;

namespace PlantaApi.Repositories
{
    public class PlantaRepository : AbstractRepository<PlantaModel>
    {
       private readonly string DATA_ATUAL_FORMATADA = new DateTime().ToString("yyyy-MM-dd hh:mm:ss");
       public PlantaRepository(IConfiguration configuration): base(configuration) { }

        public override void Add(PlantaModel item)
        {
            using (IDbConnection dbConnection = new MySqlConnection(ConnectionString))
            {
                string sQuery = "INSERT INTO Planta (Nome, MinutosRegar, UrlImage)"
                                + " VALUES(@Nome, @MinutosRegar, @UrlImage)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, item);
            }
        }
        public override void Remove(int id)
        {
            using (IDbConnection dbConnection = new MySqlConnection(ConnectionString))
            {
                string sQuery = "UPDATE Planta SET Ativo = false, UpdateAt = @UpdateAt" 
                            + " WHERE Id = @Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = id, UpdateAt = DATA_ATUAL_FORMATADA });
            }
        }
        public override void Update(PlantaModel item)
        {
            using (IDbConnection dbConnection = new MySqlConnection(ConnectionString))
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
            using (IDbConnection dbConnection = new MySqlConnection(ConnectionString))
            {
                string sQuery = "UPDATE Planta SET UltimaRegagem = @UltimaRegagem"
                            + " WHERE Id = @Id";
                dbConnection.Open();
                dbConnection.Query(sQuery, new { Id = plantaId, UltimaRegagem = ultimaRegagem});
            }
        }
        public override PlantaModel FindByID(int id)
        { 
            using (IDbConnection dbConnection = new MySqlConnection(ConnectionString))
            {
                string sQuery = "SELECT * FROM Planta" 
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
                return dbConnection.Query<PlantaModel>("SELECT * FROM Planta");
            }
        }
    }
}