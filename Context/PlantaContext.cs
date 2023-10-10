
namespace planta_api.Context
{
    public class PlantaContext
    {
        private string _connectionString;
        protected string ConnectionString => _connectionString;
        public PlantaContext(IConfiguration configuration){
            _connectionString = configuration.GetConnectionString("Container");
            
            Seed.CreateDb(configuration);
        }
    }
}