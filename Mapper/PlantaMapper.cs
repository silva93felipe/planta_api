using planta_api.DTO;
using PlantaApi.Model;

namespace planta_api.Mapper
{
    public class PlantaMapper
    {
        public static PlantaModel Mapper(PlantaRequest planta){
            PlantaModel plantaRequest = new PlantaModel ()
            {
                Nome = planta.Nome,
                MinutosRegar = planta.MinutosRegar,
                UltimaRegagem = planta.UltimaRegagem,
                UrlImage = planta.UrlImage,
            };

            return plantaRequest;
        }

         public static PlantaResponse Mapper(PlantaModel planta){
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