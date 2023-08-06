using planta_api.Model;
using PlantaApi.Enum;

namespace PlantaApi.Model
{
    public class PlantaModel : BaseModel<int>
    {
        public string Nome { get; set; }
        public int MinutosRegar {get; set; }
        public string UrlImage {get; set;}
        public DateTime UltimaRegagem { get; set; }
    }
}