using planta_api.Model;
using planta_api.Enum;

namespace planta_api.Model
{
    public class Planta : BaseModel<int>
    {
        public string Nome { get; set; }
        public int MinutosRegar {get; set; }
        public string UrlImage {get; set;}
        public DateTime UltimaRegagem { get; set; }
    }
}