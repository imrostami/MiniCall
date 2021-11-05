
using EasyTcp4;
using EasyTcp4.ServerUtils;
using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace MiniCallService
{
    public class Program
    {
        static List<System.Net.EndPoint> Users = new List<System.Net.EndPoint>();

        
        static EasyTcpServer server;
        public static void Main(string [] args)
        {
            server = new EasyTcpServer().Start("localhost", 89);
            server.OnConnect += Server_OnConnect;
            server.OnDataReceive += Server_OnDataReceive;
            server.OnDataSend += Server_OnDataSend;
            server.OnDisconnect += Server_OnDisconnect;




            Console.WriteLine("Service Started");
            Console.ReadKey();
        }

        private static void Server_OnDisconnect(object sender, EasyTcpClient e)
        {
            Users.Remove(e.BaseSocket.RemoteEndPoint);
        }

        private static void Server_OnDataSend(object sender, Message e)
        {
            
        }

        private static async void Server_OnDataReceive(object sender, Message e)
        {
            foreach (var client in server.GetConnectedClients())
            {
                if (client != e.Client)
                {
                    e.Client.Protocol.SendMessage(client, e.Data);
                }
            }
        }

        private static void Server_OnConnect(object sender, EasyTcpClient e)
        {
            Users.Add(e.BaseSocket.RemoteEndPoint);

            
        }
    }
}
