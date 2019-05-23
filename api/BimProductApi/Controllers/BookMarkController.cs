using BimProductApi.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BimProductApi.Controllers
{
    public class BookMarkController :  BaseBson<Server.BookMark>
    {

        public override Result Add(object doc)
        {
          return  base.Add(doc);
        }
    }
}
