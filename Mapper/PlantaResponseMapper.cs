using planta_api.DTO;
using PlantaApi.Model;

namespace planta_api.Mapper
{
    public class PlantaResponseMapper
    {
         public static PlantaModel PlantaDto(PlantaResponse planta){
            PlantaModel plantaRequest = new PlantaModel ()
            {
                Id = planta.Id,
                Nome = planta.Nome,
                MinutosRegar = planta.MinutosRegar,
                StatusPlanta = planta.StatusPlanta,
                DataUltimaRegagem = planta.DataUltimaRegagem,
                UrlImage = planta.UrlImage,
            };

            return plantaRequest;
        }

         public static PlantaResponse PlantaDto(PlantaModel planta){
            PlantaResponse plantaRequest = new PlantaResponse ()
            {
                Id = planta.Id,
                Nome = planta.Nome,
                MinutosRegar = planta.MinutosRegar,
                StatusPlanta = planta.StatusPlanta,
                DataUltimaRegagem = planta.DataUltimaRegagem,
                UrlImage = planta.UrlImage,
            };

            return plantaRequest;
        }
    }
}