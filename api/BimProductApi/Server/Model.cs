using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using BimProductApi.Base;
using BimProductApi.Models;
using System.Web;
using SocketClient;
using System.Text;

namespace BimProductApi.Server
{
    public class Model : BaseBsonServer
    {

        public Model() : base("model")
        {

        }


        public override BsonDocument Add(object doc)
        {


            BsonDocument document = BsonDocument.Parse(doc.ToJson());

            Client client = Client.Getinstance();

            client.SendMsg(document["path"].ToString());
            StringBuilder strbu = new StringBuilder();

         
            while (true)
            {
                    byte[] buffer = new byte[1024000];
                    int n = client.CurSocket.Receive(buffer);

                    string str = Encoding.UTF8.GetString(buffer, 0, n);
                    strbu.Append(str);

                if (str.Length< 1024000)
                {
                    break;
                }

             
            }

            //string[] dataArray=  strbu.ToString().Split('`');

            document["content"] = BsonDocument.Parse(strbu.ToString()) ;

            client.CurSocket.Close();

            return   base.AddByDocument(document);

        }


        /// <summary>
        /// 上传模型
        /// </summary>
        /// <returns></returns>
        public void UploadModel(object file)
        {
            List<Dictionary<string,string>> files = Command.PostFiles(file);

            if (files != null && files.Count > 0)
            {
                foreach (var curFile in files)
                {
                    var obj = new { name = curFile["fileName"], path = curFile["fullPath"] };
                    this.Add(obj);
                }
            }


        }


    }
}
