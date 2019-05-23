using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using BimProductApi.Models;
using MongoDB.Driver;
using MongoDB.Bson.IO;
using BimProductApi.Base;

namespace BimProductApi.Server
{
    public class ModelStructure : BaseBsonServer
    {
        public ModelStructure() : base("modelStructure")
        {
           
        }

        public BsonDocument  QueryByValue(string seachVal)
        {
            var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict };
            var json = this.Query("{}","").ToList().First().ToJson(jsonWriterSettings);
            var item=  Newtonsoft.Json.JsonConvert.DeserializeObject<Models.ModelStructure>(json);
            var res = new List<Models.ModelStructure>();
            if (item != null)
            {
                if (item.items != null && item.items.Count() > 0)
                {

                    item.items.ForEach((sonItem) =>
                    {
                        GetSonItem(sonItem, ref res);
                    });
                }

            }
          
            res = res.FindAll((row) => row.text.IndexOf(seachVal) > 0 || row.id == seachVal);

            var rows = new BsonArray();
            if (res != null && res.Count > 0)
            {
                res.ForEach((curRes) =>
                {
                    var row = BsonDocument.Parse(curRes.ToJson());
                    rows.Add(row);
                });
            }


            
            BsonDocument curRet = new BsonDocument
            {
                { "data", new BsonDocument { { "total", res.Count() }, { "rows", rows } }}
            };

            return curRet;
        }


        //获取符合条件的集合
        private void GetSonItem(Models.ModelStructure item, ref List<Models.ModelStructure> res)
        {
           
            if (item != null)
            {
                var items = item.items;
                if (items != null&& items.Count>0)
                {
                    for (int i = 0; i < items.Count; i++)
                    {

                        GetSonItem(items[i],ref res);
                        items[i].items = null;
                        res.Add(items[i]);
                    }

                }

            }

        }
    }
}