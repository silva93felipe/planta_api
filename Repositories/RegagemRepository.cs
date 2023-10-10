using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;
using planta_api.Model;
using planta_api.Repositories.Interfaces;

namespace planta_api.Repositories
{
    public class RegagemRepository : IRegagemRepository
    {
        private readonly string _connectionString;
        private readonly IPlantaRepository _plantaRepository;
        public RegagemRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Container");
        }

        public void Add(int plantaId, DateTime dataRegagem)
        { 
            Regagem regar = new Regagem();
            regar.PlantaId = plantaId;
            regar.Data = dataRegagem;

            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
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
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                 dbConnection.Open();
                return dbConnection.Query<Regagem>("SELECT * FROM Regagem");
            }
        }
    }
}