using PlantaApi.Context;

namespace PlantaApi.Repositories
{
    public abstract  class AbstractRepository<T>
    {
        private string _connectionString;
        protected string ConnectionString => _connectionString;
        public AbstractRepository(IConfiguration configuration){

            //if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development"){
                //_connectionString = configuration.GetConnectionString("Dev");
            //}else if(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production"){
            //    
            _connectionString = configuration.GetConnectionString("Prod");
            //}

            Seed.CreateDb(configuration);

        }
        public abstract void Add(T item);
        public abstract void Remove(int id);
        public abstract void Update(T item);
        public abstract T FindByID(int id);
        public abstract IEnumerable<T> FindAll();
    }
}