using BimProductApi.Base;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BimProductApi.Server
{
    public class Callout: BaseBsonServer
    {
        public Callout():base("callout")
        {


        }

        public override BsonDocument Add(object doc)
        {

            BsonDocument document = BsonDocument.Parse(doc.ToString());
            var image = document["cameraMark"]["image"].ToString();
            string imgPath = Command.Base64StringToImage(image);
            document["cameraMark"]["image"] = imgPath;

            document["CreateDate"] = DateTime.Now;
            document["UpdateDate"] = DateTime.Now;
            bsCollection.InsertOne(document);
            return document;
        }

    }
}