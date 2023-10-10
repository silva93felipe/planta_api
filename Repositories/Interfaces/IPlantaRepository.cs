using planta_api.Model;

namespace planta_api.Repositories.Interfaces
{
    public interface IPlantaRepository :  IBaseRepository<Planta>
    {
        void UpdateUltimgaRegagem(DateTime ultimaRegagem, int plantaId);
    }
}