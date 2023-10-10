using planta_api.Model;


namespace planta_api.Repositories.Interfaces
{
    public interface IRegagemRepository 
    {
        void Add(int plantaId, DateTime dataRegagem);
        public IEnumerable<Regagem> GetAll();

    }
}