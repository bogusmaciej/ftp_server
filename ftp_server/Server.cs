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


        public async Task startServer()
        {
            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddr = IPAddress.Any;
            IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 11111);
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(10);
                clientSocket = await Task.Run(() => listener.Accept());
                sendMessage("connected");
                receiveMessages();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public async Task receiveMessages()
        {
            while (true)
            {
                byte[] bytes = new Byte[1024];
                string data = null;

                int numByte = await Task.Run(()=> clientSocket.Receive(bytes));
                if (clientSocket.Connected)
                {
                    data += Encoding.ASCII.GetString(bytes, 0, numByte);
                    OnMessageRecieved(data);
                }
                else
                {
                    break;
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

        public void shutDownServer()
        {
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Disconnect(true);
        }

        public bool IsConnected()
        {
            if (clientSocket is null) return false;
            else if (clientSocket.Connected) return true;
            else return false;
        }

        public string getClientIp()
        {
            return ((IPEndPoint)(clientSocket.RemoteEndPoint)).Address.ToString();
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
