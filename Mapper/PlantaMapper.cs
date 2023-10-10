using planta_api.DTO;
using planta_api.Model;

namespace planta_api.Mapper
{
    public class PlantaMapper
    {
        public static Planta Mapper(PlantaRequest planta){
            Planta plantaRequest = new Planta ()
            {
                Nome = planta.Nome,
                MinutosRegar = planta.MinutosRegar,
                UltimaRegagem = planta.UltimaRegagem,
                UrlImage = planta.UrlImage,
            };

            return plantaRequest;
        }

         public static PlantaResponse Mapper(Planta planta){
            PlantaResponse plantaRequest = new PlantaResponse ()
            {
                Id = planta.Id,
                Nome = planta.Nome,
                MinutosRegar = planta.MinutosRegar,
                UltimaRegagem = planta.UltimaRegagem,
                UrlImage = planta.UrlImage,
            };

            return plantaRequest;
        }
    }
}