using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using BimProductApi.Server;
using BimProductApi.Models;
using BimProductApi.Base;

namespace BimProductApi.Controllers
{
    public class ModelController : BaseBson<Server.Model>
    {


     


        [HttpPost]
        public Result UploadModel()
        {
            HttpFileCollection filelist = HttpContext.Current.Request.Files;
            this.bs.UploadModel(filelist);
            return this.Success();
        }



    }
}