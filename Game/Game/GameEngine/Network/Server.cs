using System;
using System.Collections.Generic;
using System.Threading;
using System.Net.Sockets;
using System.Net;

namespace Game.GameEngine
{
    public class Server
    {
        private Socket socketServer = null;
        private IPEndPoint endPoint = null;
        private List<Socket> clients = new List<Socket>();
        private bool run = true;

        public Server()
        {
            socketServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        private void Start(int port)
        {
            endPoint = new IPEndPoint(IPAddress.Any, port);
            socketServer.Bind(endPoint);
            socketServer.Listen(10);
            new Thread(SearchClients).Start();
            new Thread(Idle).Start();
        }

        public void SearchClients()
        {
            while (run)
            {
                var client = socketServer.Accept();
                clients.Add(client);
            }
        }

        public void Stop()
        {
            run = false;
        }

        private void Idle()
        {
            while (run)
            {
                Socket[] read = new Socket[clients.Count];
                clients.CopyTo(read, 0);
                Socket[] write = new Socket[clients.Count];
                clients.CopyTo(write, 0);
                Socket[] error = new Socket[clients.Count];
                clients.CopyTo(error, 0);
                Socket.Select(read, write, error, 100);

            }
        }

    }
}
