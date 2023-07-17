using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;


namespace ftp_server
{
    public partial class serverForm : Form
    {

        Server server = new Server();
        public serverForm()
        {
            server.MessageRecieved += this.OnMessageRecieved;
            InitializeComponent();
            try
            {
                server.startServer();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
            /* 
             while (true)
             {
                 label.Text = server.connetion_msg;
             }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            server.shutDownServer();
            this.Close();
        }

        private void sendMessageBtn_Click(object sender, EventArgs e)
        {
            if (server.IsConnected())
            {
                if(messageBox.Text != "") {
                    messagesBox.AppendText("You: " + messageBox.Text + Environment.NewLine);
                    server.sendMessage(messageBox.Text);
                    messageBox.Text = "";
                }
            }
            else
            {
                messagesBox.AppendText("You are not connected" + Environment.NewLine);
            }

        }

        private void label_Click(object sender, EventArgs e)
        {

        }
        public void OnMessageRecieved(object source, MessageEventArgs args)
        {
            messagesBox.AppendText($"{server.getClientIp()} : {args.message} {Environment.NewLine}");
            messageBox.Text = "";
        }
    }
}
