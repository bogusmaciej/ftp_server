using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ftp_server
{
    public class MessageEventArgs: EventArgs
    {
        public string message;
    }
    public class Server
    {
        Socket clientSocket;
        public delegate void MessageRecievedEventHandler(object source, MessageEventArgs args);
        public event MessageRecievedEventHandler MessageRecieved;


        public void startServer()
        {
            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddr = IPAddress.Any;
            IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 11111);
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(10);
                clientSocket = listener.Accept();
                receiveMessages();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            
               
        }

        public void receiveMessages()
        {
            while (true)
            {
                byte[] bytes = new Byte[1024];
                string data = null;

                int numByte = clientSocket.Receive(bytes);
                data += Encoding.ASCII.GetString(bytes, 0, numByte);
                OnMessageRecieved(data);
                if (data.IndexOf("<EOF>") > -1)
                    break;
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

        public void shutDownServer()
        {
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();
        }

        protected virtual void OnMessageRecieved(string message_)
        {
            if(MessageRecieved != null)
            {
                MessageRecieved(this, new MessageEventArgs() { message = message_ });
            }
        }

    }
}
