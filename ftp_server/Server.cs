using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ftp_server
{
    public class Server
    {
        Socket listener;
        Socket clientSocket;
        
        public void startServer()
        {
            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddr = IPAddress.Parse("127.0.0.1");
            IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 11111);

            try
            {
                listener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                try
                {
                    listener.Bind(localEndPoint);
                    listener.Listen(10);
                    clientSocket = listener.Accept();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public void sendMessage(string msg)
        {
            byte[] message = Encoding.ASCII.GetBytes(msg);
            try
            {
                clientSocket.Send(message);
            }
            catch (Exception e) { Console.WriteLine(e); }

        }

        public void receiveMessages()
        {
            byte[] bytes = new Byte[1024];
            string data = null;
            
            
            while (true)
            {
                int numByte = clientSocket.Receive(bytes);

                data += Encoding.ASCII.GetString(bytes, 0, numByte);

                if (data.IndexOf("<EOF>") > -1)
                    break;
            }
        }

        public void shutDownServer()
        {
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();
        }

    }
}
