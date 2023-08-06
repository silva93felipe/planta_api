using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace planta_api.Model
{
    public abstract class BaseModel<T>
    {
           public T Id { get; set; }
           public bool Ativo { get; set; }
           public DateTime CreateAt { get; set; }
           public DateTime UpdateAt { get; set; }
           public BaseModel()
           {
                Ativo = true;
                CreateAt = DateTime.Now.Date;
                UpdateAt = DateTime.Now.Date;
           }
    }
}