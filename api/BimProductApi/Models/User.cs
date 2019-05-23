using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BimProductApi.Models
{
    public class User : BaseModel
    {

        public string Phone { get; set; }

        public string Name { get; set; }

        public string LoginName { get; set; }

        public string PassWord { get; set; }

        public int Age { get; set; }

        public string Sex { get; set; }
    }
}