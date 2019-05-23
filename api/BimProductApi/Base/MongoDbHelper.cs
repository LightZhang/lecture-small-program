using MongoDB.Driver.Core;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using System.Web.Configuration;

namespace BimProductApi.Base
{
    public class MongoDbHelper
    {


        /// <summary>  
        /// 数据库的实例  
        /// </summary>  
        public static  IMongoDatabase _db;


        public static void Init()
        {
            _db = GetDataBase();

        }


        private static IMongoDatabase GetDataBase()
        {
            string mongoSetting = WebConfigurationManager.AppSettings["MongoDBServer"];
            string contion = WebConfigurationManager.AppSettings["MongoDBContion"];
            //创建Mongo的客户端  
            MongoClient client = new MongoClient(mongoSetting);
            //得到服务器端并且生成数据库实例  
            return client.GetDatabase(contion);
        }



        public static List<UpdateDefinition<BsonDocument>> BuildUpdateDefinition(BsonDocument bc, string parent)
        {
            var updates = new List<UpdateDefinition<BsonDocument>>();
            foreach (var element in bc.Elements)
            {
                var key = parent == null ? element.Name : $"{parent}.{element.Name}";
                var subUpdates = new List<UpdateDefinition<BsonDocument>>();
                //子元素是对象  
                if (element.Value.IsBsonDocument)
                {
                    updates.AddRange(BuildUpdateDefinition(element.Value.ToBsonDocument(), key));
                }
                //子元素是其他  
                else
                {
                    updates.Add(Builders<BsonDocument>.Update.Set(f => f[key], element.Value));
                }
            }
            return updates;
        }




    }


}
