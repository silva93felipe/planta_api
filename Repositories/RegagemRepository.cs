using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;
using planta_api.Model;
using PlantaApi.Repositories;

namespace planta_api.Repositories
{
    public class RegagemRepository 
    {
        private string _connectionString;
        protected string ConnectionString => _connectionString;
        private readonly PlantaRepository _plantaRepository;
        public RegagemRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Prod");
            _plantaRepository = new PlantaRepository(configuration);
        }

        public void Regar(int plantaId, DateTime dataRegagem)
        { 
            Regagem regar = new Regagem();
            regar.PlantaId = plantaId;
            regar.Data = dataRegagem;

            using (IDbConnection dbConnection = new MySqlConnection(ConnectionString))
            {
                string sQuery = "INSERT INTO Regagem (Data, PlantaId, Observacao)"
                            + " VALUES(@Data, @PlantaId, @Observacao)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, regar);
            }

            _plantaRepository.UpdateUltimgaRegagem(dataRegagem, plantaId);
        }

         public IEnumerable<Regagem> GetAll()
        { 
            using (IDbConnection dbConnection = new MySqlConnection(ConnectionString))
            {
                 dbConnection.Open();
                return dbConnection.Query<Regagem>("SELECT * FROM Regagem");
            }
        }
    }
}