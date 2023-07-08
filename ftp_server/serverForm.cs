using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ftp_server
{
    public partial class serverForm : Form
    {
        Server server = new Server();
        public serverForm()
        {
            InitializeComponent();
            try
            {
                server.startServer();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
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
            
            messagesBox.AppendText("You: " + messageBox.Text + Environment.NewLine);
            messageBox.Text = "";

        }

        private void label_Click(object sender, EventArgs e)
        {

        }
    }
}
