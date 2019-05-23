using BimProductApi.Base;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace BimProductApi.Server
{

    /// <summary>
    /// bson 数据类型操作
    /// </summary>
    public class BaseBsonServer
    {

        protected static IMongoCollection<BsonDocument> bsCollection;


        protected static string Sort = "{CreateDate:-1}";

        public BaseBsonServer(string collectionName)
        {
            bsCollection = MongoDbHelper._db.GetCollection<BsonDocument>(collectionName);
        }


        public virtual BsonDocument Add(object doc)
        {

            BsonDocument document = BsonDocument.Parse(doc.ToString());
            document["UserId"] = UserFun.GetUserId();
            document["CreateDate"] = DateTime.Now;
            document["UpdateDate"] = DateTime.Now;
            bsCollection.InsertOne(document);

            return document.ToDoc();
        }



        public virtual BsonDocument AddByDocument(BsonDocument doc)
        {


            doc["UserId"] = UserFun.GetUserId();
            doc["CreateDate"] = DateTime.Now;
            doc["UpdateDate"] = DateTime.Now;
            bsCollection.InsertOne(doc);

            return doc.ToDoc();
        }


        public IFindFluent<BsonDocument,BsonDocument> Query(FilterDefinition<BsonDocument> filter,string sort)
        {
            Sort = string.IsNullOrEmpty(sort) ? Sort : sort;
            var ret = bsCollection.Find(filter).Sort(Sort); 
            return ret;
        }



        protected IFindFluent<BsonDocument, BsonDocument> Query(string where,string sort)
        {
            Sort = string.IsNullOrEmpty(sort) ? Sort : sort;
            var ret = bsCollection.Find(where).Sort(Sort);
            return ret;
        }


        public BsonDocument QuerySingle(FilterDefinition<BsonDocument> filter)
        {
                var ret = bsCollection.Find(filter).FirstOrDefault();
                return ret;

        }


        public BsonDocument QueryById(string id)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId(id) );
            var ret = bsCollection.Find(filter).FirstOrDefault();
                return ret;
          

        }

        public BsonDocument Update(object doc)
        {

            BsonDocument document = BsonDocument.Parse(doc.ToString());
            document["UserId"] = UserFun.GetUserId();
            var update = Builders<BsonDocument>.Update.Combine(MongoDbHelper.BuildUpdateDefinition(document, null));
            var filter = Builders<BsonDocument>.Filter.Eq("_id", document["_id"]);
            bsCollection.UpdateOne(filter, update);

            return doc.ToBsonDocument();
        }




        public void Del(string id)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id",new ObjectId(id) );
            bsCollection.DeleteOne(filter);
        }

    }
}