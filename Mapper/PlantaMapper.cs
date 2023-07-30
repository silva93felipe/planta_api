using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using planta_api.DTO;
using PlantaApi.Model;

namespace planta_api.Mapper
{
    public class PlantaMapper
    {
        public static PlantaRequest PlantaDto(PlantaModel plantaModel){
            PlantaRequest plantaRequest = new PlantaRequest ()
            {
                Id = plantaModel.Id,
                Nome = plantaModel.Nome,
                MinutosRegar = plantaModel.MinutosRegar,
                StatusPlanta = plantaModel.StatusPlanta,
                DataUltimaRegagem = plantaModel.DataUltimaRegagem,
                UrlImage = plantaModel.UrlImage,
            };

            return plantaRequest;
        }

        public static PlantaModel PlantaDto(PlantaRequest plantaModel){
            PlantaModel plantaRequest = new PlantaModel ()
            {
                Id = plantaModel.Id,
                Nome = plantaModel.Nome,
                MinutosRegar = plantaModel.MinutosRegar,
                StatusPlanta = plantaModel.StatusPlanta,
                DataUltimaRegagem = plantaModel.DataUltimaRegagem,
                UrlImage = plantaModel.UrlImage,
            };

            return plantaRequest;
        }
    }
}