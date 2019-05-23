using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BimProductApi.Models
{
    public class SonMenu 
    {

         string Name { get; set; }

         string Type { get; set; }

         string Icon { get; set; }

         string Url { get; set; }

         string Description { get; set; }

          List<SonMenu>  Children { get; set; }

         int Level { get; set; }
        
    }

  

    public class Menu : BaseModel
    {

        string Name { get; set; }

        string Type { get; set; }

        string Icon { get; set; }

        string Url { get; set; }

        string Description { get; set; }

        List<SonMenu> Children { get; set; }

        int Level { get; set; }
    }
}