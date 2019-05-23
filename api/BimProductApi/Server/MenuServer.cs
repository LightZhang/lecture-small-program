using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BimProductApi.Server
{
    public class MenuServer : BaseBsonServer
    {

        public MenuServer() : base("menu")
        {

            Sort = "{Sort:1}";

        }


    }
}