using BimProductApi.Base;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace BimProductApi.Controllers
{
    public class ModelStructureController : BaseBson<Server.ModelStructure>
    {

        [HttpPost]
        public Result QueryByValue(JObject request)
        {

           var ret=  this.bs.QueryByValue(request["seachVal"].ToString());
            return this.Success(ret) ;

        }

    }

  
}