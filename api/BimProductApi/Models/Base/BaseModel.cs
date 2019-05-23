using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BimProductApi.Models
{
    public class BaseModel
    {
        public BaseModel()
        {
          
        }

        public ObjectId _id { get; set; }

        public string UserId { get; set; }

        public DateTime CreateDate{ get; set; }

        public DateTime UpdateDate { get; set; }
    }
}