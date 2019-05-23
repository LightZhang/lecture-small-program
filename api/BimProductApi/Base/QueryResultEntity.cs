using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using System.Web.Http.Results;

namespace BimProductApi.Base
{

    public class ResultEntity
    {

        public ResultEntity()
        {
            this.code = 1;
            this.message = string.Empty;
        }

        public ResultEntity(dynamic data)
        {
            this.code = 1;
            this.message = string.Empty;
            this.data = data;
        }

        public long code { get; set; }

        public string message { get; set; }

        public object data { get; set; }

    }

    public class QueryResultEntity : ResultEntity
    {
        /// <summary>
        /// 返回类型
        /// </summary>
        /// <param name="total"></param>
        /// <param name="rows"></param>
        public QueryResultEntity(long total, dynamic rows) :
            base(new
            {
                total,
                rows
            })
        {


        }







    }



}