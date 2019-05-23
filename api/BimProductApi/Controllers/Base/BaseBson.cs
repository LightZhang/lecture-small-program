using BimProductApi.Base;
using MongoDB.Bson;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BimProductApi.Controllers
{

    /// <summary>
    /// 用于处理自定义类型，数据存取问题
    /// </summary>
    public class BaseBson<T> : ApiController
      where T : Server.BaseBsonServer, new()

    {
        /// <summary>
        /// serve层 实列对象
        /// </summary>
        protected T bs = new T();

        [HttpGet]
        public virtual Result QueryAll()
        {
         
            var ret = bs.Query("{}","").ToPages(null,null);
            return this.Success(ret);
        }


        [HttpGet]
        public virtual Result Query()
        {
            return QueryAll();
        }


        [HttpGet]
        public virtual Result Query(int page, int pageSize)
        {

            var ret = bs.Query("{}","").ToPages(page, pageSize);
            return this.Success(ret);
        }

        [HttpGet]
        public virtual Result QueryById(string  id)
        {
            var ret = bs.QueryById(id);
            return this.Success(ret);
        }

        [HttpGet]
        public virtual Result SingleOne(string  fiter)
        {
            var ret = bs.QuerySingle(fiter);
            return this.Success(ret);
        }


        [HttpPost]
        public virtual Result Add(object doc)
        {
            try
            {

                var ret = bs.Add(doc);
                return this.Success(ret);
            }
            catch (Exception e)
            {
                return this.Fail("新增失败！" + e.Message);
            }
        }



        [HttpPost]
        public virtual Result Update(object doc)
        {
            try
            {
                var ret = bs.Update(doc);
                return this.Success(ret);
            }
            catch (Exception e)
            {
                return this.Fail("更新失败！" + e.Message);
            }
          
        }


        [HttpPost]
        public virtual Result Del(JObject request)
        {
            try
            {
                string id = request["id"].ToString();
                bs.Del(id);
                return this.Success();
            }
            catch (Exception e)
            {
                return this.Fail("删除失败！"+e.Message);
            }
         
        }



    }
}