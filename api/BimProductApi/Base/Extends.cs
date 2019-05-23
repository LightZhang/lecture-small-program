using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using BimProductApi.Controllers;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using BimProductApi.Models;
using MongoDB.Bson.IO;

namespace BimProductApi.Base
{
    public static class Extends
    {


        public static QueryResultEntity ToPages<T>(this IFindFluent<T, T> rows, int? page, int? pageSize)
        {
            long total = rows.Count();
            if (page != null && pageSize != null)
            {
                var curRows = rows.Skip((page - 1) * pageSize).Limit(pageSize);
                var ret = new QueryResultEntity(total, curRows.ToList());
                return ret;
            }
            else
            {

                var ret = new QueryResultEntity(total, rows.ToList());
                return ret;
            }
        }


        /// <summary>
        /// 转换单个对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="rows"></param>
        /// <returns></returns>
        public static T ToDoc<T>(this IFindFluent<T, T> rows)
        {
            if (rows.Count() > 0)
            {
                var curRow = rows.Limit(1).ToList().FirstOrDefault();
                return curRow;
            }

            return default(T);
        }



        public static BsonDocument ToPages(this IFindFluent<BsonDocument, BsonDocument> rows, int? page, int? pageSize)
        {
            long total = rows.Count();
            if (page != null && pageSize != null)
            {
                 rows = rows.Skip((page - 1) * pageSize).Limit(pageSize);
            }

            BsonDocument curRet = new BsonDocument
            {
                { "data", new BsonDocument { { "total", total }, { "rows", new BsonArray(rows.ToList()) } }}
            };

            return curRet;
        }


        public static BsonDocument ToDoc(this BsonDocument doc)
        {

            BsonDocument curRet = new BsonDocument
            {
                { "data",doc}
            };

            return curRet;
        }



        public static Result Success(this ApiController ac)
        {
            ResultEntity ret = new ResultEntity
            {
                code = 1,
                message = "数据返回成功！"
            };
            string retJson = Newtonsoft.Json.JsonConvert.SerializeObject(ret);
            Result result = new Result { Content = new StringContent(retJson, Encoding.GetEncoding("UTF-8"), "application/json") };
            return result;
        }


        public static Result Success(this ApiController ac, BsonDocument ret)
        {
            ret["code"] = 1;
            ret["message"] = "数据返回成功！";
            var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict };
            string retJson = ret.ToJson(jsonWriterSettings);
            Result result = new Result { Content = new StringContent(retJson, Encoding.GetEncoding("UTF-8"), "application/json") };
            return result;
        }



        public static Result Success(this ApiController ac, BaseModel row)
        {
            ResultEntity ret = new ResultEntity(row)
            {
                code = 1,
                message = "数据返回成功！",

            }; ;
          
            string retJson = Newtonsoft.Json.JsonConvert.SerializeObject(ret);
            Result result = new Result { Content = new StringContent(retJson, Encoding.GetEncoding("UTF-8"), "application/json") };
            return result;
        }


        public static Result Success(this ApiController ac, QueryResultEntity row)
        {
            row.code = 1;
            row.message = "数据返回成功！";
          
            string retJson = Newtonsoft.Json.JsonConvert.SerializeObject(row);
            Result result = new Result { Content = new StringContent(retJson, Encoding.GetEncoding("UTF-8"), "application/json") };
            return result;
        }




        public static Result Fail(this ApiController ac, string msg)
        {
         
            ResultEntity ret = new ResultEntity
            {
                code = 0,
                message = String.IsNullOrEmpty(msg) ? "数据返回失败！" : msg
            };
            string retJson = Newtonsoft.Json.JsonConvert.SerializeObject(ret);
            Result result = new Result { Content = new StringContent(retJson, Encoding.GetEncoding("UTF-8"), "application/json") };
            return result;
        }

    }
}