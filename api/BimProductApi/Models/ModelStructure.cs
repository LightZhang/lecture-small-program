using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BimProductApi.Models
{
    public class ModelStructure : BaseModel
    {
        public string id { get; set; }

        public string text { get; set; }

        public List<ModelStructure>  items { get; set; } 

    }
}