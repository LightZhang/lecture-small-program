using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Collections;
using BimProductApi.Base;
using Newtonsoft.Json.Linq;

namespace BimProductApi.Controllers
{
    public class UserController: Base<Server.UserServer,Models.User>
    {


        [HttpPost]
        public Result Login(Models.User user)
        {
            var ret = this.bs.Login(user);
            if (ret != null)
            {
                return this.Success(ret);
            }
            else
            {
                return this.Fail("登录失败,用户名或者密码不正确！");
            }
        }

        [HttpGet]
        public Result GetUser()
        {

            string id = UserFun.GetUserId();
            var ret = this.bs.QueryById(id);
            if (ret != null)
            {
                return this.Success(ret);
            }
            else
            {
                return this.Fail("用户未登录！");
            }
        }

        [HttpGet]
        public Result LogOut()
        {
            try
            {
                this.bs.logOut();


                return this.Success();
            }
            catch (Exception e)
            {
                return this.Fail("退出登录失败！");
            }
           


        }


    }
}
