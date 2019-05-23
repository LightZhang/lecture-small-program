using MongoDB.Bson;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace BimProductApi.Models
{
    public class Model : BaseModel
    {

        /// <summary>
        /// 文件名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 用户内容
        /// </summary>
        private object _content;
        public object content
        {
            get { return _content; }
            set { _content = value.ToBsonDocument(); }
        }

    



    }
}