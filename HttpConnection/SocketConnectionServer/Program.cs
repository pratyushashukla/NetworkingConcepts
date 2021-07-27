using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocketConnectionServer
{
    class Program
    {
        static void Main(string[] args)
        {
            ExecuteServer();
        }


        static void ExecuteServer()
        {
            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 11111);

            Socket listener = new Socket(ipAddr.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(10);
                while(true)
                {
                    Console.WriteLine("Waiting connection ... ");
                    Socket client = listener.Accept();
                    byte[] bytes = new Byte[1024];
                    string data = null;
                    while(true)
                    {
                        int numByte = client.Receive(bytes);
                        data = data + Encoding.ASCII.GetString(bytes, 0, numByte);
                        if (data.IndexOf("<EOF>") > -1)
                            break;
                    }
                    Console.WriteLine("Text received -> {0} ", data);
                    byte[] message = Encoding.ASCII.GetBytes("Test Server");
                    client.Send(message);
                    client.Shutdown(SocketShutdown.Both);
                    client.Close();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
