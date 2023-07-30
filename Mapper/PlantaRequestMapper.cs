using planta_api.DTO;
using PlantaApi.Model;

namespace planta_api.Mapper
{
    public class PlantaRequestMapper
    {
        public static PlantaRequest PlantaDto(PlantaModel planta){
            PlantaRequest plantaRequest = new PlantaRequest ()
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

        public static PlantaModel PlantaDto(PlantaRequest planta){
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
    }
}