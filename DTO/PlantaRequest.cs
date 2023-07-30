using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlantaApi.Enum;

namespace planta_api.DTO
{
    public class PlantaRequest
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public StatusPlanta StatusPlanta { get; set; }
        public int MinutosRegar {get; set; }
        public string UrlImage {get; set;}
        public DateTime DataUltimaRegagem { get; set; }
    }
}