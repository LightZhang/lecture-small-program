using BimProductApi.Server;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Web.Configuration;

namespace SocketClient
{
    public class Client
    {

        private Client()
        {

        }

        public Socket CurSocket { get; set; }
        private static Client instance = null;
        public static Client Getinstance()
        {

            //if (instance == null)
            //{

                  instance = new Client();

                    instance.CurSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                   // instance.CurSocket.ReceiveTimeout=1000*180;//超时3分钟，自动终止请求

                    string ipStr = WebConfigurationManager.AppSettings["ModelResolveIp"];
                    string portStr = WebConfigurationManager.AppSettings["ModelResolvePort"];

                    IPAddress ip = IPAddress.Parse(ipStr);
                    //连接到目标IP的哪个应用(端口号！)
                    IPEndPoint point = new IPEndPoint(ip, int.Parse(portStr));
                    instance.CurSocket.Connect(point);

        //}

            return instance;

          
        }


        /// <summary>
        ///客户端给服务器发消息
        /// </summary>
        /// <param name="msg"></param>
        public void SendMsg(string msg)
        {

            if (instance != null)
            {
                try
                {
                    byte[] buffer = Encoding.UTF8.GetBytes(msg);
                    instance.CurSocket.Send(buffer);
                }
                catch (Exception ex)
                {
                }
            }
        }
    }
}
