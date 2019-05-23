using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BimProductApi.Base;
using MongoDB.Driver;
using System.Linq.Expressions;
using System.Reflection;

namespace BimProductApi.Server
{
    /// <summary>
    /// 强类型数据操作
    /// </summary>
    /// <typeparam name="M"></typeparam>
    public class BaseServer<M>
       where M:Models.BaseModel

    {
        protected static IMongoCollection<M> collection;

        protected static string Sort = "{CreateDate:-1}";

        public BaseServer()
        {

            collection = MongoDbHelper._db.GetCollection<M>(typeof(M).Name.ToLower());

        }



        public M Add(M doc)
        {
            doc._id = ObjectId.GenerateNewId();
            doc.CreateDate = DateTime.Now;
            doc.UpdateDate = DateTime.Now;
            collection.InsertOne(doc);
            return doc;
        }





        public M QuerySingle(FilterDefinition<M> filter)
        {
            try
            {
                var ret = collection.Find(filter).FirstOrDefault();
                return ret;
            }
            catch (Exception e)
            {
                return default(M);
            }
        }



        public M QueryById(string  id)
        {
            try
            {
                var ret = collection.AsQueryable().Where((a)=>a._id==new ObjectId(id)).FirstOrDefault();
                return ret;
            }
            catch (Exception e)
            {
                return default(M);
            }

        }


        public QueryResultEntity Query(FilterDefinition<M> filter, int? page, int? pageSize)
        {
            var ret = collection.Find(filter).Sort(Sort).ToPages(page, pageSize);
            return ret;
        }



     

        protected QueryResultEntity Query(string where,string Sort)
        {
            var ret = collection.Find(where).Sort(Sort).ToPages(null, null);
            return ret;

        }


        public M Update(M doc )
        {
            doc.UpdateDate = DateTime.Now;

            var updates = new List<UpdateDefinition<M>>();
            foreach (PropertyInfo p in doc.GetType().GetProperties())
            {
                updates.Add( Builders<M>.Update.Set(p.Name, p.GetValue(doc)));
            }

            var update = Builders<M>.Update.Combine(updates);
            var filter = Builders<M>.Filter.Gt("_id", doc._id);
            collection.UpdateOne(filter, update);

            return doc;
        }




        public void Del(string id)
        {
            collection.DeleteOne("{'_id':" + id + "}");
        }



    }
}
