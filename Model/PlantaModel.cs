using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlantaApi.Model
{
    public class PlantaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int MinutosParaAguar {get; set; }
        public string UrlImage {get; set;}
    }
}