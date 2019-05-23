using BimProductApi.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BimProductApi.Server
{
    public class UserServer: BaseServer<Models.User>
    {


        public Models.User Login(Models.User user)
        {
          var curUser=  this.QuerySingle("{LoginName:'" + user.LoginName + "' , PassWord:'"+ user .PassWord+ "'}");
            if (curUser != null)
            {
                UserFun.SetUserId(curUser._id.ToString());
            }
          return curUser;
        }




        /// <summary>
        /// 退出登录
        /// </summary>
        public void logOut()
        {
            UserFun.SetUserId("");

        }



    }
}