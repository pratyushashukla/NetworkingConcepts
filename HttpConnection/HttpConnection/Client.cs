using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace HttpConnection
{
    class Client
    {
        static void Main(string[] args)
        {

            ExecuteClient();
        }

        static void ExecuteClient()
        {
            try
            {
                IPHostEntry iPHost = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipadd = iPHost.AddressList[0];
                IPEndPoint loaclendpoint = new IPEndPoint(ipadd, 11111);

                Socket sender = new Socket(ipadd.AddressFamily,SocketType.Stream,ProtocolType.Tcp);
                try
                {
                    sender.Connect(loaclendpoint);
                    Console.WriteLine("Connected to {0}",sender.RemoteEndPoint.ToString());

                    byte[] msg = Encoding.ASCII.GetBytes("Test Client<EOF>");
                    int byteSent = sender.Send(msg);

                    byte[] msgreceived = new byte[1024];
                    int byterecv = sender.Receive(msgreceived);
                    Console.WriteLine("Message from Server -> {0}",Encoding.ASCII.GetString(msgreceived,0,byterecv));

                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();
                }
                catch (ArgumentNullException ane)
                {

                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }

                catch (SocketException se)
                {

                    Console.WriteLine("SocketException : {0}", se.ToString());
                }

                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
            }
        }
    }
}

