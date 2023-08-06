using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace planta_api.Model
{
    public class Regagem : BaseModel<int>
    {
        public int PlantaId { get; set; }
        public DateTime Data { get; set; }
        public string? Observacao { get; set; }
    }
}