using BimProductApi.Base;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BimProductApi.Server
{
    public class BookMark : BaseBsonServer
    {
        public BookMark() : base("bookMark")
        {
        }


        public override BsonDocument Add(object doc)
        {

            BsonDocument document = BsonDocument.Parse(doc.ToString());
            var image = document["image"].ToString();
            string imgPath=  Command.Base64StringToImage(image);
            document["image"] = imgPath;

            document["CreateDate"] = DateTime.Now;
            document["UpdateDate"] = DateTime.Now;
            bsCollection.InsertOne(document);
            return document;
        }

    }

}
