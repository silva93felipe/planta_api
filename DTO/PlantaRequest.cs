using PlantaApi.Enum;

namespace planta_api.DTO
{
    public class PlantaRequest
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool IsRegada { get; set; }
        public int MinutosRegar {get; set; }
        public string UrlImage {get; set;}
        public DateTime UltimaRegagem { get; set; }
    }
}