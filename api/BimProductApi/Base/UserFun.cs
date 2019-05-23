using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BimProductApi.Base
{
    public class UserFun
    {


        public static void SetUserId(string id)
        {

            Cookies.Set("userID", id);
        }



        public static string GetUserId()
        {
          return  Cookies.Get("userID");
        }



    }
}