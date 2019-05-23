using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Http.Cors;


namespace BimProductApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            //跨域处理
            string origin = WebConfigurationManager.AppSettings["Origin"];
            if (!string.IsNullOrEmpty(origin))
            {
                config.EnableCors(new EnableCorsAttribute(origin, "*", "*"));
            }
         

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{action}"
              
            );
        }
    }
}
