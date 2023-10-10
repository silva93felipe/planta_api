
namespace planta_api.Repositories.Interfaces
{
    public interface IBaseRepository<T>
    {
        public void Add(T item);
        public void Remove(int id);
        public void Update(T item);
        public T FindByID(int id);
        public IEnumerable<T> FindAll();
    }
}