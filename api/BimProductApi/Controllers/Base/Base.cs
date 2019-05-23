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

    /// <summary>
    /// 正常强类型存储
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="M"></typeparam>
    public class Base<T,M>: ApiController
        where T:Server.BaseServer<M>,new()
        where M:Models.BaseModel
    {

        /// <summary>
        /// serve层 实列对象
        /// </summary>
        protected T bs =new T();

        [HttpGet]
        public virtual Result QueryAll()
        {
            //XbimParse.IFCParser xx = new IFCParser(@"E:\SampleHouse.ifc");
            var ret = bs.Query("{}",null,null);
            return  this.Success(ret) ;
        }


        [HttpGet]
        public virtual Result Query()
        {
            return this.QueryAll();
        }


        [HttpGet]
        public virtual Result SingleOne(string  filter)
        {
          string  filterJson= filter==null? "{ }" : filter.ToString();
            var ret=  bs.QuerySingle(filterJson);
            return this.Success(ret);
        }



        [HttpGet]
        public virtual Result Query(int page, int pageSize)
        {
            var ret = bs.Query("{}", page, pageSize);
            return this.Success(ret);
        }


        [HttpPost]
        public virtual Result Add(M doc)
        {
            doc.UserId = UserFun.GetUserId();
            var ret =  bs.Add(doc);
            return this.Success(ret);
        }

      


        [HttpPost]
        public virtual Result Update(M doc)
        {
            try
            {
                doc.UserId = UserFun.GetUserId();
                var ret = bs.Update(doc);
                return this.Success(ret);
            }
            catch (Exception e)
            {
                return this.Fail("更新失败！" + e.Message);
            }
        }



        [HttpPost]
        public virtual Result Del(string id)
        {
            try
            {
                bs.Del(id);
                return this.Success();
            }
            catch (Exception e)
            {
                return this.Fail("删除失败！" + e.Message);
            }
        }

    }
}